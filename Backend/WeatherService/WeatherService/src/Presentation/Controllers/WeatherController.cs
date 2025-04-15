using Microsoft.AspNetCore.Mvc;
using WeatherService.src.Application.UseCases;

namespace WeatherService.src.Presentation.Controllers
{
    [ApiController]
    [Route("api/weather")]
    public class WeatherController : Controller
    {
        private readonly GetCurrentWeatherUseCase _getCurrentWeatherUseCase;

        public WeatherController(GetCurrentWeatherUseCase getCurrentWeatherUseCase)
        {
            _getCurrentWeatherUseCase = getCurrentWeatherUseCase;
        }

        /// <summary>
        /// Pendiente: Manejo de errores
        /// </summary>
        /// <param name="city"></param>
        /// <returns></returns>
        [HttpGet("current")]
        public async Task<IActionResult> GetCurrentWeather([FromQuery] string city)
        {
            if (string.IsNullOrEmpty(city))
            {
                return BadRequest(new 
                {
                    Message = "Campo ciudad vacio"//mejorar mensajes
                });
            }

            try
            {
                var weather = await _getCurrentWeatherUseCase.ExecuteAsync(city);
                return Ok(weather);
            }
            catch (InvalidOperationException ex)
            {
                return NotFound(new 
                {
                    Message = ex.Message
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new
                {
                    Message = "Error inesperado",//mejorar mensajes
                    Details = ex.Message
                });
            }
        }
    }
}
