using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ipsmedserviceapp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ipsmedserviceapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterWIDController : ControllerBase
    {
        private readonly MediaServiceContext _dbContext;

        public RegisterWIDController(MediaServiceContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("default")]
        public async Task<IActionResult> DefaultGetRequest()
        {
            await Task.Delay(3 * 1000);
            return Ok("It is working!");
        }
    }
}