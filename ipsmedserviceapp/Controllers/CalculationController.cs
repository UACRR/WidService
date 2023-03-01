using IpsCommonTypes.Types;
using ipsmedserviceapp.Extensions;
using ipsmedserviceapp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ipsmedserviceapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationController : ControllerBase
    {
        private readonly MediaServiceContext _dbContext;
        private readonly ILogger<CalculationController> _logger;
        private ExceptionHelper Helper { get; } = new ExceptionHelper(nameof(CalculationController));

        public CalculationController(MediaServiceContext dbContext, ILogger<CalculationController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        [HttpPost("period/changeAmount")]
        public async Task<IActionResult> SavePrepayLink([FromBody] PaidPeriod source)
        {
            try
            {
                if (source.Amount < 0)
                {
                    _logger.LogError($"{source}/n- Cума вимоги: {source.Amount}");
                    return Ok(ResponseOfRequest.NotSuccess("Cума вимоги не може бути менше 0!"));
                }

                var target = _dbContext.PaidPeriod.SingleOrDefault(rec => rec.PeriodId == source.PeriodId);
                
                if (target.Status == 7)
                {
                    return Ok(ResponseOfRequest.NotSuccess("Статус періода не дозволяє змінити суму вимоги!"));
                }

                target.Amount = source.Amount;
                await _dbContext.SaveChangesAsync();

                return Ok(ResponseOfRequest.Success());
            }
            catch (Exception e)
            {
                _logger.LogError(e, Helper.GetMessage(e, Request));
                return Ok(ResponseOfRequest.NotSuccess(e));
            }
        }

    }
}
