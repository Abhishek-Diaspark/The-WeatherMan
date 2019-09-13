using Microsoft.AspNetCore.Mvc;
using System;

namespace WeatherAppApi.Controllers
{
    [ApiController]
    public class SummaryController : ControllerBase
    {       

        [HttpGet, Route("summaryprovider")]
        public Object summaryprovider()
        {
            var data = new { FAV_PROVIDER_ID = "0" };
            return Ok(new
            {
                code = "200",
                data = data,
                message = "Message"
            });
        }

    }
}
