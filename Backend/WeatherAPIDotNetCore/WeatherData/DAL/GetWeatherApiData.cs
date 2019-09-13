using WeatherAppApi.Models;
using WeatherAppApi.Services;
using System;
using StackExchange.Redis;

namespace WeatherAppApi
{
    public class GetWeatherApiData
    {
        private WeatherService _weatherService;

        public GetWeatherApiData(WeatherService weatherservice)
        {
            _weatherService = weatherservice;
        }
        public string getOpenWeatherApiData(string lat, string longi)
        {
           
            IDatabase db = _weatherService._rediscon.GetDatabase();

            var projectData = db.StringGet("OpenWeather1" + lat + "," + longi);

            if (!string.IsNullOrEmpty(projectData))
            {
                Console.WriteLine("Get Data From Cache");
            }
            else
            {
                Console.WriteLine("Set Data in Cache");
                db.StringSet("OpenWeather1" + lat + "," + longi, _weatherService.GetOpenWeatherMapLatLong(lat, longi));

                projectData = db.StringGet("OpenWeather1" + lat + "," + longi);

            }
            return projectData;
        }


        public string getDarkSkyApiData(string lat, string longi)
        {
            //WeatherService obj = new WeatherService();
            DarkSkyFinalData obj1 = new DarkSkyFinalData();
            // IDatabase db = AppConstant.rediscon.GetDatabase();
            IDatabase db = _weatherService._rediscon.GetDatabase();

            var projectData = db.StringGet("DarkSky1" + lat + "," + longi);

            if (!string.IsNullOrEmpty(projectData))
            {
                Console.WriteLine("Get Data From Cache");
            }
            else
            {
                Console.WriteLine("Set Data in Cache");
                db.StringSet("DarkSky1" + lat + "," + longi, _weatherService.GetDarkSkyWeatherReport(lat + "," + longi));

                projectData = db.StringGet("DarkSky1" + lat + "," + longi);
            }
            return projectData;
        }

        public string getWeatherUnlockApiData(string lat, string longi)
        {
           // WeatherService obj = new WeatherService();
            WeatherUnlockFinal obj1 = new WeatherUnlockFinal();
            //IDatabase db = AppConstant.rediscon.GetDatabase();
            IDatabase db = _weatherService._rediscon.GetDatabase();

            var projectData = db.StringGet("WeatherUnlockCurrent1" + lat + "," + longi);

            if (!string.IsNullOrEmpty(projectData))
            {
                Console.WriteLine("Get Data From Cache");
            }
            else
            {
                Console.WriteLine("Set Data in Cache");
                db.StringSet("WeatherUnlockCurrent1" + lat + "," + longi, _weatherService.GetWeatherReportWeatherUnlockForcast(lat + "," + longi));
                projectData = db.StringGet("WeatherUnlockCurrent1" + lat + "," + longi);
            }
            return projectData;
        }
    }
}