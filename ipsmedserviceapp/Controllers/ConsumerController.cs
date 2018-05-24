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
                var addAgr = new AgreementMaster();
                addAgr.LicenseAgreement.Add(new LicenseAgreement());
                newCust.AgreementMaster.Add( addAgr );
                if( custType == 3 ) // юр особа
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

                _dbContext.Customer.Add(newCustomer);

                // Збереження Customer
                _dbContext.Entry(newCustomer).State = EntityState.Added;
                // Збереження Client
                if (newCustomer.Client == null)
                    newCustomer.Client = new Client();
                _dbContext.Entry(newCustomer.Client).State = EntityState.Added;

                // Збереження BankAccount
                if( newCustomer.BankAccount.Count > 0 )
                    foreach( var item in newCustomer.BankAccount)
                        _dbContext.Entry(item).State = EntityState.Added;
                // Збереження AgreementMaster
                if (newCustomer.AgreementMaster.Count > 0)
                    foreach (var item in newCustomer.AgreementMaster)
                    {
                        _dbContext.Entry(item).State = EntityState.Added;
                        // Збереження LicenseAgreement
                        if ( item.LicenseAgreement.Count > 0 )
                            foreach (var subItem in item.LicenseAgreement)
                                _dbContext.Entry(subItem).State = EntityState.Added;
                    }
                // Збереження PartnerClient
                if (newCustomer.Partner != null )
                    _dbContext.Entry(newCustomer.Partner).State = EntityState.Added;

                if (newCustomer.CustType == 3) //   Юридична особа
                {

                    // Збереження Company
                    if (newCustomer.Company == null)
                        throw new Exception("Not input data for Company");
                    _dbContext.Entry(newCustomer.Company).State = EntityState.Added;

                    // Збереження AnketaCompany
                    if( newCustomer.AnketaCompany.Count == 0)
                        throw new Exception("Not input data for AnketaCompany");
                    foreach (var item in newCustomer.AnketaCompany)
                        _dbContext.Entry(item).State = EntityState.Added;

                    // Збереження RelEmployee
                    if ( newCustomer.Company.RelEmployee.Count > 0)
                    {
                        foreach (var item in newCustomer.Company.RelEmployee )
                        {
                            // Збереження Employee
                            if (item.Empl?.Emplid != null && item.Empl.Emplid == 0)
                                _dbContext.Entry(item.Empl).State = EntityState.Added;

                            _dbContext.Entry(item).State = EntityState.Added;
                        }

                    }
                }
                else
                {
                    // Збереження Person
                    if( newCustomer.Person == null )
                        throw new Exception("Not input data for Company");
                    _dbContext.Entry(newCustomer.Person).State = EntityState.Added;
                    // Збереження AnketaPerson
                    if (newCustomer.AnketaPerson.Count == 0)
                        throw new Exception("Not input data for AnketaPerson");

                    foreach (var item in newCustomer.AnketaPerson)
                        _dbContext.Entry(item).State = EntityState.Added;
                }


                tran = _dbContext.Database.BeginTransaction();
                _dbContext.SaveChanges();
                tran.Commit();
                tran = null;

                return await GetConsumerById(newCustomer.CustId);
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