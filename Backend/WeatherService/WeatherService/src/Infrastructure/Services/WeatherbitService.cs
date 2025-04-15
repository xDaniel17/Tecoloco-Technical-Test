using System.Text.Json;
using WeatherService.src.Core.Entities;
using WeatherService.src.Core.Interfaces;

namespace WeatherService.src.Infrastructure.Services
{
    /// <summary>
    /// WeatherbitService
    /// Pendientes:
    /// Manejo de errores
    /// </summary>
    public class WeatherbitService : IWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public WeatherbitService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _apiKey = configuration["WeatherAPI:ApiKey"];
        }

        public async Task<WeatherData> GetCurrentWeatherAsync(string city)
        {
            var response = await _httpClient.GetAsync($"current?city={city}&key={_apiKey}");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var weatherGroup = JsonSerializer.Deserialize<CurrentObsGroup>(json);

            if (weatherGroup?.data == null || !weatherGroup.data.Any())
            {
                throw new InvalidOperationException("No se encontraron datos");//
            }

            return MapToWeatherData(weatherGroup.data.First());
        }

        private WeatherData MapToWeatherData(CurrentObs obs)
        {
            return new WeatherData
            {
                City = obs.city_name,
                Temperature = obs.temp,
                MinTemperature = obs.dewpt,
                MaxTemperature = obs.app_temp,
                Condition = obs.weather?.description,
                Date = DateTime.Now
            };
        }
    }
}