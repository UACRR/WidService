using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ipsmedserviceapp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ipsmedserviceapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpayController : ControllerBase
    {
        private MediaServiceContext _dbContext;
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
        public async Task<IActionResult> CreateInputFile( [FromBody] InputFile inputFile )
        {
            var dest = new InputFile();
            dest.SetFields(inputFile);
            foreach( var item in inputFile.CheckParamPays )
            {
                var newRec = new CheckParamPays();
                newRec.SetFields(item);
                dest.CheckParamPays.Add(newRec);
            }

            await _dbContext.InputFile.AddAsync(dest);
            await _dbContext.CheckParamPays.AddRangeAsync(dest.CheckParamPays);

            await _dbContext.SaveChangesAsync();
            _dbContext.Database.ExecuteSqlCommand("exec p_Tsk_1_CheckInputFile @fileId", new SqlParameter("@fileId", dest.FileId));
            dest.CheckParamPays = await _dbContext.CheckParamPays.Where(rec => rec.InputFileId == dest.FileId).ToListAsync();

            return Ok(dest);
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
        // get unlink list Отримати список непривязаних проводок
        [HttpGet("unlink")]
        public async Task<IActionResult> GetUnlink()
        {
            var list = await _dbContext.ExternalPay.Where(rec => rec.CustId == null ).ToListAsync();
            return Ok(list);
        }
        // put unlink list Зберігти дані по списку непривязаних проводок
        [HttpPut("unlink")]
        public async Task<IActionResult> SaveUnlinkList([FromBody] List<ExternalPay> pays)
        {
            var ids = pays.Select(rec => rec.PaidId);
            var dest = await _dbContext.ExternalPay.Where(rec => ids.Contains(rec.PaidId)).ToListAsync();

            if (dest.Count() == 0)
                return NotFound();

            _dbContext.UpdateList(pays, dest, i => { }, (l, r) => l.PaidId == r.PaidId);

            await _dbContext.SaveChangesAsync();

            return Ok();

        }
        // get unlink/id Отримати неприв'язану проводку по ІД
        [HttpGet("unlink/{payId}")]
        public async Task<IActionResult> GetUnlinkPay( int payId )
        {
            var exPay = await _dbContext.ExternalPay.SingleOrDefaultAsync(rec => rec.PaidId == payId);
            if (exPay == null)
                return NotFound();

            return Ok(exPay);
        }
        // put unlink/id Зберігти неприв'язану проводку по ІД
        [HttpPut("unlink/{payId}")]
        public async Task<IActionResult> SaveUnlinkPay( int payId, [FromBody] ExternalPay exPay )
        {
            var dest = await _dbContext.ExternalPay.SingleOrDefaultAsync(rec => rec.PaidId == payId);
            if (dest == null)
                return NotFound();

            dest.SetFields(exPay);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }



    }
}