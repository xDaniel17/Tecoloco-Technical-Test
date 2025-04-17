namespace WeatherService.src.Core.Entities
{
    public class WeatherData
    {
        public int Id { get; set; }
        public string City { get; set; } = string.Empty;
        public string CountryCode { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string? Condition { get; set; } = "N/A";
        public float? Temperature { get; set; } = 0;
        public float? MinTemperature { get; set; } = 0;
        public float? MaxTemperature { get; set; } = 0;
    }
}
