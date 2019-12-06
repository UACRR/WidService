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
                int a = 11;
                
                var sqlparam = new SqlParameter("a", a);
                var returnedCode = new SqlParameter();
                returnedCode.ParameterName = "@retCode";
                returnedCode.SqlDbType = SqlDbType.Int;
                returnedCode.Direction = ParameterDirection.Output;

                var query = "exec @retCode = TestExecProc @a";

                ;
                var result =  await _dbContext.Database.ExecuteSqlCommandAsync(query, sqlparam, returnedCode);
                ;

                a = 27;
                sqlparam = new SqlParameter("a", a);

                ;
                var result2 = await _dbContext.Database.ExecuteSqlCommandAsync(query, sqlparam, returnedCode);
                ;

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