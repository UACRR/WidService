using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using ipsmedserviceapp.Model;
using static ipsmedserviceapp.Utilities.DBQueryHelper;
using IpsCommonTypes.ClassesForSearchQuery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ipsmedserviceapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterWIDController : ControllerBase
    {
        private const string WID = "wid";
        private const string Local = "local";
        //private const string WIDQuery = @"select t1.wic, t1.AltTtl as objectName, t2.LstNa as performerLastName, t2.FstNa as performerFirstName, t3.lstName as authorLastName, t3.fstName as authorFirstName, ratePer, rateMEc from [WID_IPI].[dbo].[TblAltTtl] t1 join [WID_IPI].[dbo].[TblArtist] t2 on t2.WIC = t1.WIC join [WID_IPI].[dbo].[wObjectAuthor] t3 on t3.WIC = t1.WIC";
        private const string WIDQuery = @"select distinct t1.wic from [WID_IPI].[dbo].[TblAltTtl] t1 left join [WID_IPI].[dbo].[TblArtist] t2 on t2.WIC = t1.WIC left join [WID_IPI].[dbo].[wObjectAuthor] t3 on t3.WIC = t1.WIC";
        private const string ObjectListQuery = "select * from [WID_IPI].[dbo].[vObjRigthsForLink]";

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
            var currentTimeOut = _dbContext.Database.GetCommandTimeout();
            try
            {
                // select * from dbo.ft_Tsk_3_AutoLink_FULL()
                _dbContext.Database.SetCommandTimeout(2400);
                var sqlParameter = new[] {new SqlParameter("regId", regId)};
                var list = await _dbContext.getViewData("select * from dbo.ft_Tsk_3_AutoLink_FULL(@regId)",
                    sqlParameter);

                return Ok(list);
            }
            catch (Exception e)
            {
                throw;
            }
            finally
            {
                if (currentTimeOut.HasValue)
                    _dbContext.Database.SetCommandTimeout(currentTimeOut);
            }
        }

        [HttpPost("searchbyquery")]
        public async Task<IActionResult> SearchObjectRightsByQuery([FromBody] SearchObjectRightQuery searchObjectRightQuery)
        {
            var currentTimeOut = _dbContext.Database.GetCommandTimeout();
            try
            {
                _dbContext.Database.SetCommandTimeout(2400);
                switch (searchObjectRightQuery.DBSearch)
                {
                    case WID:
                        var queryWID = WIDQuery;

                        var conditionsDictionary = new Dictionary<string[], string>();

                        if (!string.IsNullOrEmpty(searchObjectRightQuery.ObjectName))
                        {
                            conditionsDictionary.Add(new []{ "t1.AltTtl"} , searchObjectRightQuery.ObjectName);
                        }

                        if (!string.IsNullOrEmpty(searchObjectRightQuery.Performer))
                        {
                            conditionsDictionary.Add(new[] { "t2.LstNa", "t2.FstNa" }, searchObjectRightQuery.Performer);
                        }

                        if (!string.IsNullOrEmpty(searchObjectRightQuery.Author))
                        {
                            conditionsDictionary.Add(new []{ "t3.lstName", "t3.fstName" }, searchObjectRightQuery.Author);
                        }

                        queryWID = ApplySqlWhereContainsCondition(queryWID, conditionsDictionary);
                        queryWID = ApplySqlWhereInCondition(ObjectListQuery, "WIC", queryWID);

                        var queryWIDParam = new SqlParameter
                        {
                            ParameterName = "@searchObjectRightQuery",
                            SqlDbType = SqlDbType.VarChar,
                            Size = 1024,
                            Value = queryWID
                        };

                        var offset = new SqlParameter
                        {
                            ParameterName = "@offset",
                            SqlDbType = SqlDbType.Int,
                            Value = (searchObjectRightQuery.Page - 1) * searchObjectRightQuery.PageSize
                        };

                        var fetch = new SqlParameter
                        {
                            ParameterName = "@fetch",
                            SqlDbType = SqlDbType.Int,
                            Value = searchObjectRightQuery.PageSize
                        };

                        var count = new SqlParameter
                        {
                            ParameterName = "@count",
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Output,
                        };

                        string execProcedureString = @"exec [WID_IPI].[dbo].[sp_ObjectsRightForLink] @searchObjectRightQuery, @offset, @fetch, @count OUT";
                        var objlist = _dbContext.ObjectsRightForLink.FromSql(execProcedureString, queryWIDParam, offset, fetch, count).AsNoTracking().ToList();
                        
                        var totalItemsWID = count.Value;

                        var responseWID = new
                        {
                            List = objlist,
                            TotalItems = totalItemsWID
                        };
                        return Ok(responseWID);

                    case Local:
                        var queryText = "select * from vtsk_3_OR_01";

                        var conditions = new Dictionary<string, string>();

                        if (!string.IsNullOrEmpty(searchObjectRightQuery.ObjectName))
                            conditions.Add("name", searchObjectRightQuery.ObjectName);

                        if (!string.IsNullOrEmpty(searchObjectRightQuery.Author))
                            conditions.Add("author", searchObjectRightQuery.Author);

                        if (!string.IsNullOrEmpty(searchObjectRightQuery.Performer))
                            conditions.Add("performer", searchObjectRightQuery.Performer);

                        queryText = ApplySqlWhereCondition(queryText, conditions);

                        var totalItems = (await _dbContext.getViewData(queryText.Replace("*", "count(*)"), null)).FirstOrDefault()?.Values.FirstOrDefault();

                        queryText = ApplySqlOrderByAndPaging(queryText, "objId", searchObjectRightQuery.Page, searchObjectRightQuery.PageSize);

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
            finally
            {
                if (currentTimeOut.HasValue)
                    _dbContext.Database.SetCommandTimeout(currentTimeOut);
            }
        }

        [HttpPost("widobjectrights")]
        public async Task<IActionResult> GetObjectRightListByWics([FromBody] int[] wics)
        {
            if (!wics.Any())
                return BadRequest();

            string query = "select * from vTsk10_WIDObjects";
            query = ApplySqlWhereInCondition(query, "WIC", wics);

            var listWIDObjects = await _dbContext.getViewData(query, null);

            return Ok(listWIDObjects);
        }

        [HttpGet("searchlocal")]
        public async Task<IActionResult> SearchObjectRightsByFunctionLocal([FromQuery] string name, [FromQuery] string authtors, [FromQuery] string performers)
        {

            var list = await _dbContext.getViewData("select * from [dbo].[ft_tsk_3_SearchObj](@name, @authtors, @performers )",
                new[] { new SqlParameter("@name", !string.IsNullOrEmpty(name) ? (object)name : DBNull.Value ),
                    new SqlParameter("@authtors", !string.IsNullOrEmpty(name) ? (object)authtors : DBNull.Value ),
                    new SqlParameter("@performers", !string.IsNullOrEmpty(name) ? (object)performers : DBNull.Value ) }
            );

            return Ok(list);
        }

        [HttpGet("searchwid")]
        public async Task<IActionResult> SearchObjectRightsByFunctionWID([FromQuery] string name, [FromQuery] string authtors, [FromQuery] string performers)
        {
            var sqlParameters= new[]
            {
                new SqlParameter("@name", !string.IsNullOrEmpty(name) ? (object) name : DBNull.Value),
                new SqlParameter("@authtors", !string.IsNullOrEmpty(name) ? (object) authtors : DBNull.Value),
                new SqlParameter("@performers", !string.IsNullOrEmpty(name) ? (object) performers : DBNull.Value)
            };

            var list = await _dbContext.getViewData("select * from [dbo].[ft_tsk_3_SearchObjWID](@name, @authtors, @performers )", sqlParameters);

            return Ok(list);
        }
    }
}