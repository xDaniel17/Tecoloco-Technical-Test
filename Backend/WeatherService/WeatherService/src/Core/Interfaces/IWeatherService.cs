using WeatherService.src.Core.Entities;

namespace WeatherService.src.Core.Interfaces
{
    public interface IWeatherService
    {
        Task<WeatherData> GetCurrentWeatherAsync(string city);
        Task<List<WeatherData>> GetDailyForecastAsync(string city, int days = 7);
    }

}
