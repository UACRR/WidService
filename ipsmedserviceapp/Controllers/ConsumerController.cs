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
    [Route("api/Consumer")]
    public class ConsumerController : Controller
    {
        private MediaServiceContext _dbContext;
        public ConsumerController(MediaServiceContext dbContext)
        {
            _dbContext = dbContext;
        }

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
                        .SingleOrDefaultAsync();
            // Отримати дані по Контрактах
            await _dbContext.Entry(cust).Collection(rec => rec.AgreementMaster)
                .Query()
                .Where(agree => agree.AgrStatus < 4)
                .Include(item => item.LicenseAgreement)
                .LoadAsync();

            // Отримати по контрактам Періоди оплат    
            await _dbContext.PaidPeriod.FromSql("select * from PaidPeriod where custId = @custId", new SqlParameter("@custId", cust.CustId))
                .Include(row => row.MoneyPeriodLink)
                .LoadAsync();
            // 
            await _dbContext.MoneyReceived.FromSql("select * from MoneyReceived where custId = @custId", new SqlParameter("@custId", cust.CustId)).LoadAsync();

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

                Customer newCust = new Customer { CustType = custType, AnkVersion = 1 };
                // Споживач
                newCust.Client = new Client();
                // Договор з Споживачем
                var addAgr = new AgreementMaster { AgrStatus = 0 };
                addAgr.LicenseAgreement.Add(new LicenseAgreement());
                newCust.AgreementMaster.Add(addAgr);
                if (custType == 3) // юр особа
                {
                    // Компанія
                    newCust.Company = new Company();
                    // Анкета
                    newCust.AnketaCompany.Add(new AnketaCompany { Version = 1 });
                }
                else
                {
                    // Фіз. особа
                    newCust.Person = new Person();
                    // Анкета
                    newCust.Person.AnketaPerson.Add(new AnketaPerson { Version = 1 });
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
                var agreeMaster = newCustomer.AgreementMaster.ToList();

                foreach (var item in agreeMaster)
                {
                    AgreementMaster addAgreeMAster = new AgreementMaster();
                    addAgreeMAster.SetFields(item, new[] { "CustId", "AgrId" });
                    addCustomer.AgreementMaster.Add(addAgreeMAster);
                    var licenseAgg = item.LicenseAgreement.ToList();
                    licenseAgg.ForEach(rec =>
                    {
                        LicenseAgreement addLic = new LicenseAgreement();

                        addLic.SetFields(rec, new[] { "CustId", "AgrId", "LicId" });
                        if (addLic.LicCode == 0)
                            addLic.LicCode = 25;

                        addCustomer.Client.LicenseAgreement.Add(addLic);
                        addAgreeMAster.LicenseAgreement.Add(addLic);
                    });

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
                    if (newCustomer.AnketaCompany.Count == 0)
                        throw new Exception("Not input data for AnketaCompany");

                    foreach (var item in newCustomer.AnketaCompany)
                    {
                        AnketaCompany addAnketa = new AnketaCompany();
                        addAnketa.SetFields(item, new[] { "CustId" });
                        addCustomer.Company.AnketaCompany.Add(item);
                    }

                    // Збереження RelEmployee
                    foreach (var item in newCustomer.Company.RelEmployee)
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
                    if (newCustomer.AnketaPerson.Count == 0)
                        throw new Exception("Not input data for AnketaPerson");

                    foreach (var item in newCustomer.AnketaPerson)
                    {
                        AnketaPerson addPerson = new AnketaPerson();
                        addPerson.SetFields(item, new[] { "CustId"});
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
        /// Отримати список Споживачів малих прав
        /// </summary>
        /// <returns></returns>
        //[HttpGet("dictionaries")]
        //public async Task<IActionResult> GetDictionaries()
        //{
        //    Dictionary<string, object> listDictionaries = new Dictionary<string, object>();

        //    listDictionaries.Add("activityType", await _dbContext.ActivityType.AsNoTracking().ToListAsync());
        //    listDictionaries.Add("agrLicenseType", await _dbContext.AgrLicenseType.AsNoTracking().ToListAsync());
        //    listDictionaries.Add("agreementStatus", await _dbContext.AgreementStatus.AsNoTracking().ToListAsync());
        //    listDictionaries.Add("agreementType", await _dbContext.AgreementType.AsNoTracking().ToListAsync());
        //    listDictionaries.Add("anketaStatus", await _dbContext.AnketaStatus.AsNoTracking().ToListAsync());
        //    listDictionaries.Add("copyrightKind", await _dbContext.CopyrightKind.AsNoTracking().ToListAsync());
        //    listDictionaries.Add("copyrightType", await _dbContext.CopyrightType.AsNoTracking().ToListAsync());
        //    listDictionaries.Add("country", await _dbContext.Country.AsNoTracking().ToListAsync());
        //    listDictionaries.Add("crkindGroup", await _dbContext.CrkindGroup.AsNoTracking().ToListAsync());
        //    listDictionaries.Add("customerStatus", await _dbContext.CustomerStatus.AsNoTracking().ToListAsync());
        //    listDictionaries.Add("customerType", await _dbContext.CustomerType.AsNoTracking().ToListAsync());
        //    listDictionaries.Add("klR030", await _dbContext.KlR030.AsNoTracking().ToListAsync());
        //    listDictionaries.Add("licenseClass", await _dbContext.LicenseClass.AsNoTracking().ToListAsync());
        //    listDictionaries.Add("licenseType", await _dbContext.LicenseType.AsNoTracking().ToListAsync());
        //    listDictionaries.Add("period", await _dbContext.Period.AsNoTracking().ToListAsync());
        //    listDictionaries.Add("periodStatus", await _dbContext.PeriodStatus.AsNoTracking().ToListAsync());
        //    listDictionaries.Add("positionType", await _dbContext.PositionType.AsNoTracking().ToListAsync());
        //    listDictionaries.Add("region", await _dbContext.Region.AsNoTracking().ToListAsync());
        //    listDictionaries.Add("residentType", await _dbContext.ResidentType.AsNoTracking().ToListAsync());
        //    listDictionaries.Add("sexType", await _dbContext.SexType.AsNoTracking().ToListAsync());
        //    listDictionaries.Add("typePlace", await _dbContext.TypePlace.AsNoTracking().ToListAsync());
        //    listDictionaries.Add("typeVat", await _dbContext.TypeVat.AsNoTracking().ToListAsync());
        //    listDictionaries.Add("userRoleType", await _dbContext.UserRoleType.AsNoTracking().ToListAsync());
        //    listDictionaries.Add("usesKind", await _dbContext.UsesKind.AsNoTracking().ToListAsync());
        //    listDictionaries.Add("usesType", await _dbContext.UsesType.AsNoTracking().ToListAsync());

        //    return Json(listDictionaries);
        //}



    }
}