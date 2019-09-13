using WeatherAppApi.Models;
using WeatherAppApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using Newtonsoft.Json.Linq;
using WeatherCore.BO;

namespace WeatherAppApi.Controllers

{
    
    [ApiController]
    public class AverageProvider : ControllerBase
    {
        private readonly AverageDataAggrigator _averagedataaggrigator;
      
        public AverageProvider(AverageDataAggrigator averagedataaggrigator)
        {     
            _averagedataaggrigator = averagedataaggrigator;

        }

        [HttpGet, Route("averageprovider")]
        public Object GetWeatherReport(string lat, string longi)
        {
            // string[] latlong = latLong.Split(',');
            _averagedataaggrigator.GetAverageAggrigatedData(lat, longi);   
            
            Response response = new Response();
            response.status = "OK";
            // response.message = "Messsage";                              
            response.payload = _averagedataaggrigator.GetAverageAggrigatedData(lat, longi);
            return Ok(response);   
        }
    }
}
