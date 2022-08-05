using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using IpsCommonTypes.DataModels;
using IpsCommonTypes.Types;
using ipsmedserviceapp.Extensions;
using ipsmedserviceapp.Model;
using ipsmedserviceapp.Model.SQLViewsData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoyaltyCorrectionTransfer = IpsCommonTypes.DataModels.RoyaltyCorrectionTransfer;

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
            ResponseOfRequest<RoyaltyCorrectionTransfer> responseOfRequest;
            try
            {
                var rightholder = await _dbContext.vCustomer.FirstOrDefaultAsync(rec => rec.CustId == custId);
                var objectright = await _dbContext.ObjectRight.FirstOrDefaultAsync(rec => rec.ObjId == objId);

                if (rightholder == null || objectright == null)
                {
                    responseOfRequest = new ResponseOfRequest<RoyaltyCorrectionTransfer>
                    {
                        Message = "NotFound",
                        IsSuccess = false,
                    };

                    return Ok(responseOfRequest);
                }

                // some query
                string query = $"exec MPay41_D21_K21_transfer_list @custid, @objid";

                object[] sqlParameters =
                {
                    new SqlParameter("@custid", custId),
                    new SqlParameter("@objid", objId),
                };

                var result = await _dbContext.MPay41D21K21TransferLists.FromSql(query, sqlParameters).ToListAsync();
                
                //var result = ExecuteQuery.GetDataFromSqlServer((SqlConnection)_dbContext.Database.GetDbConnection(), query, sqlParameters);

                responseOfRequest = new ResponseOfRequest<RoyaltyCorrectionTransfer>(new RoyaltyCorrectionTransfer
                {
                    ObjectRightName = objectright.Name,
                    RightholderName = rightholder.FullName,
                    TransferList = result,
                });

                return Ok(responseOfRequest);
            }
            catch (Exception e)
            {
                responseOfRequest = new ResponseOfRequest<RoyaltyCorrectionTransfer>(e);
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
            ResponseOfRequest<vCustomer> responseOfRequest;
            try
            {
                var vcustomer = await _dbContext.vCustomer.FirstOrDefaultAsync(rec => rec.CustId == custId);
                
                responseOfRequest = new ResponseOfRequest<vCustomer>(vcustomer);
                return Ok(responseOfRequest);
            }
            catch (Exception e)
            {
                responseOfRequest = new ResponseOfRequest<vCustomer>(e);
                return Ok(responseOfRequest);
            }
        }

        /// <summary>
        /// Запустити процес виправлення
        /// </summary>
        /// <returns></returns>
        [HttpPost("CorrectionProcess")]
        public async Task<IActionResult> RunCorrectionProcessAsync([FromBody] List<RoyaltyCorrectionParams> correctionParamsList)
        {
            ResponseOfRequest<List<RoyaltyCorrectionParams>> responseOfRequest;
            try
            {

                if (!correctionParamsList.Any())
                {
                    responseOfRequest = new ResponseOfRequest<List<RoyaltyCorrectionParams>>
                    {
                        IsSuccess = false,
                        Message = "Parameters is empty!",
                    };
                    return Ok(responseOfRequest);
                }

                // custidD - кому, custidK - від кого
                string query = $"exec @returnCode = [MPay41_D21_K21_transfer] @custidD, @custidK, @kindCode, @objid, @amount, @turnid";

                _dbContext.Database.SetCommandTimeout(600);

                var notSuccessExecList = new List<RoyaltyCorrectionParams>();

                foreach (var correctionParams in correctionParamsList)
                {
                    object[] sqlParameters =
                    {
                        new SqlParameter
                        {
                            ParameterName = "@returnCode",
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Output
                        },
                        new SqlParameter("@custidD", correctionParams.CustIdD),
                        new SqlParameter("@custidK", correctionParams.CustIdK),
                        new SqlParameter("@kindCode", correctionParams.KindCode),
                        new SqlParameter("@objid", correctionParams.Objid),
                        new SqlParameter("@amount", correctionParams.Amount),
                        new SqlParameter("@turnid", correctionParams.TurnId), 
                    };

                    var result = await _dbContext.Database.ExecuteSqlCommandAsync(query, sqlParameters);

                    if ((int) ((SqlParameter) sqlParameters[0]).Value != 0)
                    {
                        notSuccessExecList.Add(correctionParams);
                    }
                }

                responseOfRequest = new ResponseOfRequest<List<RoyaltyCorrectionParams>>
                {
                    IsSuccess = notSuccessExecList.Count == 0,
                    Data = notSuccessExecList,
                };

                return Ok(responseOfRequest);
            }
            catch (Exception e)
            {
                responseOfRequest = new ResponseOfRequest<List<RoyaltyCorrectionParams>>(e);
                return Ok(responseOfRequest);
            }
        }
    }
}
