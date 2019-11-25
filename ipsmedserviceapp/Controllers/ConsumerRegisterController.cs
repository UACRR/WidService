using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

        [HttpGet("register/getitems/{registerId}")]
        public IActionResult GetRegisterItems(int registerId)
        {
            try
            {
                DataTable table;
                string query = "select t1.itemName, t1.performer, t1.authorMusic, t1.authorText, " +
                               "t2.amountPerfCur, t2.amountPerf, t2.amountMechCur, t2.amountMech " +
                               "from registerItem t1 " +
                               "join RegisterCCIDMW t2 on t2.regId = t1.regId and t2.regIItemId = t1.regIItemId " + 
                               $"where t1.regId = {registerId}";

                using (SqlConnection sqlConnection = (SqlConnection)_dbContext.Database.GetDbConnection())
                {
                    sqlConnection.Open();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);

                    DataSet dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet);

                    table = dataSet.Tables[0];
                }

                var list = new List<object[]>();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    var row = table.Rows[i].ItemArray;
                    list.Add(row);
                }

                return Ok(list);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }

        /// <summary>
        /// Створити новий звіт
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        [HttpPost("register/create")]
        public async Task<IActionResult> CreateRegister([FromBody] Register source)
        {
            ResponseOfRequest response;
            try
            {
                var targetRegister = new Register
                {
                    CreateDate = DateTime.Now,
                };
                targetRegister.SetFields(source, new[] { "RegId", "CreateDate" });

                foreach (var item in source.RegisterItem)
                {
                    var registerItem = new RegisterItem();
                    registerItem.SetFields(item, new []{ "RegId", "RegIitemId" });
                    targetRegister.RegisterItem.Add(registerItem);
                }

                RegisterRatedList targetRll = null;
                if (source.Rm != null && source.Rm.RmId == 0)
                {
                    targetRll = new RegisterRatedList
                    {
                        CreateDate = DateTime.Now,
                    };
                    targetRll.SetFields(source, new[] { "RmId", "CreateDate" });

                    targetRll.Register.Add(targetRegister);
                }


                if (targetRll != null)
                    await _dbContext.RegisterRatedList.AddAsync(targetRll);
                else
                    await _dbContext.Register.AddAsync(targetRegister);

                await _dbContext.SaveChangesAsync();

                response = new ResponseOfRequest("Новий звіт збережено!");

                return Ok(response);
            }
            catch (Exception e)
            {
                response = new ResponseOfRequest
                {
                    InnerMessage = e.ToString(),
                    StatusCode = e.HResult,
                    Message = "Неможливо зберегти звіт!"
                };
                return BadRequest(response);
            }
        }

        [HttpPut("register/update")]
        public async Task<IActionResult> UpdateRegister([FromBody] Register source)
        {
            return Ok();
        }

        [HttpDelete("register/delete/{regId}")]
        public async Task<IActionResult> DeleteRegister(int regId)
        {
            return Ok();
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
                    Message = "Неможливо виконати дію!"
                });
            }
        }
    }
}