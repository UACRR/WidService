using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using IpsCommonTypes.ClassesForSearchQuery;
using IpsCommonTypes.Types;
using ipsmedserviceapp.Extensions;
using ipsmedserviceapp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ipsmedserviceapp.Controllers
{
    [Produces("application/json")]
    [Route("api/Register")]
    public class RegisterController : Controller
    {
        private readonly MediaServiceContext _dbContext;

        public RegisterController(MediaServiceContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// ведомость
        /// </summary>
        /// <returns></returns>
        //[HttpGet("view/list_0401")]
        public async Task<IActionResult> GetList()
        {
            var list = await _dbContext.getViewData("select * from vtsk_3_R_04 where rgStatus <> 0", null);
            return Json(list);
        }

        /// <summary>
        /// Список звітів малих прав
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        [HttpPost("list/sr")]
        public async Task<IActionResult> GetSRReportsList([FromBody] SearchModuleResource resource)
        { 
            string query = "select t0.* from vtsk_3_R_04_wpf t0";
            List<FrameParam> frameParam = await _dbContext.FrameParam.Where(rec => rec.FrameCode == 6).ToListAsync();
            var result = await _dbContext.Database.GetItemsListAsync(query, frameParam, resource);
            return Ok(result);
        }

        /// <summary>
        /// Список звітів онлайн ресурси
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        [HttpPost("list/online")]
        public async Task<IActionResult> GetOnlineReportsList([FromBody] SearchModuleResource resource)
        {
            string query = "select t0.* from vtsk_3_R_04_ccid_wpf t0";
            List<FrameParam> frameParam = await _dbContext.FrameParam.Where(rec => rec.FrameCode == 8).ToListAsync();
            var result = await _dbContext.Database.GetItemsListAsync(query, frameParam, resource);
            return Ok(result);
        }

        /// <summary>
        /// Список звітів
        /// </summary>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpGet("filter")]
        public async Task<IActionResult> GetListByFilter([FromQuery] DateTime? beginDate, [FromQuery] DateTime? endDate, [FromQuery] int? status)
        {
            var list = await _dbContext.getViewData($"select * from ft_tsk_3_R_04(@beginDate, @endDate, @status)", new[] {
                new SqlParameter("beginDate", beginDate),
                new SqlParameter("endDate", endDate),
                new SqlParameter("status", status),
            });

            return Json(list);
        }

        /// <summary>
        /// Список звітів CCID
        /// </summary>
        /// <param name="beginDate"></param>
        /// <param name="endDate"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpGet("ccid/filter")]
        public async Task<IActionResult> GetExternalListByFilter([FromQuery] DateTime? beginDate, [FromQuery] DateTime? endDate, [FromQuery] int? status)
        {
            string query = $"select * from ft_tsk_3_R_04_ccid(@beginDate, @endDate, @status) ";

            var list = await _dbContext.getViewData(query, new[] {
                new SqlParameter("beginDate", beginDate),
                new SqlParameter("endDate", endDate),
                new SqlParameter("status", status),
            });

            return Json(list);
        }

        /// <summary>
        /// Отримати дані звіту CCID
        /// </summary>
        /// <param name="regId"></param>
        /// <returns></returns>
        [HttpGet("ccid/{regId}")]
        public async Task<IActionResult> GetRegisterCCID(int regId)
        {
            var register = await _dbContext.Register
                .Include(r => r.Rm)
                .ThenInclude(rl => rl.Period)
                .ThenInclude(p => p.Lic)
                .FirstOrDefaultAsync(r => r.RegId == regId);

            // invert return (JSON ignore)
            return Ok(register.Rm.Period.Lic);
        }

        /// <summary>
        /// Отримати вміст звіту CCID по ID
        /// </summary>
        /// <param name="regId"></param>
        /// <returns></returns>
        [HttpGet("ccid/items/{regId}")]
        public IActionResult GetRegisterItemsCCID(int regId)
        {
            try
            {
                string query = $"select * from ft_Tsk_3_Report_CCID ({regId})";
                DataTable table;
                using (SqlConnection sqlConnection = (SqlConnection)_dbContext.Database.GetDbConnection())
                {
                    sqlConnection.Open();

                    using (SqlCommand sqlCommand = new SqlCommand(query, sqlConnection))
                    {
                        sqlCommand.CommandTimeout = 300;

                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);

                        DataSet dataSet = new DataSet();
                        sqlDataAdapter.Fill(dataSet);

                        table = dataSet.Tables[0];
                    }
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
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Запустити процедуру синхронізації
        /// </summary>
        /// <param name="regId"></param>
        /// <returns></returns>
        [HttpGet("ccid/sync/{regId}")]
        public async Task<IActionResult> ExecuteSyncProcedure(int regId)
        {
            ResponseOfRequest response;
            try
            {
                //>>> OlegM:NewWid
                //string query = $"exec @retCode = pTsk10_LoadWICRegister @regId";
                string query = $"exec @retCode = spWidLoadRegister @regId";
                //<<< OlegM:NewWid

                var param = new SqlParameter("regId", regId);
                var returnedCode = new SqlParameter
                {
                    ParameterName = "@retCode", 
                    SqlDbType = SqlDbType.Int, 
                    Direction = ParameterDirection.Output
                };

                _dbContext.Database.SetCommandTimeout(600);
                var result = await _dbContext.Database.ExecuteSqlCommandAsync(query, param, returnedCode);
                if ((int)returnedCode.Value == 1)
                {
                    response = new ResponseOfRequest
                    {
                        Message = "Процедура синхронізації повернула помилку! \nКод: 1",
                        IsSuccess = false,
                    };

                    return BadRequest(response);
                }

                _dbContext.Database.SetCommandTimeout(30);
                response = new ResponseOfRequest("Процедуру синхронізації виконано!");
                return Ok(response);
            }
            catch (Exception e)
            {
                response = new ResponseOfRequest($"Неможливо виконати синхронізацію! {e.Message}", e);
                return BadRequest(response);
            }
        }

        /// <summary>
        /// Запустити процедуру розподілу
        /// </summary>
        /// <param name="regId"></param>
        /// <returns></returns>
        [HttpGet("ccid/distribution/{regId}")]
        public async Task<IActionResult> ExecuteDistributionProcedure(int regId)
        {
            ResponseOfRequest response;
            try
            {
                //>>> OlegM:NewWid
                //string query = $"exec @retCode = p_CreateDistribution_DDEX @regId";
                string query = $"exec @retCode = spCreateDistributionDdex @regId";
                //<<< OlegM:NewWid
                var param = new SqlParameter("regId", regId);
                var returnedCode = new SqlParameter
                {
                    ParameterName = "@retCode",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };

                _dbContext.Database.SetCommandTimeout(600);
                var result = await _dbContext.Database.ExecuteSqlCommandAsync(query, param, returnedCode);
                if ((int)returnedCode.Value == 1)
                {
                    response = new ResponseOfRequest
                    {
                        Message = "Процедура розподілу повернула помилку! \nКод: 1",
                        IsSuccess = false,
                    };

                    return BadRequest(response);
                }

                _dbContext.Database.SetCommandTimeout(30);
                response = new ResponseOfRequest("Процедуру розподілу виконано!");
                return Ok(response);
            }
            catch (Exception e)
            {
                response = new ResponseOfRequest("Неможливо виконати розподіл!", e);
                return BadRequest(response);
            }
        }

        /// <summary>
        /// Запустити процедуру оплати
        /// </summary>
        /// <param name="regId"></param>
        /// <returns></returns>
        [HttpGet("ccid/payment/{regId}")]
        public async Task<IActionResult> ExecutePaymentProcedure(int regId)
        {
            ResponseOfRequest response;
            try
            {
                string query = "exec @retCode = MPPay_#DDEX @regId";
                var returnedCode = new SqlParameter
                {
                    ParameterName = "@retCode",
                    SqlDbType = SqlDbType.Int,
                    Direction = ParameterDirection.Output
                };

                var param = new SqlParameter("regId", regId);

                _dbContext.Database.SetCommandTimeout(600);
                var result = await _dbContext.Database.ExecuteSqlCommandAsync(query, param, returnedCode);
                if ((int)returnedCode.Value == 1)
                {
                    response = new ResponseOfRequest
                    {
                        Message = "Процедура оплати повернула помилку! \nКод: 1",
                        IsSuccess = false,
                    };

                    return BadRequest(response);
                }

                _dbContext.Database.SetCommandTimeout(30);
                response = new ResponseOfRequest("Процедуру оплати виконано!");
                return Ok(response);
            }
            catch (Exception e)
            {
                response = new ResponseOfRequest("Неможливо виконати оплату!", e);
                return BadRequest(response);
            }
        }

        [HttpGet("{regId}")]
        public async Task<IActionResult> GetById(int? regId)
        {
            if (regId == null)
                BadRequest();

            var register = await GetAgreementByRegisterId((int)regId);

            if (register == null)
                NotFound();

            return Json(register);
        }

        [HttpPut("{regId}")]
        public async Task<IActionResult> Update(int? regId, [FromBody] Register register)
        {
            if (regId == null)
                BadRequest();

            var foundedRegister = await GetRegisterById((int)regId);
            var oldStatus = foundedRegister.RgStatus;

            if (foundedRegister == null)
                NotFound();

            UpdateRegister(foundedRegister, register);

            await _dbContext.SaveChangesAsync();
            if (oldStatus != 3 && foundedRegister.RgStatus == 3) // До розподілу
                await _dbContext.Database.ExecuteSqlCommandAsync("exec p_Tsk3_AddAltName @regId", new SqlParameter("@regId", (int)regId));
            return Ok();

        }

        private void UpdateRegister(Register destRegister, Register sourceRegister)
        {
            var excludeFields = new string[] { "RegId" };

            destRegister.SetFields(sourceRegister, excludeFields);

            var excludeFieldRegisterItem = new string[] { "Obj" };
            _dbContext.UpdateList(sourceRegister.RegisterItem, destRegister.RegisterItem, r => { }, (l, r) => l.RegId == r.RegId && l.RegIitemId == r.RegIitemId, excludeFieldRegisterItem);
        }

        /// <summary>
        /// Ведомость история
        /// </summary>
        /// <returns></returns>
        [HttpGet("view/list_0403")]
        public async Task<IActionResult> vtsk_3_R_06()
        {
            var list = await _dbContext.getViewData("select * from vtsk_3_R_06", null);
            return Json(list);
        }

        private async Task<LicenseAgreement> GetAgreementByRegisterId(int regId)
        {
            var register = await _dbContext.Register
                .Include(r => r.RegisterItem)
                    .ThenInclude(i => i.Obj)
                        .ThenInclude(o => o.MediaTrack)
                 .Include(r => r.RegisterItem)
                    .ThenInclude(i => i.RegisterExtra)
                .Include(r => r.Rm)
                    .ThenInclude(rl => rl.Period)
                        .ThenInclude(p => p.Lic)
                .FirstOrDefaultAsync(r => r.RegId == regId);

            return register.Rm.Period.Lic;
        }

        private async Task<Register> GetRegisterById(int regId)
        {
            var register = await _dbContext.Register
                .Include(r => r.RegisterItem)
                    .ThenInclude(i => i.Obj)
                        .ThenInclude(o => o.MediaTrack)
                 .Include(r => r.RegisterItem)
                    .ThenInclude(i => i.RegisterExtra)
                .FirstOrDefaultAsync(r => r.RegId == regId);

            return register;
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchObjectRights([FromQuery] string name, [FromQuery] string authtors, [FromQuery] string performers)
        {

            var list = await _dbContext.getViewData("select * from [dbo].[ft_tsk_3_SearchObj](@name, @authtors, @performers )",
                new[] { new SqlParameter("@name", !string.IsNullOrEmpty(name) ? (object)name : DBNull.Value ),
                        new SqlParameter("@authtors", !string.IsNullOrEmpty(name) ? (object)authtors : DBNull.Value ),
                        new SqlParameter("@performers", !string.IsNullOrEmpty(name) ? (object)performers : DBNull.Value ) }
                );

            return Json(list);
        }

        [HttpPut("setstatus/{regId}")]
        public async Task<IActionResult> SetStatus(int regId, [FromBody] int newStatus)
        {
            var register = await _dbContext.Register.FirstOrDefaultAsync(r => r.RegId == regId);

            if (register == null)
                return NotFound();

            List<int> allowedStatuses = new List<int>();

            if (register.RgStatus == 0)
                allowedStatuses.AddRange(new[] { 1, 5 });
            else if (register.RgStatus == 1)
                allowedStatuses.AddRange(new[] { 2, 5 });
            else if (register.RgStatus == 2)
                allowedStatuses.AddRange(new[] { 3 });
            else
                allowedStatuses.AddRange(new int[0]);

            if (allowedStatuses.Contains(newStatus))
            {
                register.RgStatus = newStatus;
                await _dbContext.SaveChangesAsync();

            }
            else
            {
                return StatusCode(StatusCodes.Status406NotAcceptable);
            }

            return Ok();
        }

        [HttpGet("{regId}/autolinkedobjects")]
        public async Task<IActionResult> GetAutoLinkedObjects(int regId)
        {
            var currentTimeOut = _dbContext.Database.GetCommandTimeout();
            try
            {
                _dbContext.Database.SetCommandTimeout(600);
                var list = await _dbContext.getViewData($"select * from ft_Tsk_3_AutoLink( @regId )", new[] {
                new SqlParameter("regId", regId),
                });

                return Ok(list);
            }
            finally
            {
                if (currentTimeOut.HasValue)
                    _dbContext.Database.SetCommandTimeout(currentTimeOut);
            }
        }
    }
}