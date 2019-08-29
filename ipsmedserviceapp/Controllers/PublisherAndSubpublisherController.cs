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
    public class PublisherAndSubpublisherController : ControllerBase
    {
        private readonly MediaServiceContext _dbContext;

        public PublisherAndSubpublisherController(MediaServiceContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Отримати зв'язаний список видавництв/субвидавництв
        /// </summary>
        /// <returns></returns>
        [HttpGet("list")]
        public async Task<IActionResult> GetPublisherAndSubpublisherList()
        {
            string query = @"select * from vPubSub";
            var list = await _dbContext.getViewData(query, null);

            return Ok(list);
        }
    }
}