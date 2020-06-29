using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using IpsCommonTypes.SQLViews;
using IpsCommonTypes.Types;
using ipsmedserviceapp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ipsmedserviceapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationBRController : ControllerBase
    {
        private readonly MediaServiceContext _dbContext;

        public CalculationBRController(MediaServiceContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("LicenseAgreement/{custId}")]
        public async Task<IActionResult> GetLicenseAgreement(int custId)
        {
            var data = await _dbContext.LicenseAgreement
                .Include(item => item.Agr)
                .ThenInclude(item => item.AgreementAddBr)
                .Include(item => item.PaidPeriod)
                .SingleOrDefaultAsync(rec => rec.CustId == custId && rec.LicClass == 1 && rec.LicStatus == 2);

            var licenseAgrParam = await _dbContext.LicenseAgrParam
                .Include(item => item.PeriodCodeNavigation)
                .Include(item => item.LicStatusNavigation)
                .Where(rec => rec.LicId == data.LicId && rec.LicVersion == data.LicVersion).ToListAsync();

            data.LicenseAgrParam = licenseAgrParam;

            return Ok(data);
        }

        [HttpGet("MoneyReceived/{custId}")]
        public async Task<IActionResult> GetMoneyReceivedList(int custId)
        {
            var data = await _dbContext.MoneyReceived
                .Where(rec => rec.CustId == custId)
                .ToListAsync();

            var response = new ResponseOfRequest<List<MoneyReceived>>(data);
            return Ok(response);
        }

        [HttpGet("MoneyPrepay/{custId}")]
        public async Task<IActionResult> GetMoneyPrepay(int custId)
        {
            try
            {
                var sqlParam = new SqlParameter("@custId", custId);
                string query = "select * from ft_Tsk_1_BRMoneyPrepay (@custId)";
                var data = await _dbContext.FT_TSK_1_BRMoneyPrepay.FromSql(query, sqlParam).ToListAsync();
                var result = ResponseOfRequest<List<FT_TSK_1_BRMoneyPrepay>>.Success(data);
                return Ok(result);
            }
            catch (Exception e)
            {
                return Ok(ResponseOfRequest.NotSuccess(e));
            }
        }

        [HttpPost("CreatePeriod")]
        public async Task<IActionResult> CreatePeriod([FromBody] PaidPeriod paidPeriod)
        {
            IDbContextTransaction transaction = null;
            try
            {
                var target = new PaidPeriod();
                target.SetFields(paidPeriod, new []{ "PeriodId" });

                await _dbContext.PaidPeriod.AddAsync(target);

                transaction = await _dbContext.Database.BeginTransactionAsync();
                await _dbContext.SaveChangesAsync();
                transaction.Commit();

                return Ok(ResponseOfRequest.Success());
            }
            catch (Exception e)
            {
                transaction?.Rollback();
                return Ok(ResponseOfRequest.NotSuccess(e));
            }
        }
    }
}
