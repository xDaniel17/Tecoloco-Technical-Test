namespace WeatherService.src.Core.Entities
{
    public class WeatherData
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string CountryCode { get; set; }
        public DateTime Date { get; set; }
        public string? Condition { get; set; }
        public float? Temperature { get; set; }
        public float? MinTemperature { get; set; }
        public float? MaxTemperature { get; set; }
    }
}
