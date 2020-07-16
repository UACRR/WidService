using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using IpsCommonTypes.IntermediaryTypes;
using IpsCommonTypes.SQLViews;
using IpsCommonTypes.Types;
using ipsmedserviceapp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ipsmedserviceapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HelperController : ControllerBase
    {
        private readonly MediaServiceContext _dbContext;

        public HelperController(MediaServiceContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Отримати суму prepayAmount для таблиці Register по LicId та розрахованого AuthAmount
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        [HttpPost("PrepayAmount")]
        public IActionResult GetPrepayAmount([FromBody] PrepayAmountResource item)
        {
            try
            {
                string query = @"select sum(prepay) as prepayAmount from ft_Tsk_2_BRRegisterAuthor (@licId, @authAmount)";

                var sqlParams = new object[]
                {
                    new SqlParameter("@licId", item.LicId),
                    new SqlParameter("@authAmount", item.AuthAmount),
                };

                var result = _dbContext.FT_TSK_2_BRRegisterAuthor.FromSql(query, sqlParams).First();

                return Ok(ResponseOfRequest<FT_TSK_2_BRRegisterAuthor>.Success(result));
            }
            catch (Exception e)
            {
                return Ok(ResponseOfRequest.NotSuccess(e));
            }
        }
    }
}
