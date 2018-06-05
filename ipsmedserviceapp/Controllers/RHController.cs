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
                        .SingleOrDefaultAsync();

            var currDate = DateTime.Now.Date;

            await _dbContext.TermsOfService
                .Include(tos => tos.CrkindCodeNavigation)
                    .ThenInclude(ck => ck.CrGroupCodeNavigation)
                .Where(tos => tos.CustId == id)
                .LoadAsync();

            await _dbContext.CustCmRight
                .Where(cr => cr.CustId == id)
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
        [HttpGet("listRH")]
        public async Task<IActionResult> GetListSR()
        {
            var List = await _dbContext.getViewData("select * from vTsk_1_ListRightHolder01", null);
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
            _dbContext.UpdateList(sorsCust.AnketaAddName, destCustomer.AnketaAddName, rec => { }, (l, r) => l.Lang == r.Lang );
            // TermsOfService
            foreach (var item in sorsCust.RightHolder.TermsOfService)
            {
                TermsOfService addItem = destCustomer.RightHolder.TermsOfService.Where( rec => rec.CrkindCode == item.CrkindCode ).SingleOrDefault();
                if (addItem == null)
                    addItem = new TermsOfService();

                addItem.SetFields(item, excludeFields);
                // CustCmRight
                var custCmRightToSave = item.CustCmRight.Where(c => c.CmCustId != 0).ToList();
                _dbContext.UpdateList(custCmRightToSave, addItem.CustCmRight, rec => { }, (l, r) => l.CRkindCode == r.CRkindCode && l.CmCustId == r.CmCustId && l.DateBegin == r.DateBegin );

                destCustomer.RightHolder.TermsOfService.Add(addItem);
            }
            // territoryInclude
            _dbContext.UpdateList(sorsCust.RightHolder.TerritoryInclude, destCustomer.RightHolder.TerritoryInclude
                                                            , rec => { }, (l, r) => l.CountryCode == r.CountryCode);

            // territoryExclude
            _dbContext.UpdateList(sorsCust.RightHolder.TerritoryExclude, destCustomer.RightHolder.TerritoryExclude
                                                            , rec => { }, (l, r) => l.CountryCode == r.CountryCode);


            // Збереження BankAccount
            if (sorsCust.BankAccount.Count > 0)
                _dbContext.UpdateList(sorsCust.BankAccount, destCustomer.BankAccount
                                                                , rec => { }, (l, r) => l.BanAccId == r.BanAccId );

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
                    // _dbContext.AppendList(addAgr.AgreementAddRh, destCustomer.RightHolder.AgreementAddRh, i => { }, (l, r) => l.AgrId == r.AgrId && l.Version == r.Version, new[] { "AgrId" });
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
                if (destCustomer.Person == null ) destCustomer.Person = new Person();
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
                _dbContext.Customer.Add( addRightHolder );
                updateRihtholder( newRightHolder, addRightHolder );

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
                //// Customer
                //dest.SetFields(updCustomer);
                ////.Include(item => item.BankAccount)
                //_dbContext.UpdateList(updCustomer.BankAccount, dest.BankAccount, row => row.BanAccId = 0, (sorsItem, destItem) => sorsItem.BanAccId == destItem.BanAccId);
                ////.Include(item => item.AnketaAddName)
                //_dbContext.UpdateList(updCustomer.AnketaAddName, dest.AnketaAddName, row => { }, (sorsItem, destItem) => sorsItem.Lang == destItem.Lang);
                ////.Include(item => item.RightHolder)
                //dest.RightHolder.SetFields(updCustomer.RightHolder);
                ////.Include(item => item.AnketaAddName)
                //_dbContext.UpdateList(updCustomer.RightHolder.AnketaAddNick, dest.RightHolder.AnketaAddNick, row => { }, (sorsItem, destItem) => sorsItem.AddId == destItem.AddId);

                ////.Include(rh => rh.TermsOfService)
                //_dbContext.UpdateList(updCustomer.RightHolder.TermsOfService, dest.RightHolder.TermsOfService, row => { }
                //                                                    , (sorsItem, destItem) => sorsItem.CrkindCode == destItem.CrkindCode);
                ////CustCmRight
                //foreach (var item in updCustomer.RightHolder.TermsOfService)
                //{
                //    var updCmRightToSave = item.CustCmRight.Where(c => c.CmCustId != 0).ToList();
                //    var destCmRight = dest.RightHolder.TermsOfService.FirstOrDefault(t => t.CrkindCode == item.CrkindCode).CustCmRight;
                //    _dbContext.UpdateList(updCmRightToSave, destCmRight, row => { }, (sorsItem, destItem) => sorsItem.CRkindCode == destItem.CRkindCode);
                //}

                //_dbContext.UpdateList(updCustomer.RightHolder.TerritoryExclude, dest.RightHolder.TerritoryExclude, row => { }
                //                                                    , (sorsItem, destItem) => sorsItem.CountryCode == destItem.CountryCode);
                //_dbContext.UpdateList(updCustomer.RightHolder.TerritoryInclude, dest.RightHolder.TerritoryInclude, row => { }
                //                                                    , (sorsItem, destItem) => sorsItem.CountryCode == destItem.CountryCode);


                //var destAgrList = dest.AgreementMaster.ToList();
                //var sorsAgrList = updCustomer.AgreementMaster.ToList();

                //List<AgreementMaster> agrList = destAgrList.Where(row => !sorsAgrList.Any(item => item.AgrId == row.AgrId)).ToList();

                //// Delete
                //agrList.ForEach(item =>
                //{
                //    _dbContext.AgreementAddRh.RemoveRange(item.AgreementAddRh);
                //});
                //_dbContext.AgreementMaster.RemoveRange(agrList);
                //// Modify
                //{

                //    agrList = destAgrList.Where(row => sorsAgrList.Any(item => item.AgrId == row.AgrId)).ToList();
                //    var sorsDic = sorsAgrList.ToDictionary(rec => rec.AgrId);
                //    agrList.ForEach(item =>
                //    {
                //        var sorsItem = sorsDic[item.AgrId];
                //        item.SetFields(sorsItem);
                //        _dbContext.UpdateList(sorsItem.AgreementAddRh, item.AgreementAddRh, i => { }, (l, r) => l.AgrId == r.AgrId && l.Version == r.Version);
                //    });
                //}
                //// Add
                //{
                //    agrList = sorsAgrList.Where(row => !destAgrList.Any(item => item.AgrId == row.AgrId)).ToList();
                //    agrList.ForEach(item =>
                //    {
                //        AgreementMaster addAgr = new AgreementMaster();
                //        addAgr.SetFields(item);
                //        _dbContext.AppendList(item.AgreementAddRh, addAgr.AgreementAddRh, i => { }, (l, r) => l.AgrId == r.AgrId && l.Version == r.Version);
                //        _dbContext.AppendList(addAgr.AgreementAddRh, dest.RightHolder.AgreementAddRh, i => { }, (l, r) => l.AgrId == r.AgrId && l.Version == r.Version);
                //        dest.AgreementMaster.Add(addAgr);
                //    });
                //}





                //if (dest.CustType == 3) // Company
                //{
                //    //.Include(item => item.Company)
                //    if (dest.Company == null)
                //        dest.Company = new Company();

                //    //.Include(item => item.AnketaCompany)
                //    var sorsList = updCustomer.Company.AnketaCompany.ToList();
                //    _dbContext.UpdateList(sorsList, dest.Company.AnketaCompany, rec => { }, (sorsItem, destItem) => sorsItem.Version == destItem.Version);
                //    //.Include(comp => comp.RelEmployee)
                //    _dbContext.UpdateList(updCustomer.Company.RelEmployee, dest.Company.RelEmployee, rec => { },
                //                        (sorsItem, destItem) => sorsItem.PositionCode == destItem.PositionCode && sorsItem.Emplid == destItem.Emplid);

                //    foreach (var emplRel in dest.Company.RelEmployee)
                //    {
                //        if (emplRel.Empl.Emplid == 0)
                //            _dbContext.Entry(emplRel.Empl).State = EntityState.Added;
                //    }
                //}
                //else
                //{
                //    //.Include(item => item.Person)
                //    if (dest.Person == null)
                //        dest.Person = new Person();
                //    _dbContext.AppendList(updCustomer.Person.AnketaPerson, dest.Person.AnketaPerson, rec => { }, (sorsItem, destItem) => sorsItem.Version == destItem.Version);
                //    //.Include(item => item.AnketaPerson)
                //}

                //.Include(item => item.Community)

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

    }
}