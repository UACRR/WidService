using AutoMapper;
using ipsmedserviceapp.Controllers.Resources;
using ipsmedserviceapp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ipsmedserviceapp.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class FixationsController : Controller
    {
        private readonly MediaServiceContext _dbContext;
        private readonly IMapper _mapper;

        public FixationsController(MediaServiceContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IActionResult> GetFixations([FromQuery] FixationQueryResource query)
        {
            var list = await _dbContext.getViewData($"select * from ft_Tsk_7_Fixations(@stage, @stageStatus)", new[] {
                new SqlParameter("stage", query.Stage),
                new SqlParameter("stageStatus", query.StageStatus),
            });
            return Ok(list);
        }

        [HttpGet("{fixId}")]
        public async Task<IActionResult> GetById(int? fixId)
        {
            if (fixId == null)
                BadRequest();

            var fixation = await GetFixationById((int)fixId, includeRelated: true);

            if (fixation == null)
                NotFound();

            var response = new FixationResponseResource();
            response.Fixation = fixation;

            if (fixation.StageStatus > 1)
            {
                var regId = fixation.Lic.PaidPeriod.First().RegisterRatedList.First().Register.First().RegId;

                response.RegisterCounts = await _dbContext.getViewData($"select * from ft_Tsk_7_RegisterRegisterCounts(@regId)", new[] {
                    new SqlParameter("regId", regId),
                });
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Fixation newFixation)
        {
            if (newFixation == null)
                BadRequest();

            var fixation = _mapper.Map<Fixation, Fixation>(newFixation);

            if (fixation.StageStatus > 1)
            {
                fixation.Lic.Agr = newFixation.Lic.Agr;
                fixation.Lic.Agr.CustId = newFixation.ClientCustId.Value;
            }

            _dbContext.Fixation.Add(fixation);
            await _dbContext.SaveChangesAsync();

            return Ok(fixation);
        }

        [HttpPut("{fixId}")]
        public async Task<IActionResult> Update(int fixId, [FromBody] Fixation updFixation)
        {
            if (updFixation == null)
                BadRequest();

            var fixation = await GetFixationById(fixId, includeRelated: true);

            if (fixation == null)
                NotFound();

            _mapper.Map(updFixation, fixation);

            if (updFixation.StageStatus > 1)
            {
                var agr = _dbContext.AgreementMaster.Find(updFixation.Lic.AgrId);
                agr.CustId = updFixation.ClientCustId.Value;
            }

            await _dbContext.SaveChangesAsync();

            return Ok(fixation);
        }

        [HttpPut("{fixId}/stagestatus")]
        public async Task<IActionResult> SetStageStatus(int fixId, [FromBody] int newStageStatus)
        {
            if (newStageStatus < 1 || newStageStatus > 22)
                BadRequest();

            var fixation = await GetFixationById(fixId);

            if (fixation == null)
                return NotFound();

            // TODO: check if status is acceptable (like as in RHController)

            fixation.StageStatus = newStageStatus;
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpGet("{fixId}/amountdistribution")]
        public async Task<IActionResult> GetAmountDistribution(int? fixId)
        {
            if (fixId == null)
                BadRequest();

            var fixation = await GetFixationById(fixId.Value);

            if (fixation == null)
                NotFound();

            var list = await _dbContext.getViewData($"select * from ft_tsk_7_FixDistr01(@licId)", new[] {
                new SqlParameter("licId", fixation.LicId),
            });

            return Ok(list);
        }

        private async Task<Fixation> GetFixationById(int fixId, bool includeRelated = false )
        {
            if (!includeRelated)
            {
                return await _dbContext.Fixation
                    .FirstOrDefaultAsync(f => f.FixId == fixId);
            }

            var fixation = await _dbContext.Fixation
                .Include(f => f.FixStorageDevice)
                .Include(f => f.FixFile)
                .Include(f => f.Lic)
                    .ThenInclude(l => l.Agr)
                .Include(f => f.Lic)
                    .ThenInclude(l => l.PaidPeriod)
                        .ThenInclude(pp => pp.RegisterRatedList)
                            .ThenInclude(rr => rr.Register)
                                .ThenInclude(r => r.RegisterItem)
                                    .ThenInclude(ri => ri.RegisterCount)
                .Include(f => f.Lic)
                    .ThenInclude(l => l.PaidPeriod)
                        .ThenInclude(pp => pp.RegisterRatedList)
                            .ThenInclude(rr => rr.Register)
                                .ThenInclude(r => r.RegisterItem)
                                    .ThenInclude(ri => ri.Obj)
                .Include(f => f.Lic)
                    .ThenInclude(l => l.PaidPeriod)
                        .ThenInclude(pp => pp.RegisterRatedList)
                            .ThenInclude(rr => rr.Register)
                                .ThenInclude(r => r.RegisterItem)
                                    .ThenInclude(ri => ri.RegisterItemFix)
                .FirstOrDefaultAsync(f => f.FixId == fixId);

            //await _dbContext.Entry(fixation.Lic).Collection(lic => lic.PaidPeriod).Query()
            //        .Include(pp => pp.RegisterRatedList).ThenInclude(rr => rr.Register).LoadAsync();

            //foreach (var period in fixation.Lic.PaidPeriod)
            //    foreach (var ratedList in period.RegisterRatedList)
            //        foreach (var reg in ratedList.Register)
            //        {
            //            await _dbContext.Entry(reg).Collection(rec => rec.RegisterItem).Query()
            //                .Include(rec => rec.RegisterCount)
            //                .Include(rec => rec.Obj)
            //                .Include(rec => rec.RegisterItemFix)
            //                .LoadAsync();
            //        }

            return fixation;
        }
    }
}
