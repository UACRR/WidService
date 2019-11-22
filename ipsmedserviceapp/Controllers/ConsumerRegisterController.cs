using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IpsCommonTypes.Types;
using ipsmedserviceapp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;

namespace ipsmedserviceapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsumerRegisterController : ControllerBase
    {
        private readonly MediaServiceContext _dbContext;
        private readonly ILogger<ConsumerRegisterController> _logger;
        
        public ConsumerRegisterController(MediaServiceContext dbContext, ILogger<ConsumerRegisterController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        [HttpGet("licenses/{custId}")]
        public async Task<IActionResult> GetLicenseAgreementList(int custId)
        {
            try
            {
                //string query = "select t0.* from LicenseAgreement t0 " +
                //               "join AgrLicenseType t1 on t1.codeI = t0.licCode " +
                //               "join UsesKind t2 on t2.codeI = t1.usesKind" +
                //               "where t2.usesType = 2";

                var licenseAgreementList = await _dbContext.LicenseAgreement
                    .Where(i => i.CustId == custId && i.LicType == null && i.LicStatus == 2 
                                && (i.LicCodeNavigation.UsesKindNavigation.UsesType == 2 || i.LicCodeNavigation.UsesKindNavigation.UsesType == 4))
                    .Include(item => item.PaidPeriod)
                    .ThenInclude(item => item.RegisterRatedList)
                    .ThenInclude(item => item.Register)
                    .Include(item => item.LicenseAgrParam)
                    .ToListAsync();

                // костиль
                foreach (var licenseAgreement in licenseAgreementList)
                {
                    var licenses = licenseAgreement.LicenseAgrParam
                        .Where(rec => rec.LicVersion != licenseAgreement.LicVersion)
                        .ToList();

                    foreach (var license in licenses)
                    {
                        licenseAgreement.LicenseAgrParam.Remove(license);
                    }
                }

                return Ok(licenseAgreementList);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        /// <summary>
        /// Відправити звіт на погодження
        /// </summary>
        /// <param name="registerId"></param>
        /// <returns></returns>
        [HttpPut("register/accept/{registerId}")]
        public async Task<IActionResult> SetRegisterState(int registerId)
        {
            IDbContextTransaction transaction = null;
            try
            {
                var register = await _dbContext.Register.SingleOrDefaultAsync(rec => rec.RegId == registerId);
                if (register == null)
                    return NotFound();

                // RegisterStatus
                // 1	На погодженні
                register.RgStatus = 1;

                transaction = await _dbContext.Database.BeginTransactionAsync();
                await _dbContext.SaveChangesAsync();
                transaction.Commit();
                
                return Ok();
            }
            catch (Exception ex)
            {
                transaction?.Rollback();

                return BadRequest(new ResponseOfRequest
                {
                    StatusCode = 0,
                    InnerMessage = ex.ToString(),
                    ResponseMessage = "Неможливо виконати дію!"
                });
            }
        }
    }
}