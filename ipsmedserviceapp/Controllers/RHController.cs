using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using ipsmedserviceapp.Controllers.Resources;
using ipsmedserviceapp.Extensions;
using ipsmedserviceapp.Model;
using ipsmedserviceapp.Repositories;
using ipsmedserviceapp.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace ipsmedserviceapp.Controllers
{
    [Produces("application/json")]
    [Route("api/RH")]
    public class RHController : Controller
    {
        private readonly MediaServiceContext _dbContext;
        private readonly RightholderRepository _rightholderRepository;

        public RHController(MediaServiceContext dbContext, RightholderRepository rightholderRepository)
        {
            _dbContext = dbContext;
            _rightholderRepository = rightholderRepository;
        }

        /// <summary>
        /// Отримати структуру Правовласника
        /// </summary>
        /// <param name="id">Ід Правовласника</param>
        /// <param name="forSync">
        /// true - TermOfService only DataBase
        /// false - TermOfService with Dictionary
        /// </param>
        /// <returns></returns>
        private async Task<Customer> GetRightHolderAllData(int id, bool forSync = false)
        {
            var cust = await _dbContext.Customer.Where(row => row.CustId == id)
                        .Include(item => item.Company)
                            .ThenInclude(comp => comp.RelEmployee)
                        .Include(item => item.AnketaCompany)
                        .Include(item => item.Person)
                        .Include(item => item.AnketaPerson)
                        .Include(item => item.Community)
                        .Include(item => item.BankAccount)
                        .Include(item => item.AnketaAddName)
                        .Include(item => item.RightHolder)
                            .Include(item => item.RightHolder)
                            .ThenInclude(rh => rh.TerritoryExclude)
                        .Include(item => item.RightHolder)
                            .ThenInclude(rh => rh.TerritoryInclude)
                        .Include(item => item.RightHolder)
                            .ThenInclude(rh => rh.CopyRight)
                        .Include(item => item.RightHolder)
                            .ThenInclude(rh => rh.AnketaAddNick)
                        .SingleOrDefaultAsync();

            if (cust.RightHolder == null)
                return null;

            var currDate = DateTime.Now.Date;



            if (!forSync)
                await _dbContext.TermsOfService.FromSql(@"select @custid as custId, t1.CodeI as CRKindCode, isnull(t2.ourService,1) as ourService
from CopyrightKind t1
left outer join TermsOfService t2 on  custid = @custid and t2.CRKindCode = t1.codeI", new SqlParameter("@custid", id))
                    .Include(tos => tos.CrkindCodeNavigation)
                        .ThenInclude(ck => ck.CrGroupCodeNavigation)
                    .Where(tos => tos.CustId == id)
                    .LoadAsync();
            else
                await _dbContext.Entry(cust.RightHolder).Collection(rec => rec.TermsOfService)
                    //.Query()
                    //    .Include(tos => tos.CrkindCodeNavigation)
                    //    .ThenInclude(ck => ck.CrGroupCodeNavigation)
                        .LoadAsync();


            await _dbContext.CustCmRight
                .FromSql("select * from CustCmRight where custId = @custId and getdate() between dateBegin and dateEnd", new SqlParameter("custId", id))
                .LoadAsync();

            if (cust.Company != null)
            {
                foreach (var relEmp in cust.Company.RelEmployee)
                {
                    _dbContext.Entry(relEmp).Reference(item => item.Empl).Load();
                }
            }

            await _dbContext.Entry(cust).Collection(rec => rec.AgreementMaster)
                .Query()
                .Where(item => item.AgrStatus != 4 && item.AgrType == 1)
                .LoadAsync();

            // load only one active agreement with AgreementAddRh for customer
            await _dbContext.Entry(cust.RightHolder).Collection(rec => rec.AgreementAddRh)
                .Query()
                .Where(item => item.AgrStatus != 4)
                .LoadAsync();


            await _dbContext.AgreementMaster.FromSql(
                @"select * from AgreementMaster t1
where agrId in ( select distinct agrid from AgreementAddRH where custId = @custid )
and agrStatus != 4", new SqlParameter("@custId", cust.CustId))
                .LoadAsync();

            return cust;

        }

        /// <summary>
        /// Отримати список Споживачів малих прав
        /// </summary>
        /// <returns></returns>
        [HttpGet("listRH/{filterType?}")]
        public async Task<IActionResult> GetListSR(string filterType)
        {
            var queryText = "select * from vTsk_1_ListRightHolder01";

            if (!string.IsNullOrEmpty(filterType))
            {
                if (filterType.ToLower() == "new")
                {
                    queryText = queryText + " where status = 0";
                }
                else if (filterType.ToLower() == "notaccepted")
                {
                    queryText = queryText + " where status = 1";
                }
                else if (filterType.ToLower() == "active")
                {
                    queryText = queryText + " where status = 2";
                }
                else if (filterType.ToLower() == "inheritance")
                {
                    queryText = queryText + " where status = 7";
                }
                else if (filterType.ToLower() == "blocked")
                {
                    queryText = queryText + " where status = 8";
                }
                else if (filterType.ToLower() == "closed")
                {
                    queryText = queryText + " where status = 9";
                }
            }

            var List = await _dbContext.getViewData(queryText, null);
            return Json(List);
        }

        [HttpGet]
        public async Task<IActionResult> GetRightholders([FromQuery] RightholderListQueryResource query)
        {
            var queryText = "select * from vTsk_1_ListRightHolder01";

            var conditions = new Collection<string>();
            if (query != null)
            {
                if (query.RightholderStatus.HasValue)
                    conditions.Add($"custStatus = {query.RightholderStatus.Value}");

                if (query.AgreementStatus.HasValue)
                    conditions.Add($"agrStatus = {query.AgreementStatus.Value}");

                if (conditions.Any())
                    queryText = queryText + " where " + string.Join(" and ", conditions);
            }

            var List = await _dbContext.getViewData(queryText, null);
            return Ok(List);
        }

        [HttpGet("newrightholder/{custType}")]
        public async Task<IActionResult> Newrightholder(int custType)
        {
            Customer newCust = new Customer { CustType = custType, AnkVersion = 1 };
            newCust.RightHolder = new RightHolder { AroundWord = true };
            newCust.BankAccount.Add(new BankAccount());
            if (custType < 3) // jur
            {
                newCust.RightHolder.RHolderType = 1;
                newCust.Person = new Person();
                newCust.Person.AnketaPerson.Add(new AnketaPerson
                {
                    Version = 1,
                    NikName = string.Empty,
                    FaCountry = "804",
                    FaRegion = 9,
                    ReCountry = "804",
                    ReRegion = 9,
                    LeCountry = "804",
                    LeRegion = 9,
                });
            }
            else if (custType == 3)
            {
                newCust.RightHolder.RHolderType = 2;
                newCust.Company = new Company();
                newCust.Company.AnketaCompany.Add(new AnketaCompany
                {
                    Version = 1,
                    FaCountry = "804",
                    FaRegion = 9,
                    JaCountry = "804",
                    JaRegion = 9,
                    LeCountry = "804",
                    LeRegion = 9,
                });
            }

            var copyrightList = await _dbContext.CopyrightKind
                .Include(rec => rec.CrGroupCodeNavigation)
                // .Include(rec => rec.)
                .AsNoTracking().ToListAsync();

            copyrightList.ForEach(rec => newCust.RightHolder.TermsOfService.Add(new TermsOfService { CrkindCode = rec.CodeI, OurService = true, CrkindCodeNavigation = rec }));
            var agrMaster = new AgreementMaster { Version = 1, AgrStatus = 0, AgrType = 1 };
            agrMaster.AgreementAddRh.Add(new AgreementAddRh { Version = 1, AgrStatus = 0, AgrDate = DateTime.Now, DateBegin = DateTime.Now, DateEnd = new DateTime(3000,1,1) });

            newCust.AgreementMaster.Add(agrMaster);


            return Json(newCust);

        }

        /// <summary>
        /// Сінхронізація структури Правовласника
        /// </summary>
        /// <param name="sorsCust"></param>
        /// <param name="destCustomer"></param>
        private void updateRihtholder(Customer sorsCust, Customer destCustomer)
        {

            var excludeFields = new string[] { "CustId", "UserId" };
            if (sorsCust == null)
                throw new Exception("new rightholder is empty");
            if (!(sorsCust.CustType > 0 && sorsCust.CustType < 4))
                throw new Exception("Bad customer type for new rightholder");

            // Збереження Customer
            destCustomer.SetFields(sorsCust, excludeFields);

            // Збереження RightHolder
            if (destCustomer.RightHolder == null)
                destCustomer.RightHolder = new RightHolder();
            destCustomer.RightHolder.SetFields(sorsCust.RightHolder, excludeFields);

            if (sorsCust.Community != null)
            {
                if (destCustomer.Community == null)
                    destCustomer.Community = new Community();
                destCustomer.Community.SetFields(sorsCust.Community, excludeFields);
            }

            // AnketaAddName
            _dbContext.UpdateList(sorsCust.AnketaAddName, destCustomer.AnketaAddName, rec => { }, (l, r) => l.Lang == r.Lang);

            // AnketaAddNick
            _dbContext.UpdateList(sorsCust.RightHolder.AnketaAddNick, destCustomer.RightHolder.AnketaAddNick, row => { }, (sorsItem, destItem) => sorsItem.AddId == destItem.AddId);


            // TermsOfService
            {
                _dbContext.UpdateList(sorsCust.RightHolder.TermsOfService, destCustomer.RightHolder.TermsOfService, i => { }, (l, r) => l.CrkindCode == r.CrkindCode);
                var sorseDic = sorsCust.RightHolder.TermsOfService.ToDictionary(rec => rec.CrkindCode);
                var commutitiDic = new Dictionary<int, Community>();
                foreach (var destTerm in destCustomer.RightHolder.TermsOfService)
                {
                    var sorsTerm = sorseDic[destTerm.CrkindCode];
                    _dbContext.UpdateList(sorsTerm.CustCmRight.Where(item=>item.CmCustId!=0).ToList(), destTerm.CustCmRight, i => {
                        Community atachCom = null;
                        if (!commutitiDic.Keys.Contains(i.CmCustId))
                        {
                            atachCom = new Community { CustId = i.CmCustId };

                            _dbContext.Attach(atachCom);
                            commutitiDic.Add(i.CmCustId, atachCom);
                        }
                        else
                            atachCom = commutitiDic[i.CmCustId];
                        atachCom.CustCmRight.Add(i);
                    }, (l, r) => l.CustId == r.CustId
                                        && l.CRkindCode == r.CRkindCode
                                        && l.CmCustId == r.CmCustId
                                        && l.DateBegin == r.DateBegin/*, new[] { "CustId", "CRkindCode" }*/);
                }
            }


            if (sorsCust.RightHolder.AroundWord == null || sorsCust.RightHolder.AroundWord == false)
                sorsCust.RightHolder.TerritoryExclude.Clear();
            else
                sorsCust.RightHolder.TerritoryInclude.Clear();

            // territoryInclude
            _dbContext.UpdateList(sorsCust.RightHolder.TerritoryInclude, destCustomer.RightHolder.TerritoryInclude
                                                            , rec => { }, (l, r) => l.CountryCode == r.CountryCode);

            // territoryExclude
            _dbContext.UpdateList(sorsCust.RightHolder.TerritoryExclude, destCustomer.RightHolder.TerritoryExclude
                                                            , rec => { }, (l, r) => l.CountryCode == r.CountryCode);

            // Збереження BankAccount
            if (sorsCust.BankAccount.Count > 0)
                _dbContext.UpdateList(sorsCust.BankAccount, destCustomer.BankAccount
                                                                , rec => { }, (l, r) => l.BanAccId == r.BanAccId);

            var destAgrList = destCustomer.AgreementMaster.ToList();
            var sorsAgrList = sorsCust.AgreementMaster.ToList();

            List<AgreementMaster> agrList = destAgrList.Where(row => !sorsAgrList.Any(item => item.AgrId == row.AgrId)).ToList();

            // Delete
            agrList.ForEach(item =>
            {
                _dbContext.AgreementAddRh.RemoveRange(item.AgreementAddRh);
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
                    _dbContext.UpdateList(sorsItem.AgreementAddRh, item.AgreementAddRh, i => { }, (l, r) => l.AgrId == r.AgrId && l.Version == r.Version);
                });
            }
            // Add
            {
                agrList = sorsAgrList.Where(row => !destAgrList.Any(item => item.AgrId == row.AgrId)).ToList();
                agrList.ForEach(item =>
                {
                    AgreementMaster addAgr = new AgreementMaster();
                    addAgr.SetFields(item);
                    _dbContext.AppendList(item.AgreementAddRh, addAgr.AgreementAddRh, i => { }, (l, r) => l.AgrId == r.AgrId && l.Version == r.Version, new[] { "AgrId" });
                    foreach (var addRhItem in addAgr.AgreementAddRh)
                        destCustomer.RightHolder.AgreementAddRh.Add(addRhItem);
                    destCustomer.AgreementMaster.Add(addAgr);
                });
            }


            if (destCustomer.CustType == 3) // Company
            {
                //.Include(item => item.Company)
                if (destCustomer.Company == null)
                    destCustomer.Company = new Company();
                destCustomer.Company.SetFields(sorsCust.Company);

                //.Include(item => item.AnketaCompany)
                var sorsList = sorsCust.Company.AnketaCompany.ToList();
                _dbContext.UpdateList(sorsList, destCustomer.Company.AnketaCompany, rec => { }, (sorsItem, destItem) => sorsItem.Version == destItem.Version);
                //.Include(comp => comp.RelEmployee)
                _dbContext.UpdateListExtra(sorsCust.Company.RelEmployee, destCustomer.Company.RelEmployee,
                    (isNew, sors, dest) =>
                    {
                        if (dest.Empl == null && sors.Empl != null)
                            dest.Empl = new Employee();

                        dest.Empl.SetFields(sors.Empl);
                    },
                    (sorsItem, destItem) =>
                        sorsItem.PositionCode == destItem.PositionCode && sorsItem.Emplid == destItem.Emplid
                );
            }
            else
            {
                // Збереження Person
                if (sorsCust.Person == null)
                    throw new Exception("Not input data for Company");
                if (destCustomer.Person == null) destCustomer.Person = new Person();
                destCustomer.Person.SetFields(sorsCust.Person, excludeFields);

                if (sorsCust.Person.AnketaPerson.Count == 0)
                    throw new Exception("Not input data for AnketaPerson");

                _dbContext.UpdateList(sorsCust.Person.AnketaPerson, destCustomer.Person.AnketaPerson
                                                                , rec => { }, (l, r) => l.Version == r.Version);
            }

            // add or clear community depends on rightholder type
            if (sorsCust.RightHolder.RHolderType == 2) // community
            {
                if (destCustomer.Community == null)
                    destCustomer.Community = new Community();
            }
            else
            {
                destCustomer.Community = null;
            }
        }

        /// <summary>
        /// Збереження нового Споживача
        /// </summary>
        /// <param name="newRightHolder"></param>
        /// <returns></returns>
        [HttpPost("newrightholder")]
        public async Task<IActionResult> Insertrightholder([FromBody] Customer newRightHolder)
        {
            IDbContextTransaction tran = null;
            try
            {
                Customer addRightHolder = new Customer();
                _dbContext.Customer.Add(addRightHolder);
                updateRihtholder(newRightHolder, addRightHolder);

                tran = _dbContext.Database.BeginTransaction();
                _dbContext.SaveChanges();
                tran.Commit();
                tran = null;

                return await getRh(addRightHolder.CustId);
            }
            catch (Exception ex)
            {
                if (tran != null)
                    tran.Rollback();
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Отримати всю інформацію по Правовласнику
        /// </summary>
        /// <param name="rhId"> Ид Правовласника </param>
        /// <returns></returns>
        [HttpGet("detail/{rhId}")]
        public async Task<IActionResult> getRh(int rhId)
        {
            var customer = await GetRightHolderAllData(rhId);
            if (customer == null)
                return NotFound();
            return Json(customer);
        }


        /// <summary>
        /// Отримати всю інформацію по Правовласнику
        /// </summary>
        /// <param name="rhId"> Ид Правовласника </param>
        /// <returns></returns>
        [HttpPut("detail/{rhId}")]
        public async Task<IActionResult> updateRh(int rhId, [FromBody] Customer updCustomer)
        {
            IDbContextTransaction tran = null;
            if (updCustomer == null || rhId != updCustomer.CustId)
                return BadRequest();

            try
            {
                var dest = await GetRightHolderAllData(rhId, true);
                updateRihtholder(updCustomer, dest);
                tran = _dbContext.Database.BeginTransaction();
                _dbContext.SaveChanges();
                tran.Commit();
                tran = null;
                dest = await GetRightHolderAllData(rhId);
                return Json(dest);
            }
            catch (Exception ex)
            {
                if (tran != null)
                    tran.Rollback();

                return BadRequest(ex.Message);
            }

        }

        #region Методи отримання допоміжної інформації по правовласникам
        /// <summary>
        /// Отримати масив авторів по першим літарам назви
        /// </summary>
        /// <param name="wildcard">Фільтр</param>
        /// <returns>Масив Authors</returns>
        [HttpGet("filters/authors/{wildcard}")]
        public async Task<IActionResult> GetFilteredAuthors(string wildcard)
        {
            if (String.IsNullOrWhiteSpace(wildcard))
                return BadRequest("Empty Filter");

            try
            {
                var filterStr = string.Concat(wildcard, "%");
                var listAuthors = await _dbContext.getViewData("select distinct authorName from Authors where authorName like @filter", new[] { new SqlParameter("@filter", filterStr) });
                return Json(listAuthors);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.InnerException.Message);
            }

        }
        #endregion

        [HttpPut("setstatus/{rhId}")]
        public async Task<IActionResult> SetStatus(int rhId, [FromBody] int newStatus)
        {
            var customer = await _dbContext.Customer.FirstOrDefaultAsync(c => c.CustId == rhId);

            if (customer == null)
                return NotFound();

            List<int> allowedStatuses = new List<int>();

            if (customer.Status == 2)
                allowedStatuses.AddRange(new[] { 7, 8, 9 });
            else if (customer.Status == 9)
                allowedStatuses.Add(2);
            else
                allowedStatuses.AddRange(new[] { 2, 9 });

            if (allowedStatuses.Contains(newStatus))
            {
                customer.Status = newStatus;
                if (newStatus == 2)
                {
                    var agreement = customer.AgreementMaster.FirstOrDefault();
                    if (agreement != null)
                    {
                        agreement.AgrStatus = 2;

                        var agrRh = agreement.AgreementAddRh.FirstOrDefault();
                        if (agrRh != null)
                        {
                            agrRh.AgrStatus = 2;
                        }
                    }
                }
                await _dbContext.SaveChangesAsync();
            }
            else
            {
                return StatusCode(StatusCodes.Status406NotAcceptable);
            }

            return Ok();
        }

        [HttpGet("checkexists/okpo/{okpo}")]
        public async Task<IActionResult> CheckExistsOkpo( string okpo )
        {
            var vCust = await _dbContext.vCustomer
                        .FromSql("select CustId, name, INNOKPO, IPI from vCustomer where INNOKPO = @okpo", new SqlParameter("@okpo", okpo))
                        .FirstOrDefaultAsync();
            if (vCust == null)
                return NotFound();

            return Ok(vCust);
        }

        [HttpGet("checkexists/ipi/{ipi}")]
        public async Task<IActionResult> CheckExistsIpi(string ipi)
        {
            var vCust = await _dbContext.vCustomer
                        .FromSql("select CustId, name, INNOKPO, IPI from vCustomer where IPI = @ipi", new SqlParameter("@ipi", ipi)).FirstOrDefaultAsync();
            if (vCust == null)
                return NotFound();

            return Ok(vCust);

        }
        #region inheritance

        /// <summary>
        /// Внутрішній метод передачі об'єктів з одного правовласника на інших
        /// </summary>
        /// <param name="rhId"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        private async Task ProcessObjectTransfer(int rhId, List<RightHolder> body)
        {
            // Права Автора / Правовласника
            DateTime endDate = body.Where(rec => rec.CustId == rhId).SingleOrDefault()?.CopyRight.SingleOrDefault()?.EndDate ?? DateTime.Today;
            var checkDate = new DateTime(endDate.Year, endDate.Month, endDate.Day).AddDays(1);
            var listCopyRight = await _dbContext.CopyRight.Where(item => item.CustId == rhId && item.BeginDate <= checkDate && item.EndDate >= checkDate)
                                .Include(rec => rec.Obj).ThenInclude(obj => obj.Authors).ToListAsync();

            if (listCopyRight.Count == 0)
                return;

            // Правовласник з інтерфейсу
            var oldBodyCust = body.Where(rec => rec.CustId == rhId).SingleOrDefault();
            if (oldBodyCust == null)
                return;

            // Об'єкти правовласника
            var objects = await _dbContext.ObjectRight.FromSql(@"
select distinct t1.* 
from ObjectRight t1
join CopyRight t2 on t2.objId = t1.objId and getdate() between t2.beginDate and t2.endDate
where
t2.custId = @custid
", new SqlParameter("@custid", rhId)).ToDictionaryAsync(rec => rec.ObjId);


            // Автора об'єктів
            var authtors = await _dbContext.Authors.FromSql(@"
select distinct t1.* 
from Authors t1
join CopyRight t2 on t2.objId = t1.objId and getdate() between t2.beginDate and t2.endDate
where
t2.custId = @custid
", new SqlParameter("@custid", rhId)).ToListAsync();

            //DateTime checkDate = oldBodyCust.CopyRight.FirstOrDefault()?.EndDate ?? DateTime.Today;
            DateTime beginDate = endDate.AddDays(1);


            // Оброблюємо нових правовласників
            body.Where(rec => rec.CustId != rhId).ToList()
                .ForEach(item =>
                {
                    // Додаємо нові права
                    foreach (var cright in item.CopyRight)
                    {
                        CopyRight addItem = new CopyRight();
                        // addItem.CRightId
                        addItem.SetFields(cright, new[] { "CRightId" });
                        _dbContext.CopyRight.Add(addItem);

                        foreach (var author in cright.Obj.Authors)
                        {
                            if (authtors.Any(rec => rec.ObjId == author.ObjId && rec.CustId == author.CustId && rec.RoleCode == author.RoleCode))
                                continue;

                            Authors addAutor = new Authors();
                            addAutor.SetFields(author, new[] { "AuthId" });
                            // addAutor.AuthId
                            _dbContext.Authors.Add(addAutor);
                        }
                    }
                    // Додаємо Авторів
                });

            // Очищаємо CustId
            // Патлякевич Зберігаємо custId
            //foreach (var author in authtors.Where(rec => rec.CustId == rhId).ToArray())
            //    author.CustId = null;

            // Проставляємо кінцеву дату права
            listCopyRight.ForEach(item =>
            {
                //
                item.EndDate = endDate;

                // Патлякевич Зберігаємо custId
                //foreach (var author in item.Obj.Authors.Where(a => a.CustId == item.CustId))
                //{
                //    author.CustId = null;
                //}
            });
        }

        private void SetCloseStatusForRightholderAndAgreement(int custId)
        {
            var customer = _dbContext.Customer.FirstOrDefault(c => c.CustId == custId);

            // Закриваємо Правовласника і його договір
            customer.Status = 9;

            var agreement = _dbContext.AgreementAddRh
                .Include(a => a.Agr)
                .FirstOrDefault(a => a.CustId == custId);

            agreement.AgrStatus = 4;
            agreement.Agr.AgrStatus = 4;
        }


        /// <summary>
        /// Зміна правовласника - спадщина
        /// </summary>
        /// <param name="rhId">Ід старого правовласника</param>
        /// <param name="body">Список нових правовласників
        ///                    та запис по старому правовласнику з датою завершення володінням правами 
        /// </param>
        /// <returns>Ok</returns>
        [HttpPost("inheritance/{rhId}")]
        public async Task<IActionResult> Inheritance(int rhId, [FromBody]List<RightHolder> body)
        {
            await ProcessObjectTransfer(rhId, body);

            SetCloseStatusForRightholderAndAgreement(body[0].CustId);

            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        /// <summary>
        /// Зміна правовласника - передача
        /// </summary>
        /// <param name="rhId">Ід старого правовласника</param>
        /// <param name="body">Список нових правовласників
        ///                    та запис по старому правовласнику з датою завершення володінням правами 
        /// </param>
        /// <returns>Ok</returns>
        [HttpPut("objects/transfer")]
        public IActionResult ObjectTransfer([FromBody] TransferParametersResource transferParams)
        {
            if (transferParams == null)
                return BadRequest("Некоректні параметри передачі.");

            var transferProcessor = new ObjectTransferProcessor(_dbContext, _rightholderRepository, transferParams);
            transferProcessor.Process();

            if (transferProcessor.Result.AreErrorsExist)
            {
                ModelState.AddValidationErrors(transferProcessor.Result);

                return BadRequest(ModelState);
            }

            return Ok();
        }

        #endregion

        #region Copyright requests

        [HttpGet("withNotAcceptedCopyrights")]
        public async Task<IActionResult> GetRightholderWithNotAcceptedCopyrights()
        {
            var list = await _dbContext.getViewData("select * from vtsk_3_WRH_03", null);
            return Json(list);
        }

        [HttpGet("notAcceptedObjects/{custId}")]
        public async Task<IActionResult> GetNotAcceptedObjectsByRightholder(int custId)
        {
            var list = await _dbContext.getViewData("select * from ft_tsk_3_WRH_03( @custId )", new[] { new SqlParameter("@custId", custId) });
            return Json(list);
        }

        [HttpPut("updateCopyrights")]
        public async Task<IActionResult> UpdateCopyrights([FromBody] List<CopyRight> copyrightList)
        {
            var foundedCopyrights = await GetCopyrightListById(copyrightList.Select(cr => cr.CRightId).ToList());

            foreach (var sourceCopyright in copyrightList)
            {
                var destCopyright = foundedCopyrights.FirstOrDefault(cr => cr.CRightId == sourceCopyright.CRightId);

                if (destCopyright == null)
                    throw new Exception("Copyright not founded."); // TODO: accumulate and return list of NotFounded errors

                destCopyright.Rate = sourceCopyright.Rate;

                if (sourceCopyright.WorkRh != null)
                {
                    if (sourceCopyright.WorkRh.WorkTypeRh == 5) // Відмова
                    {
                        // TODO: it is a poorly way to do so
                        _dbContext.CopyRight.Remove(destCopyright);
                        continue;
                    }

                    if (destCopyright.WorkRh == null)
                        destCopyright.WorkRh = new WorkRh();

                    if (destCopyright.WorkRh.WorkTypeRh != sourceCopyright.WorkRh.WorkTypeRh || sourceCopyright.WorkRh.WorkTypeRh == 1)
                    {
                        destCopyright.WorkRh.WorkDateRh = DateTime.Now;
                    }
                    if (sourceCopyright.WorkRh.WorkTypeRh == 4) // Погоджено
                    {
                        destCopyright.Status = 1;
                    }
                    destCopyright.WorkRh.WorkTypeRh = sourceCopyright.WorkRh.WorkTypeRh;
                    destCopyright.WorkRh.WorkCommentRh = sourceCopyright.WorkRh.WorkCommentRh;
                }
            }

            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        private async Task<List<CopyRight>> GetCopyrightListById(List<int> copyrightIdList)
        {
            return await _dbContext.CopyRight
                .Include(cr => cr.WorkRh)
                .Where(cr => copyrightIdList.Contains(cr.CRightId))
                .ToListAsync();
        }

        #endregion
    }
}