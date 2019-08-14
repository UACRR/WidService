using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using IpsCommonTypes.Types;
using IpsCommonTypes.Enums;
using ipsmedserviceapp.Model;
using IpsCommonTypes.Wrappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;

namespace ipsmedserviceapp.Controllers
{
    [Produces("application/json")]
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

        /// <summary>
        /// Отримати список файлів правовласника
        /// </summary>
        /// <param name="custId"></param>
        /// <returns></returns>
        [HttpGet("{custId}")]
        public async Task<IActionResult> GetRightholderRegisterFileList(int custId)
        {

            var list = await _dbContext.CatalogFile
                            .Where(rec => rec.CustId == custId && rec.RhcatalogItem.Any())
                            .Include(rec => rec.StatusNavigation)
                            .ToArrayAsync();

            return Ok(list);
        }

        /// <summary>
        /// Отримати файл з елементами
        /// </summary>
        /// <param name="custId"></param>
        /// <param name="fileId"></param>
        /// <returns></returns>
        [HttpGet("{custId}/file/{fileId}")]
        public async Task<IActionResult> GetFile(int custId, int fileId)
        {
            var file = await _dbContext.CatalogFile
                .Where(rec => rec.CustId == custId && rec.FileId == fileId)
                .Include(item => item.StatusNavigation)
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

        /// <summary>
        /// Перевірити файл
        /// </summary>
        /// <param name="custId"></param>
        /// <param name="fileId"></param>
        /// <returns></returns>
        [HttpPost("{custId}/file/{fileId}/validate")]
        public async Task<IActionResult> ValidateFile(int custId, int fileId)
        {
            var currentTimeOut = _dbContext.Database.GetCommandTimeout();
            _dbContext.Database.SetCommandTimeout(2400);

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

                var responce = new ExecSqlResponce<CatalogFile>
                {
                    Message = message.Value.ToString(),
                    StatusCode = Convert.ToInt32(returnCode.Value) == 0 ? ExecSqlResponceStatus.Successed : ExecSqlResponceStatus.Failed
                };

                var validCatalog = await _dbContext.CatalogFile
                    .Include(rec => rec.RhcatalogItem)
                    .ThenInclude(pub => pub.StatusNavigation)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(rec => rec.FileId == fileId);
                responce.Data = validCatalog;

                return Ok(responce);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
            finally
            {
                if (currentTimeOut.HasValue)
                    _dbContext.Database.SetCommandTimeout(currentTimeOut);
            }
        }

        /// <summary>
        /// Запустити процес завантаження
        /// </summary>
        /// <param name="custId"></param>
        /// <param name="fileId"></param>
        /// <returns></returns>
        [HttpPost("{custId}/file/{fileId}/process")]
        public async Task<IActionResult> ProcessFile(int custId, int fileId)
        {
            var currentTimeOut = _dbContext.Database.GetCommandTimeout();
            _dbContext.Database.SetCommandTimeout(2400);

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

                var responce = new ExecSqlResponce<CatalogFile>
                {
                    Message = message.Value.ToString(),
                    StatusCode = Convert.ToInt32(returnCode.Value) == 0
                        ? ExecSqlResponceStatus.Successed
                        : ExecSqlResponceStatus.Failed
                };

                // Процедура виконала дії без помилок

                var validCatalog = await _dbContext.CatalogFile
                    .Include(rec => rec.RhcatalogItem)
                    .ThenInclude(pub => pub.StatusNavigation)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(rec => rec.FileId == fileId);
                responce.Data = validCatalog;

                return Ok(responce);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
            finally
            {
                if (currentTimeOut.HasValue)
                    _dbContext.Database.SetCommandTimeout(currentTimeOut);
            }
        }

        /// <summary>
        /// Upload new file
        /// </summary>
        /// <param name="custId"></param>
        /// <param name="source"></param>
        /// <returns></returns>
        [HttpPost("{custId}/upload")]
        public async Task<IActionResult> UploadFile(int custId, [FromBody] CatalogFile source)
        {
            var currentTimeOut = _dbContext.Database.GetCommandTimeout();
            IDbContextTransaction transaction = null;
            try
            {
                if (source == null)
                {
                    string msg = $"Upload *** Catalog File is empty";
                    _logger.LogWarning(msg);
                    return BadRequest(msg);
                }

                _dbContext.Database.SetCommandTimeout(2400);
                var vcustomer = await _dbContext.vCustomer.SingleOrDefaultAsync(rec => rec.CustId == custId);
                var rightholder = _dbContext.RightHolder.SingleOrDefault(rec => rec.CustId == custId);
                if (rightholder == null)
                    return NotFound($"RightHolder with ID:{custId} not found!");

                var dest = new CatalogFile
                {
                    CustId = custId,
                    Status = 0,
                    UserId = source.UserId ?? "system",
                    RhType = rightholder.RHolderType,
                    CreateDate = DateTime.Now,
                    CountZap = source.RhcatalogItem.Count,
                    FileName = source.FileName,
                    CustName = vcustomer?.name,
                };

                var items = source.RhcatalogItem.ToArray();
                foreach (var item in items)
                {
                    source.RhcatalogItem.Remove(item);
                    item.Status = 0;
                    item.CustId = custId;
                    dest.RhcatalogItem.Add(item);
                }

                transaction = _dbContext.Database.BeginTransaction();

                await _dbContext.CatalogFile.AddAsync(dest);
                await _dbContext.RhcatalogItem.AddRangeAsync(dest.RhcatalogItem);
                await _dbContext.SaveChangesAsync();

                transaction.Commit();

                return Ok(dest);
            }
            catch
            {
                transaction?.Rollback();
                throw;
            }
            finally
            {
                if(currentTimeOut.HasValue)
                    _dbContext.Database.SetCommandTimeout(currentTimeOut);
            }
        }

        /// <summary>
        /// Оновити коментар CatalogFile
        /// </summary>
        /// <param name="catalogFile"></param>
        /// <returns></returns>
        [HttpPut("updatecomment")]
        public async Task<IActionResult> UpdateComment([FromBody] CatalogFile catalogFile)
        {
            IDbContextTransaction transaction = null;
            try
            {
                var destination = await _dbContext.CatalogFile
                    .SingleOrDefaultAsync(rec => rec.CustId == catalogFile.CustId && rec.FileId == catalogFile.FileId);

                if (destination == null)
                    return NotFound($"CatalogFile with CustID:{catalogFile.CustId} and FileID:{catalogFile.FileId} not found!");

                destination.Comment = catalogFile.Comment;

                transaction = _dbContext.Database.BeginTransaction();
                _dbContext.SaveChanges();
                transaction.Commit();
                return Ok();
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                _logger.LogError(ex.InnerException.Message);
                throw;
            }
            finally
            {
                transaction?.Dispose();
            }
        }
    }
}