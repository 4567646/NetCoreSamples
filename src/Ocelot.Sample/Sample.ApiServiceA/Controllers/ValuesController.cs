using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Sample.ApiServiceA.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ValuesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // GET api/values
        [HttpGet]
        public string Get()
        {
            return $"prot={HttpContext.Request.Host.Port} appName={ _configuration["AppName"]}  thisTime={DateTime.Now.ToString()}";
        }


    }
}
