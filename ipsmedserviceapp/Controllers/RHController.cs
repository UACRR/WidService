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
    [Route("api/RH")]
    public class RHController : Controller
    {
        private MediaServiceContext _dbContext;
        public RHController(MediaServiceContext dbContext)
        {
            _dbContext = dbContext;
        }


        private async Task<Customer> GetRightHolderAllData(int id)
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
                            .ThenInclude(rh => rh.TermsOfService)
                        .Include(item => item.RightHolder)
                            .ThenInclude(rh => rh.TerritoryExclude)
                        .Include(item => item.RightHolder)
                            .ThenInclude(rh => rh.TerritoryInclude)
                        .Include(item => item.RightHolder)
                            .ThenInclude(rh => rh.AnketaAddNick)
                        .SingleOrDefaultAsync();

            var currDate = DateTime.Now.Date;

            await _dbContext.TermsOfService.FromSql(@"select @custid as custId, t1.CodeI as CRKindCode, isnull(t2.ourService,0) as ourService
from CopyrightKind t1
left outer join TermsOfService t2 on  custid = @custid and t2.CRKindCode = t1.codeI", new SqlParameter("@custid", id))
                .Include(tos => tos.CrkindCodeNavigation)
                    .ThenInclude(ck => ck.CrGroupCodeNavigation)
                .Where(tos => tos.CustId == id)
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
and agrStatus between  0 and 4", new SqlParameter("@custId", cust.CustId))
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
            }

            var List = await _dbContext.getViewData(queryText, null);
            return Json(List);
        }

        [HttpGet("newrightholder/{custType}")]
        public async Task<IActionResult> Newrightholder(int custType)
        {
            Customer newCust = new Customer { CustType = custType, AnkVersion = 1 };
            newCust.RightHolder = new RightHolder { AroundWord = true };
            newCust.BankAccount.Add(new BankAccount());
            if (custType < 3) // jur
            {
                newCust.Person = new Person();
                newCust.Person.AnketaPerson.Add(new AnketaPerson
                {
                    Version = 1,
                    NikName = string.Empty,
                    FaCountry = "804",
                    FaRegion = 25,
                    ReCountry = "804",
                    ReRegion = 25,
                    LeCountry = "804",
                    LeRegion = 25,

                });
            }

            var copyrightList = await _dbContext.CopyrightKind
                .Include(rec => rec.CrGroupCodeNavigation)
                // .Include(rec => rec.)
                .AsNoTracking().ToListAsync();

            copyrightList.ForEach(rec => newCust.RightHolder.TermsOfService.Add(new TermsOfService { CrkindCode = rec.CodeI, OurService = true, CrkindCodeNavigation = rec }));
            var agrMaster = new AgreementMaster { Version = 1, AgrStatus = 0 };
            agrMaster.AgreementAddRh.Add(new AgreementAddRh { Version = 1, AgrStatus = 0 });

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

            var excludeFields = new string[] { "CustId" };
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
            foreach (var item in sorsCust.RightHolder.TermsOfService)
            {
                TermsOfService addItem = destCustomer.RightHolder.TermsOfService.Where(rec => rec.CrkindCode == item.CrkindCode).SingleOrDefault();
                if (addItem == null)
                    addItem = new TermsOfService();

                addItem.SetFields(item, excludeFields);
                // CustCmRight
                var custCmRightToSave = item.CustCmRight.Where(c => c.CmCustId != 0).ToList();
                _dbContext.UpdateList(custCmRightToSave, addItem.CustCmRight, rec => { }, (l, r) => l.CRkindCode == r.CRkindCode && l.CmCustId == r.CmCustId && l.DateBegin == r.DateBegin);

                destCustomer.RightHolder.TermsOfService.Add(addItem);
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
                _dbContext.UpdateList(sorsCust.Company.RelEmployee, destCustomer.Company.RelEmployee, rec => { },
                                    (sorsItem, destItem) => sorsItem.PositionCode == destItem.PositionCode && sorsItem.Emplid == destItem.Emplid);

                var newEmployee = sorsCust.Company.RelEmployee.Where(rec => rec.Emplid == 0).ToList();
                newEmployee.ForEach(item =>
                   {
                       var destEmpl = destCustomer.Company.RelEmployee.Where(rec => rec.Emplid == 0 && rec.PositionCode == item.PositionCode).SingleOrDefault();

                       Employee addEmpl = new Employee();
                       addEmpl.SetFields(item.Empl);
                       destEmpl.Empl = addEmpl;
                   });

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
                var dest = await GetRightHolderAllData(rhId);
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

        #region inheritance

        /// <summary>
        /// Внутрішній метод підготовки данних до зміни
        /// </summary>
        /// <param name="rhId"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        private async Task<bool> internalRHInheritance(int rhId, List<RightHolder> body )
        {
            // Права Автора / Правовласника
            DateTime checkDate = DateTime.Today;
            var listCopyRight = await _dbContext.CopyRight.Where(item => item.CustId == rhId && item.BeginDate <= checkDate && item.EndDate >= checkDate)
                                .Include(rec => rec.Cust).ThenInclude(cr => cr.Cust)
                                .Include(rec => rec.Obj).ThenInclude(obj => obj.Authors).ToListAsync();

            if (listCopyRight.Count == 0)
                return false;

            // Правовласник
            var oldRightHolder = listCopyRight[0].Cust;

            // Правовласник з інтерфейсу
            var oldBodyCust = body.Where(rec => rec.CustId == rhId).SingleOrDefault();
            if (oldBodyCust == null)
                return false;

            // Закриваємо Правовласника
            oldRightHolder.Cust.Status = 9;

            // Об'єкти правовласника
            var objects = await _dbContext.ObjectRight.FromSql(@"
select t1.* 
from ObjectRight t1
join CopyRight t2 on t2.objId = t1.objId and getdate() between t2.beginDate and t2.endDate
where
t2.custId = @custid
", new SqlParameter("@custid", rhId)).AsNoTracking().ToListAsync();


            // Автора об'єктів
            var authtors = await _dbContext.Authors.FromSql(@"
select t1.* 
from Authors t1
join CopyRight t2 on t2.objId = t1.objId and getdate() between t2.beginDate and t2.endDate
where
t2.custId = @custid
", new SqlParameter("@custid", rhId)).AsNoTracking().ToListAsync();

            // Проставляємо кінцеву дату права
            DateTime endDate = oldBodyCust.CopyRight.FirstOrDefault()?.EndDate ?? DateTime.Today;
            listCopyRight.ForEach(item => {
                //
                item.EndDate = endDate;

            });

            // Оброблюємо нових правовласників
            body.Where(rec => rec.CustId != rhId).ToList()
                .ForEach(item => {
                        // Додаємо нові права
                        foreach (var cright in item.CopyRight)
                    {
                        CopyRight addItem = new CopyRight();
                        addItem.SetFields(cright);
                        _dbContext.CopyRight.Add(addItem);
                    }
                        // Додаємо Авторів
                        foreach (var author in item.Authors)
                    {
                        if (authtors.Any(rec => rec.ObjId == author.ObjId && rec.CustId == author.CustId && rec.RoleCode == author.RoleCode))
                            continue;

                        Authors addAutor = new Authors();
                        addAutor.SetFields(author);
                        _dbContext.Authors.Add(addAutor);
                    }
                });

            return true;

        }
        /// <summary>
        /// Зміна правовласника по спадщині
        /// </summary>
        /// <param name="rhId">Ід старого правовласника</param>
        /// <param name="body">Список нових правовласників
        ///                    та запис по старому правовласнику з датою завершення володінням правами 
        /// </param>
        /// <returns>Ok</returns>
        [HttpPost("inheritance/{rhId}")]
        public async Task<IActionResult> SetRHInheritance( int rhId, [FromBody]List<RightHolder> body)
        {
            IDbContextTransaction tran = null;
            try
            {
                if ( await internalRHInheritance(rhId, body) == false)
                    return Ok();

                tran = await _dbContext.Database.BeginTransactionAsync();
                await _dbContext.SaveChangesAsync();
                tran.Commit();
                tran = null;

                return Ok();

            }
            catch (Exception)
            {

                tran?.Rollback();
                return BadRequest();
            }
        }

#if DEBUG
        /// <summary>
        /// Отримати результат після зміни процесу
        /// </summary>
        /// <param name="rhId"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        private async Task<IActionResult> getDebugInfoForSetRHInheritance(int rhId, [FromBody]List<RightHolder> body)
        {
            DateTime checkDate = DateTime.Today;
            var listCopyRight = await _dbContext.CopyRight.Where(item => item.CustId == rhId && item.BeginDate >= checkDate && item.EndDate <= checkDate)
                    .Include(rec => rec.Cust).ThenInclude(cr => cr.Cust)
                    .Include(rec => rec.Obj).ThenInclude(obj => obj.Authors).AsNoTracking().ToListAsync();

            var authtors = await _dbContext.Authors.FromSql(@"
select t1.* 
from Authors t1
join CopyRight t2 on t2.objId = t1.objId and getdate() between t2.beginDate and t2.endDate
where
t2.custId = @custid
", new SqlParameter("@custid", rhId)).AsNoTracking().ToListAsync();

            var oldBodyCust = body.Where(rec => rec.CustId == rhId).SingleOrDefault();
            DateTime endDate = oldBodyCust.CopyRight.FirstOrDefault()?.EndDate ?? DateTime.Today;

            var inheriers = await _dbContext.CopyRight.FromSql(@"
select t3.* 
from ObjectRight t1
join CopyRight t2 on t2.objId = t1.objId and @dateend between t2.beginDate and t2.endDate
join CopyRight t3 on t3.objId = t1.objId and @dateend < t3.beginDate
where
t2.custId = @custid
", new SqlParameter("@custid", rhId), new SqlParameter("@dateend", endDate) ).AsNoTracking().ToListAsync();


            return Json(new { listCopyRight, authtors, inheriers });

        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="rhId"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPost("inheritancedebug/{rhId}")]
        public async Task<IActionResult> SetRHInheritanceDebug(int rhId, [FromBody]List<RightHolder> body)
        {
            IDbContextTransaction tran = null;
            try
            {
                if (await internalRHInheritance(rhId, body) == false)
                    return Ok();

                tran = await _dbContext.Database.BeginTransactionAsync();
                await _dbContext.SaveChangesAsync();

                var result = await getDebugInfoForSetRHInheritance(rhId, body);
                tran.Rollback();
                tran = null;

                return result;

            }
            catch (Exception)
            {

                tran?.Rollback();
                return BadRequest();
            }
        }

#endif
#endregion

    }
}