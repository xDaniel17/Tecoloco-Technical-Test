using Microsoft.AspNetCore.Mvc;
using Serilog;
using WeatherService.src.Application.UseCases;
using WeatherService.src.Core.Entities;
using WeatherService.src.Core.Entities.Database;
using WeatherService.src.Infrastructure.Data;
using WeatherService.src.Presentation.Models;
using ILogger = Serilog.ILogger;

namespace WeatherService.src.Presentation.Controllers
{
    [ApiController]
    [Route("api/weather")]
    public class WeatherController : ControllerBase
    {
        private readonly GetCurrentWeatherUseCase _getCurrentWeatherUseCase;
        private readonly GetDailyForecastUseCase _getDailyForecastUseCase;
        private readonly WeatherDbContext _dbContext;
        private readonly ILogger _logger;

        public WeatherController(
            GetCurrentWeatherUseCase getCurrentWeatherUseCase,
            GetDailyForecastUseCase getDailyForecastUseCase,
            WeatherDbContext dbContext)
        {
            _getCurrentWeatherUseCase = getCurrentWeatherUseCase;
            _getDailyForecastUseCase = getDailyForecastUseCase;
            _dbContext = dbContext;
            _logger = Log.ForContext<WeatherController>();
        }

        /// <summary>
        /// Obtiene el clima actual de la ciudad especificada y guarda la consulta en la base de datos.
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        [HttpGet("current")]
        public async Task<IActionResult> GetCurrentWeather([FromQuery] string city)
        {
            _logger.Information("API Call: GetCurrentWeather para cuidad {City}", city);

            if (string.IsNullOrEmpty(city))
            {
                _logger.Warning("BadRequest: Falta el parámetro de ciudad.");
                return BadRequest(new BaseResponse<object>
                {
                    ResultCode = 400,
                    Messages = new List<string> { "El campo ciudad está vacío." }
                });
            }

            try
            {
                var queryDate = DateTime.Now;
                _logger.Information("Obteniendo datos meteorológicos para la ciudad {City}", city);

                var weatherData = await _getCurrentWeatherUseCase.ExecuteAsync(city);
                var weatherCurrentEntity = new WeatherCurrent
                {
                    City = weatherData.City,
                    Country = weatherData.CountryCode ?? "Unknown",
                    Temperature = weatherData.Temperature ?? 0,
                    MinTemperature = weatherData.MinTemperature ?? 0,
                    MaxTemperature = weatherData.MaxTemperature ?? 0,
                    Condition = weatherData.Condition ?? "Unknown",
                    ObservationDate = weatherData.Date,
                    QueryDate = queryDate
                };

                _dbContext.WeatherCurrents.Add(weatherCurrentEntity);
                await _dbContext.SaveChangesAsync();

                _logger.Information("Los datos meteorológicos de la ciudad {City} se guardaron correctamente en la base de datos.", city);

                return Ok(new BaseResponse<WeatherData>
                {
                    ResultCode = 200,
                    Content = weatherData,
                    Messages = new List<string> { "Consulta exitosa." },
                });
            }
            catch (InvalidOperationException ex)
            {
                _logger.Warning(ex, "Ciudad {City} no encontrada.", city);
                return NotFound(new BaseResponse<object>
                {
                    ResultCode = 404,
                    Messages = new List<string> { ex.Message }
                });
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Se produjo un error inesperado al obtener datos meteorológicos para la ciudad {City}", city);
                return StatusCode(500, new BaseResponse<object>
                {
                    ResultCode = 500,
                    Messages = new List<string> { "Error inesperado." },
                    ErrorMessageSystem = ex.Message
                });
            }
        }

