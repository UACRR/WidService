using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ipsmedserviceapp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ipsmedserviceapp.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private readonly MediaServiceContext _dbContext;
        public InfoController(MediaServiceContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("Owner")]
        public async Task<IActionResult> GetOwner()
        {
            var owner = await _dbContext.vCustomer.Where(rec => rec.ankMy == 1).FirstOrDefaultAsync();
            return Ok(owner);
        }
    }
}