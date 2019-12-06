using System;
using System.Collections.Generic;
using System.Data;
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
    public class LanguagesController : ControllerBase
    {
        private readonly MediaServiceContext _dbContext;

        public LanguagesController(MediaServiceContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("execprocedure")]
        public async Task<IActionResult> ExecutProcedure()
        {
            try
            {
                Random random = new Random();
                int a = random.Next(1, 30);
                int retCode = 0;

                var sqlparam = new SqlParameter("a", a);
                var sqlparam2 = new SqlParameter("retCode ", retCode);
                sqlparam2.Direction = ParameterDirection.ReturnValue;

                string query = "declare @retCode int " +
                               "exec @retCode = TestExecProc @a ";
                //               "select @retCode ";

                //string query = "exec @retCode = TestExecProc @a";

                var result =  await _dbContext.Database.ExecuteSqlCommandAsync(query, sqlparam, sqlparam2);

                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}