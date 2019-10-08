using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.DirectoryServices.AccountManagement;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using IpsCommonTypes.Enums;
using ipsmedserviceapp.Model;
using IpsCommonTypes.Wrappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace ipsmedserviceapp.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : Controller
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
                //.Include(rec => rec.PubCatalogItem)
                //    .ThenInclude(rec => rec.StatusNavigation)
                .SingleOrDefaultAsync(rec => rec.CustId == custId && rec.FileId == fileId);

            if (catalogFile == null)
                return NotFound($"CatalogFile with CustId:{custId} and FileId:{fileId} not found!");

            return Ok(catalogFile);
        }

        [HttpGet("catalogfileitems/{fileId}/{skip}/{take}")]
        public async Task<IActionResult> GetCatalogFileItems(int fileId, int skip, int take)
        {
            var list = await _dbContext.PubCatalogItem
                .Where(rec => rec.FileId == fileId)
                .Skip(skip).Take(take)
                .ToListAsync();

            return Ok(list);
        }

        /// <summary>
        /// Отримати дані для експорту
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        [HttpGet("exportdata/{fileId}")]
        public IActionResult GetDataForExport(int fileId)
        {
            try
            {
                DataTable table;
                string query = "select itemCode, iswc, objName, genreName, performer, authorMusic, authorText, roleName, rhName, rate, dateBegin, dateEnd, errComment from PubCatalogItem";
                query += $" where fileId = {fileId}";
                using (SqlConnection sqlConnection = (SqlConnection)_dbContext.Database.GetDbConnection())
                {
                    sqlConnection.Open();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(query, sqlConnection);

                    DataSet dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet);

                    table = dataSet.Tables[0];
                }

                var list = new List<object[]>();
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    var row = table.Rows[i].ItemArray;
                    list.Add(row);
                }

                return Ok(list);
            }
            catch (Exception e)
            {
                _logger.LogError(e.ToString());
                throw;
            }
        }

        [DisableRequestSizeLimit]
        [HttpPost("upload/{custId}")]
        public async Task<IActionResult> UploadFile(int custId, [FromBody] CatalogFile source)
        {
            int? catalogFileLoadedId = null;
            var currentTimeOut = _dbContext.Database.GetCommandTimeout();
            try
            {
                _dbContext.Database.SetCommandTimeout(3200);
                if (source == null || !source.PubCatalogItem.Any())
                    return BadRequest("Loaded file is empty or not read!");

                var vcustomer = await _dbContext.vCustomer.SingleOrDefaultAsync(rec => rec.CustId == custId);

                var rightholder = await _dbContext.RightHolder.SingleOrDefaultAsync(rec => rec.CustId == custId);
                if (rightholder == null)
                    return BadRequest($"RightHolder with ID:{custId} not found!");

                string[] excludedFields = { "CustId", "FileId", "UserId", "Status" };

                var target = new CatalogFile
                {
                    CustId = custId,
                    UserId = source.UserId ?? "system",
                    Status = 0,
                    PubCatalogItem = new List<PubCatalogItem>()
                };
                target.SetFields(source, excludedFields);
                target.CustName = vcustomer?.name;
                target.CreateDate = DateTime.Now;

                if (rightholder.RHolderType == 3)
                    target.RhType = 3;

                target.CountZap = source.PubCatalogItem.Count;

                // save target
                _dbContext.CatalogFile.Add(target);
                _dbContext.SaveChanges();
                catalogFileLoadedId = target.FileId;

                //var connectionString = _dbContext.Database.GetDbConnection().ConnectionString;

                //using (var sqlConnection = new SqlConnection(connectionString))
                using (SqlConnection sqlConnection = (SqlConnection)_dbContext.Database.GetDbConnection())
                {
                    sqlConnection.Open();
                    using (var bulkCopy = new SqlBulkCopy(sqlConnection))
                    {
                        bulkCopy.DestinationTableName = nameof(PubCatalogItem);

                        DataTable dataTable = new DataTable(nameof(PubCatalogItem));

                        DataColumn[] dataColumns =
                        {
                                new DataColumn("itemId", typeof(int)),
                                new DataColumn("fileId", typeof(int)),
                                new DataColumn("cRightId", typeof(int)),
                                new DataColumn("custId", typeof(int)),
                                new DataColumn("itemCode", typeof(string)),
                                new DataColumn("iswc", typeof(string)),
                                new DataColumn("objName", typeof(string)),
                                new DataColumn("genreName", typeof(string)),
                                new DataColumn("roleName", typeof(string)),
                                new DataColumn("rate", typeof(decimal)),
                                new DataColumn("authorMusic", typeof(string)),
                                new DataColumn("authorText", typeof(string)),
                                new DataColumn("performer", typeof(string)),
                                new DataColumn("comment", typeof(string)),
                                new DataColumn("objId", typeof(int)),
                                new DataColumn("genreCode", typeof(int)),
                                new DataColumn("roleCode", typeof(int)),
                                new DataColumn("status", typeof(int)),
                                new DataColumn("errComment", typeof(string)),
                                new DataColumn("rhName", typeof(string)),
                                new DataColumn("dateBegin", typeof(DateTime)),
                                new DataColumn("dateEnd", typeof(DateTime)),
                            };

                        dataTable.Columns.AddRange(dataColumns);

                        foreach (var item in source.PubCatalogItem)
                        {
                            DataRow row = dataTable.NewRow();
                            row.ItemArray = new object[]
                            {
                                    null,
                                    target.FileId,
                                    null,
                                    target.CustId,
                                    item.ItemCode,
                                    item.Iswc,
                                    item.ObjName,
                                    item.GenreName,
                                    item.RoleName,
                                    item.Rate,
                                    item.AuthorMusic,
                                    item.AuthorText,
                                    item.Performer,
                                    null,
                                    null,
                                    null,
                                    null,
                                    0,
                                    null,
                                    item.RhName,
                                    item.DateBegin,
                                    item.DateEnd
                            };

                            dataTable.Rows.Add(row);
                        }

                        bulkCopy.WriteToServer(dataTable);
                    }
                }

                if (currentTimeOut.HasValue)
                    _dbContext.Database.SetCommandTimeout(currentTimeOut);

                return Ok(target);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());

                if (catalogFileLoadedId.HasValue)
                {
                    var removeItems = _dbContext.PubCatalogItem.Where(rec => rec.FileId == catalogFileLoadedId.Value).ToList();
                    _dbContext.PubCatalogItem.RemoveRange(removeItems);

                    var removeCatalogFile = _dbContext.CatalogFile.SingleOrDefault(rec => rec.FileId == catalogFileLoadedId.Value);
                    if (removeCatalogFile != null)
                        _dbContext.CatalogFile.Remove(removeCatalogFile);

                    _dbContext.SaveChanges();
                }
                throw;
            }
        }

        [HttpDelete("delete/{custId}/{fileId}")]
        public async Task<IActionResult> DeleteCatalogFile(int custId, int fileId)
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

                string command = "exec CatalogFileDelete @fileId, @result OUTPUT, @RetCode OUTPUT";

                await _dbContext.Database.ExecuteSqlCommandAsync(command, paramFileId, message, returnCode);

                var responce = new ExecSqlResponce
                {
                    Message = message.Value.ToString(),
                    StatusCode = Convert.ToInt32(returnCode.Value) == 0
                        ? ExecSqlResponceStatus.Successed
                        : ExecSqlResponceStatus.Failed
                };

                return Ok(responce);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
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
            var currentTimeOut = _dbContext.Database.GetCommandTimeout();
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

                _dbContext.Database.SetCommandTimeout(1200);

                await _dbContext.Database.ExecuteSqlCommandAsync(command, paramFileId, message, returnCode);

                var responce = new ExecSqlResponce<CatalogFile>
                {
                    Message = message.Value.ToString(),
                    StatusCode = Convert.ToInt32(returnCode.Value) == 0
                        ? ExecSqlResponceStatus.Successed
                        : ExecSqlResponceStatus.Failed
                };

                var validCatalog = await _dbContext.CatalogFile
                    //.Include(rec => rec.PubCatalogItem)
                    //.ThenInclude(pub => pub.StatusNavigation)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(rec => rec.FileId == fileId);
                responce.Data = validCatalog;

                if (currentTimeOut.HasValue)
                    _dbContext.Database.SetCommandTimeout(currentTimeOut);

                return Ok(responce);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
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
            var currentTimeOut = _dbContext.Database.GetCommandTimeout();
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
                _dbContext.Database.SetCommandTimeout(1200);

                await _dbContext.Database.ExecuteSqlCommandAsync(command, paramFileId, message, returnCode);

                var responce = new ExecSqlResponce<CatalogFile>
                {
                    Message = message.Value.ToString(),
                    StatusCode = Convert.ToInt32(returnCode.Value) == 0
                        ? ExecSqlResponceStatus.Successed
                        : ExecSqlResponceStatus.Failed
                };

                var validCatalog = await _dbContext.CatalogFile
                    //.Include(rec => rec.PubCatalogItem)
                    //.ThenInclude(pub => pub.StatusNavigation)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(rec => rec.FileId == fileId);
                responce.Data = validCatalog;

                if (currentTimeOut.HasValue)
                    _dbContext.Database.SetCommandTimeout(currentTimeOut);

                return Ok(responce);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }
    }
}