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

        [HttpGet("filelist/{custId}")]
        public async Task<IActionResult> GetCatalogFilesList(int custId)
        {
            var catalogFile = new List<CatalogFile>
            {
                new CatalogFile
                {
                    CustId = 100,
                    FileId = 100,
                    FileName = "FileName",
                    PubСatalogItem = new List<PubСatalogItem>
                    {
                        new PubСatalogItem
                        {
                            CustId = 100,
                            FileId = 100,
                            ObjName = "Name1"
                        },
                        new PubСatalogItem
                        {
                            CustId = 100,
                            FileId = 100,
                            ObjName = "Name2"
                        },
                        new PubСatalogItem
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
                .Include(rec => rec.PubСatalogItem).ToListAsync();
            

            return Ok(catalogFile);
        }

        [HttpPost("upload/{custId}")]
        public async Task<IActionResult> UploadFile(int custId, [FromBody] CatalogFile source)
        {
            IDbContextTransaction transaction = null;
            try
            {
                if (source == null || !source.PubСatalogItem.Any())
                    return BadRequest("Loaded file is empty or not read!");

                if (_dbContext.RightHolder.SingleOrDefault(rec => rec.CustId == custId) == null)
                    return NotFound($"RightHolder with ID:{custId} not found!");

                //if (string.IsNullOrEmpty(source.UserId))
                //    return Unauthorized();

                string[] excludedFields = {"CustId", "FileId", "UserId"};
                var destination = new CatalogFile
                {
                    CustId = custId,
                    UserId = User.Identity.Name,
                    PubСatalogItem = new List<PubСatalogItem>()
                };
                destination.SetFields(source, excludedFields);

                foreach (var item in source.PubСatalogItem)
                {
                    var pubСatalogItem = new PubСatalogItem
                    {
                        CustId = destination.CustId,
                    };
                    pubСatalogItem.SetFields(item, excludedFields);
                    destination.PubСatalogItem.Add(pubСatalogItem);
                }

                await _dbContext.CatalogFile.AddAsync(destination);
                //await _dbContext.PubСatalogItem.AddRangeAsync(destination.PubСatalogItem);

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
                    .Include(rec => rec.PubСatalogItem)
                    .SingleOrDefaultAsync(rec => rec.CustId == custId && rec.FileId == fileId);

                if (catalogFile == null)
                    return NotFound($"CatalogFile with CustId: {custId} and FileId: {fileId} not found!");

                _dbContext.PubСatalogItem.RemoveRange(catalogFile.PubСatalogItem);
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