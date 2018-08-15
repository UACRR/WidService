using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
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
        /// ведомость акц
        /// </summary>
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

        [HttpGet("{regId}")]
        public async Task<IActionResult> GetById(int? regId)
        {
            if (regId == null)
                BadRequest();

            var register = await GetRegisterById((int)regId);

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

            if (foundedRegister == null)
                NotFound();

            UpdateRegister(foundedRegister, register);

            await _dbContext.SaveChangesAsync();

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

        private async Task<Register> GetRegisterById(int regId)
        {
            return await _dbContext.Register
                .Include(r => r.RegisterItem)
                    .ThenInclude(i => i.Obj)
                        .ThenInclude(o => o.MediaTrack)
                .FirstOrDefaultAsync(r => r.RegId == regId);
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

        [HttpPut("autosearch/{regId}")]
        public async Task<IActionResult> AutoSearch(int regId)
        {
            var rowsAffected = await _dbContext.Database.ExecuteSqlCommandAsync($"exec pTsk_3_AutoLink {@regId}");

            return Ok();
        }
    }
}