using System.Collections.Generic;

namespace WeatherAppApi.Models
{
    public class WeatherBitFinal
    {
        //  public WeatherBit WeatherBit {get;set;}
        public WeatherBitData WeatherBitData { get; set; }
        public Tempindiffform Tempindiffform { get; set; }
        public IconsDetails IconsDetails { get; set; }
    }

    public class Weather
    {
        public string icon { get; set; }
        public string code { get; set; }
        public string description { get; set; }
    }

    public class Datum
    {
        public int rh { get; set; }
        public string pod { get; set; }
        public double lon { get; set; }
        public double pres { get; set; }
        public string timezone { get; set; }
        public string ob_time { get; set; }
        public string country_code { get; set; }
        public int clouds { get; set; }
        public int ts { get; set; }
        public double solar_rad { get; set; }
        public string state_code { get; set; }
        public string city_name { get; set; }
        public double wind_spd { get; set; }
        public string last_ob_time { get; set; }
        public string wind_cdir_full { get; set; }
        public string wind_cdir { get; set; }
        public double slp { get; set; }
        public double vis { get; set; }
        public double h_angle { get; set; }
        public string sunset { get; set; }
        public double dni { get; set; }
        public double dewpt { get; set; }
        public int snow { get; set; }
        public double uv { get; set; }
        public int precip { get; set; }
        public int wind_dir { get; set; }
        public string sunrise { get; set; }
        public double ghi { get; set; }
        public double dhi { get; set; }
        public int aqi { get; set; }
        public double lat { get; set; }
        public Weather weather { get; set; }
        public string datetime { get; set; }
        public string temp { get; set; }
        public string station { get; set; }
        public double elev_angle { get; set; }
        public double app_temp { get; set; }
    }

    public class WeatherBit
    {
        public List<Datum> data { get; set; }
        public int count { get; set; }
    }

    public class WeatherBitData
    {
        public int rh { get; set; }
        public int pres { get; set; }
        public int wind_spd { get; set; }
        public int weather { get; set; }
        public int app_temp { get; set; }
        public string description { get; set; }
    }

    public class IconsDetails
    {
        public string IconName { get; set; }
        public string IconUrl { get; set; }
    }

}
