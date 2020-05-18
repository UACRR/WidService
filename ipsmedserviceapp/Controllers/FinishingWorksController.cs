using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using IpsCommonTypes.Types;
using ipsmedserviceapp.Extensions;
using ipsmedserviceapp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            ResponseOfRequest<object> responseOfRequest;
            try
            {
                string query = $"select * from ProcessManagement where processId = 1";

                DataTable data = null;
                using (var sqlConnection = (SqlConnection)_dbContext.Database.GetDbConnection())
                {
                    await Task.Factory.StartNew(() => data = ExecuteQuery.GetDataFromSqlServer(sqlConnection, query));
                }

                var a = new
                {
                    Status = data.Rows[0].ItemArray[0],
                    DateStop = data.Rows[0].ItemArray[0],
                    DateStopAuto = data.Rows[0].ItemArray[0],
                };

                responseOfRequest = new ResponseOfRequest<object>(new object());

                return Ok(responseOfRequest);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());

                responseOfRequest = new ResponseOfRequest<object>(e);
                return Ok(responseOfRequest);
            }
        }

        [HttpGet("RunPayment")]
        public async Task<IActionResult> RunPayment()
        {
            ResponseOfRequest<object> responseOfRequest;
            try
            {
                var posibleResponse = CheckAuthToken();
                if (posibleResponse != null)
                    return Ok(posibleResponse);


                responseOfRequest = new ResponseOfRequest<object>(new object());
                
                return Ok(responseOfRequest);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());

                responseOfRequest = new ResponseOfRequest<object>(e);
                return Ok(responseOfRequest);
            }
        }

        [HttpGet("StopPayment")]
        public async Task<IActionResult> StopPayment()
        {
            ResponseOfRequest<object> responseOfRequest;
            try
            {
                var posibleResponse = CheckAuthToken();
                if (posibleResponse != null)
                    return Ok(posibleResponse);


                responseOfRequest = new ResponseOfRequest<object>(new object());

                return Ok(responseOfRequest);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());

                responseOfRequest = new ResponseOfRequest<object>(e);
                return Ok(responseOfRequest);
            }
        }


        [HttpGet("RunFinalPayment")]
        public async Task<IActionResult> RunFinalPayment()
        {
            ResponseOfRequest<object> responseOfRequest;
            try
            {
                var posibleResponse = CheckAuthToken();
                if (posibleResponse != null)
                    return Ok(posibleResponse);
                
                responseOfRequest = new ResponseOfRequest<object>(new object());

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
            bool isAuth = Request.Headers.ContainsKey("Authorization");

            if (!isAuth || Request.Headers["Authorization"] != "ff_zxcvbnm951")
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