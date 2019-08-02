using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ipsFormsDesign.Dictionary;
using ipsmedserviceapp.Model;
using IpsCommonTypes.ClassesForSearchQuery;
using IpsCommonTypes.Types;
using IpsCommonTypes.Views;
using IpsCommonTypes.Wrappers;
using Microsoft.AspNetCore.Http;
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
                switch (query.DBSearch)
                {
                    case WID:
                        break;
                    case Local:
                        var param = new[]
                        {
                            new SqlParameter("@name", !string.IsNullOrEmpty(query.ObjectName) ? (object) query.ObjectName : DBNull.Value),
                            new SqlParameter("@authtors", !string.IsNullOrEmpty(query.Author) ? (object) query.Author : DBNull.Value),
                            new SqlParameter("@performers", !string.IsNullOrEmpty(query.Performer) ? (object) query.Performer : DBNull.Value)
                        };
                        var list = await _dbContext.getViewData("select * from [dbo].[ft_tsk_3_SearchObj](@name, @authtors, @performers )", param);
                        break;
                }

                var response = new ItemListResponse<ObjectRightWithWID>
                {
                    TotalItems = 0,
                    List = new List<ObjectRightWithWID>()
                };

                return Ok(response);
            }
            catch (Exception e)
            {
                return BadRequest(e.ToString());
            }
        }
    }
}