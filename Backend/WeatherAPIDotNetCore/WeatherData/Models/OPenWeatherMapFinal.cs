using System.Collections.Generic;

namespace WeatherAppApi.Models
{

    public class Main
    {
        public double temp { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public double pressure { get; set; }
        public double sea_level { get; set; }
        public double grnd_level { get; set; }
        public int humidity { get; set; }
        public double temp_kf { get; set; }
    }

    public class Weather1
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class Clouds
    {
        public int all { get; set; }
    }

    public class Wind
    {
        public double speed { get; set; }
        public double deg { get; set; }
    }

    public class Rain
    {
        public double __invalid_name__3h { get; set; }
    }

    public class Sys
    {
        public string pod { get; set; }
    }

    public class __invalid_type__0
    {
        public int dt { get; set; }
        public Main main { get; set; }
        public List<Weather1> weather { get; set; }
        public Clouds clouds { get; set; }
        public Wind wind { get; set; }
        public Rain rain { get; set; }
        public Sys sys { get; set; }
        public string dt_txt { get; set; }
    }

    public class Main2
    {
        public double temp { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public double pressure { get; set; }
        public double sea_level { get; set; }
        public double grnd_level { get; set; }
        public int humidity { get; set; }
        public int temp_kf { get; set; }
    }

    public class Weather2
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class Clouds2
    {
        public int all { get; set; }
    }

    public class Wind2
    {
        public double speed { get; set; }
        public double deg { get; set; }
    }

    public class Rain2
    {
        public double __invalid_name__3h { get; set; }
    }

    public class Sys2
    {
        public string pod { get; set; }
    }

    public class __invalid_type__1
    {
        public int dt { get; set; }
        public Main2 main { get; set; }
        public List<Weather2> weather { get; set; }
        public Clouds2 clouds { get; set; }
        public Wind2 wind { get; set; }
        public Rain2 rain { get; set; }
        public Sys2 sys { get; set; }
        public string dt_txt { get; set; }
    }

    public class Main3
    {
        public double temp { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public double pressure { get; set; }
        public double sea_level { get; set; }
        public double grnd_level { get; set; }
        public int humidity { get; set; }
        public int temp_kf { get; set; }
    }

    public class Weather3
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class Clouds3
    {
        public int all { get; set; }
    }

    public class Wind3
    {
        public double speed { get; set; }
        public double deg { get; set; }
    }

    public class Rain3
    {
        public double __invalid_name__3h { get; set; }
    }

    public class Sys3
    {
        public string pod { get; set; }
    }

    public class __invalid_type__2
    {
        public int dt { get; set; }
        public Main3 main { get; set; }
        public List<Weather3> weather { get; set; }
        public Clouds3 clouds { get; set; }
        public Wind3 wind { get; set; }
        public Rain3 rain { get; set; }
        public Sys3 sys { get; set; }
        public string dt_txt { get; set; }
    }

    public class Main4
    {
        public double temp { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public double pressure { get; set; }
        public double sea_level { get; set; }
        public double grnd_level { get; set; }
        public int humidity { get; set; }
        public int temp_kf { get; set; }
    }

    public class Weather4
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class Clouds4
    {
        public int all { get; set; }
    }

    public class Wind4
    {
        public double speed { get; set; }
        public double deg { get; set; }
    }

    public class Rain4
    {
        public double __invalid_name__3h { get; set; }
    }

    public class Sys4
    {
        public string pod { get; set; }
    }

    public class __invalid_type__3
    {
        public int dt { get; set; }
        public Main4 main { get; set; }
        public List<Weather4> weather { get; set; }
        public Clouds4 clouds { get; set; }
        public Wind4 wind { get; set; }
        public Rain4 rain { get; set; }
        public Sys4 sys { get; set; }
        public string dt_txt { get; set; }
    }

    public class Main5
    {
        public double temp { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public double pressure { get; set; }
        public double sea_level { get; set; }
        public double grnd_level { get; set; }
        public int humidity { get; set; }
        public int temp_kf { get; set; }
    }

    public class Weather5
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class Clouds5
    {
        public int all { get; set; }
    }

    public class Wind5
    {
        public double speed { get; set; }
        public double deg { get; set; }
    }

    public class Rain5
    {
        public double __invalid_name__3h { get; set; }
    }

    public class Sys5
    {
        public string pod { get; set; }
    }

    public class __invalid_type__4
    {
        public int dt { get; set; }
        public Main5 main { get; set; }
        public List<Weather5> weather { get; set; }
        public Clouds5 clouds { get; set; }
        public Wind5 wind { get; set; }
        public Rain5 rain { get; set; }
        public Sys5 sys { get; set; }
        public string dt_txt { get; set; }
    }

    public class Openweathermap
    {
        public __invalid_type__0 __invalid_name__0 { get; set; }
        public __invalid_type__1 __invalid_name__1 { get; set; }
        public __invalid_type__2 __invalid_name__2 { get; set; }
        public __invalid_type__3 __invalid_name__3 { get; set; }
        public __invalid_type__4 __invalid_name__4 { get; set; }
    }

    public class Data
    {
        public Openweathermap openweathermap { get; set; }
    }

    public class OPenWeatherMapFinal
    {
        public string code { get; set; }
        public Data data { get; set; }
        public string message { get; set; }
    }
}
