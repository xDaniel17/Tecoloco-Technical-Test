using Microsoft.Extensions.Caching.Memory;
using Polly;
using Polly.Wrap;
using System.Text.Json;
using WeatherService.src.Core.Entities;
using WeatherService.src.Core.Interfaces;

namespace WeatherService.src.Infrastructure.Services
{
    /// <summary>
    /// WeatherbitService
    /// Incluye manejo de errores, almacenamiento en caché y patrón Circuit Breaker.
    /// </summary>
    public class WeatherbitService : IWeatherService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly IMemoryCache _cache;
        private readonly AsyncPolicyWrap _resiliencePolicy;

        public WeatherbitService(HttpClient httpClient, IConfiguration configuration, IMemoryCache cache)
        {
            _httpClient = httpClient;
            _apiKey = configuration["WeatherAPI:ApiKey"];
            _cache = cache;

            // Configuración del patrón Circuit Breaker con Polly
            var retryPolicy = Policy
                .Handle<HttpRequestException>()
                .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)));

            var circuitBreakerPolicy = Policy.Handle<HttpRequestException>().AdvancedCircuitBreakerAsync(
                failureThreshold: 0.5,
                samplingDuration: TimeSpan.FromSeconds(60),
                minimumThroughput: 10,
                durationOfBreak: TimeSpan.FromMinutes(2)
            );

            _resiliencePolicy = Policy.WrapAsync(retryPolicy, circuitBreakerPolicy);
        }

        #region GetCurrentWeatherAsync

        public async Task<WeatherData> GetCurrentWeatherAsync(string city)
        {
            // Construccion de identificador de de caché única
            var cacheKey = $"current_weather_{city.ToLower()}";

            if (_cache.TryGetValue(cacheKey, out WeatherData cachedWeather))
            {
                return cachedWeather;
            }

            return await _resiliencePolicy.ExecuteAsync(async () =>
            {
                var response = await _httpClient.GetAsync($"current?city={city}&key={_apiKey}");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var weatherGroup = JsonSerializer.Deserialize<CurrentObsGroup>(json);

                if (weatherGroup?.data == null || !weatherGroup.data.Any())
                {
                    throw new InvalidOperationException("No se encontraron datos");
                }

                var weatherData = MapToWeatherData(weatherGroup.data.First());

                // Almacenar en caché por 10 minutos
                _cache.Set(cacheKey, weatherData, TimeSpan.FromMinutes(10));
                return weatherData;
            });
        }

        private WeatherData MapToWeatherData(CurrentObs obs)
        {
            return new WeatherData
            {
                Id = 1,
                City = obs.city_name,
                CountryCode = obs.country_code,
                Temperature = obs.temp,
                MinTemperature = obs.dewpt,
                MaxTemperature = obs.app_temp,
                Condition = obs.weather?.description,
                Date = DateTime.Now
            };
        }

        #endregion

        #region GetDailyForecastAsync

        public async Task<List<WeatherData>> GetDailyForecastAsync(string city, int days = 7)
        {
            // Construccion de identificador de de caché única
            var cacheKey = $"daily_forecast_{city.ToLower()}_{days}";

            if (_cache.TryGetValue(cacheKey, out List<WeatherData> cachedForecast))
            {
                return cachedForecast;
            }

            return await _resiliencePolicy.ExecuteAsync(async () =>
            {
                var response = await _httpClient.GetAsync($"forecast/daily?city={city}&days={days}&key={_apiKey}");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var forecast = JsonSerializer.Deserialize<DailyForecast>(json);

                if (forecast?.data == null || !forecast.data.Any())
                {
                    throw new InvalidOperationException("No se encontraron datos de pronóstico");
                }

                var weatherDataList = MapToWeatherData(forecast, forecast.city_name);

                // Almacenar en caché por 10 minutos
                _cache.Set(cacheKey, weatherDataList, TimeSpan.FromMinutes(10));
                return weatherDataList;
            });
        }

        private List<WeatherData> MapToWeatherData(DailyForecast days, string cityName)
        {
            var weatherDataList = new List<WeatherData>();
            int n = 1;
            string countryCode = days.country_code;
            foreach (var day in days.data)
            {
                weatherDataList.Add(new WeatherData
                {
                    Id = n,
                    City = cityName,
                    CountryCode = countryCode,
                    Temperature = day.temp,
                    MinTemperature = day.min_temp,
                    MaxTemperature = day.max_temp,
                    Condition = day.weather?.description,
                    Date = DateTime.Parse(day.valid_date)
                });
                n++;
            }
            return weatherDataList;
        }

        #endregion

    }
}