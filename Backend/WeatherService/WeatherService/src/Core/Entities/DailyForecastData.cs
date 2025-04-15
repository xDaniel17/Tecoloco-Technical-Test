namespace WeatherService.src.Core.Entities
{
    public class DailyForecastData
    {
        public double? app_max_temp { get; set; }
        public double? app_min_temp { get; set; }
        public int? clouds { get; set; }
        public int? clouds_hi { get; set; }
        public int? clouds_low { get; set; }
        public int? clouds_mid { get; set; }
        public string datetime { get; set; }
        public double? dewpt { get; set; }
        public double? high_temp { get; set; }
        public double? low_temp { get; set; }
        public float? max_temp { get; set; }
        public float? min_temp { get; set; }
        public double? moon_phase { get; set; }
        public double? moon_phase_lunation { get; set; }
        public long? moonrise_ts { get; set; }
        public long? moonset_ts { get; set; }
        public double? ozone { get; set; }
        public int? pop { get; set; }
        public double? precip { get; set; }
        public double? pres { get; set; }
        public int? rh { get; set; }
        public double? slp { get; set; }
        public double? snow { get; set; }
        public double? snow_depth { get; set; }
        public long? sunrise_ts { get; set; }
        public long? sunset_ts { get; set; }
        public float? temp { get; set; }
        public long? ts { get; set; }
        public double? uv { get; set; }
        public string valid_date { get; set; }
        public double? vis { get; set; }
        public Weather weather { get; set; }
        public string wind_cdir { get; set; }
        public string wind_cdir_full { get; set; }
        public int? wind_dir { get; set; }
        public double? wind_gust_spd { get; set; }
        public double? wind_spd { get; set; }
    }
}
