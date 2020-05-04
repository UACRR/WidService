using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IpsCommonTypes.ClassesForSearchQuery;
using ipsmedserviceapp.Extensions;
using ipsmedserviceapp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ipsmedserviceapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientBigRightController : ControllerBase
    {
        private readonly MediaServiceContext _dbContext;
        private readonly ILogger<ClientSmallRightController> _logger;

        public ClientBigRightController(MediaServiceContext dbContext, ILogger<ClientSmallRightController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        [HttpPost("list")]
        public async Task<IActionResult> GetClientSRList([FromBody] SearchModuleResource resource)
        {
            string query = "select t0.* from vtsk_1_MasterListBR_wpf t0";
            List<FrameParam> frameParam = await _dbContext.FrameParam.Where(rec => rec.FrameCode == 4).ToListAsync();
            var result = await _dbContext.Database.GetItemsListAsync(query, frameParam, resource);
            return Ok(result);
        }
    }
}