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
                    Status = 0,
                };
                partnerCustomer.Partner = new Partner();

                // договір
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
                    // Анкета компанії
                    partnerCustomer.Company.AnketaCompany.Add(new AnketaCompany
                    {
                        Version = 1,
                        Status = 0,
                        FaCountry = "804",
                        LeCountry = "804",
                        JaCountry = "804",
                        FaRegion = 25,
                        LeRegion = 25,
                        JaRegion = 25,
                    });
                }
                else if (custType == 1) // Фіз. особа
                {
                    partnerCustomer.Person = new Person();
                    // Анкета особи
                    partnerCustomer.Person.AnketaPerson.Add(new AnketaPerson
                    {
                        Version = 1,
                        Status = 0,
                        Citizenship = "804",
                        FaCountry = "804",
                        LeCountry = "804",
                        ReCountry = "804",
                        FaRegion = 25,
                        LeRegion = 25,
                        ReRegion = 25,
                    });
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

        /// <summary>
        /// збереження НОВОГО представника ФІЗИЧНОЇ/ЮРИДИЧНОЇ особи
        /// </summary>
        /// <param name="sourceCustomer"></param>
        /// <returns></returns>
        [HttpPost("addnewpartner")]
        public async Task<IActionResult> SaveNewPartnerPhis([FromBody] Customer sourceCustomer)
        {
            return await SavePartner(sourceCustomer, sourceCustomer.CustType);
        }

        /// <summary>
        /// збереження ІСНУЮЧОГО представника ФІЗИЧНОЇ особи
        /// </summary>
        /// <param name="custId"></param>
        /// <param name="sourceCustomer"></param>
        /// <returns></returns>
        [HttpPut("partnerphis/{custId}")]
        public async Task<IActionResult> SaveExistPartnerPhis(int custId, [FromBody] Customer sourceCustomer)
        {
            IDbContextTransaction tran = null;
            // основна інформація
            var destinationCustomer = await _dbContext.Customer.Where(item => item.CustId == custId)
                .Include(item => item.AgreementMaster).ThenInclude( agrAdd => agrAdd.AgreementAddPartner)
                .Include(item => item.Partner).ThenInclude(pcl => pcl.PartnerClient)
                .Include(item => item.BankAccount)
                .Include(item => item.Person).ThenInclude(ank => ank.AnketaPerson)
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

        /// <summary>
        /// синхронізація даних для ФІЗИНИХ осіб
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
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
                    _dbContext.AppendList(sorsItem.AgreementAddPartner, item.AgreementAddPartner, i => { }, (l, r) => l.AgrId == r.AgrId && l.Version == r.Version, new[] { "CustId", "AgrId" });
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

        /// <summary>
        /// збереження ІСНУЮЧОГО представника ЮРИДИЧНОЇ особи
        /// </summary>
        /// <param name="custId"></param>
        /// <param name="sourceCustomer"></param>
        /// <returns></returns>
        [HttpPut("partnerjur/{custId}")]
        public async Task<IActionResult> SaveExistPartnerJur(int custId, [FromBody] Customer sourceCustomer)
        {
            IDbContextTransaction transaction = null;
            var destinationCustomer = await _dbContext.Customer.Where(item => item.CustId == custId)
                .Include(item => item.AgreementMaster).ThenInclude(agrAdd => agrAdd.AgreementAddCommunity)
                .Include(item => item.Partner).ThenInclude(pcl => pcl.PartnerClient)
                .Include(item => item.BankAccount)
                .Include(item => item.Company).ThenInclude(rempl => rempl.RelEmployee).ThenInclude(empl => empl.Empl)
                .Include(item => item.Company).ThenInclude(ank => ank.AnketaCompany)
                .SingleOrDefaultAsync();
            try
            {
                UpdatePartnerDataJ(sourceCustomer, destinationCustomer);
                transaction = await _dbContext.Database.BeginTransactionAsync();
                await _dbContext.SaveChangesAsync();
                transaction.Commit();
                transaction = null;

                return Json(destinationCustomer);
            }
            catch (Exception ex)
            {
                if(transaction != null)
                    transaction.Rollback();
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// сихнронізація даних для ЮРИДИЧНИХ ОСІБ
        /// </summary>
        /// <param name="source"></param>
        /// <param name="destination"></param>
        private void UpdatePartnerDataJ(Customer source, Customer destination)
        {
            destination.SetFields(source);
            // банківські
            _dbContext.UpdateList(source.BankAccount, destination.BankAccount, row => row.BanAccId = 0, (sorsItem, destItem) => sorsItem.BanAccId == destItem.BanAccId);
            // клієнт * партнер?
            //if (destination.Client == null)
            //    destination.Client = new Client();
            //destination.Client.SetFields(source.Client);

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
                    item.SetFields(sorsItem, new []{ "AgrId" });
                    //_dbContext.AppendList(sorsItem.AgreementAddPartner, item.AgreementAddPartner, i => { }, (l, r) => l.AgrId == r.AgrId && l.Version == r.Version, new[] { "CustId", "AgrId" });
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

            if (destination.CustType == 3) // Company
            {
                if (destination.Company == null)
                    destination.Company = new Company();

                var sorsList = source.Company.AnketaCompany.ToList();
                _dbContext.UpdateList(sorsList, destination.Company.AnketaCompany, rec => { }, (sorsItem, destItem) => sorsItem.Version == destItem.Version);

                //керівники
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

            }
        }

        /// <summary>
        /// Список всіх представників
        /// </summary>
        /// <returns></returns>
        [HttpGet("list")]
        public async Task<IActionResult> GetPartnersList()
        {
            
            var list = await _dbContext.Customer.FromSql(@"
select t1.* from Customer t1 
join Partner t2 on t2.custId = t1.custId 
")
                .Include(item => item.AgreementMaster)
                .Include(item => item.Person).ThenInclude(ank => ank.AnketaPerson)
                .Include(item => item.Partner).ThenInclude(agrAdd => agrAdd.AgreementAddPartner)
                .Include(partcl => partcl.Partner.PartnerClient)
                .Include(item => item.BankAccount)
                .AsNoTracking().ToListAsync();
            return Json(list);
        }

        //отримати анкету представника по ID клієнта (не представника)
        [HttpGet("listcl/{clientId}")]
        public async Task<IActionResult> GetPartnerByClientId(int clientId)
        {
            var partnerId = await _dbContext.PartnerClient.SingleOrDefaultAsync(rec => rec.ClCustId == clientId);
            if (partnerId == null)
                return Json(null);

            var partner = await _dbContext.Customer.Where(rec => rec.CustId == partnerId.CustId)
                .Include(item => item.AgreementMaster)
                .Include(item => item.Person).ThenInclude(ank => ank.AnketaPerson)
                .Include(item => item.Partner).ThenInclude(agrAdd => agrAdd.AgreementAddPartner)
                .Include(partcl => partcl.Partner.PartnerClient)
                .SingleOrDefaultAsync();

            // old call
            //var anketaPerson = await _dbContext.AnketaPerson.SingleOrDefaultAsync(rec => rec.CustId == partnerId.CustId);

            return Json(partner);
        }

        /// <summary>
        /// отримати всі дані представника по ID представника
        /// </summary>
        /// <param name="custId"></param>
        /// <returns></returns>
        [HttpGet("list/{custId}")]
        public async Task<IActionResult> GetPartnerAnketaById(int custId)
        {
            var partner = await _dbContext.Customer.Where(rec => rec.CustId == custId)
                .Include(item => item.AgreementMaster)
                .Include(item => item.Person).ThenInclude(ank => ank.AnketaPerson)
                .Include(item => item.Partner).ThenInclude(agrAdd => agrAdd.AgreementAddPartner)
                .Include(partcl => partcl.Partner.PartnerClient)
                .Include(item => item.BankAccount)
                .SingleOrDefaultAsync();
            return Json(partner);
        }

        [HttpGet("{custId}")]
        public async Task<IActionResult> GetPartnerAllData(int custId)
        {
            Customer customer = null;
            // основна інформація
            var custType = _dbContext.Customer.Where(item => item.CustId == custId).SingleOrDefault().CustType;
            if(custType == 1) // фізична особа 
            {
                customer = await _dbContext.Customer.Where(item => item.CustId == custId)
                    .Include(item => item.AgreementMaster)
                    .Include(item => item.Person).ThenInclude(ank => ank.AnketaPerson)
                    .Include(item => item.Partner).ThenInclude(agrAdd => agrAdd.AgreementAddPartner)
                    .Include(partcl => partcl.Partner.PartnerClient)
                    .Include(item => item.BankAccount)
                    .SingleOrDefaultAsync();
            }
            else if (custType == 3) // юридична особа
            {
                customer = await _dbContext.Customer.Where(item => item.CustId == custId)
                    .Include(item => item.AgreementMaster)
                    .Include(item => item.Company).ThenInclude(ank => ank.AnketaCompany)
                    .Include(item => item.Company).ThenInclude(rempl => rempl.RelEmployee).ThenInclude(empl => empl.Empl)
                    .Include(item => item.Partner).ThenInclude(agrAdd => agrAdd.AgreementAddPartner)
                    .Include(partcl => partcl.Partner.PartnerClient)
                    .Include(item => item.BankAccount)
                    .SingleOrDefaultAsync();
            }

            return Json(customer);
        }

        /// <summary>
        /// призначити клієнтові представника
        /// </summary>
        /// <param name="clientId">ID КЛІЄНТА</param>
        /// <param name="partnerId">ID ПРЕДСТАВНИКА</param>
        /// <returns></returns>
        [HttpPost("{clientId}/insert/{partnerId}")]
        public async Task<IActionResult> SetPartnerOnClient(int clientId, int partnerId)
        {
            IDbContextTransaction tran = null;
            try
            {
                PartnerClient partnerClient = new PartnerClient
                {
                    CustId = partnerId,
                    ClCustId = clientId
                };
                _dbContext.PartnerClient.Add(partnerClient);

                tran = _dbContext.Database.BeginTransaction();
                _dbContext.SaveChanges();
                tran.Commit();
                tran = null;

                var partner = await _dbContext.PartnerClient.SingleOrDefaultAsync(rec => rec.CustId == partnerId && rec.ClCustId == clientId);
                return Json(partner);
            }
            catch (Exception ex)
            {
                if (tran != null)
                    tran.Rollback();
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// змінити клієнтові представника
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="partnerId"></param>
        /// <param name="oldPartnerId"></param>
        /// <returns></returns>
        [HttpPut("{clientId}/update/{partnerId}/{oldPartnerId}")]
        public async Task<IActionResult> ChangePartnerOnClient(int clientId, int partnerId, int oldPartnerId)
        {
            IDbContextTransaction tran = null;
            try
            {
                var partnerClient = await _dbContext.PartnerClient.SingleOrDefaultAsync(rec => rec.CustId == oldPartnerId && rec.ClCustId == clientId);

                var destination = new PartnerClient();
                destination.SetFields(partnerClient);
                destination.CustId = partnerId;
                //видалити старий custId не модифікується
                _dbContext.PartnerClient.Remove(partnerClient);
                //додати новий
                _dbContext.PartnerClient.Add(destination);
                tran = _dbContext.Database.BeginTransaction();
                _dbContext.SaveChanges();
                tran.Commit();
                tran = null;

                var partner = await _dbContext.PartnerClient.SingleOrDefaultAsync(rec => rec.CustId == partnerId && rec.ClCustId == clientId);
                return Json(partner);
            }
            catch (Exception ex)
            {
                if (tran != null)
                    tran.Rollback();
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// вилучити клієнтові представника
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="partnerId"></param>
        /// <returns></returns>
        [HttpDelete("{clientId}/remove/{partnerId}")]
        public async Task<IActionResult> RemovePartnerOnClient(int clientId, int partnerId)
        {
            IDbContextTransaction tran = null;
            try
            {
                // search
                var partnerClient = await _dbContext.PartnerClient.SingleOrDefaultAsync(rec => rec.CustId == partnerId && rec.ClCustId == clientId);
                // remove
                _dbContext.PartnerClient.Remove(partnerClient);

                tran = _dbContext.Database.BeginTransaction();
                _dbContext.SaveChanges();
                tran.Commit();
                tran = null;

                var partner = await _dbContext.PartnerClient.SingleOrDefaultAsync(rec => rec.CustId == partnerId && rec.ClCustId == clientId);
                return Json(partner);
            }
            catch (Exception ex)
            {
                if (tran != null)
                    tran.Rollback();
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// зміна статусу представника
        /// </summary>
        /// <param name="custId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpPut("{custId}/statuschange/{status}")]
        public async Task<IActionResult> ChangePartnerStatus(int custId, int status)
        {
            IDbContextTransaction tran = null;
            try
            {
                int custStatus = default(int); // customer
                int ankStatus = default(int);  // anketa
                int agrStatus = default(int);  // agreement
                switch (status)
                {
                    case 2: // ACTIVE
                        custStatus = 2;
                        ankStatus = 2;
                        agrStatus = 2;
                        break;
                    case 4: //CLOSE
                        custStatus = 9;
                        ankStatus = 9;
                        agrStatus = 4;
                        break;

                    default: throw new ArgumentOutOfRangeException("Неможливо змінити на обраний статус!");
                }
                
                // основна інформація
                var partner = await _dbContext.Customer.Where(item => item.CustId == custId)
                    .Include(item => item.AgreementMaster).ThenInclude(agr => agr.AgreementAddPartner)
                    .Include(item => item.Partner).ThenInclude(pcl => pcl.PartnerClient)
                    .Include(item => item.Person).ThenInclude(ank => ank.AnketaPerson)
                    .SingleOrDefaultAsync();
                if (partner != null)
                {
                    partner.Status = custStatus;

                    if (partner.AgreementMaster?.SingleOrDefault() != null)
                        partner.AgreementMaster.SingleOrDefault().AgrStatus = agrStatus;

                    if(partner.AgreementMaster.SingleOrDefault()?.AgreementAddPartner?.SingleOrDefault() != null)
                        partner.AgreementMaster.SingleOrDefault().AgreementAddPartner.SingleOrDefault().AgrStatus = agrStatus;

                    if (partner.Person?.AnketaPerson?.SingleOrDefault() != null)
                        partner.Person.AnketaPerson.SingleOrDefault().Status = ankStatus;
                }

                tran = _dbContext.Database.BeginTransaction();
                _dbContext.SaveChanges();
                tran.Commit();
                tran = null;

                return Json(partner);
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