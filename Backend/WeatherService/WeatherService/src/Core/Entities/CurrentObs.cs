namespace WeatherService.src.Core.Entities
{
    public class CurrentObs
    {
        public float? app_temp { get; set; }
        public int? aqi { get; set; }
        public string city_name { get; set; } = string.Empty;
        public int? clouds { get; set; }
        public string country_code { get; set; } = string.Empty;
        public string datetime { get; set; } = string.Empty;
        public float? dewpt { get; set; }
        public double? dhi { get; set; }
        public double? dni { get; set; }
        public double? elev_angle { get; set; }
        public double? ghi { get; set; }
        public double? gust { get; set; }
        public double? h_angle { get; set; }
        public double? lat { get; set; }
        public double? lon { get; set; }
        public string ob_time { get; set; } = string.Empty;
        public string pod { get; set; } = string.Empty;
        public double? precip { get; set; }
        public double? pres { get; set; }
        public int? rh { get; set; }
        public double? slp { get; set; }
        public double? snow { get; set; }
        public double? solar_rad { get; set; }
        public List<string> Sources { get; set; } = new List<string>();
        public string state_code { get; set; } = string.Empty;
        public string station { get; set; } = string.Empty;
        public string sunrise { get; set; } = string.Empty;
        public string sunset { get; set; } = string.Empty;
        public float? temp { get; set; }
        public string timezone { get; set; } = string.Empty;
        public long? ts { get; set; }
        public double? uv { get; set; }
        public double? vis { get; set; }
        public Weather weather { get; set; } = new Weather();
        public string wind_cdir { get; set; } = string.Empty;
        public string wind_cdir_full { get; set; } = string.Empty;
        public int? wind_dir { get; set; }
        public double? wind_spd { get; set; }
    }
}
