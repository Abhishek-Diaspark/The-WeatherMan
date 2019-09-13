using WeatherAppApi.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using WeatherCore.BO;

namespace WeatherAppApi.Controllers
{

    [ApiController]
    public class GetWeatherController : ControllerBase
    {
        private readonly WeatherDataAggrigator _weatherDataAggrigator;

        public GetWeatherController(WeatherDataAggrigator weatherDataAggrigator)
        {
            _weatherDataAggrigator = weatherDataAggrigator;
        }

        [HttpGet, Route("getweather/openweathermap")]
        public Object GetOpenWeatherMap(string lat, string longi)
        {   
            Console.WriteLine(Environment.GetEnvironmentVariable(AppConstant.REDIS_CONNECTION_STRING));
            Response response = new Response();
            response.status = "OK";
            // response.message = "Messsage";
            response.payload = _weatherDataAggrigator.OpenWeatherAggrigator(lat, longi);            
            return Ok(response);
        }

        [HttpGet, Route("getweather/darksky")]
        public Object GetDarkSkyWeatherReport_v2(string lat, string longi)
        {            
            Response response = new Response();
            response.status = "OK";
            // response.message = "Messsage";
            response.payload = _weatherDataAggrigator.DarkSkyAggrigator(lat,longi);
            return Ok(response);
        }

        [HttpGet, Route("getweather/weatherunlocked")]
        public Object GetWeatherReportWeatherUnlockCurrent(string lat, string longi)
        {
            Response response = new Response();
            response.status = "OK";
            // response.message = "Messsage";
            response.payload = _weatherDataAggrigator.WeatherUnlockAggrigator(lat,longi);
            return Ok(response);
        }

    }
}