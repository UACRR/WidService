using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ipsmedserviceapp.Model;
using static ipsmedserviceapp.Utilities.DBQueryHelper;
using IpsCommonTypes.ClassesForSearchQuery;
using IpsCommonTypes.Views;
using IpsCommonTypes.Wrappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ipsmedserviceapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterWIDController : ControllerBase
    {
        private const string WID = "wid";
        private const string Local = "local";

        private readonly MediaServiceContext _dbContext;

        public RegisterWIDController(MediaServiceContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Автопошук та прив'язка об'єктів по локальній та WID БД
        /// </summary>
        /// <param name="regId"></param>
        /// <returns></returns>
        [HttpGet("autolinkedobjects/{regId}")]
        public async Task<IActionResult> DefaultGetRequest(int regId)
        {
            await Task.Delay(3 * 1000);
            var currentTimeOut = _dbContext.Database.GetCommandTimeout();
            try
            {
                // select * from dbo.ft_Tsk_3_AutoLink_FULL()
                _dbContext.Database.SetCommandTimeout(2400);
                var sqlParameter = new[] { new SqlParameter("regId", regId) };
                var list = await _dbContext.getViewData("select * from dbo.ft_Tsk_3_AutoLink_FULL(@regId)", sqlParameter);

                return Ok(list);
            }
            finally
            {
                if (currentTimeOut.HasValue)
                    _dbContext.Database.SetCommandTimeout(currentTimeOut);
            }
        }

        [HttpPost("searchbyquery")]
        public async Task<IActionResult> SearchObjectRightsByQuery([FromBody] SearchObjectRightQuery query)
        {
            try
            {
                var conditions = new Dictionary<string, string>();

                if (!string.IsNullOrEmpty(query.ObjectName))
                    conditions.Add("name", query.ObjectName);

                if (!string.IsNullOrEmpty(query.Author))
                    conditions.Add("author", query.Author);

                if (!string.IsNullOrEmpty(query.Performer))
                    conditions.Add("performer", query.Performer);

                switch (query.DBSearch)
                {
                    case WID:
                        var queryWIDText = "select * from [WID_IPI].[dbo].[vtsk_3_OR_01_new]";
                        queryWIDText = ApplySqlWhereCondition(queryWIDText, conditions);

                        int totalItemsWID = 1000;

                        queryWIDText = ApplySqlOrderByAndPaging(queryWIDText, "WIC", query.Page, query.PageSize);

                        var listWID = await _dbContext.getViewData(queryWIDText, null);

                        var responseWID = new
                        {
                            List = listWID,
                            TotalItems = (object) totalItemsWID
                        };
                        return Ok(responseWID);

                    case Local:
                        var queryText = "select * from vtsk_3_OR_01";
                        queryText = ApplySqlWhereCondition(queryText, conditions);

                        var totalItems = (await _dbContext.getViewData(queryText.Replace("*", "count(*)"), null)).FirstOrDefault()?.Values.FirstOrDefault();

                        queryText = ApplySqlOrderByAndPaging(queryText, "objId", query.Page, query.PageSize);

                        var list = await _dbContext.getViewData(queryText, null);

                        var response = new
                        {
                            List = list,
                            TotalItems = totalItems
                        };

                        return Ok(response);
                }

                return BadRequest();
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
    }
}