using System;
using System.Collections.Generic;
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
            var catalogFile = new List<CatalogFile>
            {
                new CatalogFile
                {
                    CustId = 100,
                    FileId = 100,
                    FileName = "FileName",
                    PubCatalogItem = new List<PubCatalogItem>
                    {
                        new PubCatalogItem
                        {
                            CustId = 100,
                            FileId = 100,
                            ObjName = "Name1"
                        },
                        new PubCatalogItem
                        {
                            CustId = 100,
                            FileId = 100,
                            ObjName = "Name2"
                        },
                        new PubCatalogItem
                        {
                            CustId = 100,
                            FileId = 100,
                            ObjName = "Name3"
                        },
                    }
                }
            };

            var catalogFiles = await _dbContext.CatalogFile
                .Where(rec => rec.CustId == custId)
                .Include(rec => rec.PubCatalogItem).ToListAsync();
            

            return Ok(catalogFile);
        }

        [HttpPost("upload/{custId}")]
        public async Task<IActionResult> UploadFile(int custId, [FromBody] CatalogFile source)
        {
            IDbContextTransaction transaction = null;
            try
            {
                if (source == null || !source.PubCatalogItem.Any())
                    return BadRequest("Loaded file is empty or not read!");

                var rightholder = _dbContext.RightHolder.SingleOrDefault(rec => rec.CustId == custId);
                if (rightholder == null)
                    return NotFound($"RightHolder with ID:{custId} not found!");

                string[] excludedFields = {"CustId", "FileId", "UserId"};

                var destination = new CatalogFile
                {
                    CustId = custId,
                    UserId = User.Identity.Name,
                    PubCatalogItem = new List<PubCatalogItem>()
                };
                destination.SetFields(source, excludedFields);

                switch (rightholder.RHolderType)
                {
                    // видавництво
                    case 3:
                        foreach (var item in source.PubCatalogItem)
                        {
                            var PubCatalogItem = new PubCatalogItem
                            {
                                CustId = destination.CustId,
                            };
                            PubCatalogItem.SetFields(item, excludedFields);
                            destination.PubCatalogItem.Add(PubCatalogItem);
                        }
                        break;

                    // правовласник
                    case 1:
                        break;

                    // інші RHolderType
                    default:
                        return BadRequest("Unsupported RHolderType!");
                }

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

        public async Task<IActionResult> BeginValidationFile([FromBody] CatalogFile catalogFile)
        {
            IDbContextTransaction transaction = null;
            try
            {

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


    }
}