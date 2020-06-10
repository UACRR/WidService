using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using IpsCommonTypes.DataModels;
using IpsCommonTypes.Types;
using ipsmedserviceapp.Model;
using ipsmedserviceapp.Model.SQLViewsData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ipsmedserviceapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoyaltyCorrectionController : ControllerBase
    {
        private readonly MediaServiceContext _dbContext;

        public RoyaltyCorrectionController(MediaServiceContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Знайти об'єкт права за ID об'єкта права та його правовласника
        /// </summary>
        /// <param name="custId"></param>
        /// <param name="objId"></param>
        /// <returns></returns>
        [HttpGet("search/object/{custId}/{objId}")]
        public async Task<IActionResult> SearchObjectRightAsync(int custId, int objId)
        {
            ResponseOfRequest<object> responseOfRequest;
            try
            {
                // some query

                responseOfRequest = new ResponseOfRequest<object>(new object());
                return Ok(responseOfRequest);
            }
            catch (Exception e)
            {
                responseOfRequest = new ResponseOfRequest<object>(e);
                return Ok(responseOfRequest);
            }
        }

        /// <summary>
        /// Знайти правильного правовласника
        /// </summary>
        /// <param name="custId"></param>
        /// <returns></returns>
        [HttpGet("search/rh/{custId}")]
        public async Task<IActionResult> SearchCorrectRightholderAsync(int custId)
        {
            ResponseOfRequest<Account> responseOfRequest;
            try
            {
                var data = await _dbContext.Account.FirstOrDefaultAsync(rec => rec.CustId == custId);
                
                var vcustomer = await _dbContext.vCustomer.FirstOrDefaultAsync(rec => rec.CustId == custId);
                
                if (data != null)
                    data.AccName = vcustomer.FullName;

                responseOfRequest = new ResponseOfRequest<Account>(data);
                return Ok(responseOfRequest);
            }
            catch (Exception e)
            {
                responseOfRequest = new ResponseOfRequest<Account>(e);
                return Ok(responseOfRequest);
            }
        }

        /// <summary>
        /// Запустити процес виправлення
        /// </summary>
        /// <returns></returns>
        [HttpPost("CorrectionProcess")]
        public async Task<IActionResult> RunCorrectionProcessAsync([FromBody] RoyaltyCorrectionParams correctionParams)
        {
            ResponseOfRequest responseOfRequest;
            try
            {
                // process
                await Task.Delay(2740);

                string query = $"exec @returnCode = [MPay41_D21_K21_transfer] @accountD, @accountK, @kindCode, @objid, @amount";

                object[] sqlParameters =
                {
                    new SqlParameter
                    {
                        ParameterName = "@returnCode",
                        SqlDbType = SqlDbType.Int,
                        Direction = ParameterDirection.Output
                    },
                    new SqlParameter("@accountD", correctionParams.AccountD),
                    new SqlParameter("@accountK", correctionParams.AccountK),
                    new SqlParameter("@kindCode", correctionParams.KindCode),
                    new SqlParameter("@objid", correctionParams.Objid),
                    new SqlParameter("@amount", correctionParams.Amount),
                };

                _dbContext.Database.SetCommandTimeout(600);

                var result = await _dbContext.Database.ExecuteSqlCommandAsync(query, sqlParameters);

                var returnedCode = (SqlParameter)sqlParameters[0];

                responseOfRequest = new ResponseOfRequest
                {
                    IsSuccess = (int)returnedCode.Value == 0,
                    StatusCode = (int)returnedCode.Value,
                };

                return Ok(responseOfRequest);
            }
            catch (Exception e)
            {
                responseOfRequest = new ResponseOfRequest(e);
                return Ok(responseOfRequest);
            }
        }
    }
}
