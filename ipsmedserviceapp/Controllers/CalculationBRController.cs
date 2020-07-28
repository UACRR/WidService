using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using IpsCommonTypes.DataModels;
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
                .ThenInclude(item => item.RegisterRatedList)
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

        [HttpGet("RegisterPrepayAmountList/{licId}")]
        public async Task<IActionResult> GetPrepayAmount(int licId)
        {
            try
            {
                var sqlParam = new SqlParameter("@licId", licId);
                string query = $@"select t3.custId, t3.licId, t3.periodId, sum(t1.prepayAmount) as prepayAmountSum
                                  from register t1
                                  join RegisterRatedList t2 on t1.rmId = t2.rmId
                                  join PaidPeriod t3 on t3.periodId = t2.periodId
                                  where t3.licId = @licId
                                  group by t3.custId, t3.licId, t3.periodId";

                var data = await _dbContext.QUERY_RegisterPrepayAmountSumList.FromSql(query, sqlParam).ToListAsync();
                
                var result = ResponseOfRequest<List<QUERY_RegisterPrepayAmountSum>>.Success(data);

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

        [HttpPut("ChangePrepaySum")]
        public async Task<IActionResult> ChangePrepaySumAsync([FromBody] ChangePrepaySumParams source)
        {
            IDbContextTransaction transaction = null;
            try
            {
                var target = await _dbContext.LicAuthorBr
                    .SingleAsync(rec =>
                        rec.LicId == source.LicId &&
                        rec.LicVersion == source.LicVersion &&
                        rec.CustIdRh == source.CustIdRH);

                target.PrepaySum = source.NewAmount;

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

        [HttpPost("SavePrepayLink")]
        public async Task<IActionResult> SavePrepayLink([FromBody] MoneyPrepayLink source)
        {
            IDbContextTransaction transaction = null;
            try
            {
                var target = new MoneyPrepayLink();
                target.SetFields(source, new []{ "LinkId" });
                
                await _dbContext.MoneyPrepayLink.AddAsync(target);

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

        [HttpPost("PayPrepayment/{licId}/{custId}")]
        public async Task<IActionResult> PayPrepayment(int licId, int custId)
        {
            try
            {
                string query = "exec @returnCode = MPay8_prepaymentByRH @licId, @custIdRHolder";

                var returnedCode = new SqlParameter
                {
                    ParameterName = "@returnCode",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };

                var sqlParamLicId = new SqlParameter("@licId", licId);
                var sqlParamCustId = new SqlParameter("@custIdRHolder", custId);

                _dbContext.Database.SetCommandTimeout(600);

                var result = await _dbContext.Database.ExecuteSqlCommandAsync(query, returnedCode, sqlParamLicId, sqlParamCustId);

                var responseOfRequest = new ResponseOfRequest
                {
                    IsSuccess = (int)returnedCode.Value == 0,
                    StatusCode = (int)returnedCode.Value,
                };

                return Ok(responseOfRequest);
            }
            catch (Exception e)
            {
                return Ok(ResponseOfRequest.NotSuccess(e));
            }
        }
    }
}
