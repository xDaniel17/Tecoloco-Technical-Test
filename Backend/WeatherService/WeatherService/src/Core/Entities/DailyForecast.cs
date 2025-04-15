namespace WeatherService.src.Core.Entities
{
    public class DailyForecast
    {
        public string city_name { get; set; }
        public string country_code { get; set; }
        public string state_code { get; set; }
        public string timezone { get; set; }
        public string lat { get; set; }
        public string lon { get; set; }
        public List<DailyForecastData> data { get; set; }
    }
}
