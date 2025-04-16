namespace WeatherService.src.Core.Entities
{
    public class DailyForecast
    {
        public string city_name { get; set; } = string.Empty;
        public string country_code { get; set; } = string.Empty;
        public string state_code { get; set; } = string.Empty;
        public string timezone { get; set; } = string.Empty;
        public string lat { get; set; } = string.Empty;
        public string lon { get; set; } = string.Empty;
        public List<DailyForecastData> data { get; set; } = new List<DailyForecastData>();
    }
}
