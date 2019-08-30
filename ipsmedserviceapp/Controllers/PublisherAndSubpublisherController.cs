using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ipsmedserviceapp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

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
        [HttpGet("list/links")]
        public async Task<IActionResult> GetPublisherAndSubpublisherList()
        {
            string query = @"select * from vPubSub";
            var list = await _dbContext.getViewData(query, null);

            return Ok(list);
        }

        /// <summary>
        /// Отримати зв'язаний список видавництва з субвидавництвом по ID
        /// </summary>
        /// <returns></returns>
        [HttpGet("list/links/{custId}")]
        public async Task<IActionResult> GetPublisherAndSubpublisherList(int custId)
        {
            var date = GetSqlTodayDate();

            string query = $"select * from vPubSub where custIdSub = {custId} and ('{date}' >= dateBegin and '{date}' <= dateEnd)";

            var list = await _dbContext.getViewData(query, null);

            return Ok(list);
        }

        [HttpGet("ukrainesubpublisher/{custId}")]
        public async Task<IActionResult> GetSubpublisherUkraine(int custId)
        {
            var date = GetSqlTodayDate();

            string query = $"select * from vPubSub where custIdPub = {custId} and ('{date}' >= dateBegin and '{date}' <= dateEnd)";

            var list = (await _dbContext.getViewData(query, null));
            var item = list.FirstOrDefault();
            return Ok(item);
        }

        /// <summary>
        /// Отримати список видавництв
        /// </summary>
        /// <returns></returns>
        [HttpGet("list/publishers")]
        public async Task<IActionResult> GetPublisherList()
        {
            string query = @"select * from vPublishers";
            var list = await _dbContext.getViewData(query, null);

            return Ok(list);
        }

        /// <summary>
        /// Створити зв'язок видавництва/субвидавництва
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        [HttpPost("link/create")]
        public async Task<IActionResult> CreateLink([FromBody] RelSubPublish source)
        {
            IDbContextTransaction transaction = null;
            try
            {
                var newRelSubPublish = new RelSubPublish();
                newRelSubPublish.SetFields(source);
                newRelSubPublish.CreateDate = DateTime.Now;

                await _dbContext.RelSubPublish.AddAsync(newRelSubPublish);

                transaction = _dbContext.Database.BeginTransaction();
                _dbContext.SaveChanges();
                transaction.Commit();

                return Ok();
            }
            catch (Exception e)
            {
                transaction?.Rollback();
                return BadRequest(e.ToString());
            }
        }

        /// <summary>
        /// Оновити зв'язок видавництва/субвидавництва
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        [HttpPut("link/update")]
        public async Task<IActionResult> UpdateLink([FromBody] RelSubPublish source)
        {
            IDbContextTransaction transaction = null;
            try
            {
                var target = await _dbContext.RelSubPublish
                    .SingleOrDefaultAsync(rec => rec.CustIdPub == source.CustIdPub
                                                 && rec.CustIdSub == source.CustIdSub
                                                 && rec.CreateDate == source.CreateDate);

                if (target == null)
                    return NotFound();

                target.DateEnd = source.DateEnd;

                transaction = _dbContext.Database.BeginTransaction();
                _dbContext.SaveChanges();
                transaction.Commit();

                return Ok();
            }
            catch (Exception e)
            {
                transaction?.Rollback();
                return BadRequest(e.ToString());
            }
        }

        /// <summary>
        /// Отримати рядкове представлення дати для SQL параметра
        /// </summary>
        /// <returns></returns>
        private string GetSqlTodayDate()
        {
            return $"{DateTime.Now.Year}-{DateTime.Now.Month}-{DateTime.Now.Day}";
        }
    }
}