using ipsmedserviceapp.Controllers.Resources;
using ipsmedserviceapp.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace ipsmedserviceapp.Controllers
{
    [Route("api/licenseAgreements")]
    public class LicenseController : Controller
    {
        private readonly MediaServiceContext _dbContext;

        public LicenseController(MediaServiceContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetLicenseAgreements([FromQuery] LicenseAgreementListResource query)
        {
            var queryText = "select * from vTsk_1_BRAllDocs";

            var conditions = new Collection<string>();
            if (query != null)
            {
                if (query.State.HasValue)
                {
                    conditions.Add($"licType = {query.State.Value}");
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
