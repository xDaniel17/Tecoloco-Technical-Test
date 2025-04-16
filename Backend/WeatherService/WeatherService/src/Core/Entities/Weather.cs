namespace WeatherService.src.Core.Entities
{
    public class Weather
    {
        public int? code { get; set; }
        public string icon { get; set; } = string.Empty;
        public string description { get; set; } = string.Empty;
    }
}
