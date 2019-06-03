using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using IpsCommonTypes.Types;
using ipsmedserviceapp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ipsmedserviceapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RightholderRegisterController : ControllerBase
    {
        private readonly MediaServiceContext _dbContext;
        private readonly ILogger<CatalogController> _logger;

        public RightholderRegisterController(MediaServiceContext dbContext, ILogger<CatalogController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }


        // *** GET --- List CatalogFile
        [HttpGet("{custId}")]
        public async Task<IActionResult> GetRightholderRegisterFileList(int custId)
        {

            var list = await _dbContext.CatalogFile
                            .Where(rec => rec.CustId == custId && rec.RhcatalogItem.Any())
                            .Include(rec => rec.StatusNavigation)
                            .ToArrayAsync();

            return Ok(list);
        }
        // file
        // *** Get
        [HttpGet("{custId}/file/{fileId}")]
        public async Task<IActionResult> GetFile(int custId, int fileId)
        {
            var file = await _dbContext.CatalogFile
                        .Where(rec => rec.CustId == custId && rec.FileId == fileId)
                        .Include(rec => rec.RhcatalogItem)
                            .ThenInclude(item => item.StatusNavigation)
                        .FirstOrDefaultAsync();

            if (file == null)
            {
                string msg = $"GET *** File with fileId = {fileId} not found";
                _logger.LogWarning(msg);
                return NotFound(msg);
            }

            return Ok(file);
        }
        // *** Delete
        [HttpDelete("{custId}/file/{fileId}")]
        public async Task<IActionResult> DeleteFile(int custId, int fileId)
        {
            var file = await _dbContext.CatalogFile
            .Where(rec => rec.CustId == custId && rec.FileId == fileId)
            .Include(rec => rec.RhcatalogItem)
            .FirstOrDefaultAsync();

            if (file == null)
            {
                string msg = $"DELETE *** File with fileId = {fileId} not found";
                _logger.LogWarning(msg);
                return NotFound(msg);
            }

            _dbContext.RhcatalogItem.RemoveRange(file.RhcatalogItem);
            _dbContext.CatalogFile.Remove(file);
            await _dbContext.SaveChangesAsync();
            return Ok(file);
        }
        // *** Update
        [HttpPut("{custId}/file/{fileId}")]
        public async Task<IActionResult> UpdateFile(int custId, int fileId, [FromBody] CatalogFile sors)
        {
            var file = await _dbContext.CatalogFile
            .Where(rec => rec.CustId == custId && rec.FileId == fileId)
            .FirstOrDefaultAsync();

            if (file == null)
            {
                string msg = $"UPDATE *** File with fileId = {fileId} not found";
                _logger.LogWarning(msg);
                return NotFound(msg);
            }

            file.SetFields(sors);

            await _dbContext.SaveChangesAsync();

            return Ok(file);


        }
        //

        // *** Validate
        [HttpPut("{custId}/file/{fileId}/validate")]
        public async Task<IActionResult> ValidateFile(int custId, int fileId)
        {

            var file = await _dbContext.CatalogFile
            .Where(rec => rec.CustId == custId && rec.FileId == fileId)
            .FirstOrDefaultAsync();

            if (file == null)
            {
                string msg = $"VALIDATE *** File with fileId = {fileId} not found";
                _logger.LogWarning(msg);
                return NotFound(msg);
            }

            try
            {
                var paramFileId = new SqlParameter("@fileId", fileId);

                var message = new SqlParameter("@result", SqlDbType.VarChar, 100)
                {
                    Direction = ParameterDirection.Output
                };

                var returnCode = new SqlParameter("@RetCode", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };

                string command = "exec CatalogControlRH @fileId, @result OUTPUT, @RetCode OUTPUT";

                await _dbContext.Database.ExecuteSqlCommandAsync(command, paramFileId, message, returnCode);

                var responce = new ExecSqlResponce<CatalogFile>();
                responce.Message = message.Value.ToString();

                // Процедура виконала дії без помилок
                if (Convert.ToInt32(returnCode.Value) == 0)
                {
                    var validCatalog = await _dbContext.CatalogFile
                        .Include(rec => rec.RhcatalogItem)
                        .ThenInclude(pub => pub.StatusNavigation)
                        .AsNoTracking()
                        .FirstOrDefaultAsync(rec => rec.FileId == fileId);

                    responce.StatusCode = IpsCommonTypes.Enums.ExecSqlResponceStatus.Successed;
                    responce.Data = validCatalog;
                }
                else
                {
                    responce.StatusCode = IpsCommonTypes.Enums.ExecSqlResponceStatus.Failed;
                }

                return Ok(responce);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException.Message);
                throw;
            }
        }

        // *** Process
        [HttpPut("{custId}/file/{fileId}/process")]
        public async Task<IActionResult> ProcessFile(int custId, int fileId)
        {
            var file = await _dbContext.CatalogFile
            .Where(rec => rec.CustId == custId && rec.FileId == fileId)
            .FirstOrDefaultAsync();

            if (file == null)
            {
                string msg = $"PROCESS *** File with fileId = {fileId} not found";
                _logger.LogWarning(msg);
                return NotFound(msg);
            }

            try
            {
                var paramFileId = new SqlParameter("@fileId", fileId);

                var message = new SqlParameter("@result", SqlDbType.VarChar, 100)
                {
                    Direction = ParameterDirection.Output
                };

                var returnCode = new SqlParameter("@RetCode", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };

                string command = "exec CatalogInputRH @fileId, @result OUTPUT, @RetCode OUTPUT";

                await _dbContext.Database.ExecuteSqlCommandAsync(command, paramFileId, message, returnCode);

                var responce = new ExecSqlResponce<CatalogFile>();
                responce.Message = message.Value.ToString();

                // Процедура виконала дії без помилок
                if (Convert.ToInt32(returnCode.Value) == 0)
                {
                    var validCatalog = await _dbContext.CatalogFile
                        .Include(rec => rec.RhcatalogItem)
                        .ThenInclude(pub => pub.StatusNavigation)
                        .AsNoTracking()
                        .FirstOrDefaultAsync(rec => rec.FileId == fileId);

                    responce.StatusCode = IpsCommonTypes.Enums.ExecSqlResponceStatus.Successed;
                    responce.Data = validCatalog;
                }
                else
                {
                    responce.StatusCode = IpsCommonTypes.Enums.ExecSqlResponceStatus.Failed;
                }

                return Ok(responce);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException.Message);
                throw;
            }
        }

        // upload
        [HttpPut("{custId}/upload")]
        public async Task<IActionResult> UploadFile(int custId, [FromBody] CatalogFile sors)
        {
            if (sors == null)
            {
                string msg = $"Upload *** Catalog File is empty";
                _logger.LogWarning(msg);
                return BadRequest(msg);

            }

            CatalogFile dest = new CatalogFile { CustId = custId };
            dest.SetFields(sors, new[] { "CustId", "FileId" });

            var items = sors.RhcatalogItem.ToArray();
            foreach (var item in items)
            {
                sors.RhcatalogItem.Remove(item);
                dest.RhcatalogItem.Add(item);
            }

            await _dbContext.CatalogFile.AddAsync(dest);
            await _dbContext.RhcatalogItem.AddRangeAsync(dest.RhcatalogItem);
            await _dbContext.SaveChangesAsync();

            return Ok(dest);
        }
    }
}