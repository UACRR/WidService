using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ipsmedserviceapp.Controllers.Resources;
using ipsmedserviceapp.DATA;
using ipsmedserviceapp.Model;
using ipsmedserviceapp.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using IpsCommonTypes.Enums;

namespace ipsmedserviceapp.Controllers
{
    [Produces("application/json")]
    [Route("api/Consumer")]
    public class ConsumerController : Controller
    {
        private readonly AmountDistributor _rateDistributor;
        private MediaServiceContext _dbContext;
        private IConfiguration _config;
        private ILogger<ConsumerController> _logger;

        public ConsumerController(MediaServiceContext dbContext, IConfiguration config, ILogger<ConsumerController> logger)
        {
            _dbContext = dbContext;
            _config = config;
            _logger = logger;

            _rateDistributor = new AmountDistributor
            {
                Amount = 100
            };
        }

        /// <summary>
        /// Додаткові дані по великим правам
        /// </summary>
        /// <param name="bigRConsumer"></param>
        /// <returns></returns>
        private async Task GetConsumerBR(Customer bigRConsumer)
        {
            foreach (var item in bigRConsumer.Client.LicenseAgreement.Where(rec => rec.LicenseBigR != null))
            {
                await _dbContext.Entry(item).Reference(rec => rec.LicenseBigR).Query()
                    .Include(rec => rec.Obj).ThenInclude(obj => obj.Authors)
                    .Include(rec => rec.Obj).ThenInclude(obj => obj.CopyRight)
                    .LoadAsync();

                await _dbContext.Entry(item).Collection(rec => rec.MoneyPeriodLink).Query().Include(rec => rec.Period).LoadAsync();

                foreach (var royalty in item.LicenseBigR.Obj.CopyRight)
                {
                    await _dbContext.Entry(royalty).Reference(r => r.LicAuthorBr).LoadAsync();
                }

            }
        }

        //отримати всі дані
        private async Task<Customer> GetConsumerAllData(int id)
        {
            // Отримати основну інформацію
            var cust = await _dbContext.Customer.Where(row => row.CustId == id)
                        .Include(item => item.Company).ThenInclude(comp => comp.RelEmployee)
                        .Include(item => item.AnketaCompany)
                        .Include(item => item.Person)
                        .Include(item => item.AnketaPerson)
                        .Include(item => item.BankAccount)
                        .Include(item => item.FileCustomer).ThenInclude(file => file.DocTypeNavigation)
                        .Include(item => item.Client).ThenInclude(cln => cln.ClnBusinessPlace)
                        .Include(item => item.Client).ThenInclude(cln => cln.MoneyReceived)
                        .SingleOrDefaultAsync();
            if (cust.Client == null)
                return null;
            // Отримати дані по Контрактах
            await _dbContext.Entry(cust.Client).Collection(rec => rec.LicenseAgreement)
                .Query()
                .Where(agree => (agree.LicType ?? 1) <= 3) // не закриті не технічні Ліцензійні договора
                .Include(item => item.Agr)
                .Include(item => item.LicCodeNavigation)
                .Include(item => item.LicenseBigR).ThenInclude(br => br.MusicalDesign).ThenInclude(md => md.Obj).ThenInclude(obj => obj.MediaTrack)
                .Include(rec => rec.PaidPeriod)
                .LoadAsync();

            foreach (var licAgreement in cust.Client.LicenseAgreement)
            {
                // AggreAddBr 
                await _dbContext.Entry(licAgreement.Agr).Collection(rec => rec.AgreementAddBr)
                    .Query()
                    .Where(item => item.Version >= licAgreement.Agr.Version)
                    .LoadAsync();
                // LicenseBigR
                await _dbContext.Entry(licAgreement).Reference(rec => rec.LicenseBigR)
                    .Query()
                    .Include(item => item.Obj).ThenInclude(obj => obj.CopyRight).ThenInclude(cprt => cprt.WorkRh)
                    .Include(item => item.Obj).ThenInclude(obj => obj.CopyRight).ThenInclude(cprt => cprt.LicAuthorBr)
                    .LoadAsync();
                // Лцензії для майданчиків
                await _dbContext.Entry(licAgreement).Collection(rec => rec.LicenseAgrParam)
                    .Query()
                    //.Where(rec => rec.LicVersion >= licAgreement.LicVersion || rec.LicVersion == licAgreement.ProlongVersion)
                    .Include(rec => rec.License)
                    .LoadAsync();

                await _dbContext.Entry(licAgreement).Collection(rec => rec.MoneyPeriodLink).Query()
                    .Include(r => r.Period).LoadAsync();
                // Великі права
            }
            // Великі права
            await GetConsumerBR(cust);

            // Отримати Майданчики
            foreach (var place in cust.Client.ClnBusinessPlace)
            {
                await _dbContext.Entry(place).Collection(item => item.ClnPlaceHoll).LoadAsync();
                await _dbContext.Entry(place).Reference(item => item.PlCodeNavigation).LoadAsync();
            }

            // Отримати співробітників (юридична осба)
            if (cust.CustType == 3)
                foreach (var relEmp in cust.Company.RelEmployee)
                {
                    await _dbContext.Entry(relEmp).Reference(item => item.Empl).LoadAsync();
                }

            return cust;

        }

        [HttpGet("info/{id}")]
        public async Task<IActionResult> GetConsumerShortInfoById(int id)
        {
            var list = await _dbContext.getViewData($"select * from vTsk_1_ListConsumer where custId={id}", null);
            return Ok(list.FirstOrDefault());
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
            if (cust == null)
                return NotFound();
            return Json(cust);
        }

