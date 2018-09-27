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

            return Ok(fixation);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Fixation newFixation)
        {
            if (newFixation == null)
                BadRequest();

            var fixation = _mapper.Map<Fixation, Fixation>(newFixation);

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

        private async Task<Fixation> GetFixationById(int fixId, bool includeRelated = false )
        {
            if (!includeRelated)
            {
                return await _dbContext.Fixation
                    .FirstOrDefaultAsync(f => f.FixId == fixId);
            }

            return await _dbContext.Fixation
                .Include(f => f.FixStorageDevice)
                .Include(f => f.FixFile)
                .FirstOrDefaultAsync(f => f.FixId == fixId);
        }
    }
}
