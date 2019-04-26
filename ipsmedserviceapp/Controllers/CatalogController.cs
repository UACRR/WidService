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
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly MediaServiceContext _dbContext;

        public CatalogController(MediaServiceContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("catalogfile/{custId}/{fileId}")]
        public async Task<IActionResult> GetCatalogFile(int custId, int fileId)
        {
            var catalogFile = await _dbContext.CatalogFile
                .Include(rec => rec.PubCatalogItem)
                .SingleOrDefaultAsync(rec => rec.CustId == custId && rec.FileId == fileId);

            if (catalogFile == null)
                return NotFound($"CatalogFile with CustId:{custId} and FileId:{fileId} not found!");

            return Ok(catalogFile);
        }

        [HttpGet("catalogfilelist/{custId}")]
        public async Task<IActionResult> GetCatalogFilesList(int custId)
        {
            var catalogFiles = await _dbContext.CatalogFile
                .Where(rec => rec.CustId == custId)
                .Include(rec => rec.PubCatalogItem)
                .ThenInclude(rec => rec.StatusNavigation)
                .Include(rec => rec.StatusNavigation)
                .ToListAsync();
            

            return Ok(catalogFiles);
        }

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

                string[] excludedFields = {"CustId", "FileId", "UserId", "Status"};

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
                        return BadRequest("Unsupported RHolderType!");
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
            catch
            {
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
            catch
            {
                transaction?.Rollback();
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
            catch
            {
                transaction?.Rollback();
                throw;
            }
            finally
            {
                transaction?.Dispose();
            }
        }

        [HttpPut("validate/{fileId}")]
        public async Task<IActionResult> BeginValidationFile(int fileId )
        {
            try
            {
                await _dbContext.Database.ExecuteSqlCommandAsync("exec CatalogControlPub @fileId", new SqlParameter("@fileId", fileId ) );

                var valiCatalog = await _dbContext.CatalogFile
                                    .Include(rec => rec.PubCatalogItem)
                                        .ThenInclude(pub => pub.StatusNavigation)
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync(rec => rec.FileId == fileId);
                return Ok(valiCatalog);
            }
            catch
            {
                throw;
            }

        }

        [HttpPut("process/{fileId}")]
        public async Task<IActionResult> BeginProcessFile(int fileId)
        {
            try
            {
                await _dbContext.Database.ExecuteSqlCommandAsync("exec CatalogInputPub @fileId", new SqlParameter("@fileId", fileId));

                var valiCatalog = await _dbContext.CatalogFile
                                    .Include(rec => rec.PubCatalogItem)
                                        .ThenInclude(pub => pub.StatusNavigation)
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync(rec => rec.FileId == fileId);
                return Ok(valiCatalog);
            }
            catch
            {
                throw;
            }

        }

    }
}