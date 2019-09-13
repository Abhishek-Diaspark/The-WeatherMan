using WeatherAppApi.Models;
using WeatherAppApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using StackExchange.Redis;
using Newtonsoft.Json.Linq;

namespace WeatherAppApi.Controllers
{
    [Route("averageprovider1")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class WeatherAverageReportController : ControllerBase
    {
        private readonly WeatherService _weatherService;      

        public WeatherAverageReportController(WeatherService weatherservice)
        {
            _weatherService = weatherservice;
        }

        [HttpGet]
        public Object GetAverageWeatherReport(string date, string place, string lat, string lon)
        {            
          
            IDatabase db = AppConstant.rediscon.GetDatabase();

            string darksky = db.StringGet("DarkSky1" + lat + "," + lon);
            Console.WriteLine("darksky");
            string openweather = db.StringGet("OpenWeather1" + place);
            Console.WriteLine("openweather");
            string apixu = db.StringGet("Apixu" + place + date);
            Console.WriteLine("apixu");
            if (darksky != null && openweather != null && apixu != null)
            {
                JObject json1 = JObject.Parse(darksky);               
                JObject json2 = JObject.Parse(openweather);               
                JObject json3 = JObject.Parse(apixu);
               

                decimal tempc = ((5 * (Convert.ToDecimal(json1["currently"]["temperature"]) - 32)) / 9 + (Convert.ToDecimal(json2["main"]["temp"]) - 273) + (5 * (Convert.ToDecimal(json3["current"]["temp_f"]) - 32)) / 9) / 3;
                decimal tempf = ((9 * (tempc)) / 5) + 32;

                decimal temphumid = (((Convert.ToDecimal(json1["currently"]["humidity"]) * 100) + Convert.ToDecimal(json2["main"]["humidity"])) + Convert.ToDecimal(json3["current"]["humidity"])) / 3;

                decimal temppressure = ((Convert.ToDecimal(json1["currently"]["pressure"]) + Convert.ToDecimal(json2["main"]["pressure"])) + Convert.ToDecimal(json3["current"]["pressure_mb"])) / 3;

                decimal tempwind = ((Convert.ToDecimal(json1["currently"]["windSpeed"]) + (Convert.ToDecimal(json2["wind"]["speed"])) * 10) + Convert.ToDecimal(json3["current"]["wind_kph"])) / 3;

                decimal tempapprent = (((5 * (Convert.ToDecimal(json1["currently"]["apparentTemperature"]) - 32)) / 9) + ((Convert.ToDecimal(json2["main"]["temp"])) - 273) + Convert.ToDecimal(json3["current"]["feelslike_c"])) / 3;

                AverageReport obj3 = new AverageReport();
                obj3.Temp_C = Math.Round(tempc, 2);
                obj3.Temp_F = Math.Round(tempf, 2);
                obj3.Pressure = Math.Round(temppressure, 2);
                obj3.Humidity = Math.Round(temphumid, 1);
                obj3.AppearentTemp = Math.Round(tempapprent, 1);
                obj3.WindSpeed = Math.Round(tempwind, 2);

                return Ok(obj3);

            }
            else
            {
                WeatherService obj = new WeatherService();
                JObject json3 = JObject.Parse(obj.GetAPixuWeatherReport(place));
                JObject json2 = JObject.Parse(obj.GetOpenWeatherMap(place));
                JObject json1 = JObject.Parse(obj.GetDarkSkyWeatherReport(lat + "," + lon));

                decimal tempc = ((5 * (Convert.ToDecimal(json1["currently"]["temperature"]) - 32)) / 9 + (Convert.ToDecimal(json2["main"]["temp"]) - 273) + (5 * (Convert.ToDecimal(json3["current"]["temp_f"]) - 32)) / 9) / 3;
                decimal tempf = ((9 * (tempc)) / 5) + 32;
                decimal temphumid = (((Convert.ToDecimal(json1["currently"]["humidity"]) * 100) + Convert.ToDecimal(json2["main"]["humidity"])) + Convert.ToDecimal(json3["current"]["humidity"])) / 3;
                decimal temppressure = ((Convert.ToDecimal(json1["currently"]["pressure"]) + Convert.ToDecimal(json2["main"]["pressure"])) + Convert.ToDecimal(json3["current"]["pressure_mb"])) / 3;
                decimal tempwind = ((Convert.ToDecimal(json1["currently"]["windSpeed"]) + (Convert.ToDecimal(json2["wind"]["speed"])) * 10) + Convert.ToDecimal(json3["current"]["wind_kph"])) / 3;
                decimal tempapprent = (((5 * (Convert.ToDecimal(json1["currently"]["apparentTemperature"]) - 32)) / 9) + ((Convert.ToDecimal(json2["main"]["temp"])) - 273) + Convert.ToDecimal(json3["current"]["feelslike_c"])) / 3;

                AverageReport obj3 = new AverageReport();
                obj3.Temp_C = Math.Round(tempc, 2);
                obj3.Temp_F = Math.Round(tempf, 2);
                obj3.Pressure = Math.Round(temppressure, 2);
                obj3.Humidity = Math.Round(temphumid, 1);
                obj3.AppearentTemp = Math.Round(tempapprent, 1);
                obj3.WindSpeed = Math.Round(tempwind, 2);

                return Ok(obj3);
            }
        }

        [HttpPost]
        public Object GetAverageWeatherReport(ApiRequest apirequest)
        {
            Console.WriteLine("Data from Cache");
            Console.WriteLine("GetAverageData");

            IDatabase db = AppConstant.rediscon.GetDatabase();

            string darksky = db.StringGet("DarkSky" + apirequest.Place + apirequest.RequestDate.date);
            Console.WriteLine("darksky");
            string openweather = db.StringGet("OpenWeather" + apirequest.Place + apirequest.RequestDate.date);
            Console.WriteLine("openweather");
            string apixu = db.StringGet("Apixu" + apirequest.Place + apirequest.RequestDate.date);
            Console.WriteLine("apixu");
            if (darksky != null && openweather != null && apixu != null)
            {
                JObject json1 = JObject.Parse(darksky);

                JObject json2 = JObject.Parse(openweather);

                JObject json3 = JObject.Parse(apixu);
               

                decimal tempc = ((5 * (Convert.ToDecimal(json1["currently"]["temperature"]) - 32)) / 9 + (Convert.ToDecimal(json2["main"]["temp"]) - 273) + (5 * (Convert.ToDecimal(json3["current"]["temp_f"]) - 32)) / 9) / 3;
                decimal tempf = ((9 * (tempc)) / 5) + 32;

                decimal temphumid = (((Convert.ToDecimal(json1["currently"]["humidity"]) * 100) + Convert.ToDecimal(json2["main"]["humidity"])) + Convert.ToDecimal(json3["current"]["humidity"])) / 3;

                decimal temppressure = ((Convert.ToDecimal(json1["currently"]["pressure"]) + Convert.ToDecimal(json2["main"]["pressure"])) + Convert.ToDecimal(json3["current"]["pressure_mb"])) / 3;

                decimal tempwind = ((Convert.ToDecimal(json1["currently"]["windSpeed"]) + (Convert.ToDecimal(json2["wind"]["speed"])) * 10) + Convert.ToDecimal(json3["current"]["wind_kph"])) / 3;

                decimal tempapprent = (((5 * (Convert.ToDecimal(json1["currently"]["apparentTemperature"]) - 32)) / 9) + ((Convert.ToDecimal(json2["main"]["temp"])) - 273) + Convert.ToDecimal(json3["current"]["feelslike_c"])) / 3;

                AverageReport obj3 = new AverageReport();
                obj3.Temp_C = Math.Round(tempc, 2);
                obj3.Temp_F = Math.Round(tempf, 2);
                obj3.Pressure = Math.Round(temppressure, 2);
                obj3.Humidity = Math.Round(temphumid, 1);
                obj3.AppearentTemp = Math.Round(tempapprent, 1);
                obj3.WindSpeed = Math.Round(tempwind, 2);

                return Ok(obj3);

            }
            else
            {
                // Console.WriteLine("Data from Api");
                WeatherService obj = new WeatherService();
                // Console.WriteLine("apiplace"+apirequest.Place);
                JObject json3 = JObject.Parse(obj.GetAPixuWeatherReport(apirequest.Place));
                //  Console.WriteLine("apiplace"+apirequest.Place);
                JObject json2 = JObject.Parse(obj.GetOpenWeatherMap(apirequest.Place));
                // Console.WriteLine("apiplace"+apirequest.lat+","+apirequest.lon);
                JObject json1 = JObject.Parse(obj.GetDarkSkyWeatherReport(apirequest.lat + "," + apirequest.lon));
              

              
                decimal tempc = ((5 * (Convert.ToDecimal(json1["currently"]["temperature"]) - 32)) / 9 + (Convert.ToDecimal(json2["main"]["temp"]) - 273) + (5 * (Convert.ToDecimal(json3["current"]["temp_f"]) - 32)) / 9) / 3;
                decimal tempf = ((9 * (tempc)) / 5) + 32;

                decimal temphumid = (((Convert.ToDecimal(json1["currently"]["humidity"]) * 100) + Convert.ToDecimal(json2["main"]["humidity"])) + Convert.ToDecimal(json3["current"]["humidity"])) / 3;

                decimal temppressure = ((Convert.ToDecimal(json1["currently"]["pressure"]) + Convert.ToDecimal(json2["main"]["pressure"])) + Convert.ToDecimal(json3["current"]["pressure_mb"])) / 3;

                decimal tempwind = ((Convert.ToDecimal(json1["currently"]["windSpeed"]) + (Convert.ToDecimal(json2["wind"]["speed"])) * 10) + Convert.ToDecimal(json3["current"]["wind_kph"])) / 3;

                decimal tempapprent = (((5 * (Convert.ToDecimal(json1["currently"]["apparentTemperature"]) - 32)) / 9) + ((Convert.ToDecimal(json2["main"]["temp"])) - 273) + Convert.ToDecimal(json3["current"]["feelslike_c"])) / 3;

                AverageReport obj3 = new AverageReport();
                obj3.Temp_C = Math.Round(tempc, 2);
                obj3.Temp_F = Math.Round(tempf, 2);
                obj3.Pressure = Math.Round(temppressure, 2);
                obj3.Humidity = Math.Round(temphumid, 1);
                obj3.AppearentTemp = Math.Round(tempapprent, 1);
                obj3.WindSpeed = Math.Round(tempwind, 2);

                return Ok(obj3);
            }
            // weatherunlock=JsonConvert.DeserializeObject<WeatherUnlock>(db.StringGet("WeatherUnlock"+apirequest.Place+apirequest.RequestDate.date)); 
            // var openweather=Convert.Json(db.StringGet("OpenWeather"+apirequest.Place+apirequest.RequestDate.date));
            // var weatherbitcurrent=JsonConvert.DeserializeObject<WeathrBit>(db.StringGet("WeatherBitCurrent"+apirequest.Place+apirequest.RequestDate.date));
            //  var apixu=JsonConvert.DeserializeObject<APixuWeatherReport>(db. StringGet("Apixu"+apirequest.Place+apirequest.RequestDate.date)); 
            //  Console.WriteLine(openweather.main.temp); 
            // var avgtemp=Convert.ToInt32(openweather.main.temp);
            // var avcpreciptate=;
            // var avgwindspeed=;    
        }
    }
}