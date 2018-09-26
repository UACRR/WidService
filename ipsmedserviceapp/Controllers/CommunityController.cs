using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ipsmedserviceapp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.IdentityModel.Protocols;

// URLs:
// community/
namespace ipsmedserviceapp.Controllers
{
    [Produces("application/json")]
    [Route("api/community")]
    public class CommunityController : Controller
    {
        private MediaServiceContext _dbContext;
        private IConfiguration _config;
        public CommunityController(MediaServiceContext dbContext, IConfiguration config)
        {
            _dbContext = dbContext;
            _config = config;
        }

        // списк view
        private readonly Dictionary<string, string> _communityViewList = new Dictionary<string, string>
        {
            // список спільнот
            {"vTsk_1_ListCommunity", "vTsk_1_ListCommunity"},

        };

        [HttpGet("listall")]
        public async Task<IActionResult> GetCommunityList([FromQuery] string viewName, [FromQuery] int? custId)
        {
            if (viewName == null || !_communityViewList.Keys.Contains(viewName))
                return BadRequest();

            string QueryStr = string.Concat("select * from ", _communityViewList[viewName]);
            // Немає параметру по Споживачу
            if (custId == null)
            {
                var list = await _dbContext.getViewData(QueryStr, null);
                return Json(list);
            }
            else
            {
                QueryStr = string.Concat(QueryStr, " where custId = @custId");
                var list = await _dbContext.getViewData(QueryStr, new[] { new SqlParameter("@custId", custId) });
                return Json(list);

            }
        }
    }
}