using Microsoft.AspNetCore.Mvc;
using WeatherService.src.Application.UseCases;
using WeatherService.src.Core.Entities;
using WeatherService.src.Presentation.Models;

namespace WeatherService.src.Presentation.Controllers
{
    [ApiController]
    [Route("api/weather")]

    public class WeatherController : Controller
    {
        private readonly GetCurrentWeatherUseCase _getCurrentWeatherUseCase;
        private readonly GetDailyForecastUseCase _getDailyForecastUseCase;

        public WeatherController(GetCurrentWeatherUseCase getCurrentWeatherUseCase, GetDailyForecastUseCase getDailyForecastUseCase)
        {
            _getCurrentWeatherUseCase = getCurrentWeatherUseCase;
            _getDailyForecastUseCase = getDailyForecastUseCase;
        }

        /// <summary>
        /// Obtiene el clima actual de la ciudad especificada.
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        [HttpGet("current")]
        public async Task<IActionResult> GetCurrentWeather([FromQuery] string city)
        {
            if (string.IsNullOrEmpty(city))
            {
                return BadRequest(new BaseResponse<object>
                {
                    ResultCode = 400,
                    Messages = new List<string> { "El campo ciudad está vacío." }
                });
            }

            try
            {
                var weather = await _getCurrentWeatherUseCase.ExecuteAsync(city);
                return Ok(new BaseResponse<object>
                {
                    ResultCode = 200,
                    Content = weather,
                    Messages = new List<string> { "Consulta exitosa." }
                });
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new BaseResponse<object>
                {
                    ResultCode = 404,
                    Messages = new List<string> { ex.Message }
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new BaseResponse<object>
                {
                    ResultCode = 500,
                    Messages = new List<string> { "Error inesperado." },
                    ErrorMessageSystem = ex.Message
                });
            }
        }

        /// <summary>
        /// Obtiene el pronóstico diario para la ciudad especificada con paginación.
        /// </summary>
        /// <param name="city">Nombre de la ciudad</param>
        /// <param name="days">Número de días del pronóstico (valor predeterminado: 7)</param>
        /// <param name="page">Número de página (valor predeterminado: 1)</param>
        /// <param name="pageSize">Tamaño de la página (valor predeterminado: 7)</param>
        /// <returns></returns>
        [HttpGet("forecast/daily")]
        public async Task<IActionResult> GetDailyForecast([FromQuery] string city, [FromQuery] int days = 7, [FromQuery] int page = 1, [FromQuery] int pageSize = 7)
        {
            if (string.IsNullOrEmpty(city))
            {
                return BadRequest(new BaseResponse<object>
                {
                    ResultCode = 400,
                    Messages = new List<string> { "El campo ciudad está vacío." }
                });
            }

            if (days <= 0)
            {
                return BadRequest(new BaseResponse<object>
                {
                    ResultCode = 400,
                    Messages = new List<string> { "El número de días debe ser mayor a 0." }
                });
            }

            if (page <= 0 || pageSize <= 0)
            {
                return BadRequest(new BaseResponse<object>
                {
                    ResultCode = 400,
                    Messages = new List<string> { "El número de página y el tamaño de la página deben ser mayores a 0." }
                });
            }

            try
            {
                var forecast = await _getDailyForecastUseCase.ExecuteAsync(city, days);

                // Paginación
                var totalRecords = forecast.Count;
                var totalPages = (int)Math.Ceiling((double)totalRecords / pageSize);

                if (page > totalPages)
                {
                    return NotFound(new BaseResponse<object>
                    {
                        ResultCode = 404,
                        Messages = new List<string> { $"La página solicitada ({page}) excede el total de páginas disponibles ({totalPages})." }
                    });
                }

                var paginatedForecast = forecast
                    .Skip((page - 1) * pageSize)
                    .Take(pageSize)
                    .ToList();

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
                return NotFound(new BaseResponse<object>
                {
                    ResultCode = 404,
                    Messages = new List<string> { ex.Message }
                });
            }
            catch (Exception ex)
            {
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
