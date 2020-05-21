using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using IpsCommonTypes.Types;
using ipsmedserviceapp.Extensions;
using ipsmedserviceapp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace ipsmedserviceapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FinishingWorksController : ControllerBase
    {
        private readonly MediaServiceContext _dbContext;
        private ILogger<FinishingWorksController> _logger;

        public FinishingWorksController(MediaServiceContext dbContext, ILogger<FinishingWorksController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        [HttpGet("SystemState")]
        public async Task<IActionResult> GetCurrentSystemState()
        {
            ResponseOfRequest<ProcessManagement> responseOfRequest;
            IDbContextTransaction transaction = null;
            try
            {
                var data = await _dbContext.ProcessManagement.SingleAsync(rec => rec.ProcessId == 1);
                if (data.DateStop < DateTime.Now && (!data.DateStopAvto.HasValue || data.DateStopAvto < DateTime.Now))
                {
                    data.Status = 0;
                    data.DateStopBegin = null;
                    data.DateStop = null;
                }

                transaction = await _dbContext.Database.BeginTransactionAsync();
                await _dbContext.SaveChangesAsync();
                transaction.Commit();

                responseOfRequest = new ResponseOfRequest<ProcessManagement>(data);
                return Ok(responseOfRequest);
            }
            catch (Exception e)
            {
                transaction?.Rollback();

                _logger.LogError(e.ToString());

                responseOfRequest = new ResponseOfRequest<ProcessManagement>(e);
                return Ok(responseOfRequest);
            }
        }

        [HttpPut("RunPayment")]
        public async Task<IActionResult> RunPayment()
        {
            ResponseOfRequest<ProcessManagement> responseOfRequest;
            IDbContextTransaction transaction = null;

            try
            {
                var posibleResponse = CheckAuthToken();
                if (posibleResponse != null)
                    return Ok(posibleResponse);

                // add check 

                var data = await _dbContext.ProcessManagement.SingleAsync(rec => rec.ProcessId == 1);

                if (data.DateStopAvto > DateTime.Now)
                {
                    responseOfRequest = new ResponseOfRequest<ProcessManagement>
                    {
                        IsSuccess = false,
                        Message = $"current date less than date when you can run process"
                    };

                    return Ok(responseOfRequest);
                }

                data.DateModify = DateTime.Now;
                data.DateStopBegin = null;
                data.DateStop = null;
                data.Status = 0;

                transaction = await _dbContext.Database.BeginTransactionAsync();
                await _dbContext.SaveChangesAsync();
                transaction.Commit();

                responseOfRequest = new ResponseOfRequest<ProcessManagement>(new ProcessManagement());
                return Ok(responseOfRequest);
            }
            catch (Exception e)
            {
                transaction?.Rollback();

                _logger.LogError(e.ToString());

                responseOfRequest = new ResponseOfRequest<ProcessManagement>(e);
                return Ok(responseOfRequest);
            }
        }

        [HttpPut("StopPayment")]
        public async Task<IActionResult> StopPayment([FromBody] DateTime dateTime)
        {
            ResponseOfRequest<ProcessManagement> responseOfRequest;
            IDbContextTransaction transaction = null;

            try
            {
                var posibleResponse = CheckAuthToken();
                if (posibleResponse != null)
                    return Ok(posibleResponse);

                var data = await _dbContext.ProcessManagement.SingleAsync(rec => rec.ProcessId == 1);
                data.DateModify = DateTime.Now;
                data.DateStopBegin = DateTime.Now;
                data.DateStop = dateTime;
                data.Status = 1;

                transaction = await _dbContext.Database.BeginTransactionAsync();
                await _dbContext.SaveChangesAsync();
                transaction.Commit();

                responseOfRequest = new ResponseOfRequest<ProcessManagement>(new ProcessManagement());
                return Ok(responseOfRequest);
            }
            catch (Exception e)
            {
                transaction?.Rollback();

                _logger.LogError(e.ToString());

                responseOfRequest = new ResponseOfRequest<ProcessManagement>(e);
                return Ok(responseOfRequest);
            }
        }

        [HttpPut("ChangeDateStop")]
        public async Task<IActionResult> ChangeDateStop([FromBody] DateTime dateTime)
        {
            ResponseOfRequest<ProcessManagement> responseOfRequest;
            IDbContextTransaction transaction = null;
            
            try
            {
                var posibleResponse = CheckAuthToken();
                if (posibleResponse != null)
                    return Ok(posibleResponse);

                var data = await _dbContext.ProcessManagement.SingleAsync(rec => rec.ProcessId == 1);
                data.DateModify = DateTime.Now;
                data.DateStop = dateTime;

                transaction = await _dbContext.Database.BeginTransactionAsync();
                await _dbContext.SaveChangesAsync();
                transaction.Commit();

                responseOfRequest = new ResponseOfRequest<ProcessManagement>(new ProcessManagement());
                return Ok(responseOfRequest);
            }
            catch (Exception e)
            {
                transaction?.Rollback();

                _logger.LogError(e.ToString());

                responseOfRequest = new ResponseOfRequest<ProcessManagement>(e);
                return Ok(responseOfRequest);
            }
        }

        [HttpGet("RunFinalEnrollment")]
        public async Task<IActionResult> RunFinalEnrollment()
        {
            ResponseOfRequest responseOfRequest;
            
            try
            {
                var posibleResponse = CheckAuthToken();
                if (posibleResponse != null)
                    return Ok(posibleResponse);

                string query = $"exec @returnCode = [dbo].[MPay6_D20_K21]";
                var returnedCode = new SqlParameter
                {
                    ParameterName = "@returnCode",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };
                
                responseOfRequest = new ResponseOfRequest();

                _dbContext.Database.SetCommandTimeout(600);

                var result = await _dbContext.Database.ExecuteSqlCommandAsync(query, returnedCode);
                
                responseOfRequest.IsSuccess = (int) returnedCode.Value == 0;

                return Ok(responseOfRequest);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());

                responseOfRequest = new ResponseOfRequest(e);
                return Ok(responseOfRequest);
            }
        }

        [HttpGet("RollbackLastFinalEnrollment")]
        public async Task<IActionResult> RollbackLastFinalEnrollment()
        {
            ResponseOfRequest responseOfRequest;
            try
            {
                var posibleResponse = CheckAuthToken();
                if (posibleResponse != null)
                    return Ok(posibleResponse);

                // some process
                //await Task.Delay(4838);

                //var data = await _dbContext.ProcessManagement.SingleAsync(rec => rec.ProcessId == 1);
                //if (data.DateStopAvto.HasValue && data.DateStopAvto > DateTime.Now)
                //{
                //    data.StatusAvto = 0;
                //    data.DateStopAvto = null;

                //    transaction = await _dbContext.Database.BeginTransactionAsync();
                //    await _dbContext.SaveChangesAsync();
                //    transaction.Commit();
                //}

                //responseOfRequest = new ResponseOfRequest
                //{
                //    IsSuccess = true,
                //};
                //return Ok(responseOfRequest);

                string query = $"exec @returnCode = [dbo].[MPay6_D20_K21_rollback] @dateWork";

                var returnedCode = new SqlParameter
                {
                    ParameterName = "@returnCode",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };

                var sqlParameter = new SqlParameter("@dateWork", DateTime.Today);


                responseOfRequest = new ResponseOfRequest();

                _dbContext.Database.SetCommandTimeout(600);

                var result = await _dbContext.Database.ExecuteSqlCommandAsync(query, returnedCode, sqlParameter);

                responseOfRequest.IsSuccess = (int)returnedCode.Value == 0;

                return Ok(responseOfRequest);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());

                responseOfRequest = new ResponseOfRequest<object>(e);
                return Ok(responseOfRequest);
            }
        }

        private ResponseOfRequest<object> CheckAuthToken()
        {
            ResponseOfRequest<object> responseOfRequest = null;

            bool isAuth = Request.Headers.ContainsKey("FinishingWorksToken");
            
            if (!isAuth || Request.Headers["FinishingWorksToken"] != "ff_zxcvbnm951")
            {
                responseOfRequest = new ResponseOfRequest<object>
                {
                    IsSuccess = false,
                    StatusCode = 401,
                    Message = "Unauthorized"
                };
            }

            return responseOfRequest;
        }
    }
}