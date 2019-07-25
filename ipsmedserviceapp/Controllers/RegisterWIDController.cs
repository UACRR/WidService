using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    public class RegisterWIDController : ControllerBase
    {
        private readonly MediaServiceContext _dbContext;

        public RegisterWIDController(MediaServiceContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("autolinkedobjects/{regId}")]
        public async Task<IActionResult> DefaultGetRequest(int regId)
        {
            await Task.Delay(3 * 1000);
            var currentTimeOut = _dbContext.Database.GetCommandTimeout();
            try
            {
                // imitation of process
                return Ok(new List<string>());

                _dbContext.Database.SetCommandTimeout(2400);
                var sqlParameter = new[] {new SqlParameter("regId", regId)};
                var list = await _dbContext.getViewData($"select * from ft_Tsk_3_AutoLink(@regId)", sqlParameter);

                return Ok(list);
            }
            finally
            {
                if (currentTimeOut.HasValue)
                    _dbContext.Database.SetCommandTimeout(currentTimeOut);
            }
        }
    }
}