using ipsmedserviceapp.Extensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ipsmedserviceapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthCheckController : ControllerBase
    {
        private ILogger<HealthCheckController> _logger;
        private ExceptionHelper Helper { get; } = new ExceptionHelper(nameof(HealthCheckController));

        public HealthCheckController(ILogger<HealthCheckController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult HealthCheck()
        {
            return Ok("SUCCESS");
        }

        [HttpGet("ok")]
        public IActionResult GetObject()
        {
            var a = new
            {
                Name = nameof(HealthCheckController),
                Assembly = typeof(HealthCheckController).Assembly.FullName,
                Namespace = typeof(HealthCheckController).Namespace,
                DateTime = $"{DateTime.Now:O}",
            };
            
            return Ok(a);
        }

        [HttpGet("ok/{msg}")]
        public IActionResult GetObject(string msg)
        {
            var a = new
            {
                Msg = $"Message is: {msg}",
                Name = nameof(HealthCheckController),
                Assembly = typeof(HealthCheckController).Assembly.FullName,
                Namespace = typeof(HealthCheckController).Namespace,
                DateTime = $"{DateTime.Now:O}",
            };

            return Ok(a);
        }


        [HttpGet("error")]
        public IActionResult GetError()
        {
            try
            {
                int a = 10;
                int b = 0;
                int c = a / b;
                return Ok("SUCCESS");
            }
            catch (Exception e)
            {
                return BadRequest(Helper.GetMessage(e, Request));
            }
        }
    }
}