        /// <summary>
        /// Зберегти Споживача до Id
        /// </summary>
        /// <param name="id">ідентифікатор CustId бази даних</param>
        /// <returns></returns>
        [HttpPut("detail/{id}")]
        public async Task<IActionResult> SaveConsumerById(int id, [FromBody] Customer sorsCustomer)
        {
            IDbContextTransaction tran = null;
            var destConsumer = await GetConsumerAllData(id);
            try
            {
                // Customer
                InternalUpdateConsumer(sorsCustomer, destConsumer);

                tran = _dbContext.Database.BeginTransaction();
                _dbContext.SaveChanges();
                tran.Commit();
                tran = null;


                return Json(destConsumer);
            }
            catch (DbUpdateException)
            {
                tran?.Rollback();
                //if()
                string msg = "Спроба видалити майданчик, який включений до діючої ліцензії!";
                //return BadRequest(ex.Message);
                return BadRequest(msg);
            }
            catch (Exception ex)
            {
                if (tran != null)
                    tran.Rollback();
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("genagrprol/{agrId}")]
        public async Task<IActionResult> SaveGeneralAgreement(int agrId, [FromBody] LicenseAgreement licenseAgreement)
        {
            IDbContextTransaction tran = null;
            try
            {
                var destinationAgr = await _dbContext.AgreementAddBr.SingleOrDefaultAsync(rec => rec.AgrId == agrId);
                var sourceAgr = licenseAgreement.Agr.AgreementAddBr.SingleOrDefault();
                destinationAgr.SetFields(sourceAgr, new[] { "CustId", "AgrId" });

                tran = await _dbContext.Database.BeginTransactionAsync();
                await _dbContext.SaveChangesAsync();
                tran.Commit();
                tran = null;


                return Json(null);
            }
            catch (Exception ex)
            {
                if (tran != null)
                    tran.Rollback();
                return BadRequest(ex.Message);
            }
        }

        private void PrepareDataToUpdate(Customer sorsCustomer, Customer destCustomer)
        {
        }

        /// <summary>
        /// Синхронізація об'єктів Customer 
        /// </summary>
        /// <param name="sorsCustomer"></param>
        /// <param name="destCustomer"></param>
        private void InternalUpdateConsumer(Customer sorsCustomer, Customer destCustomer)
        {

            PrepareDataToUpdate(sorsCustomer, destCustomer);

            destCustomer.SetFields(sorsCustomer, new[] { "CustId" });
            //.Include(item => item.BankAccount)
            _dbContext.UpdateList(sorsCustomer.BankAccount, destCustomer.BankAccount, row => row.BanAccId = 0, (sorsItem, destItem) => sorsItem.BanAccId == destItem.BanAccId);
            //.Include(item => item.RightHolder)
            if (destCustomer.Client == null)
                destCustomer.Client = new Client();
            destCustomer.Client.SetFields(sorsCustomer.Client);

            if (sorsCustomer.Company != null && destCustomer.Company == null)
                destCustomer.Company = new Company();
            destCustomer.Company.SetFields(sorsCustomer.Company);
            //dest.Company.RelEmployee.SetFields(updCustomer.Company.RelEmployee);

            // Звязок BuisnessPlace джерела та цілі
            Dictionary<int, ClnBusinessPlace> dicPlace = new Dictionary<int, ClnBusinessPlace>();
            // 
            var places = destCustomer.Client.ClnBusinessPlace.Where(rec => !sorsCustomer.Client.ClnBusinessPlace.Any(item => item.PlaceId == rec.PlaceId)).ToList();
            places.ForEach(item =>
            {
                _dbContext.ClnPlaceHoll.RemoveRange(item.ClnPlaceHoll);
                _dbContext.ClnBusinessPlace.Remove(item);
            });

            places = destCustomer.Client.ClnBusinessPlace.Where(rec => sorsCustomer.Client.ClnBusinessPlace.Any(item => item.PlaceId == rec.PlaceId)).ToList();
            places.ForEach(item =>
            {

                var sorsItem = sorsCustomer.Client.ClnBusinessPlace.Where(rec => item.PlaceId == rec.PlaceId).SingleOrDefault();
                _dbContext.UpdateList(sorsItem.ClnPlaceHoll, item.ClnPlaceHoll, i => { }, (l, r) => l.HollId == r.HollId);
                item.SetFields(sorsItem);
                dicPlace.Add(sorsItem.PlaceId, item);
            });
            places = sorsCustomer.Client.ClnBusinessPlace.Where(rec => !destCustomer.Client.ClnBusinessPlace.Any(item => item.PlaceId == rec.PlaceId)).ToList();
            places.ForEach(sorsItem =>
            {
                ClnBusinessPlace item = new ClnBusinessPlace();
                item.SetFields(sorsItem, new[] { "PlaceId" });
                _dbContext.AppendList(sorsItem.ClnPlaceHoll, item.ClnPlaceHoll, i => { }, (l, r) => l.PlaceId == r.PlaceId);
                destCustomer.Client.ClnBusinessPlace.Add(item);
                dicPlace.Add(sorsItem.PlaceId, item);
            });

            // LicenseAgreement
            {
                void addLicense(bool isNew, License oldLic, License lic)
                {
                    if (isNew == false) return;
                    if (oldLic.PlaceId == null) return;
                    if (dicPlace.Keys.Contains(oldLic.PlaceId ?? 0) == false) return;

                    ClnBusinessPlace place = dicPlace[oldLic.PlaceId ?? 0];
                    place.License.Add(lic);
                }
                // Delete
                List<LicenseAgreement> tempList = destCustomer.Client.LicenseAgreement.Where(row => !sorsCustomer.Client.LicenseAgreement.Any(item => row.LicId == item.LicId)).ToList();
                tempList.ForEach(item =>
                {
                    // Delete LicenseAgreement
                    var agreeItem = destCustomer.AgreementMaster.Where(rec => rec.AgrId == item.AgrId).SingleOrDefault();
                    agreeItem.LicenseAgreement.Remove(item);
                    destCustomer.Client.LicenseAgreement.Remove(item);

                    _dbContext.LicenseAgreement.Remove(item);
                }
                );

                // Modify
                tempList = sorsCustomer.Client.LicenseAgreement.Where(row => destCustomer.Client.LicenseAgreement.Any(item => row.LicId == item.LicId)).ToList();
                tempList.ForEach(item =>
                {

                    var license = destCustomer.Client.LicenseAgreement.Where(rec => rec.LicId == item.LicId).SingleOrDefault();

                    if (license.AgrId != item.AgrId)
                    {
                        license.AgrId = item.AgrId;
                        license.Agr.LicenseAgreement.Remove(license);
                        if (license.Agr.LicenseAgreement.Count() == 0)
                            _dbContext.AgreementMaster.Remove(license.Agr);
                    }
                    else
                    {
                        // Delete LicenseAgreement
                        var agreeItemDest = destCustomer.AgreementMaster.Where(rec => rec.AgrId == item.AgrId).SingleOrDefault();
                        var agreeItemSors = item.Agr;
                        agreeItemDest.SetFields(agreeItemSors);
                        _dbContext.UpdateList(agreeItemSors.AgreementAddBr, agreeItemDest.AgreementAddBr, i => { }, (l, r) => l.Version == r.Version);
                    }

                    license.SetFields(item);
                    _dbContext.UpdateList(item.LicenseAgrParam, license.LicenseAgrParam, i => { }, (l, r) => l.LicVersion == r.LicVersion);

                    var sorsDic = item.LicenseAgrParam.ToDictionary(rec => rec.LicVersion);
                    foreach (var destParam in license.LicenseAgrParam)
                    {
                        var sorsParam = sorsDic[destParam.LicVersion];
                        _dbContext.UpdateListExtra(sorsParam.License, destParam.License, (isNew, oldItem, newItem) => addLicense(isNew, oldItem, newItem), (l, r) => l.LicVersion == r.LicVersion && l.PlaceId == r.PlaceId, new[] { "LId" });
                    }



                    // Заявка
                    if (item.LicenseBigR != null)
                    {
                        // Nested update
                        UpdateLicenseBigR(item, license);
                    }




                });
                // Add
                tempList = sorsCustomer.Client.LicenseAgreement.Where(row => !destCustomer.Client.LicenseAgreement.Any(item => row.LicId == item.LicId)).ToList();
                tempList.ForEach(item =>
                {

                    // Delete LicenseAgreement
                    var agreeItem = item.Agr;
                    var destAgreeItem = destCustomer.AgreementMaster.Where(rec => rec.AgrId == item.AgrId).SingleOrDefault();
                    if (destAgreeItem == null)
                    {
                        destAgreeItem = new AgreementMaster();
                        destAgreeItem.SetFields(agreeItem, new[] { "AgrId" });
                        destCustomer.AgreementMaster.Add(destAgreeItem);
                    }

                    var license = new LicenseAgreement { LicVersion = 1 };
                    license.SetFields(item, new[] { "LicId", "LicVersion" });

                    _dbContext.AppendList(item.LicenseAgrParam, license.LicenseAgrParam, (sors, dest) =>
                    {
                        _dbContext.AppendListExtra(sors.License, dest.License, (isNew, oldItem, newItem) => addLicense(isNew, oldItem, newItem), (l, r) => l.PlaceId == r.PlaceId, new[] { "LId" });
                    }, (l, r) => l.LicVersion == r.LicVersion);


                    if (item.LicenseBigR != null)
                    {
                        UpdateLicenseBigR(item, license);
                    }

                    destCustomer.Client.LicenseAgreement.Add(license);
                    destAgreeItem.LicenseAgreement.Add(license);

                    if (agreeItem?.AgreementAddBr != null && destAgreeItem?.AgreementAddBr != null)
                        _dbContext.AppendList(agreeItem.AgreementAddBr, destAgreeItem?.AgreementAddBr, i => { }, (l, r) => l.Version == r.Version);
                });
            }

            if (destCustomer.CustType == 3) // Company
            {
                if (destCustomer.Company == null)
                    destCustomer.Company = new Company();

                var sorsList = sorsCustomer.Company.AnketaCompany.ToList();
                _dbContext.UpdateList(sorsList, destCustomer.Company.AnketaCompany, rec => { }, (sorsItem, destItem) => sorsItem.Version == destItem.Version);

                // RelEmployee
                // del
                var relEmployeeList = sorsCustomer.Company.RelEmployee.Where(rec => !string.IsNullOrEmpty(rec.Empl?.LastName?.Trim())).ToList();
                var listRel = destCustomer.Company.RelEmployee.Where(rec => !relEmployeeList.Any(item => item.Emplid == rec.Emplid && item.PositionCode == rec.PositionCode)).ToList();
                listRel.ForEach(delitem =>
                {
                    _dbContext.Employee.Remove(delitem.Empl);
                    _dbContext.RelEmployee.Remove(delitem);
                    destCustomer.Company.RelEmployee.Remove(delitem);

                });
                // upd
                listRel = destCustomer.Company.RelEmployee.Where(rec => relEmployeeList.Any(item => item.Emplid == rec.Emplid && item.PositionCode == rec.PositionCode)).ToList();
                listRel.ForEach(updItem =>
                {
                    var sorsItem = listRel.SingleOrDefault(item => item.Emplid == updItem.Emplid && item.PositionCode == updItem.PositionCode);
                    updItem.SetFields(sorsItem);
                    updItem.Empl.SetFields(sorsItem?.Empl);
                });

                // 
                var relEmpl = sorsCustomer.Company.RelEmployee.Select(items => items.Empl).ToList();
                listRel = destCustomer.Company.RelEmployee.Where(rec => relEmployeeList.Any(item => item.Emplid == rec.Emplid && item.PositionCode == rec.PositionCode)).ToList();

                listRel.ForEach(updEmpl =>
                {
                    var sourceItem = relEmpl.SingleOrDefault(item => item.Emplid == updEmpl.Emplid);
                    updEmpl.SetFields(sorsCustomer.Company.RelEmployee.SingleOrDefault(item => item.Emplid == updEmpl.Emplid && item.PositionCode == updEmpl.PositionCode));
                    updEmpl.Empl.SetFields(sourceItem);
                });

                listRel = relEmployeeList.Where(rec => !destCustomer.Company.RelEmployee.Any(item => item.Emplid == rec.Emplid && item.PositionCode == rec.PositionCode)).ToList();
                listRel.ForEach(addItem =>
                {
                    Employee addEmpl = new Employee();
                    addEmpl.SetFields(addItem.Empl);
                    RelEmployee addRelItem = new RelEmployee { Empl = addEmpl };
                    addRelItem.SetFields(addItem);
                    addEmpl.CustId = addRelItem.CustId;
                    destCustomer.Employee.Add(addEmpl);
                    destCustomer.Company.RelEmployee.Add(addRelItem);
                });
            }
            else
            {
                //.Include(item => item.Person)
                if (destCustomer.Person == null)
                    destCustomer.Person = new Person();
                _dbContext.AppendList(sorsCustomer.Person.AnketaPerson, destCustomer.Person.AnketaPerson, rec => { }, (sorsItem, destItem) => sorsItem.Version == destItem.Version);
                //.Include(item => item.AnketaPerson)
            }

            //.Include(item => item.Community)
        }

        /// <summary>
        /// Сінхронізація Великих прав
        /// </summary>
        /// <param name="item"></param>
        /// <param name="license"></param>
        private void UpdateLicenseBigR(LicenseAgreement item, LicenseAgreement license)
        {
            if (item.LicenseBigR == null)
                return;
            if (license.LicenseBigR == null)
                license.LicenseBigR = new LicenseBigR();

            license.LicenseBigR.SetFields(item.LicenseBigR);

            _dbContext.UpdateList(item.LicenseBigR.MusicalDesign, license.LicenseBigR.MusicalDesign, i => { }, (l, r) => l.MdId == r.MdId);

            if (item.LicenseBigR.Obj != null)
            {

                if (item.LicenseBigR.Obj.ObjId == 0)
                {
                    ObjectRight newObj = new ObjectRight();
                    _dbContext.ObjectRight.Add(newObj);
                    license.LicenseBigR.Obj = newObj;
                }
                else
                    license.LicenseBigR.Obj.SetFields(item.LicenseBigR.Obj);

                license.LicenseBigR.Obj.SetFields(item.LicenseBigR.Obj);

                _dbContext.UpdateListExtra(item.LicenseBigR.Obj.CopyRight, license.LicenseBigR.Obj.CopyRight,
                    (isnew, sorsCp, destCp) =>
                    {
                        if (sorsCp.WorkRh != null)
                        {
                            if (destCp.WorkRh == null)
                            {
                                destCp.WorkRh = new WorkRh();
                                _dbContext.WorkRh.Add(destCp.WorkRh);

                            }
                            destCp.WorkRh.SetFields(sorsCp.WorkRh);
                        }

                        if (sorsCp.LicAuthorBr != null)
                        {
                            if (destCp.LicAuthorBr == null)
                            {
                                destCp.LicAuthorBr = new LicAuthorBr();
                                _dbContext.LicAuthorBr.Add(destCp.LicAuthorBr);
                            }
                            destCp.LicAuthorBr.SetFields(sorsCp.LicAuthorBr);
                        }

                    }, (l, r) => l.CRightId == r.CRightId);

                // calculate Rate by RoleRate
                // перерахувати %
                if (license.LicenseBigR.Rate.HasValue && license.LicenseBigR.Rate != 0 && license.LicenseBigR.Obj.CopyRight.Any())
                {
                    var sumRate = 0m;
                    foreach (var copyRight in license.LicenseBigR.Obj.CopyRight)
                    {
                        copyRight.Rate = Math.Round(((copyRight.RoleRate ?? 0) * 100) / license.LicenseBigR.Rate.Value, 2);
                        sumRate += copyRight.Rate;
                    }

                    // згладжування
                    var delta = Math.Round(100m - sumRate, 2);
                    if (delta != 0 && sumRate != 0)
                    {
                        sumRate = 0m;
                        var list = license.LicenseBigR.Obj.CopyRight.Where(rec => rec.RoleRate.HasValue && rec.RoleRate.Value != 0).ToList();

                        var divDelta = Math.Round(delta / list.Count, 2);
                        foreach (var copyRight in list)
                        {
                            copyRight.Rate = Math.Round(copyRight.Rate + divDelta, 2);
                            sumRate += copyRight.Rate;
                        }

                        // вирівнювання до 100%
                        delta = Math.Round(100m - sumRate, 2);
                        if (delta != 0)
                        {
                            license.LicenseBigR.Obj.CopyRight.OrderByDescending(rec => rec.Rate).First().Rate += delta;
                        }
                    }
                }

                _dbContext.UpdateList(item.LicenseBigR.Obj.Authors, license.LicenseBigR.Obj.Authors, i => { }, (l, r) => l.AuthId == r.AuthId);
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
                license.LicenseAgrParam.Add(new LicenseAgrParam { LicVersion = 1, LicStatus = 0 });
                addAgr.LicenseAgreement.Add(license);
                // addAgr.LicenseAgreement.Add(new LicenseAgreement { LicStatus = 0 });
                newCust.Client.LicenseAgreement.Add(license);
                newCust.AgreementMaster.Add(addAgr);
                if (custType == 3) // юр особа
                {
                    // Компанія
                    newCust.Company = new Company();
                    // Анкета
                    newCust.Company.AnketaCompany.Add(new AnketaCompany { Version = 1, Status = 2, TypeVat = 1 });
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
        /// Дані по LicenseAgrParam -> LicenseAgreement Для нового Споживача
        /// </summary>
        /// <param name="sorsCustomer"></param>
        private void FillLicenseAgreement(Customer sorsCustomer)
        {
            foreach (var item in sorsCustomer.Client.LicenseAgreement)
            {
                item.Agr.AgrStatus = 0;
                var param = item.LicenseAgrParam.Where(rec => rec.LicVersion == item.LicVersion).Single();
                // ***** Потрібно змінити після підключення кабінету
                item.LicStatus = 0;
                param.LicStatus = 0;


            }
        }

        /// <summary>
        /// Збереження нового Споживача
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        [HttpPost("newconsumer")]
        public async Task<IActionResult> NewConsumer([FromBody] Customer source)
        {
            IDbContextTransaction transaction = null;
            try
            {
                if (source == null)
                    throw new Exception("new consumer is empty");

                if (!(source.CustType > 0 && source.CustType < 4))
                    throw new Exception("Bad customer type for new consumer");

                var target = new Customer { CustId = 0 };
                _dbContext.Customer.Add(target);

                InternalUpdateConsumer(source, target);

                transaction = _dbContext.Database.BeginTransaction();
                _dbContext.SaveChanges();

                if (target.Client.LicenseAgreement.FirstOrDefault()?.LicId is int licId)
                {
                    var licVersion = target.Client.LicenseAgreement.FirstOrDefault()?.LicVersion ?? 1;
                    
                    // викликати процедуру присвоєння номеру договору для користувача
                    string setAgrNumber = "exec pTsk4_GetClnNdog @licId, @version";
                    _dbContext.Database.ExecuteSqlCommand(setAgrNumber, new SqlParameter("@licId", licId), new SqlParameter("@version", licVersion));
                }

                transaction.Commit();
                transaction = null;

                return await GetConsumerById(target.CustId);
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                return BadRequest(ex.ToString());
            }
        }

        /// <summary>
        /// Отримати список Споживачів малих прав
        /// </summary>
        /// <returns></returns>
        [HttpGet("listSR/{whatId}")]
        public async Task<IActionResult> GetListSmallRight(int whatId, [FromQuery] ConsumerSmallRightResource queryResource)
        {
            ConsumersSmallRightFilter what = Enum.Parse<ConsumersSmallRightFilter>(whatId.ToString());

            string function = "select * from ft_tsk_1_LicenseAgreementList (@strSeek)";

            switch (what)
            {
                case ConsumersSmallRightFilter.All:
                case ConsumersSmallRightFilter.None:
                    break;
                case ConsumersSmallRightFilter.Working:
                    function = string.Concat(function, " where statusActive = 1");
                    break;
                case ConsumersSmallRightFilter.ForAccept:
                    function = string.Concat(function, " where statusForAccept = 1");
                    break;
                case ConsumersSmallRightFilter.NotAccepted:
                    function = string.Concat(function, " where statusNoAccept = 1");
                    break;
                case ConsumersSmallRightFilter.ForProlongation:
                    function = string.Concat(function, " where statusProlong = 1");
                    break;
                case ConsumersSmallRightFilter.ForDistribution:
                    function = string.Concat(function, " where statusUndistribute = 1");
                    break;
                case ConsumersSmallRightFilter.UnattachedMoney:
                    function = string.Concat(function, " where statusUnattach = 1");
                    break;
                case ConsumersSmallRightFilter.Debt:
                    function = string.Concat(function, " where statusBorg = 1");
                    break;
                case ConsumersSmallRightFilter.ReceivingMoney:
                    function = string.Concat(function, " where statusNoReport = 1");
                    break;
                case ConsumersSmallRightFilter.ReceivingRegister:
                    function = string.Concat(function, " where statusNoMoney = 1");
                    break;
                case ConsumersSmallRightFilter.RegisterStatusOk:
                    function = string.Concat(function, " where rgStatusOk = 1");
                    break;
                case ConsumersSmallRightFilter.RegisterStatusRefuse:
                    function = string.Concat(function, " where rgStatusRefuse = 1");
                    break;
            }

            string strSeek = !string.IsNullOrEmpty(queryResource?.SearchText) ? queryResource.SearchText.Replace('\'', '_') : string.Empty;

            var totalItems = (await _dbContext.getViewData(function.Replace("*", "count(*)"), new[] { new SqlParameter("@strSeek", strSeek) }))
                .FirstOrDefault()?.Values.FirstOrDefault();

            int page = 1;
            int pageSize = 200;

            if (queryResource.Page.HasValue)
                page = (int)queryResource.Page;

            if (queryResource.PageSize.HasValue)
                pageSize = (int)queryResource.PageSize;

            // paging conditions
            string orderBy = $" ORDER BY custId OFFSET {(page - 1) * pageSize} ROWS FETCH NEXT {pageSize} ROWS ONLY";
            function = string.Concat(function, orderBy);

            var list = await _dbContext.getViewData(function, new[] { new SqlParameter("@strSeek", strSeek) });

            return Ok(new
            {
                List = list,
                TotalItems = totalItems
            });
        }

        [HttpGet("listall")]
        public async Task<IActionResult> GetListAll(int whatId)
        {
            string query = "select * from vTsk_1_ListConsumer";
            var List = await _dbContext.getViewData(query, null);
            return Ok(List);
        }

        #region * * * Змінні для фільтрів * * *

        Dictionary<ConsumersBigRightFilter, string> validQueryForAllDocs = new Dictionary<ConsumersBigRightFilter, string> {
            { ConsumersBigRightFilter.ForDistribution, "statusUndistribute=1"},
            { ConsumersBigRightFilter.Debt, "isnull(borg,0)>0"},
            { ConsumersBigRightFilter.UnattachData, "isnull(unattachAmount,0)>0"}
        };

        private readonly Dictionary<ConsumersBigRightCategoryFilter, Dictionary<ConsumersBigRightFilter, string>> validDocRequest = new Dictionary<ConsumersBigRightCategoryFilter, Dictionary<ConsumersBigRightFilter, string>>
        {
            {
                ConsumersBigRightCategoryFilter.GenAgreement, new Dictionary<ConsumersBigRightFilter, string>
                {
                    {ConsumersBigRightFilter.All, ""},
                    {ConsumersBigRightFilter.Working, "statusMasterActive=1"},
                    {ConsumersBigRightFilter.NotAccepted, "agrStatus=1"},
                    {ConsumersBigRightFilter.NotConfirmed, "agrStatus=0"},
                    {ConsumersBigRightFilter.ForProlongation, "statusMasterProlong=1"},
                    {ConsumersBigRightFilter.Closed, "agrStatus=4"}
                }
            },
            {
                ConsumersBigRightCategoryFilter.License, new Dictionary<ConsumersBigRightFilter, string>
                {
                    {ConsumersBigRightFilter.All, "countLic1NoActive+countLic1Active>0"},
                    {ConsumersBigRightFilter.Working, "statusLic1Active=1"},
                    {ConsumersBigRightFilter.NotActive, "statusLic1Noactive=1"},
                    {ConsumersBigRightFilter.ForProlongation, "statusLic1ToProlong=1"}
                }
            },
            {
                ConsumersBigRightCategoryFilter.Request, new Dictionary<ConsumersBigRightFilter, string>
                {
                    {ConsumersBigRightFilter.All, "countLic2Active+countLic2NoActive>0"},
                    {ConsumersBigRightFilter.Working, "statusLic2Active=1"},
                    {ConsumersBigRightFilter.NotActive, "statusLic2Noactive=1"}
                }
            },
            {
                ConsumersBigRightCategoryFilter.Reference, new Dictionary<ConsumersBigRightFilter, string>
                {
                    {ConsumersBigRightFilter.All, "countLic3Active+countLic3NoActive>0"},
                    {ConsumersBigRightFilter.Working, "statusLic3Active=1"},
                    {ConsumersBigRightFilter.NotActive, "statusLic3Noactive=1"}
                }
            }
        };

        #endregion


        #region * * * ВЕЛИКІ ПРАВА * * *

        /// <summary>
        /// Список SQL VIEW для великих прав
        /// </summary>
        private Dictionary<string, string> listBrView = new Dictionary<string, string>
        {
            {"vTsk_vBRLicense", "vTsk_vBRLicense"},
            {"vTsk_1_ListConsumer01", "vTsk_1_ListConsumer01"},
            {"vTsk_1_ListConsumer02", "vTsk_1_ListConsumer02"},
            {"vTsk_1_BRBid", "vTsk_1_BRBid"},
            {"vTsk_1_BRBidAuthors", "vTsk_1_BRBidAuthors"},
            {"vTsk_1_BRNotice", "vTsk_1_BRNotice"},
            {"vTSK_1_BRMaster", "vTSK_1_BRMaster"},
            {"vTSK_1_BRRegister", "vTSK_1_BRRegister"},
            {"vTsk_1_MoneyUndescrib", "vTsk_1_MoneyUndescrib"},
            {"vTSK_1_BRMoneyPrepay", "vTSK_1_BRMoneyPrepay"},
            {"vTSK_1_BRObjects", "vTSK_1_BRObjects"},
            {"vTsk_1_BRAuthorsDistributed", "vTsk_1_BRAuthorsDistributed"},
            {"vTsk_1_BRMusic", "vTsk_1_BRMusic"},
            {"vTsk_6_ListPartner", "vTsk_6_ListPartner"},
            {"vTsk_6_ListPClient", "vTsk_6_ListPClient"},
            {"vTsk_6_ListFreeCln", "vTsk_6_ListFreeCln"}
        };

        /// <summary>
        /// Отримати VIEW по назві
        /// </summary>
        /// <param name="viewName"></param>
        /// <param name="custId"></param>
        /// <returns></returns>
        [HttpGet("BR/view/list")]
        public async Task<IActionResult> GetBigRightView([FromQuery] string viewName, [FromQuery] int? custId)
        {
            if (viewName == null || !listBrView.Keys.Contains(viewName))
                return BadRequest();

            string QueryStr = string.Concat("select * from ", listBrView[viewName]);
            // Немає параметру по Споживачу
            if (custId == null)
            {
                var list = await _dbContext.getViewData(QueryStr, null);
                return Json(list);
            }
            else
            {
                QueryStr = string.Concat(QueryStr, " where custId = @custId");
                var list = await _dbContext.getViewData(QueryStr, new[] { new SqlParameter("@custId", custId) });
                return Json(list);

            }
        }

        /// <summary>
        /// Отримати список [Користувачі Великих прав]
        /// </summary>
        /// <returns></returns>
        [HttpGet("listBR")]
        public async Task<IActionResult> GetListBR([FromQuery(Name = "whatId")] int whatId, [FromQuery(Name = "typeDocId")] int typeDocId)
        {
            ConsumersBigRightFilter what = Enum.Parse<ConsumersBigRightFilter>(whatId.ToString());
            ConsumersBigRightCategoryFilter typeDoc = Enum.Parse<ConsumersBigRightCategoryFilter>(typeDocId.ToString());
            string queue = "select * from vtsk_1_MasterListBR";


            if (validDocRequest.Keys.Contains(typeDoc))
            {
                Dictionary<ConsumersBigRightFilter, string> filterObject = validDocRequest[typeDoc];
                if (filterObject.Keys.Contains(what))
                {
                    string filter = filterObject[what];
                    if (!string.IsNullOrEmpty(filter))
                    {
                        queue = string.Concat(queue, " where ", filter);
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            // Недопустиміе параметрі запроса для вібора всех елементов
            else if (typeDoc == ConsumersBigRightCategoryFilter.All && validQueryForAllDocs.Keys.Contains(what))
                queue = $"{queue} where {validQueryForAllDocs[what]}";
            else
                queue = queue + " where 1 != 0";  // условие для вібора пустого множества


            var List = await _dbContext.getViewData(queue, null);


            return Json(List);
        }

        [HttpGet("listBR/agrmaster/{custId}")]
        public async Task<IActionResult> GetAgrForCustId(int custId)
        {
            string queue = "select * from vTSK_1_BRMaster where custId = @custId";

            var List = await _dbContext.getViewData(queue, new[] { new SqlParameter("@custId", custId) });


            return Json(List);
        }

        [HttpGet("listBR/{custId}")]
        public async Task<IActionResult> GetLicensesForCustId(int custId)
        {
            string queue = "select * from vTsk_vBRLicense where custId = @custId";

            var List = await _dbContext.getViewData(queue, new[] { new SqlParameter("@custId", custId) });


            return Json(List);
        }

        /// <summary>
        /// Збереження Погодження Користувача
        /// </summary>
        /// <param name="licId"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPut("BR/WorkRH/{licId}")]
        public async Task<IActionResult> SaveBrWorkRH(int licId, [FromBody] List<WorkRh> body)
        {
            var lic = await _dbContext.LicenseAgreement.Where(rec => rec.LicId == licId).SingleAsync();

            await _dbContext.Entry(lic).Reference(rec => rec.LicenseBigR)
                    .Query()
                    .Include(rec => rec.Obj).ThenInclude(obj => obj.CopyRight)
                    .LoadAsync();

            var licBr = lic.LicenseBigR;

            foreach (var item in licBr.Obj.CopyRight)
                await _dbContext.Entry(item).Reference(rec => rec.WorkRh)
                    .LoadAsync();


            var dic = licBr.Obj.CopyRight.ToDictionary(rec => rec.CRightId);
            foreach (var item in body)
            {
                if (item == null)
                    continue;

                var dest = dic[item.CRightId];
                if (dest.WorkRh == null)
                    dest.WorkRh = new WorkRh { CRightId = item.CRightId };

                dest.WorkRh.SetFields(item);
            }

            IDbContextTransaction tran = null;
            try
            {
                tran = await _dbContext.Database.BeginTransactionAsync();
                await _dbContext.SaveChangesAsync();
                tran.Commit();
                tran = null;
            }
            catch (Exception)
            {
                tran?.Rollback();
                throw;
            }

            return Ok();
        }

        #endregion

        [HttpGet("listAutoCompleted")]
        public async Task<IActionResult> GetFilteredList([FromQuery]string filter)
        {
            string normalizeFilter = string.Concat(filter, "%");
            var list = await _dbContext.getViewData("select name, custid from vCustomer where custType = 3 and name like @filter", new[] { new SqlParameter("@filter", normalizeFilter) });

            var retList = list.Select(rec => new { displayValue = rec["name"], value = rec["custid"] }).ToArray();

            return Json(retList);
        }

        #region Action FOR LICENSEAGREEMENT ******************************************************

        [HttpPut("license/type/{licId}/{typeId}")]
        public async Task<IActionResult> SetLicenseAgreementType(int licId, int typeId)
        {
            var lic = await _dbContext.LicenseAgreement.SingleOrDefaultAsync(rec => rec.LicId == licId && rec.LicStatus != 4);
            if (lic == null)
                return BadRequest();

            if (typeId == 1)
            {
                var licenseBigR = await _dbContext.LicenseBigR
                    .Include(rec => rec.Obj)
                        .ThenInclude(obj => obj.CopyRight)
                    .SingleOrDefaultAsync(rec => rec.LicId == lic.LicId);
                var licenseAgrParam = await _dbContext.LicenseAgrParam.SingleOrDefaultAsync(rec => rec.LicId == lic.LicId);

                licenseAgrParam.DateBegin = licenseBigR.DatePremiere;
                if (licenseBigR.LicTerm is short licTerm)
                    licenseAgrParam.DateEnd = licenseBigR.DatePremiere.Value.AddYears(licTerm);

                // MED-505
                foreach (var cpRight in licenseBigR.Obj.CopyRight)
                    cpRight.Status = 1;
            }

            lic.LicType = typeId;


            await _dbContext.SaveChangesAsync();

            return Json(lic);
        }

        /// <summary>
        /// Зміна статусу 
        /// </summary>
        /// <param name="licid"></param>
        /// <param name="version"></param>
        /// <param name="status"></param>
        private async Task<LicenseAgreement> SetLicAgrStatus(int licid, int version, int status, bool toChangeVersion)
        {
            // *******  Отримати дані з бази по договорам
            var licAgreement = await _dbContext.LicenseAgreement.Where(rec => rec.LicId == licid)
                .Include(rec => rec.Agr)
                .Include(rec => rec.LicCodeNavigation).ThenInclude(code => code.UsesKindNavigation)
                .SingleOrDefaultAsync();

            // LicClass тільки для великих прав
            if (licAgreement.LicClass == 1) // Ген угода Великих Прав 
            {
                await _dbContext.Entry(licAgreement.Agr).Collection(rec => rec.AgreementAddBr).Query()
                    .Where(item => item.Version >= licAgreement.Agr.Version).LoadAsync();

                await _dbContext.Entry(licAgreement.Agr).Collection(rec => rec.LicenseAgreement)
                    .LoadAsync();

                var cntLicense = licAgreement.Agr.LicenseAgreement.Count(rec => rec.LicStatus != 4 && rec.LicClass == 2);
                // Перевірка на пусту ген угоду
                if (status == 4 && cntLicense > 0)
                    throw new CloseAgreementWithActiveLicense("Закривається Генеральна угода з незакритими ліцензійними угодами");
            }

            await _dbContext.Entry(licAgreement).Collection(item => item.LicenseAgrParam)
                .Query()
                .Where(rec => rec.LicVersion >= version || rec.LicVersion == licAgreement.ProlongVersion).LoadAsync();



            LicenseAgrParam licParam = licAgreement?.LicenseAgrParam?.SingleOrDefault(rec => rec.LicVersion == version);
            AgreementAddBr addBr = licAgreement.Agr.AgreementAddBr.SingleOrDefault(rec => rec.Version == version);


            // Якщо змінюється версія 
            if (version > licAgreement.LicVersion && toChangeVersion)
            {
                if (licAgreement.LicClass != 1) // Малі права та ліцензійні договора Великих прав
                {
                    // попередня ліцензія що повинна закритись
                    var closeAgr = await _dbContext.LicenseAgrParam
                        .SingleOrDefaultAsync(rec => rec.LicId == licAgreement.LicId &&
                                                     rec.LicVersion == licAgreement.LicVersion);
                    if (closeAgr != null)
                        closeAgr.LicStatus = 4; // Close

                    if (licAgreement.LicCodeNavigation.UsesKindNavigation.UsesType == 2) // малі права
                        licAgreement.Agr.Version = version;
                    // Видаляємо ліцензії закритої версії
                    _dbContext.License.RemoveRange(licParam.License);

                }
                else
                {
                    if (addBr != null)
                        addBr.AgrStatus = 4; // Close
                    licAgreement.Agr.Version = version;

                }
                licAgreement.LicVersion = version;

                if (licParam != null)
                    licParam = licAgreement.LicenseAgrParam.Single(rec => rec.LicVersion == licAgreement.LicVersion);
                addBr = licAgreement.Agr.AgreementAddBr.SingleOrDefault(rec => rec.Version == licAgreement.Agr.Version);
            }

            // *******   Зміна статусу
            if (licAgreement.LicVersion == version)
                licAgreement.LicStatus = status;

            if (licAgreement.LicClass != 1) // не Генеральна угода
            {
                if (licParam != null)
                    licParam.LicStatus = status;
                if (licAgreement.LicCodeNavigation.UsesKindNavigation.UsesType == 2) // Малі права
                    licAgreement.Agr.AgrStatus = status;
            }
            else // Генеральна угода
            {
                licAgreement.Agr.AgrStatus = status;
                if (addBr != null)
                    addBr.AgrStatus = status;
            }

            if (status == 4) // Закрити договір
            {
                foreach (var item in licAgreement.LicenseAgrParam)
                    item.LicStatus = status;
                foreach (var item in licAgreement.Agr.AgreementAddBr)
                    item.AgrStatus = status;
            }

            return licAgreement;

        }

        /// <summary>
        /// Видалення ліцензійного договору
        /// </summary>
        /// <param name="licId">ID ліцензії</param>
        /// <param name="licVersion">Версія ліцензії</param>
        /// <returns></returns>
        private async Task<LicenseAgrParam> DeleteLicenseAgreement(int licId, int licVersion)
        {
            var licenseAgrParam = await _dbContext.LicenseAgrParam
                .SingleOrDefaultAsync(rec => rec.LicId == licId && rec.LicVersion == licVersion);
            licenseAgrParam.LicStatus = 10;

            // договір що був створений для пролонгації
            var license = await _dbContext.LicenseAgreement
                .SingleOrDefaultAsync(rec => rec.LicId == licId && rec.ProlongVersion == licVersion);
            if (license != null)
                license.ProlongVersion = null;

            // видалити ліцензії бізнес-точок
            var placeLicenses = await _dbContext.License
                .Where(rec => rec.LicId == licId && rec.LicVersion == licVersion).ToListAsync();
            if (placeLicenses.Any())
                _dbContext.License.RemoveRange(placeLicenses);

            return licenseAgrParam;
        }

        /// <summary>
        /// Зміна статусу ліцензії: підтвердження, закривання, видалення і т.д.
        /// </summary>
        /// <param name="lic">Ліцензія з якою будуть виконані дії</param>
        /// <param name="version">Версія доп угоди</param>
        /// <returns></returns>
        [HttpPut("license/State/{version}/{status}/{toChangeVersion}")]
        public async Task<IActionResult> LicenseActionAccept(int version, int status, int toChangeVersion, [FromBody] LicenseAgreement lic)
        {
            IDbContextTransaction tran = null;
            try
            {
                if (status == 10)
                    await DeleteLicenseAgreement(lic.LicId, version);
                else
                    await SetLicAgrStatus(lic.LicId, version, status, toChangeVersion == 0 ? false : true);

                tran = await _dbContext.Database.BeginTransactionAsync();
                await _dbContext.SaveChangesAsync();
                tran.Commit();
                tran = null;

                return Ok();
            }
            catch (CloseAgreementWithActiveLicense ex)
            {
                tran?.Rollback();
                return BadRequest(ex.InnerException.Message);
            }
            catch (Exception ex)
            {
                tran?.Rollback();
                return BadRequest(ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Закриті ліцензії (status 4)
        /// </summary>
        /// <param name="custId"></param>
        /// <returns></returns>
        [HttpGet("license/closed/{custId}")]
        public async Task<IActionResult> GetClosedLicenseAgreements(int custId)
        {
            try
            {
                var licIds = await _dbContext.LicenseAgreement.Where(rec => rec.CustId == custId).Select(rec => rec.LicId).ToListAsync();
                var license = await _dbContext.LicenseAgrParam
                    .Where(rec => rec.LicStatus == 4 && licIds.Contains(rec.LicId))
                    .ToListAsync();

                return Ok(license);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

        #region period POST PUT DELETE ******************************************************

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
                    .LoadAsync();


                await _dbContext.DistributionItem.FromSql(@"
select t3.* from PaidPeriod t1 join Distribution t2 on t2.periodId = t1.periodId 
join DistributionItem t3 on t3.distId = t2.distId
where t1.licid = @licid", new SqlParameter("@licid", licid))
                    .LoadAsync();

                return Json(licenseAgrement.Cust.Cust);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        } // GetPeriodDetail(int licid)

        /// <summary>
        /// Збереження стану Періода платежів
        /// </summary>
        /// <param name="periodid"></param>
        /// <param name="stateid"></param>
        /// <returns></returns>
        [HttpPut("period/state/{periodid}/{stateid}")]
        public async Task<IActionResult> SetPeriodState(int periodid, int stateid, [FromBody] PaidPeriod body)
        {
            var period = await _dbContext.PaidPeriod.Where(rec => rec.PeriodId == periodid)
                .Include(rec => rec.Lic)
                    .ThenInclude(lic => lic.LicCodeNavigation)
                        .ThenInclude(licCode => licCode.UsesKindNavigation)
                .Include(rec => rec.RegisterRatedList)
                .SingleOrDefaultAsync();
            if (period == null)
                return BadRequest();

            foreach (var rrl in period.RegisterRatedList)
                await _dbContext.Entry(rrl).Collection(rec => rec.Register).LoadAsync();

            var oldStatus = period.Status;
            period.Status = stateid;

            // При переході періоду зі статусу Прийом звітів на Прийом коштів
            // Розрахункові листи переходять в статус Погоджені
            // 17-04-2019 Патлякевич Ворона Добавлено Ограничение только для Малых прав
            if (oldStatus == 1 && stateid == 2 && period.Lic.LicCodeNavigation.UsesKindNavigation.UsesType != 1)
            {
                foreach (var rrl in period.RegisterRatedList)
                {
                    rrl.Status = 1;
                }
            }

            try
            {
                await _dbContext.SaveChangesAsync();
            }
            catch
            {
                throw;
            }

            //await _dbContext.SaveChangesAsync();
            return Ok(body);
        }

        /// <summary>
        /// Отримати детальну інформацію по звіту періоду
        /// </summary>
        /// <param name="regid">Ід звіта</param>
        /// <returns></returns>
        /// 
        [HttpGet("period/register/{regid}")]
        public async Task<IActionResult> GetRegisterDetail(int regid)
        {
            var register = await _dbContext.Register.Where(rec => rec.RegId == regid)
                .Include(rec => rec.RegisterItem)
                .Include(rec => rec.Rm)
                .SingleOrDefaultAsync();

            await _dbContext.RegisterExtra.Where(rec => rec.RegId == regid).LoadAsync();

            return Json(register);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sors"></param>
        /// <param name="dest"></param>
        private void ModifyRatedList(RegisterRatedList sors, RegisterRatedList dest)
        {

            if (dest.Status == 0 && sors.Status == 1) // MED-197 Період переходить в стан "Прийом коштів"
            {
                dest.Period.Status = 2;
                // Великі права
                if (dest.Period.Lic.LicCodeNavigation.UsesKindNavigation.UsesType == 1)
                {
                    // Змінюємо в джерелі статус з 2 на 3
                    foreach (var item in sors.Register)
                        item.RgStatus = 3;
                }
            }

            dest.SetFields(sors);
            var dicDest = dest.Register.ToDictionary(rec => rec.RegId);

            // delete register
            var listForDelete = dest.Register.Where(rec => !sors.Register.Any(item => item.RegId == rec.RegId)).ToList();
            foreach (var item in listForDelete)
            {
                // delete registerItem
                _dbContext.RegisterItem.RemoveRange(item.RegisterItem);
                dest.Register.Remove(item);
            }
            // delete from database register
            _dbContext.Register.RemoveRange(listForDelete);


            // modify and add new item
            foreach (var sorsItem in sors.Register)
            {
                Register destItem = null;
                if (!dicDest.Keys.Contains(sorsItem.RegId))
                {
                    destItem = new Register { CreateDate = DateTime.Today, LicId = sorsItem.LicId };
                    dest.Register.Add(destItem);
                    _dbContext.Register.Add(destItem);
                }
                else
                    destItem = dicDest[sorsItem.RegId];

                destItem.SetFields(sorsItem, new[] { "RegId", "CreateDate" });

                int regItemId = 1;

                if (destItem.RegisterItem.Count() > 0)
                    regItemId = regItemId + destItem.RegisterItem.Max(rec => rec.RegIitemId);


                _dbContext.ChangeTracker.AutoDetectChangesEnabled = false;

                if (sorsItem.RegisterItem.Count > 0)
                    _dbContext.UpdateListExtra(sorsItem.RegisterItem, destItem.RegisterItem,
                        (isNew, sorsRec, destRec) =>
                        {
                            destRec.SetFields(sorsRec);
                        // TICKS *********************************
                        // Виправлення даних для вирахування пропорціність використання твору
                        if (destRec.DurationItem == null)
                            {
                                destRec.DurationItem = TimeSpan.FromTicks( TimeSpan.TicksPerMillisecond ); 
                                destRec.Ticks = 1;
                            }

                            if (destRec.Ticks == 0)
                            {
                                if (destItem.AlgorithmId == 1)  // Duration
                                destRec.Ticks = Math.Max(1,
                                                             (int)(((TimeSpan)destRec.DurationItem).Ticks * Math.Max((destRec.CountUse ?? 0), 1) / TimeSpan.TicksPerMillisecond ));
                                else
                                    destRec.Ticks = 1;          // Count
                        }
                        // TICKS *********************************

                        if (isNew)
                                destRec.RegIitemId = regItemId++;

                            _dbContext.UpdateList(sorsRec.RegisterExtra, destRec.RegisterExtra, i => { }, (l, r) => l.RegExtraId == r.RegExtraId);
                        }
                        , (l, r) => l.RegId == r.RegId && l.RegIitemId == r.RegIitemId);

                _dbContext.ChangeTracker.AutoDetectChangesEnabled = true;

                destItem.CountRows = destItem.RegisterItem.Count();
                if (destItem.AlgorithmId == 1)
                {
                    var sumTicks = destItem.RegisterItem.Sum(rec => (long)(rec.Ticks));
                    destItem.Durationticks = (int)sumTicks;
                }
                else
                    destItem.Durationticks = destItem.RegisterItem.Count(rec => rec.Ticks != 0);
            }
        }

        /// <summary>
        /// Змінити звіт періоду
        /// </summary>
        /// <param name="regid">Ід звіта</param>
        /// <returns></returns>
        [HttpPost("period/register")]
        public async Task<IActionResult> PostRegisterDetail([FromBody] Register body)
        {

            IDbContextTransaction tran = null;
            try
            {
                if (body == null)
                    throw new ApplicationException("Empty Register Body");
                Register modifyItem = null;


                var regRatedList = _dbContext.RegisterRatedList.Where(rec => rec.RmId == body.RmId).Single();
                modifyItem = new Register { CreateDate = DateTime.Now, LicId = body.LicId };
                regRatedList.Register.Add(modifyItem);
                _dbContext.Register.Add(modifyItem);

                if (modifyItem == null)
                    throw new ApplicationException("Dont find Register item");

                ModifyRegister(body, modifyItem);

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
        [HttpPut("period/register/{regId}")]
        public async Task<IActionResult> PutRegisterDetail(int regId, [FromBody] Register body)
        {

            IDbContextTransaction tran = null;
            try
            {
                if (body == null)
                    throw new ApplicationException("Empty Register Body");
                Register modifyItem = null;


                modifyItem = await _dbContext.Register.Where(rec => rec.RegId == regId)
                                        .SingleOrDefaultAsync();

                if (modifyItem == null)
                    throw new ApplicationException("Dont find Register item");

                if (body.RegisterItem.Count() > 0)
                    await _dbContext.RegisterItem.Where(rec => rec.RegId == regId)
                        .Include(rec => rec.RegisterExtra)
                        .LoadAsync();


                ModifyRegister(body, modifyItem);
                modifyItem.RgStatus = 0;

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
        private void ModifyRegister(Register body, Register modifyItem)
        {
            // addItem.PeriodId
            modifyItem.SetFields(body, new[] { "RegId" });

            int index = modifyItem.RegisterItem.Max(rec => rec.RegIitemId);
            index++;

            _dbContext.UpdateListExtra(
                body.RegisterItem, 
                modifyItem.RegisterItem,
                (isNew, sorsItem, destItem) =>
                {
                    if (isNew)
                        destItem.RegIitemId = index++;

                    _dbContext.UpdateList(sorsItem.RegisterExtra, destItem.RegisterExtra, i => { },
                        (l, r) => l.RegExtraId == r.RegExtraId);
                },
                (l, r) => l.RegId == r.RegId && l.RegIitemId == r.RegIitemId);
        }

        /// <summary>
        /// Видалити звіт періоду
        /// </summary>
        /// <param name="regid">Ід звіта</param>
        /// <returns></returns>
        [HttpDelete("period/register/{regId}")]
        public async Task<IActionResult> DeleteRegisterDetail(int regId)
        {
            IDbContextTransaction tran = null;
            int[] validDeleteStatus = { 0, 5 };
            try
            {

                Register deleteItem = await _dbContext.Register.Where(rec => rec.RegId == regId)
                                        // .Include( rec=>rec.Rm )
                                        .Include(rec => rec.RegisterItem)
                                        .SingleOrDefaultAsync();
                if (deleteItem == null)
                    throw new ApplicationException("Dont find Register item");

                if (!validDeleteStatus.Contains(deleteItem.RgStatus ?? 0))
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

        [HttpPut("period/register/state/{stateId}")]
        public async Task<IActionResult> SetRegisterState(int stateId, [FromBody] List<Register> list)
        {
            IDbContextTransaction tran = null;
            try
            {
                _dbContext.Register.AttachRange(list);

                foreach (var item in list)
                {

                    var prop = _dbContext.Entry(item).Property(e => e.RgStatus);
                    item.RgStatus = stateId;
                    prop.IsModified = true;
                    if (stateId == 3)
                    {
                        await _dbContext.Entry(item).Reference(rec => rec.Rm).Query()
                            .Include(rec => rec.Period)
                            .LoadAsync();
                        item.Rm.Status = 1;
                        item.Rm.Period.Status = 2;
                    }

                }
                if (stateId == 3)
                {

                }

                tran = await _dbContext.Database.BeginTransactionAsync();
                await _dbContext.SaveChangesAsync();
                tran.Commit();
                return Json(list);

            }
            catch (Exception ex)
            {
                tran?.Rollback();
                return BadRequest(ex.InnerException.Message);
                throw;
            }



        }

        #endregion

        #region PaydPariod Services******************************************************
        /// <summary>
        /// Отримати Нерозподілені Платежі Споживача
        /// </summary>
        /// <param name="custId"></param>
        /// <returns></returns>
        [HttpGet("period/payments/{custId}")]
        public async Task<IActionResult> GetConsumerPayments(int custId)
        {
            string query = @"
select t1.* 
from ExternalPay t1 
join vCustomer t2 on t2.INNOKPO = t1.okpoCorr and t2.custId = @custId
left outer join MoneyReceived t3 on t3.paidId = t1.paidId
where
t3.paidId is null
or t3.amount > (t3.destribAmount+t3.destribPrepay)
";
            var list = await _dbContext.ExternalPay.FromSql(query, new SqlParameter("@custId", custId)).AsNoTracking().ToArrayAsync();
            return Json(list);
        }

        [HttpPut("period/payments/{custId}")]
        public async Task<IActionResult> PutExternalPay(int custId, [FromBody] List<ExternalPay> pays)
        {
            List<ExternalPay> dest = new List<ExternalPay>();
            foreach (var item in pays.Where(rec => rec.PaidId == 0))
            {
                var addRec = new ExternalPay();
                addRec.SetFields(item);
                dest.Add(addRec);
            }

            await _dbContext.ExternalPay.AddRangeAsync(dest);
            var tran = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                await _dbContext.SaveChangesAsync();
                foreach (var item in dest)
                {
                    MoneyReceived addRec = new MoneyReceived
                    {
                        PaidId = item.PaidId,
                        MoneyType = 1,
                        CustId = custId,
                        DateInvoice = item.DocDate ?? DateTime.Today,
                        NumberInvoice = item.DocNum,
                        GoalInvoice = item.Nplat,
                        Amount = Convert.ToDecimal(item.SCredit),
                        DestribAmount = 0,
                        DestribPrepay = 0
                    };

                    await _dbContext.MoneyReceived.AddAsync(addRec);
                }

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


        [HttpPut("period/payments/paidperiods/{custId}")]
        public async Task<IActionResult> SavePeriods(int custId, [FromBody] List<PaidPeriod> body)
        {
            var dest = await _dbContext.PaidPeriod.FromSql(@"
select t1.* from PaidPeriod t1
join LicenseAgreement t2 on t2.licId = t1.licId 
where t2.licStatus between 0 and 3
and t2.custId = @custId
", new SqlParameter("@custId", custId)).ToListAsync();

            _dbContext.AppendList(body, dest, i => { _dbContext.PaidPeriod.Add(i); }, (l, r) => l.PeriodId == r.PeriodId);

            var tran = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                await _dbContext.SaveChangesAsync();
                tran.Commit();

                tran = null;

                return Json(dest);
            }
            catch (Exception)
            {
                tran?.Rollback();
                return BadRequest();
            }

        }

        [HttpPut("period/payments/linkperiods/{custId}")]
        public async Task<IActionResult> SaveLink(int custId, [FromBody] List<MoneyPeriodLink> body)
        {
            string query = @"
select t1.* from MoneyPeriodLink t1
join PaidPeriod t2 on t2.periodId = t1.periodId
join LicenseAgreement t3 on t3.licId = t2.licId
where 
t3.custId = @custId
and t3.licStatus between 0 and 3
";
            var linkList = await _dbContext.MoneyPeriodLink.FromSql(query, new SqlParameter("@custId", custId))
                .ToListAsync();
            _dbContext.MoneyPeriodLink.AttachRange(linkList);

            _dbContext.AppendList(body, linkList, i => _dbContext.MoneyPeriodLink.Add(i), (l, r) => l.PaidId == r.PaidId && l.PeriodId == r.PeriodId);

            var tran = await _dbContext.Database.BeginTransactionAsync();

            try
            {
                await _dbContext.SaveChangesAsync();
                tran.Commit();
                tran = null;
                linkList = await _dbContext.MoneyPeriodLink.FromSql(query, new SqlParameter("@custId", custId))
                .Include(rec => rec.Paid)
                .Include(rec => rec.Period)
                .ToListAsync();
            }
            catch (Exception)
            {
                tran.Rollback();
                throw;
            }

            return Json(linkList);
        }

        [HttpGet("period/getcustomerinfo/{custId}")]
        public async Task<IActionResult> GetCustomerInfo(int custId)
        {
            var cust = await _dbContext.Customer.Where(rec => rec.CustId == custId)
                .Include(rec => rec.Client)
                .SingleOrDefaultAsync();

            await _dbContext.LicenseAgrParam.FromSql(@"
            select t1.* from LicenseAgrParam t1
            join LicenseAgreement t2 on t2.licId = t1.licId and t2.licVersion = t1.licVersion
            where t2.licStatus between 0 and 3 and  t2.custId = @custId
            ", new SqlParameter("@custId", custId))
                .Include(rec => rec.Lic)
                .LoadAsync();

            await _dbContext.MoneyReceived.FromSql(@"
select t1.* from MoneyReceived t1
where t1.custId = @custId
", new SqlParameter("@custId", custId))
                .Include(rec => rec.MoneyPeriodLink)
                .LoadAsync();

            await _dbContext.PaidPeriod.FromSql(@"
select t1.* from PaidPeriod t1
join LicenseAgreement t2 on t2.licId = t1.licId 
where t2.licStatus between 0 and 3
and t2.custId = @custId
", new SqlParameter("@custId", custId))
                .LoadAsync();



            return Json(cust);
        }


        /// <summary>
        /// Отримати розрахункові листи для споживача
        /// </summary>
        /// <param name="custId"></param>
        /// <returns></returns>
        [HttpGet("period/register/RatedList")]
        public async Task<IActionResult> GetRegisterInfoForCustomer([FromQuery] int custId)
        {
            var licenseAgreement = await _dbContext.LicenseAgreement.FromSql(@"
select t1.* 
from LicenseAgreement t1 
where t1.custId = @custId
and isnull(licType,1) between 1 and 3
", new SqlParameter("@custId", custId))
                .Include(lic => lic.Cust)
                    .ThenInclude(cln => cln.Cust)
                .Include(lic => lic.Agr)
                .Include( lic => lic.LicCodeNavigation )
                .ToListAsync();


            if (licenseAgreement.Count() == 0)
                return Ok();

            await _dbContext.MoneyReceived.Where(rec => rec.CustId == custId).LoadAsync();


            foreach (var item in licenseAgreement)
            {
                await _dbContext.Entry(item).Collection(rec => rec.PaidPeriod)
                    .Query()
                    // .Where(rec => rec.BeginDate >= item.DateBegin && rec.EndDate <= item.DateEnd )
                    .Include(rec => rec.RegisterRatedList).ThenInclude(reg => reg.Register)
                    .LoadAsync();

                await _dbContext.Entry(item).Collection(rec => rec.LicenseAgrParam).Query()
                    .Where(rec => rec.LicVersion == item.LicVersion).LoadAsync();

                await _dbContext.Entry(item.Agr).Collection(rec => rec.AgreementAddBr).Query()
                    .Where(rec => rec.Version == item.Agr.Version).LoadAsync();
            }

            var customer = licenseAgreement.First().Cust.Cust;
            return Json(customer);

        }

        /// <summary>
        /// Отримати Р/Л по ідентифікатору
        /// </summary>
        /// <param name="rmId"></param>
        /// <returns></returns>
        [HttpGet("period/register/RatedList/{rmId}")]
        public async Task<IActionResult> GetRatedListById(int rmId)
        {
            var item = await _dbContext.RegisterRatedList.Where(rec => rec.RmId == rmId)
                        .Include(rec => rec.Period)
                        .Include(rec => rec.Register)
                        .SingleOrDefaultAsync();

            return Json(item);
        }

        /// <summary>
        /// Створити новий Р/Л
        /// </summary>
        /// <param name="regId"></param>
        /// <returns></returns>
        [HttpGet("period/register/RegisterItem/{regId}")]
        public async Task<IActionResult> GetRegisterItems(int regId)
        {
            var list = await _dbContext.RegisterItem.Where(rec => rec.RegId == regId)
                .Include(rec => rec.RegisterExtra)
                .AsNoTracking().ToListAsync();
            return Json(list);
        }

        /// <summary>
        /// Створити звіту періоду
        /// </summary>
        /// <param name="regid">Ід звіта</param>
        /// <returns></returns>
        [HttpPost("period/register/RatedList")]
        public async Task<IActionResult> PostRegisterDetail([FromBody] RegisterRatedList body)
        {

            IDbContextTransaction tran = null;
            try
            {
                RegisterRatedList dest = null;

                dest = new RegisterRatedList { CreateDate = DateTime.Today };
                // _dbContext.RegisterRatedList.Add(dest);
                var period = await _dbContext.PaidPeriod
                    .Include(rec => rec.Lic)
                        .ThenInclude(lic => lic.LicCodeNavigation)
                            .ThenInclude(licCode => licCode.UsesKindNavigation)
                    .FirstOrDefaultAsync(rec => rec.PeriodId == body.PeriodId);

                if (period == null)
                    return NotFound();
                dest.SetFields(body);

                period.RegisterRatedList.Add(dest);

                ModifyRatedList(body, dest);

                tran = _dbContext.Database.BeginTransaction();
                await _dbContext.SaveChangesAsync();
                tran.Commit();
                tran = null;
                return Json(dest);
            }
            catch (Exception e)
            {
                if (tran != null)
                    tran.Rollback();
                return BadRequest(e.Message);
            }

        }

        // PostRegisterDetail
        /// <summary>
        /// Змінити Р/Л
        /// </summary>
        /// <param name="RmId"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        [HttpPut("period/register/RatedList/{RmId}")]
        public async Task<IActionResult> PutRegisterDetail(int RmId, [FromBody] RegisterRatedList body)
        {

            IDbContextTransaction tran = null;
            try
            {
                RegisterRatedList dest = null;
                dest = await _dbContext.RegisterRatedList.Where(rec => rec.RmId == body.RmId)
                    .Include(rec => rec.Register)
                    .Include(rec => rec.Period)
                    .ThenInclude(p => p.Lic)
                    .ThenInclude(lic => lic.LicCodeNavigation)
                    .ThenInclude(code => code.UsesKindNavigation)
                    .SingleOrDefaultAsync();

                foreach (var item in dest.Register)
                {
                    await _dbContext.RegisterItem.Where(rec => rec.RegId == item.RegId)
                            .Include(rec => rec.RegisterExtra)
                            .LoadAsync();
                }

                ModifyRatedList(body, dest);

                tran = _dbContext.Database.BeginTransaction();
                await _dbContext.SaveChangesAsync();
                tran.Commit();
                return Json(dest);
            }
            catch (Exception e)
            {
                tran?.Rollback();
                return BadRequest(e.Message);
            }

        } // PostRegisterDetail

        /// <summary>
        /// Видалення розрахункового листа
        /// </summary>
        /// <param name="RmId"></param>
        /// <returns></returns>
        [HttpDelete("period/register/RatedList/{RmId}")]
        public async Task<IActionResult> DeleteRatedList(int RmId)
        {
            var item = await _dbContext.RegisterRatedList.Where(rec => rec.RmId == RmId)
                .Include(rec => rec.Register)
                .SingleOrDefaultAsync();
            if (item == null)
                return BadRequest();


            _dbContext.Register.RemoveRange(item.Register);
            _dbContext.RegisterRatedList.Remove(item);

            IDbContextTransaction tran = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                await _dbContext.Database.ExecuteSqlCommandAsync(@"
delete RegisterItem
from RegisterItem t1
join Register t2 on t2.regId = t1.regId
where t2.rmId = @rmId", new SqlParameter("@rmId", RmId));

                await _dbContext.SaveChangesAsync();
                tran.Commit();
                tran = null;

            }
            catch (Exception)
            {
                tran?.Rollback();
                throw;
            }

            return Ok();
        }

        #endregion

        #region * * * Download/Upload files * * *

        /// <summary>
        /// Завантаження файлу(ів) на сервер
        /// </summary>
        /// <param name="custId"></param>
        /// <param name="typeDocument"></param>
        /// <returns></returns>
        [HttpPost("Document/{custId}/{typeDocument}")]
        public async Task<ActionResult> UploadDocument(int custId, int typeDocument, string comment, IFormFile file)
        {

            // Перевірка існування дерикторії
            string documentsFolder = _config.GetValue<string>("DocumentsFolder");
            string consumerPath = Path.Combine(documentsFolder, custId.ToString());
            if (!Directory.Exists(consumerPath))
                Directory.CreateDirectory(consumerPath);

            consumerPath = Path.Combine(consumerPath, "Consumer");
            if (!Directory.Exists(consumerPath))
                Directory.CreateDirectory(consumerPath);

            consumerPath = Path.Combine(consumerPath, typeDocument.ToString());
            if (!Directory.Exists(consumerPath))
                Directory.CreateDirectory(consumerPath);

            // Запис бази даних по файлу
            var fileRec = await _dbContext.FileCustomer.Where(rec => rec.CustId == custId && rec.DocFile == file.FileName).SingleOrDefaultAsync();
            if (fileRec == null)
            {
                fileRec = new FileCustomer { CustId = custId, DocFile = file.FileName, CreateDate = DateTime.Now, DocType = typeDocument };
                _dbContext.FileCustomer.Add(fileRec);
            }

            // var file = files.First();
            // Зберігаємо файл
            consumerPath = Path.Combine(consumerPath, file.FileName);
            var consumerSavePath = string.Concat(consumerPath, ".old");
            if (System.IO.File.Exists(consumerPath))
            {
                if (System.IO.File.Exists(consumerSavePath))
                    System.IO.File.Delete(consumerSavePath);
                System.IO.File.Move(consumerPath, consumerSavePath);


            }


            fileRec.ModifyDate = DateTime.Now;
            fileRec.DocComment = comment;
            // Зберігаємо файл на сервері

            var tran = await _dbContext.Database.BeginTransactionAsync();
            try
            {
                using (var stream = new FileStream(consumerPath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                await _dbContext.SaveChangesAsync();
                tran.Commit();
                // Видаляемо збережений файл
                if (System.IO.File.Exists(consumerSavePath))
                    System.IO.File.Delete(consumerSavePath);

                tran = null;
            }
            catch (Exception)
            {
                if (tran != null)
                    tran.Rollback();
                if (System.IO.File.Exists(consumerPath))
                    System.IO.File.Delete(consumerPath);

                // Востанавлюємо збережений файл
                if (System.IO.File.Exists(consumerSavePath))
                    System.IO.File.Move(consumerSavePath, consumerPath);
                return BadRequest();
            }

            return Ok();
        }

        /// <summary>
        /// Завантаження файлу(ів) з сервера
        /// </summary>
        /// <param name="custId"></param>
        /// <param name="typeDocument"></param>
        /// <param name="fileName"></param>
        /// <returns></returns>
        [HttpGet("Document/{custId}/{typeDocument}/{fileName}")]
        public IActionResult DownloadDocument(int custId, int typeDocument, string fileName)
        {
            // FileStream file = null;
            try
            {
                string documentsFolder = _config.GetValue<string>("DocumentsFolder");
                string consumerPath = Path.Combine(documentsFolder, custId.ToString());
                consumerPath = Path.Combine(consumerPath, "Consumer", typeDocument.ToString());
                consumerPath = Path.Combine(consumerPath, fileName);

                if (!System.IO.File.Exists(consumerPath))
                    return NotFound($"File or file path \"{consumerPath}\" not found!");
                //_logger.LogDebug("Begin Open File");

                // file = System.IO.File.OpenRead(consumerPath);

                //_logger.LogDebug("Begin Read File");
                //var retStream = File(file, "application/vnd.ms-word", Path.GetFileName(consumerPath));

                //return retStream;

                var mime = MimeTypeMap.GetMimeType(Path.GetExtension(consumerPath));

                var file = new FileStream(consumerPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                return File(file, mime, fileName);

            }
            catch
            {
                throw;
            }
            finally
            {
                // file?.Dispose();
            }
        }

        [HttpGet("existdocument/{custId}/{typeDocument}/{fileName}")]
        public IActionResult CheckExistDocument(int custId, int typeDocument, string fileName)
        {
            string documentsFolder = _config.GetValue<string>("DocumentsFolder");
            string consumerPath = Path.Combine(documentsFolder, custId.ToString());
            consumerPath = Path.Combine(consumerPath, "Consumer", typeDocument.ToString());
            consumerPath = Path.Combine(consumerPath, fileName);

            if (!System.IO.File.Exists(consumerPath))
            {
                var e = new FileNotFoundException($"Неможливо відкрити файл \"{fileName}\" або шлях до файлу \"{consumerPath}\" не існує!", fileName);
                return Ok(e);
            }

            return Ok(null);
        }

        /// <summary>
        /// Видалення файлу з сервера по ID
        /// </summary>
        /// <param name="fileId">ID файла</param>
        /// <returns>Результат запиту</returns>
        [HttpDelete("document/delete/{fileId}")]
        public async Task<IActionResult> DeleteFile(int fileId)
        {
            IDbContextTransaction transaction = null;
            try
            {
                var file = await _dbContext.FileCustomer.SingleOrDefaultAsync(rec => rec.DocId == fileId);
                if (file == null) return NotFound("Файлу з таким ID не існує!");

                // перевірка каталогів та наявності файлу
                string documentsFolder = _config.GetValue<string>("DocumentsFolder");
                string consumerPath = Path.Combine(documentsFolder, file.CustId.ToString());
                if (Directory.Exists(consumerPath))
                    consumerPath = Path.Combine(consumerPath, "Consumer", file.DocType.ToString());
                if (Directory.Exists(consumerPath))
                    consumerPath = Path.Combine(consumerPath, file.DocFile);
                // видалення за наявності
                if (System.IO.File.Exists(consumerPath))
                    System.IO.File.Delete(consumerPath);

                _dbContext.FileCustomer.Remove(file);
                transaction = await _dbContext.Database.BeginTransactionAsync();
                await _dbContext.SaveChangesAsync();
                transaction.Commit();
                transaction = null;
                return Ok();
            }
            catch (Exception e)
            {
                transaction?.Rollback();
                return BadRequest(e.Message);
            }
        }

        #endregion
    }

    public class CloseAgreementWithActiveLicense : Exception
    {
        public CloseAgreementWithActiveLicense(string message) : base(message)
        {
        }
    }
}