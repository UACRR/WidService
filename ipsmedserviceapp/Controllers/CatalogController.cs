using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using IpsCommonTypes.Types;
using IpsCommonTypes.Enums;
using ipsmedserviceapp.Model;
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
    public class CatalogController : ControllerBase
    {
        private readonly MediaServiceContext _dbContext;
        private readonly ILogger<CatalogController> _logger;

        public CatalogController(MediaServiceContext dbContext, ILogger<CatalogController> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }


        [HttpGet("catalogfilelist/{custId}")]
        public async Task<IActionResult> GetCatalogFilesList(int custId)
        {
            var catalogFiles = await _dbContext.CatalogFile
                .Where(rec => rec.CustId == custId && rec.PubCatalogItem.Any())
                .Include(rec => rec.StatusNavigation)
                .OrderBy(rec => rec.FileId)
                .ToListAsync();

            return Ok(catalogFiles);
        }

        [HttpGet("catalogfile/{custId}/{fileId}")]
        public async Task<IActionResult> GetCatalogFile(int custId, int fileId)
        {
            var catalogFile = await _dbContext.CatalogFile
                .Include(rec => rec.PubCatalogItem)
                    .ThenInclude(rec => rec.StatusNavigation)
                .SingleOrDefaultAsync(rec => rec.CustId == custId && rec.FileId == fileId);

            if (catalogFile == null)
                return NotFound($"CatalogFile with CustId:{custId} and FileId:{fileId} not found!");

            return Ok(catalogFile);
        }

        [Authorize]
        [HttpPost("upload/{custId}")]
        public async Task<IActionResult> UploadFile(int custId, [FromBody] CatalogFile source)
        {
            IDbContextTransaction transaction = null;
            try
            {
                if (source == null || !source.PubCatalogItem.Any())
                    return BadRequest("Loaded file is empty or not read!");

                var vcustomer = await _dbContext.vCustomer.SingleOrDefaultAsync(rec => rec.CustId == custId);

                var rightholder = _dbContext.RightHolder.SingleOrDefault(rec => rec.CustId == custId);
                if (rightholder == null)
                    return NotFound($"RightHolder with ID:{custId} not found!");

                string[] excludedFields = { "CustId", "FileId", "UserId", "Status" };

                var destination = new CatalogFile
                {
                    CustId = custId,
                    UserId = User.Identity.Name,
                    Status = 0,
                    PubCatalogItem = new List<PubCatalogItem>()
                };
                destination.SetFields(source, excludedFields);

                switch (rightholder.RHolderType)
                {
                    // видавництво
                    case 3:
                        destination.RhType = 3;
                        foreach (var item in source.PubCatalogItem)
                        {
                            var PubCatalogItem = new PubCatalogItem
                            {
                                CustId = destination.CustId,
                                Status = 0,
                            };
                            PubCatalogItem.SetFields(item, excludedFields);
                            destination.PubCatalogItem.Add(PubCatalogItem);
                        }
                        break;

                    // правовласник
                    case 1:
                        destination.RhType = 1;
                        break;

                    // інші RHolderType
                    default:
                        {
                            _logger.LogInformation("Unsupported RHolderType!");
                            return BadRequest("Unsupported RHolderType!");
                        }
                }

                destination.CustName = vcustomer?.name;
                destination.CreateDate = DateTime.Now;
                destination.CountZap = destination.PubCatalogItem.Count;

                await _dbContext.CatalogFile.AddAsync(destination);

                transaction = _dbContext.Database.BeginTransaction();
                _dbContext.SaveChanges();
                transaction.Commit();
                return Ok(destination);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException.Message);
                transaction?.Rollback();
                throw;
            }
            finally
            {
                transaction?.Dispose();
            }
        }

        [HttpDelete("delete/{custId}/{fileId}")]
        public async Task<IActionResult> DeleteCatalogFile(int custId, int fileId)
        {
            IDbContextTransaction transaction = null;
            try
            {
                var catalogFile = await _dbContext.CatalogFile
                    .Include(rec => rec.PubCatalogItem)
                    .SingleOrDefaultAsync(rec => rec.CustId == custId && rec.FileId == fileId);

                if (catalogFile == null)
                    return NotFound($"CatalogFile with CustId: {custId} and FileId: {fileId} not found!");

                if (catalogFile.Status == 3 || catalogFile.Status == 4)
                    return BadRequest("CatalogFile with status 3 or 4 cannot be deleted!");

                _dbContext.PubCatalogItem.RemoveRange(catalogFile.PubCatalogItem);
                _dbContext.CatalogFile.Remove(catalogFile);

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

        /// <summary>
        /// Перевірити excel файл на помилки
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        [HttpPut("validate/{fileId}")]
        public async Task<IActionResult> BeginValidationFile(int fileId)
        {
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

                string command = "exec CatalogControlPub @fileId, @result OUTPUT, @RetCode  OUTPUT";

                await _dbContext.Database.ExecuteSqlCommandAsync(command, paramFileId, message, returnCode);

                var responce = new ExecSqlResponce<CatalogFile>
                {
                    Message = message.Value.ToString(),
                    StatusCode = Convert.ToInt32(returnCode.Value) == 0 ? ExecSqlResponceStatus.Successed : ExecSqlResponceStatus.Failed
                };

                var validCatalog = await _dbContext.CatalogFile
                    .Include(rec => rec.PubCatalogItem)
                    .ThenInclude(pub => pub.StatusNavigation)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(rec => rec.FileId == fileId);
                responce.Data = validCatalog;

                return Ok(responce);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException.Message);
                throw;
            }
        }

        /// <summary>
        /// Заупстити процес обробки записів
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        [HttpPut("process/{fileId}")]
        public async Task<IActionResult> BeginProcessFile(int fileId)
        {
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

                string command = @"exec CatalogInputPub @fileId, @result OUTPUT, @RetCode OUTPUT";

                await _dbContext.Database.ExecuteSqlCommandAsync(command, paramFileId, message, returnCode);

                var responce = new ExecSqlResponce<CatalogFile>
                {
                    Message = message.Value.ToString(),
                    StatusCode = Convert.ToInt32(returnCode.Value) == 0 ? ExecSqlResponceStatus.Successed : ExecSqlResponceStatus.Failed
                };

                var validCatalog = await _dbContext.CatalogFile
                    .Include(rec => rec.PubCatalogItem)
                    .ThenInclude(pub => pub.StatusNavigation)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(rec => rec.FileId == fileId);
                responce.Data = validCatalog;

                return Ok(responce);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.InnerException.Message);
                throw;
            }
        }
    }
}