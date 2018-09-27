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

        [HttpGet("list/all")]
        public async Task<IActionResult> GetCommunityList([FromQuery] string viewName, [FromQuery] int? paramId)
        {
            if (viewName == null || !_communityViewList.Keys.Contains(viewName))
                return BadRequest();

            string queryStr = string.Concat("select * from ", _communityViewList[viewName]);
            // Немає параметру по Споживачу
            if (paramId == null)
            {
                var list = await _dbContext.getViewData(queryStr, null);
                return Json(list);
            }
            else
            {
                queryStr = string.Concat(queryStr, " where custId = @custId");
                var list = await _dbContext.getViewData(queryStr, new[] { new SqlParameter("@custId", paramId) });
                return Json(list);
            }
        }

        [HttpGet("template")]
        public IActionResult GetCommunityTemplate()
        {
            try
            {
                Customer communityCustomer = new Customer
                {
                    CustType = 3, // спільнота юр особа
                    AnkVersion = 1,
                    Status = 2,
                    Company = new Company
                    {
                        AnketaCompany = new List<AnketaCompany>
                        {
                            new AnketaCompany
                            {
                                Version = 1,
                                Status = 2,
                            }
                        },
                        Version = 1
                    },
                    AgreementMaster = new List<AgreementMaster>
                    {
                        new AgreementMaster
                        {
                            AgrStatus = 2,
                            AgrType = 4,
                            Version = 1,
                            //agreementaddcomunity agr type = 4
                        }
                    },
                    RightHolder = new RightHolder
                    {
                        // community RH rholdertype = 2
                    }
                };

                // Договор з Споживачем
                //var agreementAddCommunity = new AgreementAddCommunity
                //{
                //    AgrStatus = 2,
                //    Agr = agreementMaster,
                //    Version = 1,
                //    AnkVersion = 1,
                //};
                

                return Json(communityCustomer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[HttpGet("list")]
        //public async Task<IActionResult> GetTest()
        //{

        //    string QueryStr = string.Concat("select * from vTsk_1_ListCommunity", "");
        //    // Немає параметру по Споживачу;
        //    var list = await _dbContext.getViewData(QueryStr, null);
        //    return Json(list);

        //}
    }
}