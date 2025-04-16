namespace WeatherService.src.Core.Entities.Database
{
    public class WeatherForecast
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public Guid ForecastGroupId { get; set; }
        public DateTime ForecastDate { get; set; }
        public float Temperature { get; set; }
        public float MinTemperature { get; set; }
        public float MaxTemperature { get; set; }
        public string Condition { get; set; }
        public DateTime QueryDate { get; set; }
    }
}
