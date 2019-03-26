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
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        MediaServiceContext _dbContext;
        public InfoController(MediaServiceContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("Name")]
        public async Task<IActionResult> GetName()
        {
            var myAnketa = await _dbContext.vCustomer.Where(rec => rec.ankMy == 1).FirstOrDefaultAsync();
            if (myAnketa == null)
                return NotFound();

            return Ok(myAnketa.name );
        }
    }
}