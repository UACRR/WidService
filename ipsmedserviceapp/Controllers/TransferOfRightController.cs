using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ipsmedserviceapp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ipsmedserviceapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferOfRightController : ControllerBase
    {
        private MediaServiceContext _dbContext;
        public TransferOfRightController(MediaServiceContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("list/rightholders")]
        public async Task<IActionResult> GetRightholdersList()
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

        [HttpGet("list/objectsright/{custId}")]
        public async Task<IActionResult> GetObjectsRightList(int custId)
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


    }
}