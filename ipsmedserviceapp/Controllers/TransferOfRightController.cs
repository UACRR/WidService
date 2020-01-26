using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using IpsCommonTypes.Types;
using ipsmedserviceapp.Extensions;
using ipsmedserviceapp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ipsmedserviceapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferOfRightController : ControllerBase
    {
        private readonly MediaServiceContext _dbContext;
        
        public TransferOfRightController(MediaServiceContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Отримати список правовласників
        /// </summary>
        /// <returns></returns>
        [HttpGet("list/rightholders/default")]
        public async Task<IActionResult> GetTransferDefaultRightholdersList()
        {
            try
            {
                string query = $"select * from vTsk_1_TransferRightHolders where isHeritage = 0";
                
                List<object[]> list = null;
                
                await Task.Factory.StartNew(() => list = ExecuteQuery.GetDataFromSqlServer(_dbContext.Database, query));
                
                return Ok(list);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        /// <summary>
        /// Отримати список правовласників для передачі спадщини
        /// </summary>
        /// <returns></returns>
        [HttpGet("list/rightholders/heritage")]
        public async Task<IActionResult> GetTransferHeritageRightholdersList()
        {
            try
            {
                string query = $"select * from vTsk_1_TransferRightHolders where isHeritage = 1";

                List<object[]> list = null;

                var a = await Task.Factory.StartNew(() => list = ExecuteQuery.GetDataFromSqlServer(_dbContext.Database, query));

                return Ok(list);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpGet("list/rightholders/pubsub")]
        public async Task<IActionResult> GetRightholdersPubSubList()
        {
            try
            {

                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet("list/objectsright/{custIdPub}/{custIdSub}")]
        public async Task<IActionResult> GetObjectsRightList(int custIdPub, int custIdSub)
        {
            try
            {

                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Отримати список об'єктів правовласника по ID для передачі прав
        /// </summary>
        /// <param name="custId"></param>
        /// <returns></returns>
        [HttpGet("list/objects/{custId}")]
        public async Task<IActionResult> GetObjectsForTransfer(int custId)
        {
            try
            {
                ObjectsForTransferInfo data = new ObjectsForTransferInfo();
                using (SqlConnection sqlConnection = (SqlConnection)_dbContext.Database.GetDbConnection())
                {
                    string query = $"select * from vtsk_3_OR_03_Transfer where custId = {custId}";
                    var datarows = await Task.Factory.StartNew(() => ExecuteQuery.GetDataFromSqlServer(sqlConnection, query));

                    string infoQuery = $"select * from vTsk_3_ObjectsCopyright where custId = {custId}";
                    var infodata = await Task.Factory.StartNew(() => ExecuteQuery.GetDataFromSqlServer(sqlConnection, infoQuery));

                    data.TransferObjects = datarows;
                    data.CopyrightsOfObjects = infodata;
                }

                return Ok(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }


        [HttpPut("transfer/default")]
        public async Task<IActionResult> TransferRightsOfObjectsDetault([FromBody] ObjectTransferDataParameters parameters)
        {
            ResponseOfRequest response;
            try
            {

                response = new ResponseOfRequest("Предачу прав виконано!");
                return Ok(response);
            }
            catch (Exception e)
            {
                response = new ResponseOfRequest("Неможливо виконати передачу прав!", e);
                return BadRequest(response);
            }
        }


        [HttpPut("transfer/heritage")]
        public async Task<IActionResult> TransferRightsOfObjectsHeritage([FromBody] ObjectTransferDataParameters parameters)
        {
            ResponseOfRequest response;
            try
            {

                response = new ResponseOfRequest("Предачу прав виконано!");
                return Ok(response);
            }
            catch (Exception e)
            {
                response = new ResponseOfRequest("Неможливо виконати передачу прав!", e);
                return BadRequest(response);
            }
        }
    }
}