using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ipsmedserviceapp.Controllers.Resources;
using ipsmedserviceapp.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

// URLs:
// community/
namespace ipsmedserviceapp.Controllers
{
    [Produces("application/json")]
    [Route("api/community")]
    public class CommunityController : Controller
    {
        private readonly MediaServiceContext _dbContext;
        private IConfiguration _config;
        public CommunityController(MediaServiceContext dbContext, IConfiguration config)
        {
            _dbContext = dbContext;
            _config = config;
        }

        // списк view
        private readonly Dictionary<string, string> _communityViewList = new Dictionary<string, string>
        {
            // список спільнот
            {"vTsk_1_ListCommunity", "vTsk_1_ListCommunity"},
            {"vTsk_1_ListRHCommunity", "vTsk_1_ListRHCommunity"},

        };

        private readonly Dictionary<string, string> _columnNames = new Dictionary<string, string>
        {
            {"cmCustId", "cmCustId"}
        };

        /// <summary>
        /// Повернути дані обраної VIEW 
        /// </summary>
        /// <param name="viewName"></param>
        /// <param name="paramId"></param>
        /// <param name="columnName"></param>
        /// <param name="queryResource"></param>
        /// <returns></returns>
        [HttpGet("list/view")]
        public async Task<IActionResult> GetCommunityList([FromQuery] string viewName, [FromQuery] int? paramId, [FromQuery] string columnName)
        {
            if (viewName == null || !_communityViewList.Keys.Contains(viewName))
                return BadRequest();

            string queryStr = string.Concat("select * from ", _communityViewList[viewName]);
            // Немає параметру по Споживачу
            if (paramId == null)
            {
                var list = await _dbContext.getViewData(queryStr, null);
                var data = list.Take(1000);
                return Json(data);
            }
            else
            {
                queryStr = string.Concat(queryStr, " where " + _columnNames[columnName] + " = @paramId");
                //queryStr = string.Concat(queryStr, " where custId = @paramId");
                var list = await _dbContext.getViewData(queryStr, new[] { new SqlParameter("@paramId", paramId) });
                return Json(list);
            }
        }

        /// <summary>
        /// Повернути дані обраної VIEW 
        /// </summary>
        /// <param name="viewName"></param>
        /// <param name="queryResource"></param>
        /// <returns></returns>
        [HttpGet("list/rhview/{viewName}")]
        public async Task<IActionResult> GetCommunityList(string viewName, [FromQuery] RightholdersQueryResource queryResource)
        {
            if (viewName == null || !_communityViewList.Keys.Contains(viewName))
                return BadRequest();

            string queryStr = string.Concat("select * from ", _communityViewList[viewName]);

            // where conditions
            if (!string.IsNullOrEmpty(queryResource.SearchText))
            {
                string normalizeText = queryResource.SearchText.Replace('\'', '_');
                string where = $" where name like '%{normalizeText}%' or innerCode like '{normalizeText}%' or interCode like '{normalizeText}%'";
                queryStr = string.Concat(queryStr, where);
            }

            var totalItems = (await _dbContext.getViewData(queryStr.Replace("*", "count(*)"), null)).FirstOrDefault()?.Values.FirstOrDefault();

            int page = 1;
            int pageSize = 200;

            if (queryResource.Page.HasValue)
                page = (int) queryResource.Page;

            if (queryResource.PageSize.HasValue)
                pageSize = (int) queryResource.PageSize;

            // paging conditions
            string orderBy = $" ORDER BY custId OFFSET {(page - 1) * pageSize} ROWS FETCH NEXT {pageSize} ROWS ONLY";
            queryStr = string.Concat(queryStr, orderBy);

            var list = await _dbContext.getViewData(queryStr, null);

            return Ok(new
            {
                List = list,
                TotalItems = totalItems
            });
        }

        /// <summary>
        /// отримати всі дані по спільноті
        /// </summary>
        /// <param name="custId"></param>
        /// <returns></returns>
        [HttpGet("list/{custId}")]
        public async Task<IActionResult> GetCommunity(int custId)
        {
            var community = await _dbContext.Customer.Where(rec => rec.CustId == custId)
                .Include(item => item.Company).ThenInclude(ank => ank.AnketaCompany)
                .Include(item => item.Company).ThenInclude(relempl => relempl.RelEmployee).ThenInclude(empl => empl.Empl)
                .Include(item => item.AgreementMaster)
                .Include(item => item.BankAccount)
                .Include(item => item.Community).ThenInclude(agr => agr.AgreementAddCommunity)
                .SingleOrDefaultAsync();
            return Json(community);
        }

