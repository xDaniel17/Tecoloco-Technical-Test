namespace WeatherService.src.Core.Entities
{
    public class CurrentObsGroup
    {
        public int count { get; set; }
        public List<CurrentObs> data { get; set; } = new List<CurrentObs>();
    }
}
