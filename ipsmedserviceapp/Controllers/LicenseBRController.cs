using ipsmedserviceapp.Controllers.Resources;
using ipsmedserviceapp.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using IpsCommonTypes.ClassesForSearchQuery;
using ipsmedserviceapp.Extensions;
using Microsoft.EntityFrameworkCore;

namespace ipsmedserviceapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LicenseBRController : Controller
    {
        private readonly MediaServiceContext _dbContext;

        public LicenseBRController(MediaServiceContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost("list")]
        public async Task<IActionResult> GetLicenseBRList([FromBody] SearchModuleResource resource)
        {
            string query = "select t0.* from vTsk_1_BRAllDocs t0";
            List<FrameParam> frameParam = await _dbContext.FrameParam.Where(rec => rec.FrameCode == 7).ToListAsync();
            var result = await _dbContext.Database.GetItemsListAsync(query, frameParam, resource);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetLicenseAgreements([FromQuery] LicenseAgreementListResource query)
        {
            var queryText = "select * from vTsk_1_BRAllDocs";

            var conditions = new Collection<string>();
            if (query != null)
            {
                if (query.States.Any())
                {
                    conditions.Add($"licType in ({string.Join(", ", query.States)})");
                }
                if (query.Status.HasValue)
                {
                    conditions.Add($"licStatus = {query.Status.Value}");
                }

                if (conditions.Any())
                {
                    queryText = queryText + " where " + string.Join(" and ", conditions);
                }
            }

            var list = await _dbContext.getViewData(queryText, null);
            return Ok(list);
        }
    }
}
