using WeatherService.src.Core.Entities;
using WeatherService.src.Core.Interfaces;

namespace WeatherService.src.Application.UseCases
{
    public class GetDailyForecastUseCase
    {
        private readonly IWeatherService _weatherService;

        public GetDailyForecastUseCase(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }

        public async Task<List<WeatherData>> ExecuteAsync(string city, int days = 7)
        {
            return await _weatherService.GetDailyForecastAsync(city, days);
        }
    }
}
