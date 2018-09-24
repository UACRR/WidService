using ipsmedserviceapp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ipsmedserviceapp.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class FixationsController : Controller
    {
        private readonly MediaServiceContext _dbContext;

        public FixationsController(MediaServiceContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IActionResult> GetFixations()
        {
            var list = await _dbContext.getViewData("select * from vtsk_3_R_04 where rgStatus <> 0", null);
            return Json(list);
            //var list = await _dbContext.getViewData($"select * from ft_tsk_3_R_04(@beginDate, @endDate, @status)", new[] {
            //    new SqlParameter("beginDate", beginDate),
            //    new SqlParameter("endDate", endDate),
            //    new SqlParameter("status", status),
            //});
        }

        [HttpGet("{fixId}")]
        public async Task<IActionResult> GetById(int? fixId)
        {
            if (fixId == null)
                BadRequest();

            var register = await GetAgreementByRegisterId((int)fixId);

            if (register == null)
                NotFound();

            return Json(register);
        }

        [HttpPut("{fixId}")]
        public async Task<IActionResult> Update(int? fixId, [FromBody] Register register)
        {
            if (fixId == null)
                BadRequest();

            var foundedRegister = await GetRegisterById((int)fixId);

            if (foundedRegister == null)
                NotFound();

            UpdateRegister(foundedRegister, register);

            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        private void Update(Register destRegister, Register sourceRegister)
        {
            var excludeFields = new string[] { "RegId" };

            destRegister.SetFields(sourceRegister, excludeFields);

            var excludeFieldRegisterItem = new string[] { "Obj" };
            _dbContext.UpdateList(sourceRegister.RegisterItem, destRegister.RegisterItem, r => { }, (l, r) => l.RegId == r.RegId && l.RegIitemId == r.RegIitemId, excludeFieldRegisterItem);
        }

        private async Task<LicenseAgreement> GetAgreementByRegisterId(int regId)
        {
            var register = await _dbContext.Register
                .Include(r => r.RegisterItem)
                    .ThenInclude(i => i.Obj)
                        .ThenInclude(o => o.MediaTrack)
                 .Include(r => r.RegisterItem)
                    .ThenInclude(i => i.RegisterExtra)
                .Include(r => r.RegisterRatedList)
                    .ThenInclude(rl => rl.Period)
                        .ThenInclude(p => p.Lic)
                .FirstOrDefaultAsync(r => r.RegId == regId);

            return register.RegisterRatedList.Period.Lic;
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

        [HttpPut("{fixId}/stagestatus")]
        public async Task<IActionResult> SetStatus(int fixId, [FromBody] int newStageStatus)
        {
            var register = await _dbContext.Register.FirstOrDefaultAsync(r => r.RegId == fixId);

            if (register == null)
                return NotFound();

            List<int> allowedStatuses = new List<int>();

            //if (register.RgStatus == 0)
            //    allowedStatuses.AddRange(new[] { 1, 5 });
            //else if (register.RgStatus == 1)
            //    allowedStatuses.AddRange(new[] { 2, 5 });
            //else if (register.RgStatus == 2)
            //    allowedStatuses.AddRange(new[] { 3 });
            //else
            //    allowedStatuses.AddRange(new int[0]);

            //if (allowedStatuses.Contains(newStatus))
            //{
            //    register.RgStatus = newStatus;
            //    await _dbContext.SaveChangesAsync();
            //}
            //else
            //{
            //    return StatusCode(StatusCodes.Status406NotAcceptable);
            //}

            return Ok();
        }
    }
}
