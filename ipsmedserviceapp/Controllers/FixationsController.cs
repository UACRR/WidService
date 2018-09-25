using AutoMapper;
using ipsmedserviceapp.Controllers.Resources;
using ipsmedserviceapp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

            var fixation = await GetFixationById((int)fixId);

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

            var fixation = await GetFixationById(fixId);

            if (fixation == null)
                NotFound();

            _mapper.Map(updFixation, fixation);

            await _dbContext.SaveChangesAsync();

            return Ok(fixation);
        }

        private async Task<Fixation> GetFixationById(int fixId)
        {
            var fixation = await _dbContext.Fixation
                .FirstOrDefaultAsync(f => f.FixId == fixId);

            return fixation;
        }
    }
}
