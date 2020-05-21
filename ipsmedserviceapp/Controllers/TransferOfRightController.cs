using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using IpsCommonTypes.Types;
using ipsmedserviceapp.Extensions;
using ipsmedserviceapp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ipsmedserviceapp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransferOfRightController : ControllerBase
    {
        private readonly MediaServiceContext _dbContext;
        
        public TransferOfRightController(MediaServiceContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Отримати список правовласників
        /// </summary>
        /// <returns></returns>
        [HttpGet("list/rightholders/default")]
        public async Task<IActionResult> GetTransferDefaultRightholdersList()
        {
            try
            {
                string query = $"select * from vTsk_1_TransferRightHolders where isHeritage = 0";
                
                List<object[]> list = null;
                
                await Task.Factory.StartNew(() => list = ExecuteQuery.GetDataFromSqlServer(_dbContext.Database, query));
                
                return Ok(list);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        /// <summary>
        /// Отримати список правовласників для передачі спадщини
        /// </summary>
        /// <returns></returns>
        [HttpGet("list/rightholders/heritage")]
        public async Task<IActionResult> GetTransferHeritageRightholdersList()
        {
            try
            {
                string query = $"select * from vTsk_1_TransferRightHolders where isHeritage = 1";

                List<object[]> list = null;

                var a = await Task.Factory.StartNew(() => list = ExecuteQuery.GetDataFromSqlServer(_dbContext.Database, query));

                return Ok(list);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        [HttpGet("list/rightholders/pubsub")]
        public async Task<IActionResult> GetRightholdersPubSubList()
        {
            try
            {

                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        [HttpGet("list/objectsright/{custIdPub}/{custIdSub}")]
        public async Task<IActionResult> GetObjectsRightList(int custIdPub, int custIdSub)
        {
            try
            {

                return Ok();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Отримати список об'єктів правовласника по ID для передачі прав
        /// </summary>
        /// <param name="custId"></param>
        /// <returns></returns>
        [HttpGet("list/objects/{custId}")]
        public async Task<IActionResult> GetObjectsForTransfer(int custId)
        {
            try
            {
                ObjectsForTransferInfo data = new ObjectsForTransferInfo();
                using (SqlConnection sqlConnection = (SqlConnection)_dbContext.Database.GetDbConnection())
                {
                    string query = $"select * from vtsk_3_OR_03_Transfer where custId = {custId}";
                    var datarows = await Task.Factory.StartNew(() => ExecuteQuery.GetDataFromSqlServer(sqlConnection, query));

                    string infoQuery = $"select * from vTsk_3_ObjectsCopyright where custId = {custId}";
                    var infodata = await Task.Factory.StartNew(() => ExecuteQuery.GetDataFromSqlServer(sqlConnection, infoQuery));

                    data.TransferObjects = datarows;
                    data.CopyrightsOfObjects = infodata;
                }

                return Ok(data);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        /// <summary>
        /// Звичайна передача прав правовласників
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        [HttpPut("transfer/default")]
        public async Task<IActionResult> TransferRightsOfObjectsDetault([FromBody] ObjectTransferDataParameters parameters)
        {
            IDbContextTransaction transaction = null;
            ResponseOfRequest response;
            try
            {
                var targetCopyRightList = new List<CopyRight>();
                var targetCRHistoryList = new List<CopyRightHistory>();
                var targetAuthorsList = new List<Authors>();
                var maxDate = new DateTime(3000, 01, 01);

                var ids = parameters.TransferObjects.Select(rec => rec.ParentCRightId.Value).ToArray();

                var copyrightlist = await _dbContext.CopyRight.Where(rec => ids.Contains(rec.CRightId)).ToListAsync();

                foreach (var copyRight in copyrightlist)
                {
                    var obj = parameters.TransferObjects.Single(rec => rec.ParentCRightId == copyRight.CRightId);

                    foreach (var rightholder in obj.TransferRightholders)
                    {
                        var newCopyRight = new CopyRight
                        {
                            CustId = rightholder.CustId,
                            Rate = rightholder.Rate,

                            ObjId = obj.ObjId,
                            ParentId = obj.ParentCRightId,
                            // CreativeRoleType
                            // 8 Правовласник
                            RoleCode = 8,
                            BeginDate = parameters.BeginDate,
                            EndDate = parameters.EndDate,
                            Status = copyRight.Status,
                            LBasis = parameters.LegalBasis,

                            CreateDate = DateTime.Now,
                            ModifyLogin = parameters.UserName,
                        };

                        targetCopyRightList.Add(newCopyRight);

                        targetCRHistoryList.Add(new CopyRightHistory
                        {
                            Rate = rightholder.Rate,
                            Parent = copyRight,
                            Child = newCopyRight,
                        });

                        var exist = _dbContext.Authors.Any(rec => rec.CustId == rightholder.CustId && rec.ObjId == obj.ObjId);
                        if (!exist)
                        {
                            var customer = await _dbContext.vCustomer.FirstOrDefaultAsync(rec => rec.CustId == rightholder.CustId);
                            targetAuthorsList.Add(new Authors
                            {
                                CustId = rightholder.CustId,
                                ObjId = obj.ObjId,
                                AuthorName = customer.name,
                                FolkType = 1,
                                RoleCode = 8,
                            });
                        }
                    }

                    // new copyright for current 
                    if (obj.RemainderRate != 0m)
                    {
                        var currentCopyRight = new CopyRight
                        {
                            CustId = copyRight.CustId,
                            ObjId = copyRight.ObjId,

                            Rate = obj.RemainderRate,
                            RateMech = copyRight.RateMech,

                            ParentId = copyRight.CRightId,
                            RoleCode = copyRight.RoleCode,

                            BeginDate = parameters.BeginDate,
                            EndDate = parameters.EndDate,

                            Status = copyRight.Status,
                            LBasis = parameters.LegalBasis,

                            CreateDate = DateTime.Now,
                            ModifyLogin = parameters.UserName,
                        };

                        targetCopyRightList.Add(currentCopyRight);

                        targetCRHistoryList.Add(new CopyRightHistory
                        {
                            Rate = currentCopyRight.Rate,
                            Parent = copyRight,
                            Child = currentCopyRight,
                        });
                    }

                    // returned copyright
                    if (parameters.EndDate != maxDate)
                    {
                        var returnCopyright = new CopyRight
                        {
                            CustId = copyRight.CustId,
                            ObjId = copyRight.ObjId,

                            Rate = copyRight.Rate,
                            RateMech = copyRight.RateMech,

                            ParentId = copyRight.CRightId,
                            RoleCode = copyRight.RoleCode,

                            BeginDate = parameters.EndDate.Value.AddDays(1),
                            EndDate = copyRight.EndDate,

                            Status = copyRight.Status,
                            LBasis = parameters.LegalBasis,

                            CreateDate = DateTime.Now,
                            ModifyLogin = parameters.UserName,
                            LBasisComment = "returning copyright",
                        };

                        targetCopyRightList.Add(returnCopyright);

                        foreach (var copyRightHistory in targetCRHistoryList.Where(rec => rec.Parent.CRightId == copyRight.CRightId).ToList())
                        {
                            targetCRHistoryList.Add(new CopyRightHistory
                            {
                                Rate = copyRightHistory.Rate,
                                Parent = copyRightHistory.Child,
                                Child = returnCopyright,
                            });
                        }
                    }

                    copyRight.EndDate = parameters.BeginDate.AddDays(-1);
                    copyRight.ModifyDate = DateTime.Now;
                    copyRight.ModifyLogin = parameters.UserName;
                }

                transaction = _dbContext.Database.BeginTransaction();

                if (targetAuthorsList.Any())
                    await _dbContext.Authors.AddRangeAsync(targetAuthorsList);
                
                await _dbContext.CopyRight.AddRangeAsync(targetCopyRightList);
                await _dbContext.CopyRightHistory.AddRangeAsync(targetCRHistoryList);
                await _dbContext.SaveChangesAsync();

                transaction.Commit();

                response = new ResponseOfRequest("Предачу прав виконано!");
                return Ok(response);
            }
            catch (Exception e)
            {
                transaction?.Rollback();

                response = new ResponseOfRequest("Неможливо виконати передачу прав!", e);
                return BadRequest(response);
            }
        }

        /// <summary>
        /// Передача прав через спадщину
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        [HttpPut("transfer/heritage")]
        public async Task<IActionResult> TransferRightsOfObjectsHeritage([FromBody] ObjectTransferDataParameters parameters)
        {
            IDbContextTransaction transaction = null;
            ResponseOfRequest response;
            try
            {
                var targetCopyRightList = new List<CopyRight>();
                var targetCRHistoryList = new List<CopyRightHistory>();
                var targetAuthorsList = new List<Authors>();

                var ids = parameters.TransferObjects.Select(rec => rec.ParentCRightId.Value).ToArray();

                var copyrightlist = await _dbContext.CopyRight.Where(rec => ids.Contains(rec.CRightId)).ToListAsync();
                
                foreach (var copyRight in copyrightlist)
                {
                    var obj = parameters.TransferObjects.Single(rec => rec.ParentCRightId == copyRight.CRightId && rec.RoleCode == copyRight.RoleCode);

                    if (DateTime.Today.Date > parameters.BeginDate.AddDays(-1).Date)
                    {
                        response = new ResponseOfRequest
                        {
                            IsSuccess = false,
                            Message = "Нові права можуть вступити в силу не раніше завтрішнього дня!",
                        };
                        return BadRequest(response);
                    }

                    if (parameters.BeginDate.Date > copyRight.EndDate.Value.Date)
                    {
                        response = new ResponseOfRequest
                        {
                            IsSuccess = false,
                            Message = $"Дата початку дії нових прав перевищує дату завершення дії поточних прав!\nID об'єкта:{obj.ObjId}, ID-CR:{obj.ParentCRightId}",
                        };
                        return BadRequest(response);
                    }

                    foreach (var rightholder in obj.TransferRightholders)
                    {
                        var newCopyRight = new CopyRight
                        {
                            CustId = rightholder.CustId,
                            Rate = rightholder.Rate,
                            
                            ObjId = obj.ObjId,
                            ParentId = obj.ParentCRightId,
                            // CreativeRoleType
                            // 8 Правовласник
                            RoleCode = 8,
                            BeginDate = parameters.BeginDate,
                            // передача в спадок
                            EndDate = copyRight.EndDate,
                            Status = copyRight.Status,
                            LBasis = parameters.LegalBasis,

                            CreateDate = DateTime.Now,
                            ModifyLogin = parameters.UserName,
                        };

                        targetCopyRightList.Add(newCopyRight);

                        targetCRHistoryList.Add(new CopyRightHistory
                        {
                            Rate = rightholder.Rate,
                            Parent = copyRight,
                            Child = newCopyRight,
                        });

                        var exist = _dbContext.Authors.Any(rec => rec.CustId == rightholder.CustId && rec.ObjId == obj.ObjId);
                        if (!exist)
                        {
                            var customer = await _dbContext.vCustomer.FirstOrDefaultAsync(rec => rec.CustId == rightholder.CustId);
                            targetAuthorsList.Add(new Authors
                            {
                                CustId = rightholder.CustId,
                                ObjId = obj.ObjId,
                                AuthorName = customer.name,
                                FolkType = 1,
                                RoleCode = 8,
                            });
                        }
                    }

                    copyRight.EndDate = parameters.BeginDate.AddDays(-1);
                    copyRight.ModifyDate = DateTime.Now;
                    copyRight.ModifyLogin = parameters.UserName;
                }


                transaction = _dbContext.Database.BeginTransaction();

                if (targetAuthorsList.Any())
                    await _dbContext.Authors.AddRangeAsync(targetAuthorsList);

                await _dbContext.CopyRight.AddRangeAsync(targetCopyRightList);
                await _dbContext.CopyRightHistory.AddRangeAsync(targetCRHistoryList);
                await _dbContext.SaveChangesAsync();

                transaction.Commit();

                response = new ResponseOfRequest("Предачу прав виконано!");
                return Ok(response);
            }
            catch (Exception e)
            {
                transaction?.Rollback();
                
                response = new ResponseOfRequest("Неможливо виконати передачу прав!", e);
                return BadRequest(response);
            }
        }
    }
}