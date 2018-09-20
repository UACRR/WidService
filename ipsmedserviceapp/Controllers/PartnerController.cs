using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ipsmedserviceapp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
// ReSharper disable All

namespace ipsmedserviceapp.Controllers
{
    [Produces("application/json")]
    [Route("api/partner")]
    public class PartnerController : Controller
    {
        private MediaServiceContext _dbContext;
        private IConfiguration _config;
        public PartnerController(MediaServiceContext dbContext, IConfiguration config)
        {
            _dbContext = dbContext;
            _config = config;
        }

        /// <summary>
        /// Шаблон нового представника
        /// </summary>
        /// <param name="custType"></param>
        /// <returns></returns>
        [HttpGet("newpartner/{custType}")]
        public IActionResult GetNewConsumer(int custType)
        {
            try
            {
                if (!(custType > 0 && custType < 4))
                    throw new Exception("Bad customer type for new partner!");
                // представник
                Customer partnerCustomer = new Customer
                {
                    CustType = custType,
                    AnkVersion = 1,
                    Status = 2,
                };
                partnerCustomer.Partner = new Partner();

                // Договор з Споживачем
                var agreementMaster = new AgreementMaster {
                    AgrStatus = 0,
                    AgrType = 3,
                    Version = 1,
                };
                var agreementAddPartner = new AgreementAddPartner
                {
                    AgrStatus = 0,
                    Agr = agreementMaster,
                    Version = 1,
                    AnkVersion = 1,
                };
                agreementMaster.AgreementAddPartner.Add(agreementAddPartner);
                partnerCustomer.AgreementMaster.Add(agreementMaster);

                //банківські дані
                var bankAccount = new BankAccount();
                partnerCustomer.BankAccount.Add(bankAccount);

                if (custType == 3) // юр особа
                {
                    // Компанія
                    partnerCustomer.Company = new Company();
                    // Анкета
                    partnerCustomer.Company.AnketaCompany.Add(new AnketaCompany { Version = 1, Status = 2 });
                }
                else if (custType == 1) // Фіз. особа
                {
                    partnerCustomer.Person = new Person();
                    // Анкета
                    partnerCustomer.Person.AnketaPerson.Add(new AnketaPerson { Version = 1, Status = 2 });
                }

                return Json(partnerCustomer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //основний метод збереження нових представників
        private async Task<IActionResult> SavePartner(Customer sourceCustomer, int? customerType)
        {
            IDbContextTransaction tran = null;
            try
            {
                Customer newPartnerCustomer = new Customer();
                _dbContext.Customer.Add(newPartnerCustomer);
                switch (customerType)
                {
                    case 1:
                        UpdatePartnerDataP(sourceCustomer, newPartnerCustomer);
                        break;
                    case 3:
                        UpdatePartnerDataJ(sourceCustomer, newPartnerCustomer);
                        break;
                    default:
                        throw new Exception("Type customer is not defined!");
                }

                tran = _dbContext.Database.BeginTransaction();
                _dbContext.SaveChanges();
                tran.Commit();
                tran = null;

                return await GetPartnerAnketaById(newPartnerCustomer.CustId);
            }
            catch (Exception ex)
            {
                if (tran != null)
                    tran.Rollback();
                return BadRequest(ex.Message);
            }
        }

        // збереження нового представника фізичної особи
        [HttpPost("newpartnerphis")]
        public async Task<IActionResult> SaveNewPartnerPhis([FromBody] Customer sourceCustomer)
        {
            return await SavePartner(sourceCustomer, sourceCustomer.CustType);
        }

        // збереження існуючого представника фізичної особи
        [HttpPut("partnerphis/{custId}")]
        public async Task<IActionResult> SaveExistPartnerPhis(int custId, [FromBody] Customer sourceCustomer)
        {
            IDbContextTransaction tran = null;
            // основна інформація
            var destinationCustomer = await _dbContext.Customer.Where(item => item.CustId == custId)
                .Include(item => item.AgreementMaster).ThenInclude(agr => agr.AgreementAddPartner)
                .Include(item => item.Partner).ThenInclude(pcl => pcl.PartnerClient)
                .Include(item => item.BankAccount)
                .Include(item => item.Person).ThenInclude(ank => ank.AnketaPerson)
                .Include(item => item.Client)
                .SingleOrDefaultAsync();
            try
            {
                // Customer
                UpdatePartnerDataP(sourceCustomer, destinationCustomer);

                tran = _dbContext.Database.BeginTransaction();
                _dbContext.SaveChanges();
                tran.Commit();
                tran = null;

                return Json(destinationCustomer);
            }
            catch (Exception ex)
            {
                if (tran != null)
                    tran.Rollback();
                return BadRequest(ex.Message);
            }
        }

        //збереження нового представника юридичної особи
        [HttpPost("newpartnerjur")]
        public async Task<IActionResult> SaveNewPartnerJur([FromBody] Customer sourceCustomer)
        {
            return await SavePartner(sourceCustomer, sourceCustomer.CustType);
        }

        // синхронізація для ФІЗИНИХ осіб
        private void UpdatePartnerDataP(Customer source, Customer destination)
        {
            var excludeFields = new string[] { "CustId" };
            if (source == null)
                throw new Exception("New partner is empty!");
            if (!(source.CustType > 0 && source.CustType < 4))
                throw new Exception("Bad customer type for new partner");

            // Збереження Customer
            destination.SetFields(source, excludeFields);

            // Збереження BankAccount
            if (source.BankAccount.Count > 0)
                _dbContext.UpdateList(source.BankAccount, destination.BankAccount, rec => { }, (l, r) => l.BanAccId == r.BanAccId);

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

        // сихнронізація для юр. осіб
        private void UpdatePartnerDataJ(Customer source, Customer destination)
        {

        }

        //список представників
        [HttpGet("list")]
        public async Task<IActionResult> GetPartnersList()
        {
            var partner = await _dbContext.Partner.AsNoTracking().ToListAsync();
            var list = await _dbContext.AnketaPerson.Where(rec => partner.Select(r => r.CustId).Contains(rec.CustId)).AsNoTracking().ToListAsync();
            return Json(list);
        }

        //отримати анкету представника по ID клієнта (не представника)
        [HttpGet("list/{clientId}")]
        public async Task<IActionResult> GetPartnerByClientId(int clientId)
        {
            var partnerId = await _dbContext.PartnerClient.SingleOrDefaultAsync(rec => rec.ClCustId == clientId);
            var anketaPerson = await _dbContext.AnketaPerson.SingleOrDefaultAsync(rec => rec.CustId == partnerId.CustId);
            return Json(anketaPerson);
        }

        //отримати анкету представника по ID представника
        [HttpGet("list/{custId}")]
        public async Task<IActionResult> GetPartnerAnketaById(int custId)
        {
            var anketaPerson = await _dbContext.AnketaPerson.SingleOrDefaultAsync(rec => rec.CustId == custId);
            return Json(anketaPerson);
        }

        [HttpGet("{custId}")]
        public async Task<IActionResult> GetPartnerAllData(int custId)
        {
            // основна інформація
            var customer = await _dbContext.Customer.Where(item => item.CustId == custId)
                .Include(item => item.AgreementMaster).ThenInclude(agr => agr.AgreementAddPartner)
                .Include(item => item.Partner).ThenInclude(pcl => pcl.PartnerClient)
                .Include(item => item.BankAccount)
                .Include(item => item.Person).ThenInclude(ank => ank.AnketaPerson)
                .Include(item => item.Client)
                .SingleOrDefaultAsync();

            return Json(customer);
        }

        [HttpPost("{clientId}/set/{custId}")]
        public async Task<IActionResult> SetPartnerOnClient(int clientId, int custId)
        {
            return null;
        }

        [HttpPut("{clientId}/change/{custId}")]
        public async Task<IActionResult> ChangePartnerOnClient(int clientId, int custId)
        {
            return null;
        }

        [HttpDelete("{clientId}/set/{custId}")]
        public async Task<IActionResult> RemovePartnerOnClient(int clientId, int custId)
        {
            return null;
        }

        // ТЕСТ МЕТОД
        //[HttpGet("newpartnerphis/1")]
        //public async Task<IActionResult> Hello()
        //{
        //    return Ok("Hello :)");
        //}
    }
}