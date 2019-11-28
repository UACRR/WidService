using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using IpsCommonTypes.IntermediaryTypes;
using IpsCommonTypes.Types;
using ipsmedserviceapp.Controllers.Resources;
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

        /// <summary>
        /// Отримати список ліцензій для перегляду звітів
        /// </summary>
        /// <param name="custId"></param>
        /// <returns></returns>
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
        /// Створити період платежів
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        [HttpPost("paidperiod/create")]
        public async Task<IActionResult> CreatePaidPeriod(PaidPeriod source)
        {
            ResponseOfRequest response;
            try
            {
                var target = new PaidPeriod
                {
                    Status = 1,
                };
                target.SetFields(source, new []{ "PeriodId", "Status" });

                await _dbContext.PaidPeriod.AddAsync(target);
                await _dbContext.SaveChangesAsync();

                response = new ResponseOfRequest("Період створено!");
                return Ok(response);
            }
            catch (Exception e)
            {
                response = new ResponseOfRequest("Неможливо створити період!", e);
                return BadRequest(response);
            }
        }

        /// <summary>
        /// Видалити період
        /// </summary>
        /// <param name="paidPeriodId"></param>
        /// <returns></returns>
        [HttpDelete("paidperiod/delete/{paidPeriodId}")]
        public async Task<IActionResult> DeletePaidPeriod(int paidPeriodId)
        {
            ResponseOfRequest response;
            IDbContextTransaction transaction = null;
            try
            {
                var target = await _dbContext.PaidPeriod.SingleOrDefaultAsync(rec => rec.PeriodId == paidPeriodId);

                var registerExist = _dbContext.Register.Any(rec => rec.PeriodId == target.PeriodId);
                if (registerExist)
                {
                    response = new ResponseOfRequest
                    {
                        Message = "Неможливо видалити період до якого вже додано звіти!",
                        IsSuccess = false,
                    };
                    return BadRequest(response);
                }

                var registerRatedList = await _dbContext.RegisterRatedList.SingleOrDefaultAsync(rec => rec.PeriodId == target.PeriodId);

                _dbContext.RegisterRatedList.Remove(registerRatedList);
                _dbContext.PaidPeriod.Remove(target);

                transaction = _dbContext.Database.BeginTransaction();
                await _dbContext.SaveChangesAsync();
                transaction.Commit();

                response = new ResponseOfRequest("Період видалено!");
                return Ok(response);
            }
            catch (Exception e)
            {
                transaction?.Rollback();
                response = new ResponseOfRequest("Неможливо видалити період!", e);
                return BadRequest(response);
            }
            finally
            {
                transaction?.Dispose();
            }
        }

        /// <summary>
        /// Створити розрахунковий лист
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        [HttpPost("rrl/create")]
        public async Task<IActionResult> CreateRegiterRatedList([FromBody] RegisterRatedList source)
        {
            ResponseOfRequest response;
            try
            {
                var target = new RegisterRatedList
                {
                    CreateDate = DateTime.Now
                };
                target.SetFields(source, new[] {"RmId", "CreateDate"});

                await _dbContext.RegisterRatedList.AddAsync(target);
                await _dbContext.SaveChangesAsync();

                response = new ResponseOfRequest("Розрахунковий лист створено!");
                return Ok(response);
            }
            catch (Exception e)
            {
                response = new ResponseOfRequest("Неможливо створити розрахунковий лист!", e);
                return BadRequest(response);
            }
        }

        /// <summary>
        /// Оновити дані розрахункового листа
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        [HttpPut("rrl/update")]
        public async Task<IActionResult> UpdateRegiterRatedList([FromBody] RegisterRatedList source)
        {
            ResponseOfRequest response;
            try
            {
                var target = await _dbContext.RegisterRatedList.SingleOrDefaultAsync(rec => rec.RmId == source.RmId);

                target.SetFields(source, new[] {"RmId", "CreateDate", "UserId"});

                await _dbContext.SaveChangesAsync();

                response = new ResponseOfRequest("Розрахунковий лист оновлено!");
                return Ok(response);
            }
            catch (Exception e)
            {
                response = new ResponseOfRequest("Неможливо оновити розрахунковий лист!", e);
                return BadRequest(response);
            }
        }

        /// <summary>
        /// Створити новий звіт
        /// </summary>
        /// <param name="objcetSource"></param>
        /// <returns></returns>
        [HttpPost("register/create")]
        public async Task<IActionResult> CreateRegister([FromBody] NewRegisterWrapResource objcetSource)
        {
            ResponseOfRequest response;
            try
            {
                Register source = objcetSource.Register;
                source.Rm = objcetSource.RegisterRatedList;

                var targetRegister = new Register
                {
                    CreateDate = DateTime.Now,
                };
                targetRegister.SetFields(source, new[] { "RegId", "CreateDate" });

                int i = 1;
                foreach (var item in source.RegisterItem)
                {
                    var registerItem = new RegisterItem
                    {
                        RegIitemId = i++,
                    };
                    registerItem.SetFields(item, new []{ "RegId", "RegIitemId" });
                    targetRegister.RegisterItem.Add(registerItem);
                }
                targetRegister.CountRows = targetRegister.RegisterItem.Count;


                RegisterRatedList targetRll = null;
                if (source.Rm != null && source.Rm.RmId == 0)
                {
                    targetRll = new RegisterRatedList
                    {
                        CreateDate = DateTime.Now,
                    };
                    targetRll.SetFields(source.Rm, new[] { "RmId", "CreateDate" });

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
                    Message = "Неможливо зберегти звіт!",
                };
                return Ok(response);
            }
        }

        /// <summary>
        /// Оновити дані звіту
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        [HttpPut("register/update")]
        public async Task<IActionResult> UpdateRegister([FromBody] Register source)
        {
            ResponseOfRequest response;
            IDbContextTransaction transaction = null;
            try
            {
                var targetRegister = await _dbContext.Register
                    .Include(item => item.RegisterItem)
                    .ThenInclude(item => item.RegisterExtra)
                    .SingleOrDefaultAsync(rec => rec.RegId == source.RegId);

                targetRegister.SetFields(source, new[] { "RegId", "PeriodId", "RmId", "LicId", "CreateDate", "UserId" });
                
                // початковий ідентифікатор для нових записів
                int regItemId = 1;
                if (targetRegister.RegisterItem.Any())
                    regItemId += targetRegister.RegisterItem.Max(rec => rec.RegIitemId);

                _dbContext.ChangeTracker.AutoDetectChangesEnabled = false;

                if (source.RegisterItem.Count > 0)
                {
                    _dbContext.UpdateListExtra(source.RegisterItem, targetRegister.RegisterItem,
                        (isNew, sourceItem, targetItem) =>
                        {
                            targetItem.SetFields(sourceItem);

                            if (targetItem.DurationItem == null)
                            {
                                targetItem.DurationItem = TimeSpan.FromTicks(TimeSpan.TicksPerMillisecond);
                                targetItem.Ticks = 1;
                            }

                            if (targetItem.Ticks == 0)
                            {
                                if (targetRegister.AlgorithmId == 1)
                                    targetItem.Ticks = Math.Max(1, (int)(((TimeSpan)targetItem.DurationItem).Ticks * Math.Max((targetItem.CountUse ?? 0), 1) / TimeSpan.TicksPerMillisecond));
                                else
                                    targetItem.Ticks = 1;
                            }
                            
                            if (isNew)
                                targetItem.RegIitemId = regItemId++;

                            _dbContext.UpdateList(sourceItem.RegisterExtra, targetItem.RegisterExtra, i => { }, (l, r) => l.RegExtraId == r.RegExtraId);
                        }, (l, r) => l.RegId == r.RegId && l.RegIitemId == r.RegIitemId);
                }

                _dbContext.ChangeTracker.AutoDetectChangesEnabled = true;

                targetRegister.CountRows = targetRegister.RegisterItem.Count;
                
                if (targetRegister.AlgorithmId == 1)
                {
                    var sumTicks = targetRegister.RegisterItem.Sum(rec => (long)(rec.Ticks));
                    targetRegister.Durationticks = (int)sumTicks;
                }
                else
                {
                    targetRegister.Durationticks = targetRegister.RegisterItem.Count(rec => rec.Ticks != 0);
                }


                transaction = _dbContext.Database.BeginTransaction();
                await _dbContext.SaveChangesAsync();
                transaction.Commit();

                response = new ResponseOfRequest("Дані звіту оновлено");
                return Ok(response);
            }
            catch (Exception e)
            {
                transaction?.Rollback();
                response = new ResponseOfRequest("Неможливо оновити дані звіту!", e);
                return BadRequest(response);
            }
            finally
            {
                transaction?.Dispose();
            }
        }

        /// <summary>
        /// Видалити звіт
        /// </summary>
        /// <param name="regId"></param>
        /// <returns></returns>
        [HttpDelete("register/delete/{regId}")]
        public async Task<IActionResult> DeleteRegister(int regId)
        {
            ResponseOfRequest response;
            IDbContextTransaction transaction = null;
            try
            {
                var targetRegister = await _dbContext.Register.SingleOrDefaultAsync(rec => rec.RegId == regId);
                var targetRegisterItem = await _dbContext.RegisterItem.Where(rec => rec.RegId == regId).ToListAsync();

                if (targetRegister == null)
                {
                    response = new ResponseOfRequest
                    {
                        Message = "Звіт не знайдено!"
                    };
                    return NotFound(response);
                }

                _dbContext.RegisterItem.RemoveRange(targetRegisterItem);
                _dbContext.Register.Remove(targetRegister);

                transaction = _dbContext.Database.BeginTransaction();
                await _dbContext.SaveChangesAsync();
                transaction.Commit();

                response = new ResponseOfRequest("Звіт видалено!");
                return Ok(response);
            }
            catch (Exception e)
            {
                transaction?.Rollback();
                response = new ResponseOfRequest("Неможливо видалити звіт!", e);
                return BadRequest(response);
            }
            finally
            {
                transaction?.Dispose();
            }
        }

        /// <summary>
        /// Отримати вміст звіту CCID типу
        /// </summary>
        /// <param name="registerId"></param>
        /// <returns></returns>
        [HttpGet("register/ccid/getitems/{registerId}")]
        public IActionResult GetCCIDRegisterItems(int registerId)
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
        /// Отримати вміст звіту стандартного типу
        /// </summary>
        /// <param name="registerId"></param>
        /// <returns></returns>
        [HttpGet("register/getitems/{registerId}")]
        public async Task<IActionResult> GetDefaultRegisterItems(int registerId)
        {
            var items = await _dbContext.RegisterItem
                .Where(rec => rec.RegId == registerId)
                .Include(item => item.RegisterExtra)
                .ToListAsync();

            return Ok(items);
        }

        /// <summary>
        /// Змінити статус звіту "на погодженні"
        /// </summary>
        /// <param name="registerId"></param>
        /// <returns></returns>
        [HttpPut("register/accept/{registerId}")]
        public async Task<IActionResult> AcceptRegister(int registerId)
        {
            ResponseOfRequest response;
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

                response = new ResponseOfRequest("Звіт відправлено на погодження!");
                return Ok(response);
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                response = new ResponseOfRequest("Неможливо відправити звіт на погодження!", ex);
                return BadRequest(response);
            }
            finally
            {
                transaction?.Dispose();
            }
        }

        /// <summary>
        /// Зафіксувати перелік звітів
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        [HttpPut("register/fixate")]
        public async Task<IActionResult> FixateRegistersList([FromBody]RegisterRatedList source)
        {
            IDbContextTransaction transaction = null;
            ResponseOfRequest response;
            try
            {
                var targetRegisterRatedList = await _dbContext.RegisterRatedList.SingleOrDefaultAsync(rec => rec.RmId == source.RmId);
                
                // RegisterListStatus
                // 1	Погоджений
                targetRegisterRatedList.Status = 1;

                var targetPaidPeriod = await _dbContext.PaidPeriod.SingleOrDefaultAsync(rec => rec.PeriodId == targetRegisterRatedList.PeriodId);

                // PeriodStatus
                // 2	Прийом коштів
                targetPaidPeriod.Status = 2;

                transaction = await _dbContext.Database.BeginTransactionAsync();
                await _dbContext.SaveChangesAsync();
                transaction.Commit();

                response = new ResponseOfRequest("Перелік звітів зафіксовано!");
                return Ok(response);
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                response = new ResponseOfRequest("Неможливо зафіксувати перелік звітів!", ex);
                return BadRequest(response);
            }
            finally
            {
                transaction?.Dispose();
            }
        }

        /// <summary>
        /// Отримати дані по курсу звіту
        /// </summary>
        /// <param name="regId"></param>
        /// <returns></returns>
        [HttpGet("register/ccid/currency/data/{regId}")]
        public IActionResult GetCCIDRegisterCurrencyData(int regId)
        {
            try
            {
                string query = "select t1.regId, t1.regRoyalty, " +
                               "t2.amountCur, t2.ExchangeRate, t2.r030 " +
                               "from Register t1 " +
                               "left join RegisterCCID t2 on t2.regId = t1.regId " +
                               $"where t1.regId = {regId}";

                var list = GetDataSetByQuery(query);
                
                var item = list.FirstOrDefault();
                if (item == null)
                    return Ok();

                var data = new RegisterCCIDCurrencyData
                {
                    RegId = (int)item[0],
                    RegRoyalty = item[1] as decimal?,
                    AmountCur = item[2] as decimal?,
                    ExchangeRate = item[3] as decimal?,
                    R030 = item[4] as string,
                };

                return Ok(data);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }

        /// <summary>
        /// Змінити курс звіту
        /// </summary>
        /// <param name="currencyData"></param>
        /// <returns></returns>
        [HttpPut("register/ccid/currency/change")]
        public async Task<IActionResult> ChangeCurrency([FromBody] RegisterCCIDCurrencyData currencyData)
        {
            IDbContextTransaction transaction = null;
            ResponseOfRequest response;
            try
            {
                // записати дані в таблиці
                var targetRegister = await _dbContext.Register.SingleOrDefaultAsync(rec => rec.RegId == currencyData.RegId);
                var targetRegisterCCID = await _dbContext.RegisterCcid.SingleOrDefaultAsync(rec => rec.RegId == currencyData.RegId);

                targetRegister.RegRoyalty = currencyData.RegRoyalty;
                targetRegisterCCID.ExchangeRate = currencyData.ExchangeRate;
                targetRegisterCCID.R030 = currencyData.R030;

                transaction = _dbContext.Database.BeginTransaction();
                _dbContext.SaveChanges();
                transaction.Commit();

                await Task.Delay(15000);

                // запустити процедуру конвертації
                string exec = "exec p_CreateDistribution_DDEX_valuation1 @registerId";
                var parameter = new SqlParameter("registerId", currencyData.RegId);

                var result = await _dbContext.Database.ExecuteSqlCommandAsync(exec, parameter);
                if (result != 0)
                {
                    response = new ResponseOfRequest
                    {
                        Message = "Курс звіту змінено! Процедура конвертації НЕ виконана!",
                        IsSuccess = false,
                    };
                    return BadRequest(response);
                }

                // Курс змінено!
                response = new ResponseOfRequest("Курс звіту змінено! Процедура конвертації виконана успішно!");
                return Ok(response);
            }
            catch (Exception e)
            {
                transaction?.Rollback();
                response = new ResponseOfRequest("Неможливо змінити курс звіту!", e);
                return BadRequest(response);
            }
            finally
            {
                transaction?.Dispose();
            }
        }

        /// <summary>
        /// Отримати масив даних з БД
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        private List<object[]> GetDataSetByQuery(string query)
        {
            DataTable table;
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

            return list;
        }
    }
}