        /// <summary>
        /// створити шаблон для створення нової спільноти
        /// </summary>
        /// <returns></returns>
        [HttpGet("template")]
        public IActionResult GetCommunityTemplate()
        {
            try
            {
                var communityCustomer = GetTemplate();
                return Json(communityCustomer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Зберегти нову спільноту
        /// </summary>
        /// <param name="sourceCustomer"></param>
        /// <returns></returns>
        [HttpPost("createcommunity")]
        public async Task<IActionResult> SaveCommunity([FromBody] Customer sourceCustomer)
        {
            IDbContextTransaction tran = null;
            try
            {
                if (sourceCustomer == null)
                    throw new Exception("New comunity object is empty!");
                if (!(sourceCustomer.CustType > 0 && sourceCustomer.CustType < 4))
                    throw new Exception("Bad customer type for new comunity");

                var newCommunity = new Customer();
                // Збереження Customer
                newCommunity.SetFields(sourceCustomer, new[] { "CustId" });

                _dbContext.Customer.Add(newCommunity);

                SyncCommunityObjects(sourceCustomer, newCommunity);

                tran = _dbContext.Database.BeginTransaction();
                _dbContext.SaveChanges();
                tran.Commit();
                tran = null;

                return Ok(await GetCommunity(newCommunity.CustId));
            }
            catch (Exception ex)
            {
                tran?.Rollback();
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Оновити дані спільноти
        /// </summary>
        /// <param name="custId"></param>
        /// <param name="sourceCustomer"></param>
        /// <returns></returns>
        [HttpPut("updatecommunity/{custId}")]
        public async Task<IActionResult> UpdateCommunity(int custId, [FromBody] Customer sourceCustomer)
        {
            var destination = await _dbContext.Customer.Where(rec => rec.CustId == custId)
                .Include(item => item.Company).ThenInclude(ank => ank.AnketaCompany)
                .Include(item => item.Company).ThenInclude(relempl => relempl.RelEmployee).ThenInclude(empl => empl.Empl)
                .Include(item => item.AgreementMaster)
                .Include(item => item.BankAccount)
                .Include(item => item.Community).ThenInclude(agr => agr.AgreementAddCommunity)
                .SingleOrDefaultAsync();

            IDbContextTransaction tran = null;
            try
            {
                // Customer
                SyncCommunityObjects(sourceCustomer, destination);

                tran = _dbContext.Database.BeginTransaction();
                _dbContext.SaveChanges();
                tran.Commit();
                tran = null;

                return Json(destination);
            }
            catch (Exception ex)
            {
                tran?.Rollback();
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Отримати список правовласників для обраної спільноти
        /// </summary>
        /// <param name="custId"></param>
        /// <returns></returns>
        [HttpGet("cmautors/{custId}")]
        public async Task<IActionResult> GetCommunityAutorsListById(int custId)
        {
            try
            {
                var cmRights = await _dbContext.CustCmRight.Where(items => items.CustId == custId).ToListAsync();
                return Json(cmRights);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Зберегти змінені обмеження прав
        /// </summary>
        /// <param name="cmCustId"></param>
        /// <param name="custId"></param>
        /// <param name="sourceList"></param>
        /// <returns></returns>
        [HttpPut("lrightsupd/{cmCustId}/{custId}")]
        public async Task<IActionResult> SaveLimitRights(int cmCustId, int custId, [FromBody] List<CustCmRight> sourceList)
        {
            //int[] workedCustId = sourceList.Select(rec => rec.CustId).Distinct().ToArray();
            int[] workedCRkindCode = sourceList.Select(rec => rec.CRkindCode).Distinct().ToArray();

            Expression<Func<CustCmRight, bool>> predicate = rec => rec.CmCustId == cmCustId && rec.CustId == custId;
            
            var destinationList = await _dbContext.CustCmRight
                .Where(predicate)
                .Include(rec => rec.C)
                .ToListAsync();

            var termOfService = await _dbContext.TermsOfService
                .Where(rec => rec.CustId == custId && workedCRkindCode.Contains(rec.CrkindCode))
                .ToArrayAsync();

            try
            {
                // remove
                var removeList = destinationList
                    .Where(dest => !sourceList.Any(sors => sors.CmCustId == dest.CmCustId 
                                                        && sors.CRkindCode == dest.CRkindCode 
                                                        && sors.CustId == dest.CustId)).ToList();
                removeList.ForEach(item =>
                {
                    item.C.OurService = true;
                    destinationList.Remove(item);
                    _dbContext.CustCmRight.Remove(item);
                });

                // update
                var updList = destinationList
                    .Where(dest => sourceList.Any(sors => sors.CmCustId == dest.CmCustId
                                                       && sors.CRkindCode == dest.CRkindCode 
                                                       && sors.CustId == dest.CustId)).ToList();
                var sourceDict = sourceList.Where(rec => rec.CmCustId != 0).ToDictionary(rec => rec.CRkindCode);
                updList.ForEach(item =>
                {
                    var sourceItem = sourceDict[item.CRkindCode];
                    item.SetFields(sourceItem);
                });

                // add new
                var addList = sourceList
                    .Where(sors => !destinationList.Any(dest => dest.CustId == sors.CustId 
                                                             && dest.CRkindCode == sors.CRkindCode 
                                                             && dest.CmCustId == sors.CmCustId)).ToList();
                addList.ForEach(item =>
                {
                    var right = new CustCmRight
                    {
                        CmCustId = cmCustId
                    };
                    right.SetFields(item, new []{ "CmCustId" });

                    //destinationList.Add(right);
                    _dbContext.CustCmRight.Add(right);
                    var terms = termOfService.FirstOrDefault(r => r.CustId == item.CustId && r.CrkindCode == item.CRkindCode);
                    if (terms != null)
                        terms.OurService = false;
                });

                // check exist CustCmRight and delete
                var crKindCode = addList.Select(rec => rec.CRkindCode).ToList();
                var existCustCmRight = _dbContext.CustCmRight
                    .Where(rec => rec.CustId == custId && rec.CmCustId != cmCustId && crKindCode.Contains(rec.CRkindCode)).ToList();
                if (existCustCmRight.Any())
                    _dbContext.CustCmRight.RemoveRange(existCustCmRight);


                _dbContext.SaveChanges();

                return Json(destinationList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Зміна статусу договору спільноти
        /// </summary>
        /// <param name="communityId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpPut("agrstatuschange/{communityId}/{status}")]
        public async Task<IActionResult> ChangeAgreementStatus(int communityId, int status)
        {
            IDbContextTransaction tran = null;
            try
            {
                var agrMaster = await _dbContext.AgreementMaster.SingleOrDefaultAsync(rec => rec.CustId == communityId);
                var agrAdd = await _dbContext.AgreementAddCommunity.SingleOrDefaultAsync(rec=>rec.CustId == communityId);

                agrMaster.AgrStatus = status;
                agrAdd.AgrStatus = status;

                tran = _dbContext.Database.BeginTransaction();
                _dbContext.SaveChanges();
                tran.Commit();
                tran = null;

                return Ok();
            }
            catch (Exception ex)
            {
                tran?.Rollback();
                return BadRequest(ex.Message);
            }
        }

        #region Винесені методи та додаткові методи синхронізацій

        /// <summary>
        /// Синхронізація даних для спільноти
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        private void SyncCommunityObjects(Customer source, Customer destination)
        {
            // Збереження BankAccount
            if (source.BankAccount.Count > 0)
                _dbContext.UpdateList(source.BankAccount, destination.BankAccount, rec => { }, (l, r) => l.BanAccId == r.BanAccId);

            //збереження Company + AnketaCompany
            if(destination.Company == null)
                destination.Company = new Company();
            destination.Company.SetFields(source.Company);
            var sorsListAncComp = source.Company.AnketaCompany.ToList();
            _dbContext.UpdateList(sorsListAncComp, destination.Company.AnketaCompany, rec => { }, (sorsItem, destItem) => sorsItem.Version == destItem.Version);

            // контактна особа
            var relEmployeeList = source.Company.RelEmployee.Where(rec => !string.IsNullOrEmpty(rec.Empl?.LastName?.Trim())).ToList();

            var listRel = destination.Company.RelEmployee.Where(rec => !relEmployeeList.Any(item => item.Emplid == rec.Emplid && item.PositionCode == rec.PositionCode)).ToList();
            listRel.ForEach(delitem =>
            {
                _dbContext.Employee.Remove(delitem.Empl);
                _dbContext.RelEmployee.Remove(delitem);
                destination.Company.RelEmployee.Remove(delitem);
            });

            listRel = destination.Company.RelEmployee.Where(rec => relEmployeeList.Any(item => item.Emplid == rec.Emplid && item.PositionCode == rec.PositionCode)).ToList();
            listRel.ForEach(updItem =>
            {
                var sorsItem = listRel.SingleOrDefault(item => item.Emplid == updItem.Emplid && item.PositionCode == updItem.PositionCode);
                updItem.SetFields(sorsItem);
                updItem.Empl.SetFields(sorsItem?.Empl);
            });

            var relEmpl = source.Company.RelEmployee.Select(items => items.Empl).ToList();
            listRel = destination.Company.RelEmployee.Where(rec => relEmployeeList.Any(item => item.Emplid == rec.Emplid && item.PositionCode == rec.PositionCode)).ToList();

            listRel.ForEach(updEmpl =>
            {
                var sourceItem = relEmpl.SingleOrDefault(item => item.Emplid == updEmpl.Emplid);
                updEmpl.SetFields(source.Company.RelEmployee.SingleOrDefault(item => item.Emplid == updEmpl.Emplid && item.PositionCode == updEmpl.PositionCode));
                updEmpl.Empl.SetFields(sourceItem);
            });

            listRel = relEmployeeList.Where(rec => !destination.Company.RelEmployee.Any(item => item.Emplid == rec.Emplid && item.PositionCode == rec.PositionCode)).ToList();
            listRel.ForEach(addItem =>
            {
                Employee addEmpl = new Employee();
                addEmpl.SetFields(addItem.Empl);
                RelEmployee addRelItem = new RelEmployee { Empl = addEmpl };
                addRelItem.SetFields(addItem);
                addEmpl.CustId = addRelItem.CustId;
                destination.Employee.Add(addEmpl);
                destination.Company.RelEmployee.Add(addRelItem);
            });

            // збереження Community
            if (destination.Community == null)
            {
                var community = new Community();
                community.SetFields(source.Community);
                destination.Community = community;
            }
            destination.Community.SetFields(source.Community);

            // --  збереження договору
            // збереження AgreementAddCommunity
            var sorsAgrAddCommunity = source.Community.AgreementAddCommunity.ToList();
            var destAgrAddCommunity = destination.Community?.AgreementAddCommunity.ToList();
            var agrList = destAgrAddCommunity.Where(row => sorsAgrAddCommunity.All(item => item.AgrId != row.AgrId)).ToList();
            // Delete
            agrList.ForEach(item => _dbContext.AgreementAddCommunity.RemoveRange(item));
            // Modify
            {
                agrList = destAgrAddCommunity?.Where(row => sorsAgrAddCommunity.Any(item => item.AgrId == row.AgrId)).ToList();
                var sorsDic = sorsAgrAddCommunity.ToDictionary(rec => rec.AgrId);
                agrList.ForEach(item =>
                {
                    var sorsItem = sorsDic[item.AgrId];
                    item.SetFields(sorsItem, new[] { "AgrId" });
                });
            }
            // Add
            {
                var sorsAgrList = source.AgreementMaster.ToList();
                var destAgrList = destination.AgreementMaster.ToList();
                var agreementMasters = sorsAgrList.Where(row => destAgrList.All(item => item.AgrId != row.AgrId)).ToList();
                var agreementAddCommunities = source.Community.AgreementAddCommunity.Where(row => destAgrList.All(item => item.AgrId != row.AgrId)).ToList();

                agreementMasters.ForEach(item =>
                {
                    // створено 1
                    var agreement = new AgreementMaster();
                    // оновлення з ресурсу 1
                    agreement.SetFields(item);
                    foreach(var agrCommunity in agreementAddCommunities)
                        item.AgreementAddCommunity.Add(agrCommunity);
                    
                    // оновлення AgreementAddCommunity
                    _dbContext.AppendList(item.AgreementAddCommunity, agreement.AgreementAddCommunity, i => { }, (l, r) => l.AgrId == r.AgrId && l.Version == r.Version, new[] { "AgrId" });

                    destination.AgreementMaster.Add(agreement); // додано 1
                    foreach (var agreementAddCommunity in agreement.AgreementAddCommunity)
                        destination.Community.AgreementAddCommunity.Add(agreementAddCommunity);
                });
            }
        }

        private Customer GetTemplate()
        {
            return new Customer
            {
                CustType = 3, // спільнота юр особа
                AnkVersion = 1,
                Status = 2,
                Company = new Company
                {
                    AnketaCompany = new List<AnketaCompany>
                    {
                        new AnketaCompany
                        {
                            Version = 1,
                            Status = 2,
                        }
                    },
                    Version = 1,
                    RelEmployee = new List<RelEmployee>
                    {
                        new RelEmployee
                        {
                            PositionCode = 3,
                            Empl = new Employee(),
                        }
                    }
                },
                AgreementMaster = new List<AgreementMaster>
                {
                    new AgreementMaster
                    {
                        AgrStatus = 2,
                        AgrType = 4,
                        Version = 1,
                    },
                },
                Community = new Community
                {
                    AgreementAddCommunity = new List<AgreementAddCommunity>
                    {
                        new AgreementAddCommunity
                        {
                            AgrStatus = 2,
                            AnkVersion = 1,
                            Version = 1,
                        }
                    },
                },
                BankAccount = new List<BankAccount>
                {
                    new BankAccount()
                }
            };
        }

        #endregion
    }
}