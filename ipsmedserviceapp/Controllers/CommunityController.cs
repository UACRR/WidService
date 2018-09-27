using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ipsmedserviceapp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Net.Http;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.IdentityModel.Protocols;

// URLs:
// community/
namespace ipsmedserviceapp.Controllers
{
    [Produces("application/json")]
    [Route("api/community")]
    public class CommunityController : Controller
    {
        private MediaServiceContext _dbContext;
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

        };

        /// <summary>
        /// повернути дані обраної VIEW 
        /// </summary>
        /// <param name="viewName"></param>
        /// <param name="paramId"></param>
        /// <returns></returns>
        [HttpGet("list/view")]
        public async Task<IActionResult> GetCommunityList([FromQuery] string viewName, [FromQuery] int? paramId)
        {
            if (viewName == null || !_communityViewList.Keys.Contains(viewName))
                return BadRequest();

            string queryStr = string.Concat("select * from ", _communityViewList[viewName]);
            // Немає параметру по Споживачу
            if (paramId == null)
            {
                var list = await _dbContext.getViewData(queryStr, null);
                return Json(list);
            }
            else
            {
                queryStr = string.Concat(queryStr, " where custId = @custId");
                var list = await _dbContext.getViewData(queryStr, new[] { new SqlParameter("@custId", paramId) });
                return Json(list);
            }
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
                .Include(item => item.AgreementMaster)
                .Include(item => item.BankAccount)
                .Include(item => item.Community).ThenInclude(agr => agr.AgreementAddCommunity)
                .Include(item => item.RightHolder).SingleOrDefaultAsync();
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
                Customer communityCustomer = new Customer
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
                        Version = 1
                    },
                    AgreementMaster = new List<AgreementMaster>
                    {
                        new AgreementMaster
                        {
                            AgrStatus = 2,
                            AgrType = 4,
                            Version = 1,
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
                    },
                    Community = new Community(),
                    RightHolder = new RightHolder
                    {
                        RHolderType = 2,
                    },
                    BankAccount = new List<BankAccount>
                    {
                        new BankAccount()
                    }

                };

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
                var newCommunity = new Customer();
                _dbContext.Customer.Add(newCommunity);
                SyncCommunityObjects(sourceCustomer, newCommunity);


                tran = _dbContext.Database.BeginTransaction();
                _dbContext.SaveChanges();
                tran.Commit();
                tran = null;

                return await GetCommunity(newCommunity.CustId);
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

            return null;
        }

        #region Винесені методи та додаткові методи синхронізацій

        /// <summary>
        /// Синхронізація даних для спільноти
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        private void SyncCommunityObjects(Customer source, Customer destination)
        {
            var excludeFields = new string[] { "CustId" };
            if (source == null)
                throw new Exception("New comunity object is empty!");
            if (!(source.CustType > 0 && source.CustType < 4))
                throw new Exception("Bad customer type for new comunity");

            // Збереження Customer
            destination.SetFields(source, excludeFields);

            // Збереження BankAccount
            if (source.BankAccount.Count > 0)
                _dbContext.UpdateList(source.BankAccount, destination.BankAccount, rec => { }, (l, r) => l.BanAccId == r.BanAccId);

            destination.Client.SetFields(source.Client);
            // збереження договору
            var destAgrList = destination.AgreementMaster.ToList();
            var sorsAgrList = source.AgreementMaster.ToList();
            List<AgreementMaster> agrList = destAgrList.Where(row => !sorsAgrList.Any(item => item.AgrId == row.AgrId)).ToList();
            // Delete
            agrList.ForEach(item =>
            {
                _dbContext.AgreementAddPartner.RemoveRange(item.AgreementAddPartner);
            });
            _dbContext.AgreementMaster.RemoveRange(agrList);
            // Modify
            {

                agrList = destAgrList.Where(row => sorsAgrList.Any(item => item.AgrId == row.AgrId)).ToList();
                var sorsDic = sorsAgrList.ToDictionary(rec => rec.AgrId);
                agrList.ForEach(item =>
                {
                    var sorsItem = sorsDic[item.AgrId];
                    item.SetFields(sorsItem);
                    _dbContext.UpdateList(sorsItem.AgreementAddPartner, item.AgreementAddPartner, i => { }, (l, r) => l.AgrId == r.AgrId && l.Version == r.Version);
                });
            }
            // Add
            {
                agrList = sorsAgrList.Where(row => !destAgrList.Any(item => item.AgrId == row.AgrId)).ToList();
                agrList.ForEach(item =>
                {
                    // створено 1
                    var agreement = new AgreementMaster();
                    // оновлення з ресурсу 1
                    agreement.SetFields(item);
                    // оновлення AgreementAddPartner
                    _dbContext.AppendList(item.AgreementAddPartner, agreement.AgreementAddPartner, i => { }, (l, r) => l.AgrId == r.AgrId && l.Version == r.Version, new[] { "AgrId" });

                    destination.Partner = new Partner();
                    foreach (var addPartner in agreement.AgreementAddPartner)
                        destination.Partner.AgreementAddPartner.Add(addPartner);

                    destination.AgreementMaster.Add(agreement); // додано 1
                });
            }

            // Збереження Person та AnketaPerson
            if (destination.CustType == 1)
            {
                if (source.Person == null)
                    throw new Exception("Not input data for Person!");
                if (destination.Person == null) destination.Person = new Person();
                destination.Person.SetFields(source.Person, excludeFields);

                if (source.Person.AnketaPerson.Count == 0)
                    throw new Exception("Not input data for AnketaPerson");

                _dbContext.UpdateList(source.Person.AnketaPerson, destination.Person.AnketaPerson, rec => { }, (l, r) => l.Version == r.Version);
            }
        }

        #endregion
    }
}