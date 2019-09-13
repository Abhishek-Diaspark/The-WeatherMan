using WeatherAppApi.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WeatherAppApi.Controllers
{
    [ApiController]
    public class MapsApiController : ControllerBase
    {
        private readonly WeatherService _weatherService;       

        public MapsApiController(WeatherService weatherservice)
        {
            _weatherService = weatherservice;
        }

        [HttpGet, Route("gmapkey")]
        public Object GetApiKey()
        {
            string secret = Environment.GetEnvironmentVariable(AppConstant.MAPS_API_KEY);
            return Ok(new
            {
                status = "OK",
                payload = secret
                // message = "Message"

            });
        }

    }
}
