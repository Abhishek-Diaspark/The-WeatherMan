using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using WeatherAppApi;
using WeatherAppApi.Services;

namespace WeatherCore.BO
{
    public class WeatherDataAggrigator
    {       
        private GetWeatherApiData _getweatherapidata;
        private JObject _jObject;
        public WeatherDataAggrigator(GetWeatherApiData getweatherapidata) {
            _getweatherapidata = getweatherapidata;
        }

      
        public JObject OpenWeatherAggrigator(string lat, string longi)
        {
            //var CosmosConnectionString = Environment.GetEnvironmentVariable("CosmosConnectionString");
           // Console.WriteLine("TestENV");
           // Console.WriteLine(CosmosConnectionString);
            var projectData = _getweatherapidata.getOpenWeatherApiData(lat, longi);

            JObject jsondata = JObject.Parse(projectData);

            JObject openweather0 = new JObject();
            openweather0.Add("0", jsondata["list"][0]);
            openweather0.Add("1", jsondata["list"][6]);
            openweather0.Add("2", jsondata["list"][13]);
            openweather0.Add("3", jsondata["list"][22]);
            openweather0.Add("4", jsondata["list"][29]);
            JObject finaldarksky = new JObject();
            _jObject = new JObject();
            _jObject.Add("openweathermap", JObject.FromObject(openweather0));
            return _jObject;
        }

        public JObject DarkSkyAggrigator(string lat, string longi)
        {
            var projectData = _getweatherapidata.getDarkSkyApiData(lat, longi);
            JObject jsondata = JObject.Parse(projectData);

            JObject _jObject = new JObject();
            _jObject.Add("darksky", JObject.FromObject(jsondata));

            return _jObject;
        }

        public JObject WeatherUnlockAggrigator(string lat, string longi)
        {
            var projectData = _getweatherapidata.getWeatherUnlockApiData(lat, longi);
            JObject jsondata = JObject.Parse(projectData);

            _jObject = new JObject();
            _jObject.Add("weatherunlocked", JObject.FromObject(jsondata));

            return _jObject;
        }

    }
}
