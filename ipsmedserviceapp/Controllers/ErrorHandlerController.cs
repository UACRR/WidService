using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ipsmedserviceapp.Model;
using IpsCommonTypes.Types;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using static ipsmedserviceapp.Utilities.ServerOrDBErrorHandler;

namespace ipsmedserviceapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorHandlerController : ControllerBase
    {
        private readonly MediaServiceContext _dbContext;
        public ErrorHandlerController(MediaServiceContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("error/apiconnector")]
        public async void CreateApiConnectorErrorLog([FromBody] ResponseError responseError)
        {
            if (responseError == null)
                return;

            try
            {
                // save to db new error log
            }
            catch (Exception e)
            {
                var requestError = new RequestError
                {
                    CallMethodName = nameof(CreateApiConnectorErrorLog),
                    ControllerName = nameof(ErrorHandlerController),
                    ObjectName = string.Empty,
                    ExceptionName = e.GetType().Name,
                    ExceptionString = e.ToString(),
                    SystemTypeName = nameof(ResponseError),
                };
                _dbContext.CreateControllerErrorLog(requestError);
            }
        }
    }
}