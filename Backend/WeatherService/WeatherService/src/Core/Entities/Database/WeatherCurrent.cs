namespace WeatherService.src.Core.Entities.Database
{
    public class WeatherCurrent
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public float Temperature { get; set; }
        public float MinTemperature { get; set; }
        public float MaxTemperature { get; set; }
        public string Condition { get; set; }
        public DateTime ObservationDate { get; set; }
        public DateTime QueryDate { get; set; }
    }
}
