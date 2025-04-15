using WeatherService.src.Core.Entities;
using WeatherService.src.Core.Interfaces;

namespace WeatherService.src.Application.UseCases
{
    public class GetCurrentWeatherUseCase
    {
        private readonly IWeatherService _weatherService;

        public GetCurrentWeatherUseCase(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public async Task<WeatherData> ExecuteAsync(string city)
        {
            return await _weatherService.GetCurrentWeatherAsync(city);
        }
    }
}
