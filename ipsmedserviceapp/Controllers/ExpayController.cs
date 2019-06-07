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
    public class ExpayController : ControllerBase
    {
        private readonly MediaServiceContext _dbContext;
        public ExpayController(MediaServiceContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Створити файл проводок
        /// Зберігається тілки структури:
        /// InputFile
        /// CheckParamPays
        /// </summary>
        /// <param name="inputFile"></param>
        /// <returns></returns>
        [HttpPost("file")]
        public async Task<IActionResult> CreateInputFile([FromBody] InputFile inputFile)
        {
            var dest = new InputFile();
            dest.SetFields(inputFile);
            foreach (var item in inputFile.CheckParamPays)
            {
                var newRec = new CheckParamPays();
                newRec.SetFields(item);
                dest.CheckParamPays.Add(newRec);
            }

            await _dbContext.InputFile.AddAsync(dest);
            // await _dbContext.CheckParamPays.AddRangeAsync(dest.CheckParamPays);
            var tran = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                await _dbContext.SaveChangesAsync();
                tran.Commit();
                _dbContext.Database.ExecuteSqlCommand("exec p_Tsk_1_CheckInputFile @fileId", new SqlParameter("@fileId", dest.FileId));
                var retDest = await _dbContext.InputFile.Where(rec => rec.FileId == dest.FileId)
                    .Include(rec => rec.CheckParamPays)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();

                return Ok(retDest);

            }
            catch( Exception ex )
            {
                tran.Rollback();
                throw ex;
            }
        }
        
        /// <summary>
        /// Зберігти файл проводок
        /// </summary>
        [HttpPut("file/{fileId}")]
        public async Task<IActionResult> SaveInputFile(int fileId, [FromBody] InputFile inputFile)
        {
            var dest = await _dbContext.InputFile
                                .Include(rec => rec.CheckParamPays)
                                .Include(rec => rec.ExternalPay)
                                .FirstOrDefaultAsync(rec => rec.FileId == fileId);

            if (dest == null)
                return NotFound();

            dest.SetFields(inputFile);

            dest.CheckParamPays.Clear();

            _dbContext.UpdateList(inputFile.ExternalPay, dest.ExternalPay, i => { }, (l, r) => l.PaidId == r.PaidId);

            await _dbContext.SaveChangesAsync();
            await _dbContext.Database.ExecuteSqlCommandAsync("exec dbo.p_Tsk_1_LinkExternalPay @fileId", new SqlParameter("@fileId", fileId));

            dest = await _dbContext.InputFile
                                .Include(rec => rec.ExternalPay)
                                .FirstOrDefaultAsync(rec => rec.FileId == fileId);

            return Ok(dest);

        }

        [HttpDelete("file/{fileId}")]
        public async Task<IActionResult> DeleteInputFile(int fileId)
        {
            IDbContextTransaction tran = null;
            try
            {
                tran = await _dbContext.Database.BeginTransactionAsync();
                await _dbContext.Database.ExecuteSqlCommandAsync("delete CheckParamPays where inputFileId = @fileId", new SqlParameter("@fileId", fileId));
                await _dbContext.Database.ExecuteSqlCommandAsync("delete InputFile where fileId = @fileId", new SqlParameter("@fileId", fileId));

                tran.Commit();

                return Ok();
            }
            catch (Exception ex)
            {
                if (tran != null)
                    tran.Rollback();

                throw ex;

            }
        }
        
        // get unlink list Отримати список непривязаних проводок
        [HttpGet("unlink")]
        public async Task<IActionResult> GetUnlink()
        {
            var list = await _dbContext.ExternalPay.Where(rec => rec.CustId == null).ToListAsync();
            return Ok(list);
        }

        private void insertNewMoneyResived(ExternalPay exPay)
        {
            _dbContext.MoneyReceived.Add(
                    new MoneyReceived
                    {
                        PaidId = exPay.PaidId,
                        MoneyType = 1,
                        DateInvoice = (DateTime)exPay.DocDate,
                        NumberInvoice = exPay.DocNum,
                        GoalInvoice = exPay.Nplat,
                        Amount = (decimal)exPay.SCredit,
                        DestribAmount = 0,
                        DestribPrepay = 0,
                        CustId = (int)exPay.CustId
                    });

        }
        
        // put unlink list Зберігти дані по списку непривязаних проводок
        [HttpPut("unlink")]
        public async Task<IActionResult> SaveUnlinkList([FromBody] List<ExternalPay> pays)
        {
            var ids = pays.Select(rec => rec.PaidId);
            var dest = await _dbContext.ExternalPay.Where(rec => ids.Contains(rec.PaidId)).ToListAsync();
            var moneyRecived = await _dbContext.MoneyReceived.Where(rec => ids.Contains(rec.PaidId)).ToListAsync();

            if (dest.Count() == 0)
                return NotFound();

            _dbContext.UpdateList(pays, dest, i => { }, (l, r) => l.PaidId == r.PaidId);
            dest.Where(rec => rec.CustId != null && !moneyRecived.Any(pay => pay.PaidId == rec.PaidId)).ToList()
                .ForEach(exPay =>
                {
                    insertNewMoneyResived(exPay);
                });

            await _dbContext.SaveChangesAsync();

            return Ok();

        }
        
        // get unlink/id Отримати неприв'язану проводку по ІД
        [HttpGet("unlink/{payId}")]
        public async Task<IActionResult> GetUnlinkPay(int payId)
        {
            var exPay = await _dbContext.ExternalPay.SingleOrDefaultAsync(rec => rec.PaidId == payId);
            if (exPay == null)
                return NotFound();

            return Ok(exPay);
        }

        // put unlink/id Зберігти неприв'язану проводку по ІД
        [HttpPut("unlink/{payId}")]
        public async Task<IActionResult> SaveUnlinkPay(int payId, [FromBody] ExternalPay exPay)
        {
            var dest = await _dbContext.ExternalPay
                .SingleOrDefaultAsync(rec => rec.PaidId == payId);
            if (dest == null)
                return NotFound();
            var moneyRecived = await _dbContext.MoneyReceived.FirstOrDefaultAsync(rec => rec.PaidId == exPay.PaidId);

            if (dest.CustId == null && exPay.CustId != null && moneyRecived == null)
            {
                insertNewMoneyResived(exPay);
            }

            dest.SetFields(exPay);

            await _dbContext.SaveChangesAsync();

            return Ok(exPay);
        }

        /// <summary>
        /// Отримати список діючих Споживачів
        /// </summary>
        /// <returns></returns>
        [HttpGet("vCustomers")]
        public async Task<IActionResult> GetVCustomers()
        {
            string query = @"select custId, name, INNOKPO, IPI, ankMy from vCustomer where isClient = 1 and custid in (select custid from LicenseAgreement where licstatus between 1 and 3)";
            try
            {
                var list = await _dbContext.vCustomer.FromSql(query).AsNoTracking().ToListAsync();
                return Ok(list);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
        }
    }
}