        /// <summary>
        /// Obtiene el pronóstico diario para la ciudad especificada, guarda la consulta en la base de datos y utiliza paginación.
        /// </summary>
        /// <param name="city">Nombre de la ciudad</param>
        /// <param name="days">Número de días del pronóstico (valor predeterminado: 7)</param>
        /// <param name="page">Número de página (valor predeterminado: 1)</param>
        /// <param name="pageSize">Tamaño de la página (valor predeterminado: 7)</param>
        /// <returns></returns>
        [HttpGet("forecast")]
        public async Task<IActionResult> GetDailyForecast([FromQuery] string city, [FromQuery] int days = 7, [FromQuery] int page = 1, [FromQuery] int pageSize = 7)
        {
            _logger.Information("API Call: GetDailyForecast cuidad {City}, dias {Days}, pagina {Page}, tamaño {PageSize}", city, days, page, pageSize);

            if (string.IsNullOrEmpty(city))
            {
                _logger.Warning("BadRequest: Falta el parámetro ciudad.");
                return BadRequest(new BaseResponse<object>
                {
                    ResultCode = 400,
                    Messages = new List<string> { "El campo ciudad está vacío." }
                });
            }

            if (days <= 0)
            {
                _logger.Warning("BadRequest: Parámetro de días no válido ({Days})", days);
                return BadRequest(new BaseResponse<object>
                {
                    ResultCode = 400,
                    Messages = new List<string> { "El número de días debe ser mayor a 0." }
                });
            }

            if (page <= 0 || pageSize <= 0)
            {
                _logger.Warning("BadRequest: Parámetros de página ({Page}) o tamaño de página ({PageSize}) no válidos.", page, pageSize);
                return BadRequest(new BaseResponse<object>
                {
                    ResultCode = 400,
                    Messages = new List<string> { "El número de página y el tamaño de la página deben ser mayores a 0." }
                });
            }

            try
            {
                var queryDate = DateTime.Now;
                _logger.Information("Obteniendo datos de pronóstico diario para la ciudad {City}", city);

                var forecastData = await _getDailyForecastUseCase.ExecuteAsync(city, days);
                Guid id = Guid.NewGuid();

                var forecastEntities = forecastData.Select(item => new WeatherForecast
                {
                    City = item.City,
                    Country = item.CountryCode ?? "Unknown",
                    ForecastGroupId = id,
                    ForecastDate = item.Date,
                    Temperature = item.Temperature ?? 0,
                    MinTemperature = item.MinTemperature ?? 0,
                    MaxTemperature = item.MaxTemperature ?? 0,
                    Condition = item.Condition ?? "Unknown",
                    QueryDate = queryDate
                }).ToList();

                _dbContext.WeatherForecasts.AddRange(forecastEntities);
                await _dbContext.SaveChangesAsync();

                _logger.Information("El pronóstico diario para la ciudad {City} se guardó correctamente en la base de datos.", city);

                // Paginación
                var totalRecords = forecastEntities.Count;
                var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

                if (page > totalPages)
                {
                    _logger.Warning("La página {Page} supera el total de páginas {TotalPages} para la ciudad {City}.", page, totalPages, city);
                    return NotFound(new BaseResponse<object>
                    {
                        ResultCode = 404,
                        Messages = new List<string> { $"La página solicitada ({page}) excede el total de páginas disponibles ({totalPages})." }
                    });
                }

                var paginatedForecast = forecastEntities
                     .Skip((page - 1) * pageSize)
                     .Take(pageSize)
                     .Select(item => new WeatherData
                     {
                         Id = item.Id,
                         City = item.City,
                         CountryCode = item.Country,
                         Date = item.ForecastDate,
                         Condition = item.Condition,
                         Temperature = item.Temperature,
                         MinTemperature = item.MinTemperature,
                         MaxTemperature = item.MaxTemperature
                     }).ToList();

                return Ok(new BaseResponse<List<WeatherData>>
                {
                    ResultCode = 200,
                    Content = paginatedForecast,
                    TotalRecords = totalRecords,
                    TotalPages = totalPages,
                    CurrentPage = page,
                    PageSize = pageSize,
                    Messages = new List<string> { "Consulta exitosa." }
                });
            }
            catch (InvalidOperationException ex)
            {
                _logger.Warning(ex, "Cuidad {City} no encontrada.", city);
                return NotFound(new BaseResponse<object>
                {
                    ResultCode = 404,
                    Messages = new List<string> { ex.Message }
                });
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Se produjo un error inesperado al obtener los datos de pronóstico para la ciudad {City}", city);
                return StatusCode(500, new BaseResponse<object>
                {
                    ResultCode = 500,
                    Messages = new List<string> { "Error inesperado." },
                    ErrorMessageSystem = ex.Message
                });
            }
        }
    }
}