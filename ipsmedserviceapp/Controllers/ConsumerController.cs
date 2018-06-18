using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ipsmedserviceapp.Model;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Protocols;


namespace ipsmedserviceapp.Controllers
{
    [Produces("application/json")]
    [Route("api/Consumer")]
    public class ConsumerController : Controller
    {
        private MediaServiceContext _dbContext;
        private IConfiguration _config;
        public ConsumerController(MediaServiceContext dbContext, IConfiguration config)
        {
            _dbContext = dbContext;
            _config = config;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        private async Task<Customer> GetConsumerAllData(int id)
        {
            // Отримати основну інформацію
            var cust = await _dbContext.Customer.Where(row => row.CustId == id)
                        .Include(item => item.Company).ThenInclude(comp => comp.RelEmployee)
                        .Include(item => item.AnketaCompany)
                        .Include(item => item.Person)
                        .Include(item => item.AnketaPerson)
                        .Include(item => item.BankAccount)
                        .Include(item => item.Client).ThenInclude(cln => cln.ClnBusinessPlace)
                        .Include(item => item.Client).ThenInclude(cln => cln.LicenseAgreement)
                        .Include(item => item.Client).ThenInclude(cln => cln.MoneyReceived)
                        .SingleOrDefaultAsync();
            // Отримати дані по Контрактах
            if (cust.Client.LicenseAgreement.Count > 0)
                await _dbContext.Entry(cust.Client).Collection(rec => rec.LicenseAgreement)
                    .Query()
                    .Where(agree => agree.LicStatus < 4)
                    .Include(item => item.Agr)
                    .Include(item => item.License)
                    .Include(rec => rec.PaidPeriod)
                    .LoadAsync();

            foreach (var license in cust.Client.LicenseAgreement)
            {
                await _dbContext.Entry(license).Collection(rec => rec.LicenseAgrParam)
                    .Query()
                    .Where(rec => rec.LicVersion == license.LicVersion)
                    .LoadAsync();

                await _dbContext.Entry(license).Collection(rec => rec.MoneyPeriodLink).LoadAsync();
            }

            // Отримати Майданчики
            foreach (var place in cust.Client.ClnBusinessPlace)
            {
                _dbContext.Entry(place).Collection(item => item.ClnPlaceHoll).Load();
                _dbContext.Entry(place).Reference(item => item.PlCodeNavigation).Load();

            }

            // Отримати співробітників
            foreach (var relEmp in cust.Company.RelEmployee)
            {
                _dbContext.Entry(relEmp).Reference(item => item.Empl).Load();
            }

            return cust;

        }

        /// <summary>
        /// Отримати Споживача до Id
        /// </summary>
        /// <param name="id">ідентифікатор CustId бази даних</param>
        /// <returns></returns>
        [HttpGet("detail/{id}")]
        public async Task<IActionResult> GetConsumerById(int id)
        {
            var cust = await GetConsumerAllData(id);
            return Json(cust);
        }

        /// <summary>
        /// Зберегти Споживача до Id
        /// </summary>
        /// <param name="id">ідентифікатор CustId бази даних</param>
        /// <returns></returns>
        [HttpPut("detail/{id}")]
        public async Task<IActionResult> SaveConsumerById(int id, [FromBody] Customer updCustomer)
        {
            IDbContextTransaction tran = null;
            try
            {
                var dest = await GetConsumerAllData(id);
                // Customer
                dest.SetFields(updCustomer);
                //.Include(item => item.BankAccount)
                _dbContext.UpdateList(updCustomer.BankAccount, dest.BankAccount, row => row.BanAccId = 0, (sorsItem, destItem) => sorsItem.BanAccId == destItem.BanAccId);
                //.Include(item => item.RightHolder)
                dest.Client.SetFields(updCustomer.Client);
                dest.Company.SetFields(updCustomer.Company);
                //dest.Company.RelEmployee.SetFields(updCustomer.Company.RelEmployee);

                // 
                var places = dest.Client.ClnBusinessPlace.Where(rec => !updCustomer.Client.ClnBusinessPlace.Any(item => item.PlaceId == rec.PlaceId)).ToList();
                places.ForEach(item =>
                {
                    _dbContext.ClnPlaceHoll.RemoveRange(item.ClnPlaceHoll);
                    _dbContext.ClnBusinessPlace.Remove(item);
                });

                places = dest.Client.ClnBusinessPlace.Where(rec => updCustomer.Client.ClnBusinessPlace.Any(item => item.PlaceId == rec.PlaceId)).ToList();
                places.ForEach(item =>
                {
                    var sorsItem = updCustomer.Client.ClnBusinessPlace.Where(rec => item.PlaceId == rec.PlaceId).SingleOrDefault();
                    _dbContext.UpdateList(sorsItem.ClnPlaceHoll, item.ClnPlaceHoll, i => { }, (l, r) => l.HollId == r.HollId);
                    item.SetFields(sorsItem);
                });
                places = updCustomer.Client.ClnBusinessPlace.Where(rec => !dest.Client.ClnBusinessPlace.Any(item => item.PlaceId == rec.PlaceId)).ToList();
                places.ForEach(item =>
                {
                    ClnBusinessPlace clnPlace = new ClnBusinessPlace();
                    clnPlace.SetFields(item);
                    _dbContext.AppendList(item.ClnPlaceHoll, clnPlace.ClnPlaceHoll, i => { }, (l, r) => l.PlaceId == r.PlaceId);
                    dest.Client.ClnBusinessPlace.Add(clnPlace);
                });

                // Delete
                List<LicenseAgreement> tempList = dest.Client.LicenseAgreement.Where(row => !updCustomer.Client.LicenseAgreement.Any(item => row.LicId == item.LicId)).ToList();
                tempList.ForEach(item =>
                {
                    // Delete LicenseAgreement
                    var agreeItem = dest.AgreementMaster.Where(rec => rec.AgrId == item.AgrId).SingleOrDefault();
                    var delLicense = agreeItem.LicenseAgreement.Where(rec => rec.LicId == item.LicId).SingleOrDefault();
                    _dbContext.License.RemoveRange(delLicense.License.ToArray());

                    agreeItem.LicenseAgreement.Remove(delLicense);
                    dest.Client.LicenseAgreement.Remove(item);


                    // AgreementMaster
                    _dbContext.LicenseAgreement.Remove(delLicense);
                }
                );

                // Modify
                tempList = updCustomer.Client.LicenseAgreement.Where(row => dest.Client.LicenseAgreement.Any(item => row.LicId == item.LicId)).ToList();
                tempList.ForEach(item =>
                {

                    // Delete LicenseAgreement
                    var agreeItemDest = dest.AgreementMaster.Where(rec => rec.AgrId == item.AgrId).SingleOrDefault();
                    var agreeItemSors = item.Agr;
                    agreeItemDest.SetFields(agreeItemSors);

                    var license = dest.Client.LicenseAgreement.Where(rec => rec.LicId == item.LicId).SingleOrDefault();
                    license.SetFields(item);
                    _dbContext.UpdateList(item.License, license.License, i => { }, (l, r) => l.PlaceId == r.PlaceId);
                    _dbContext.AppendList(item.LicenseAgrParam, license.LicenseAgrParam, i => { }, (l, r) => l.LicVersion == r.LicVersion);

                });
                // Add
                tempList = updCustomer.Client.LicenseAgreement.Where(row => !dest.Client.LicenseAgreement.Any(item => row.LicId == item.LicId)).ToList();
                tempList.ForEach(item =>
                {

                    // Delete LicenseAgreement
                    var agreeItem = item.Agr;
                    var destAgreeItem = dest.AgreementMaster.Where(rec => rec.AgrId == item.AgrId).SingleOrDefault();
                    if (destAgreeItem == null)
                    {
                        destAgreeItem = new AgreementMaster();
                        destAgreeItem.SetFields(agreeItem, new[] { "AgrId" });
                        dest.AgreementMaster.Add(destAgreeItem);
                    }

                    var addLicItem = new LicenseAgreement { LicVersion = 1 };
                    addLicItem.SetFields(item, new[] { "LicId" });
                    _dbContext.AppendList(item.License, addLicItem.License, i => { }, (l, r) => l.PlaceId == r.PlaceId);
                    _dbContext.AppendList(item.LicenseAgrParam, addLicItem.LicenseAgrParam, i => { }, (l, r) => l.LicVersion == r.LicVersion);

                    dest.Client.LicenseAgreement.Add(addLicItem);
                    destAgreeItem.LicenseAgreement.Add(addLicItem);
                }
                );


                if (dest.CustType == 3) // Company
                {
                    //.Include(item => item.Company)
                    if (dest.Company == null)
                        dest.Company = new Company();

                    //.Include(item => item.AnketaCompany)
                    var sorsList = updCustomer.Company.AnketaCompany.ToList();
                    _dbContext.UpdateList(sorsList, dest.Company.AnketaCompany, rec => { }, (sorsItem, destItem) => sorsItem.Version == destItem.Version);
                    //.Include(comp => comp.RelEmployee)
                    var relEmployeeList = updCustomer.Company.RelEmployee.Where(rec => !string.IsNullOrEmpty(rec.Empl?.LastName?.Trim())).ToList();

                    var listRel = dest.Company.RelEmployee.Where(rec => !relEmployeeList.Any(item => item.Emplid == rec.Emplid && item.PositionCode == rec.PositionCode)).ToList();
                    listRel.ForEach(delitem =>
                    {
                        _dbContext.Employee.Remove(delitem.Empl);
                        _dbContext.RelEmployee.Remove(delitem);
                        dest.Company.RelEmployee.Remove(delitem);

                    });



                    listRel = dest.Company.RelEmployee.Where(rec => relEmployeeList.Any(item => item.Emplid == rec.Emplid && item.PositionCode == rec.PositionCode)).ToList();
                    listRel.ForEach(updItem =>
                    {
                        var sorsItem = listRel.SingleOrDefault(item => item.Emplid == updItem.Emplid && item.PositionCode == updItem.PositionCode);
                        updItem.SetFields(sorsItem);
                        updItem.Empl.SetFields(sorsItem?.Empl);
                    });

                    //
                    // десь тут
                    //
                    var relEmpl = updCustomer.Company.RelEmployee.Select(items => items.Empl).ToList();
                    listRel = dest.Company.RelEmployee.Where(rec => relEmployeeList.Any(item => item.Emplid == rec.Emplid && item.PositionCode == rec.PositionCode)).ToList();

                    listRel.ForEach(updEmpl =>
                    {
                        var sourceItem = relEmpl.SingleOrDefault(item => item.Emplid == updEmpl.Emplid);
                        updEmpl.SetFields(updCustomer.Company.RelEmployee.SingleOrDefault(item => item.Emplid == updEmpl.Emplid && item.PositionCode == updEmpl.PositionCode));
                        updEmpl.Empl.SetFields(sourceItem);
                    });


                    var testOne = listRel;

                    listRel = relEmployeeList.Where(rec => !dest.Company.RelEmployee.Any(item => item.Emplid == rec.Emplid && item.PositionCode == rec.PositionCode)).ToList();
                    listRel.ForEach(addItem =>
                    {
                        Employee addEmpl = new Employee();
                        addEmpl.SetFields(addItem.Empl);
                        RelEmployee addRelItem = new RelEmployee { Empl = addEmpl };
                        addRelItem.SetFields(addItem);
                        addEmpl.CustId = addRelItem.CustId;
                        dest.Employee.Add(addEmpl);
                        dest.Company.RelEmployee.Add(addRelItem);
                    });

                    var testMany = listRel;

                }
                else
                {
                    //.Include(item => item.Person)
                    if (dest.Person == null)
                        dest.Person = new Person();
                    _dbContext.AppendList(updCustomer.Person.AnketaPerson, dest.Person.AnketaPerson, rec => { }, (sorsItem, destItem) => sorsItem.Version == destItem.Version);
                    //.Include(item => item.AnketaPerson)
                }

                //.Include(item => item.Community)

                tran = _dbContext.Database.BeginTransaction();
                _dbContext.SaveChanges();
                tran.Commit();
                tran = null;


                return Json(dest);
            }
            catch (Exception ex)
            {
                if (tran != null)
                    tran.Rollback();
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// Шаблон нового користувача
        /// </summary>
        /// <param name="custType"></param>
        /// <returns></returns>
        [HttpGet("newconsumer/{custType}")]
        public IActionResult GetNewConsumer(int custType)
        {
            try
            {
                if (!(custType > 0 && custType < 4))
                    throw new Exception("Bad customer type for new consumer");

                Customer newCust = new Customer { CustType = custType, AnkVersion = 1, Status = 2 };
                // Споживач
                newCust.Client = new Client();
                // Договор з Споживачем
                var addAgr = new AgreementMaster { AgrStatus = 0, AgrType = 2, Version = 1 };
                var license = new LicenseAgreement { LicStatus = 0, Agr = addAgr, LicVersion = 1 };
                license.LicenseAgrParam.Add(new LicenseAgrParam { LicVersion = 1 });
                addAgr.LicenseAgreement.Add(license);
                // addAgr.LicenseAgreement.Add(new LicenseAgreement { LicStatus = 0 });
                newCust.Client.LicenseAgreement.Add(license);
                newCust.AgreementMaster.Add(addAgr);
                if (custType == 3) // юр особа
                {
                    // Компанія
                    newCust.Company = new Company();
                    // Анкета
                    newCust.Company.AnketaCompany.Add(new AnketaCompany { Version = 1, Status = 2 });
                }
                else
                {
                    // Фіз. особа
                    newCust.Person = new Person();
                    // Анкета
                    newCust.Person.AnketaPerson.Add(new AnketaPerson { Version = 1, Status = 2 });
                }

                return Json(newCust);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Збереження нового Споживача
        /// </summary>
        /// <param name="newCustomer"></param>
        /// <returns></returns>
        [HttpPost("newconsumer")]
        public async Task<IActionResult> NewConsumer([FromBody] Customer newCustomer)
        {
            IDbContextTransaction tran = null;
            try
            {
                if (newCustomer == null)
                    throw new Exception("new consumer is empty");
                if (!(newCustomer.CustType > 0 && newCustomer.CustType < 4))
                    throw new Exception("Bad customer type for new consumer");

                // Збереження Customer
                Customer addCustomer = new Customer();
                addCustomer.SetFields(newCustomer, new[] { "CustId" });
                _dbContext.Customer.Add(addCustomer);

                // Збереження Client
                addCustomer.Client = new Client();
                addCustomer.Client.SetFields(newCustomer.Client, new[] { "CustId" });


                // Збереження BankAccount
                var bankAccList = newCustomer.BankAccount.ToList();
                bankAccList.ForEach(rec =>
                {
                    BankAccount addAcc = new BankAccount();
                    addAcc.SetFields(rec, new[] { "CustId", "BanAccId" });
                    addCustomer.BankAccount.Add(addAcc);
                });

                // Збереження AgreementMaster
                var licAgreement = newCustomer.Client.LicenseAgreement.ToList();

                foreach (var item in licAgreement)
                {

                    // Пошук Головного договора 
                    AgreementMaster addAgreeMAster = addCustomer.AgreementMaster.Where(rec => rec.AgrNumber == item.Agr.AgrNumber && rec.AgrDate == item.Agr.AgrDate).SingleOrDefault();
                    if (addAgreeMAster == null)
                    {
                        addAgreeMAster = new AgreementMaster();
                        addAgreeMAster.SetFields(item.Agr, new[] { "CustId", "AgrId" });
                        addCustomer.AgreementMaster.Add(addAgreeMAster);
                    }

                    LicenseAgreement addItem = new LicenseAgreement();
                    addItem.SetFields(item, new[] { "CustId", "AgrId" });
                    _dbContext.AppendList(item.LicenseAgrParam, addItem.LicenseAgrParam, i => { }, (l, r) => l.LicVersion == r.LicVersion);
                    _dbContext.AppendList(item.License, addItem.License, i => { }, (l, r) => l.PlaceId == r.PlaceId);

                    addAgreeMAster.LicenseAgreement.Add(addItem);
                    addCustomer.Client.LicenseAgreement.Add(addItem);

                }
                // Збереження PartnerClient
                if (newCustomer.Partner != null)
                {
                    addCustomer.Partner = new Partner();
                }

                // if( newCustomer.Client.PartnerClient)
                // ClnBusinessPlace
                foreach (var item in newCustomer.Client.ClnBusinessPlace)
                {
                    ClnBusinessPlace placeItem = new ClnBusinessPlace();
                    placeItem.SetFields(item, new[] { "PlaceId", "CustId" });
                    addCustomer.Client.ClnBusinessPlace.Add(placeItem);
                    // ClnPlaceHoll
                    foreach (var hollItem in item.ClnPlaceHoll)
                    {
                        ClnPlaceHoll addHoll = new ClnPlaceHoll();
                        addHoll.SetFields(hollItem, new[] { "HollId", "PlaceId" });
                        placeItem.ClnPlaceHoll.Add(addHoll);
                    }
                }
                if (newCustomer.CustType == 3) //   Юридична особа
                {

                    // Збереження Company
                    if (newCustomer.Company == null)
                        throw new Exception("Not input data for Company");
                    // _dbContext.Entry(newCustomer.Company).State = EntityState.Added;
                    addCustomer.Company = new Company();

                    // Збереження AnketaCompany
                    if (newCustomer.Company.AnketaCompany.Count == 0)
                        throw new Exception("Not input data for AnketaCompany");

                    foreach (var item in newCustomer.Company.AnketaCompany)
                    {
                        AnketaCompany addAnketa = new AnketaCompany();
                        addAnketa.SetFields(item, new[] { "CustId" });
                        addCustomer.Company.AnketaCompany.Add(item);
                    }

                    // Збереження RelEmployee
                    foreach (var item in newCustomer.Company.RelEmployee.Where(rec => !string.IsNullOrEmpty(rec.Empl?.LastName?.Trim())).ToList())
                    {
                        if (item.Empl == null)
                            continue;

                        RelEmployee relEmpl = new RelEmployee();
                        relEmpl.SetFields(item, new[] { "CustId", "Emplid" });
                        Employee emplItem = new Employee { Emplid = item.Empl.Emplid };
                        // Збереження Employee
                        if (item.Empl.Emplid == 0)
                        {
                            emplItem.SetFields(item.Empl, new[] { "CustId", "Emplid" });
                            addCustomer.Employee.Add(emplItem);
                        }
                        else
                            _dbContext.Employee.Attach(emplItem);
                        relEmpl.Empl = emplItem;
                        addCustomer.Company.RelEmployee.Add(relEmpl);
                    }

                }
                else
                {
                    // Збереження Person
                    if (newCustomer.Person == null)
                        throw new Exception("Not input data for Company");
                    addCustomer.Person = new Person();

                    // Збереження AnketaPerson
                    if (newCustomer.Person.AnketaPerson.Count == 0)
                        throw new Exception("Not input data for AnketaPerson");

                    foreach (var item in newCustomer.Person.AnketaPerson)
                    {
                        AnketaPerson addPerson = new AnketaPerson();
                        addPerson.SetFields(item, new[] { "CustId" });
                        addCustomer.Person.AnketaPerson.Add(addPerson);
                        _dbContext.Entry(item).State = EntityState.Added;
                    }
                }


                tran = _dbContext.Database.BeginTransaction();
                _dbContext.SaveChanges();
                tran.Commit();
                tran = null;

                return await GetConsumerById(addCustomer.CustId);
            }
            catch (Exception ex)
            {
                if (tran != null)
                    tran.Rollback();
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Отримати список Споживачів малих прав
        /// </summary>
        /// <returns></returns>
        [HttpGet("listSR")]
        public async Task<IActionResult> GetListSR()
        {
            var List = await _dbContext.getViewData("select * from vTsk_1_ListConsumer01", null);
            return Json(List);
        }

        /// <summary>
        /// Отримати детальну інформацію по періодам оплати договору
        /// </summary>
        /// <param name="licid"></param>
        /// <returns></returns>
        [HttpGet("period/detail/{licid}")]
        public async Task<IActionResult> GetPeriodDetail(int licid)
        {
            try
            {
                var licenseAgrement = await _dbContext.LicenseAgreement.Where(rec => rec.LicId == licid)
                                        .Include(rec => rec.PaidPeriod)
                                        .Include(rec => rec.Cust).ThenInclude(cust => cust.Cust)
                                        .SingleOrDefaultAsync();

                await _dbContext.MoneyPeriodLink.FromSql($"select * from MoneyPeriodLink where licid = {licid}")
                                .Include(rec => rec.Paid)
                                .LoadAsync();

                await _dbContext.Register.FromSql("select t2.* from PaidPeriod t1 join Register t2 on t2.periodId = t1.periodId where t1.licid = @licid", new SqlParameter("@licid", licid))
                    .Include(rec => rec.RegisterItem)
                    .Include(rec => rec.Distribution)
                    .LoadAsync();


                await _dbContext.DistributionItem.FromSql(@"
select t3.* from PaidPeriod t1 join Distribution t2 on t2.periodId = t1.periodId 
join DistributionItem t3 on t3.distId = t2.distId
where t1.licid = @licid", new SqlParameter("@licid", licid))
                    .LoadAsync();

                await _dbContext.RegisterCount.FromSql(@"
select t4.* from PaidPeriod t1 join Register t2 on t2.periodId = t1.periodId 
join RegisterItem t3 on t3.regId = t2.regId
join RegisterCount t4 on t4.regId = t3.regId and t4.regIItemId = t3.regIItemId
where t1.licid = @licid", new SqlParameter("@licid", licid))
    .LoadAsync();



                return Json(licenseAgrement.Cust.Cust);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        } // GetPeriodDetail(int licid)

        #region Register POST PUT DELETE
        /// <summary>
        /// Отримати детальну інформацію по звіту періоду
        /// </summary>
        /// <param name="regid">Ід звіта</param>
        /// <returns></returns>
        [HttpGet("period/register/{regid}")]
        public async Task<IActionResult> GetRegisterDetail(int regid)
        {
            var register = await _dbContext.Register.Where(rec => rec.RegId == regid)
                .Include(rec => rec.RegisterItem)
                .SingleOrDefaultAsync();

            return Json(register);

        }


        /// <summary>
        /// Створити звіту періоду
        /// </summary>
        /// <param name="regid">Ід звіта</param>
        /// <returns></returns>
        [HttpPost("period/register/new")]
        public async Task<IActionResult> PostRegisterDetail([FromBody] Register body)
        {

            IDbContextTransaction tran = null;
            try
            {
                if (body == null)
                    throw new ApplicationException("Empty Register Body");

                var period = await _dbContext.PaidPeriod.Where(rec => rec.PeriodId == body.PeriodId).SingleOrDefaultAsync();
                if (period == null)
                    throw new ApplicationException("Dont find PAidPeriod");

                Register addItem = new Register { RgStatus = 1 };
                // addItem.RegId
                addItem.SetFields(body, new[] { "RegId" });
                period.Register.Add(addItem);

                int index = 1;
                _dbContext.AppendList(body.RegisterItem, addItem.RegisterItem, item => item.RegIitemId = index++, (l, r) => l.RegId == r.RegId && l.RegIitemId == r.RegIitemId);

                tran = _dbContext.Database.BeginTransaction();
                await _dbContext.SaveChangesAsync();
                tran.Commit();
                tran = null;
                return Json(addItem);
            }
            catch (Exception e)
            {
                if (tran != null)
                    tran.Rollback();
                return BadRequest(e.Message);
            }

        } // PostRegisterDetail


        /// <summary>
        /// Змінити звіт періоду
        /// </summary>
        /// <param name="regid">Ід звіта</param>
        /// <returns></returns>
        [HttpPut("period/register/{regId}")]
        public async Task<IActionResult> PutRegisterDetail(int regId, [FromBody] Register body)
        {

            IDbContextTransaction tran = null;
            try
            {
                if (body == null)
                    throw new ApplicationException("Empty Register Body");


                Register modifyItem = await _dbContext.Register.Where(rec => rec.RegId == regId)
                                        .Include(rec => rec.RegisterItem)
                                        .SingleOrDefaultAsync();
                if (modifyItem == null)
                    throw new ApplicationException("Dont find Register item");

                // addItem.PeriodId
                modifyItem.SetFields(body, new[] { "RegId", "PeriodId" });

                int index = modifyItem.RegisterItem.Max(rec => rec.RegIitemId);
                index++;

                _dbContext.UpdateList(body.RegisterItem, modifyItem.RegisterItem, item => item.RegIitemId = index++, (l, r) => l.RegId == r.RegId && l.RegIitemId == r.RegIitemId);


                tran = _dbContext.Database.BeginTransaction();
                await _dbContext.SaveChangesAsync();
                tran.Commit();
                tran = null;
                return Json(modifyItem);
            }
            catch (Exception e)
            {
                if (tran != null)
                    tran.Rollback();
                return BadRequest(e.Message);
            }

        } // PoutRegisterDetail

        /// <summary>
        /// Змінити звіт періоду
        /// </summary>
        /// <param name="regid">Ід звіта</param>
        /// <returns></returns>
        [HttpDelete("period/register/{regId}")]
        public async Task<IActionResult> DeleteRegisterDetail(int regId)
        {
            IDbContextTransaction tran = null;
            try
            {

                Register deleteItem = await _dbContext.Register.Where(rec => rec.RegId == regId)
                                        .Include(rec => rec.RegisterItem)
                                        .SingleOrDefaultAsync();
                if (deleteItem == null)
                    throw new ApplicationException("Dont find Register item");

                if (deleteItem.RgStatus > 1)
                {
                    throw new ApplicationException("Can not delete Register with status > 1");
                }

                // var itemList = deleteItem.RegisterItem.ToList();
                _dbContext.RegisterItem.RemoveRange(deleteItem.RegisterItem);
                _dbContext.Register.Remove(deleteItem);

                tran = _dbContext.Database.BeginTransaction();
                await _dbContext.SaveChangesAsync();
                tran.Commit();
                tran = null;
                return Ok();
            }
            catch (Exception e)
            {
                if (tran != null)
                    tran.Rollback();
                return BadRequest(e.Message);
            }

        } // DeleteRegisterDetail

        #endregion

        #region Download Upload file
        /// <summary>
        /// Завантаження файлу(ів) на сервер
        /// </summary>
        /// <param name="custId"></param>
        /// <param name="typeDocument"></param>
        /// <returns></returns>
        [HttpPost("Document/{custId}/{typeDocument}")]
        public async Task<ActionResult> UploadDocument(int custId, int typeDocument, IFormFile file)
        {

            string documentsFolder = _config.GetValue<string>("DocumentsFolder");
            string consumerPath = Path.Combine(documentsFolder, custId.ToString());
            if (!Directory.Exists(consumerPath))
                Directory.CreateDirectory(consumerPath);

            consumerPath = Path.Combine(consumerPath, typeDocument.ToString());
            if (!Directory.Exists(consumerPath))
                Directory.CreateDirectory(consumerPath);

            consumerPath = Path.Combine(consumerPath, file.FileName);

            if (System.IO.File.Exists(consumerPath))
                System.IO.File.Delete(consumerPath);

            using (var stream = new FileStream(consumerPath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return Ok();
        }


        /// <summary>
        /// Завантаження файлу(ів) на сервер
        /// </summary>
        /// <param name="custId"></param>
        /// <param name="typeDocument"></param>
        /// <returns></returns>
        [HttpGet("Document/{custId}/{typeDocument}")]
        public async Task<ActionResult> DownloadDocument(int custId, int typeDocument, string fileName)
        {

            string documentsFolder = _config.GetValue<string>("DocumentsFolder");
            string consumerPath = Path.Combine(documentsFolder, custId.ToString());
            if (!Directory.Exists(consumerPath))
                return BadRequest();

            consumerPath = Path.Combine(consumerPath, typeDocument.ToString());
            if (!Directory.Exists(consumerPath))
                return BadRequest();

            consumerPath = Path.Combine(consumerPath, fileName);

            if (!System.IO.File.Exists(consumerPath))
                return BadRequest();

            var memoryStream = new MemoryStream();
            using (var stream = new FileStream(consumerPath, FileMode.Open))
            {
                await stream.CopyToAsync(memoryStream);
            }
            memoryStream.Position = 0;

            return File(memoryStream, "application/vnd.ms-word", Path.GetFileName( consumerPath ));
        }



        #endregion

    } // public class ConsumerController : Controller
}