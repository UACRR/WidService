using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ipsmedserviceapp.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
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
        /// Додаткові дані по великим правам
        /// </summary>
        /// <param name="bigRConsumer"></param>
        /// <returns></returns>
        private async Task GetConsumerBR(Customer bigRConsumer)
        {
            foreach (var item in bigRConsumer.Client.LicenseAgreement.Where(rec => rec.LicenseBigR.Count() > 0))
            {
                await _dbContext.Entry(item).Collection(rec => rec.LicenseBigR).Query()
                    .Include(rec => rec.Obj).ThenInclude(obj => obj.Authors)
                    .Include(rec => rec.LicAuthorBr)
                    .LoadAsync();

                foreach (var lic in item.LicenseBigR)
                {
                    await _dbContext.Entry(lic.Obj).Collection(obj => obj.CopyRight).LoadAsync();
                }

            }
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
                        .Include(item => item.FileCustomer)
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
                    .Include(item => item.LicCodeNavigation)

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
                await _dbContext.Entry(licAgreement).Collection(rec => rec.LicenseBigR)
                    .Query()
                    .Where(item => item.LicVersion >= licAgreement.LicVersion)
                    .Include( item => item.Obj ).ThenInclude(obj=>obj.CopyRight).ThenInclude(cprt=>cprt.WorkRh)
                    .LoadAsync();
                // Лцензії для майданчиків
                await _dbContext.Entry(licAgreement).Collection(rec => rec.LicenseAgrParam)
                    .Query()
                    .Where(rec => rec.LicVersion >= licAgreement.LicVersion)
                    .Include(rec => rec.License)
                    .LoadAsync();

                await _dbContext.Entry(licAgreement).Collection(rec => rec.MoneyPeriodLink).LoadAsync();
                // Великі права
            }
            // Великі права
            await GetConsumerBR(cust);

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
        [Authorize]
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
            catch (Exception ex)
            {
                if (tran != null)
                    tran.Rollback();
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Внутрішній метод збереження змін по Споживачу
        /// </summary>
        /// <param name="sorsCustomer"></param>
        /// <param name="destCustomer"></param>
        private void InternalUpdateConsumer(Customer sorsCustomer, Customer destCustomer)
        {
            destCustomer.SetFields(sorsCustomer);
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
            });
            places = sorsCustomer.Client.ClnBusinessPlace.Where(rec => !destCustomer.Client.ClnBusinessPlace.Any(item => item.PlaceId == rec.PlaceId)).ToList();
            places.ForEach(item =>
            {
                ClnBusinessPlace clnPlace = new ClnBusinessPlace();
                clnPlace.SetFields(item);
                _dbContext.AppendList(item.ClnPlaceHoll, clnPlace.ClnPlaceHoll, i => { }, (l, r) => l.PlaceId == r.PlaceId);
                destCustomer.Client.ClnBusinessPlace.Add(clnPlace);
            });

            // LicenseAgreement
            {
                Dictionary<int, ClnBusinessPlace> dicPlace = sorsCustomer.Client.ClnBusinessPlace.ToDictionary(rec => rec.PlaceId);
                Action<License> addLicense = (lic) =>
                {
                    if (lic.PlaceId == null)
                        return;
                    int placeId = (int)lic.PlaceId;
                    ClnBusinessPlace place = null;
                    if (!dicPlace.Keys.Contains(placeId))
                    {
                        place = new ClnBusinessPlace { PlaceId = placeId };
                        _dbContext.ClnBusinessPlace.Attach(place);
                        dicPlace.Add(placeId, place);
                    }
                    else
                        place = dicPlace[placeId];

                    place.License.Add(lic);
                };
                // Delete
                List<LicenseAgreement> tempList = destCustomer.Client.LicenseAgreement.Where(row => !sorsCustomer.Client.LicenseAgreement.Any(item => row.LicId == item.LicId)).ToList();
                tempList.ForEach(item =>
                {
                    // Delete LicenseAgreement
                    var agreeItem = destCustomer.AgreementMaster.Where(rec => rec.AgrId == item.AgrId).SingleOrDefault();
                    // var delLicense = agreeItem.LicenseAgreement.Where(rec => rec.LicId == item.LicId).SingleOrDefault();
                    agreeItem.LicenseAgreement.Remove(item);
                    destCustomer.Client.LicenseAgreement.Remove(item);

                    // LicenseBigR
                    //if (item.LicenseBigR != null)
                    //{

                    //    //_dbContext.LicAuthorBr.RemoveRange(item.LicenseBigR.LicAuthorBr);
                    //    _dbContext.LicenseBigR.Remove(item.LicenseBigR);
                    //}
                    // AgreementMaster
                    _dbContext.LicenseAgreement.Remove(item);

                }
                );

                // Modify
                tempList = sorsCustomer.Client.LicenseAgreement.Where(row => destCustomer.Client.LicenseAgreement.Any(item => row.LicId == item.LicId)).ToList();
                tempList.ForEach(item =>
                {

                    // Delete LicenseAgreement
                    var agreeItemDest = destCustomer.AgreementMaster.Where(rec => rec.AgrId == item.AgrId).SingleOrDefault();
                    var agreeItemSors = item.Agr;
                    agreeItemDest.SetFields(agreeItemSors);

                    var license = destCustomer.Client.LicenseAgreement.Where(rec => rec.LicId == item.LicId).SingleOrDefault();
                    license.SetFields(item);
                    _dbContext.UpdateList(item.LicenseAgrParam, license.LicenseAgrParam, i => { }, (l, r) => l.LicVersion == r.LicVersion);

                    if (item.LicenseBigR != null)
                    {
                        //if (license.LicenseBigR == null)
                        //    license.LicenseBigR = new LicenseBigR();
                        license.LicenseBigR.SetFields(item.LicenseBigR);

                        //_dbContext.UpdateList(item.LicenseBigR.LicAuthorBr, license.LicenseBigR.LicAuthorBr, i => { }, (l, r) => l.LicId == r.LicId && l.LicAuthorId == r.LicAuthorId);
                    }


                    var sorsDic = item.LicenseAgrParam.ToDictionary(rec => rec.LicVersion);
                    foreach (var destParam in license.LicenseAgrParam)
                    {
                        var sorsParam = sorsDic[destParam.LicVersion];
                        _dbContext.UpdateList(sorsParam.License, destParam.License, i => addLicense(i), (l, r) => l.LicVersion == r.LicVersion && l.PlaceId == r.PlaceId, new[] { "LId" });
                    }

                    _dbContext.UpdateList(agreeItemSors.AgreementAddBr, agreeItemDest.AgreementAddBr, i => { }, (l, r) => l.Version == r.Version);

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

                    var addLicItem = new LicenseAgreement { LicVersion = 1 };
                    addLicItem.SetFields(item, new[] { "LicId" });

                    _dbContext.AppendList(item.LicenseAgrParam, addLicItem.LicenseAgrParam, (sors, dest) =>
                    {
                        _dbContext.AppendList(sors.License, dest.License, i => addLicense(i), (l, r) => l.PlaceId == r.PlaceId, new[] { "LId" });
                    }, (l, r) => l.LicVersion == r.LicVersion);


                    if (item.LicenseBigR != null)
                    {
                        //addLicItem.LicenseBigR = new LicenseBigR();
                        addLicItem.LicenseBigR.SetFields(item.LicenseBigR);
                        //_dbContext.AppendList(item.LicenseBigR.LicAuthorBr, addLicItem.LicenseBigR.LicAuthorBr
                        //            , i => { }
                        //            , (l, r) => l.LicId == r.LicId && l.LicAuthorId == r.LicAuthorId);
                    }
                    destCustomer.Client.LicenseAgreement.Add(addLicItem);
                    destAgreeItem.LicenseAgreement.Add(addLicItem);

                    // old: _dbContext.AppendList(agreeItem?.AgreementAddBr, destAgreeItem?.AgreementAddBr, i => { }, (l, r) => l.Version == r.Version);
                    if (agreeItem?.AgreementAddBr != null && destAgreeItem?.AgreementAddBr != null)
                        _dbContext.AppendList(agreeItem.AgreementAddBr, destAgreeItem?.AgreementAddBr, i => { }, (l, r) => l.Version == r.Version);
                }
                );
            }

            if (destCustomer.CustType == 3) // Company
            {
                //.Include(item => item.Company)
                if (destCustomer.Company == null)
                    destCustomer.Company = new Company();

                //.Include(item => item.AnketaCompany)
                var sorsList = sorsCustomer.Company.AnketaCompany.ToList();
                _dbContext.UpdateList(sorsList, destCustomer.Company.AnketaCompany, rec => { }, (sorsItem, destItem) => sorsItem.Version == destItem.Version);
                //.Include(comp => comp.RelEmployee)
                var relEmployeeList = sorsCustomer.Company.RelEmployee.Where(rec => !string.IsNullOrEmpty(rec.Empl?.LastName?.Trim())).ToList();

                var listRel = destCustomer.Company.RelEmployee.Where(rec => !relEmployeeList.Any(item => item.Emplid == rec.Emplid && item.PositionCode == rec.PositionCode)).ToList();
                listRel.ForEach(delitem =>
                {
                    _dbContext.Employee.Remove(delitem.Empl);
                    _dbContext.RelEmployee.Remove(delitem);
                    destCustomer.Company.RelEmployee.Remove(delitem);

                });



                listRel = destCustomer.Company.RelEmployee.Where(rec => relEmployeeList.Any(item => item.Emplid == rec.Emplid && item.PositionCode == rec.PositionCode)).ToList();
                listRel.ForEach(updItem =>
                {
                    var sorsItem = listRel.SingleOrDefault(item => item.Emplid == updItem.Emplid && item.PositionCode == updItem.PositionCode);
                    updItem.SetFields(sorsItem);
                    updItem.Empl.SetFields(sorsItem?.Empl);
                });

                //
                // десь тут
                //
                var relEmpl = sorsCustomer.Company.RelEmployee.Select(items => items.Empl).ToList();
                listRel = destCustomer.Company.RelEmployee.Where(rec => relEmployeeList.Any(item => item.Emplid == rec.Emplid && item.PositionCode == rec.PositionCode)).ToList();

                listRel.ForEach(updEmpl =>
                {
                    var sourceItem = relEmpl.SingleOrDefault(item => item.Emplid == updEmpl.Emplid);
                    updEmpl.SetFields(sorsCustomer.Company.RelEmployee.SingleOrDefault(item => item.Emplid == updEmpl.Emplid && item.PositionCode == updEmpl.PositionCode));
                    updEmpl.Empl.SetFields(sourceItem);
                });


                var testOne = listRel;

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

                var testMany = listRel;

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
        /// Дані по LicenseAgrParam -> LicenseAgreement Для нового Споживача
        /// </summary>
        /// <param name="sorsCustomer"></param>
        private void fillLicenseAgreement(Customer sorsCustomer)
        {
            foreach (var item in sorsCustomer.Client.LicenseAgreement)
            {
                item.Agr.AgrStatus = 2;
                var param = item.LicenseAgrParam.Where(rec => rec.LicVersion == item.LicVersion).Single();
                /// ***** Потрібно змінити після підключення кабінету
                item.LicStatus = 2;
                param.LicStatus = 2;


            }
        }
        /// <summary>
        /// Збереження нового Споживача
        /// </summary>
        /// <param name="sorsCustomer"></param>
        /// <returns></returns>
        [HttpPost("newconsumer")]
        public async Task<IActionResult> NewConsumer([FromBody] Customer sorsCustomer)
        {
            IDbContextTransaction tran = null;
            try
            {
                if (sorsCustomer == null)
                    throw new Exception("new consumer is empty");
                if (!(sorsCustomer.CustType > 0 && sorsCustomer.CustType < 4))
                    throw new Exception("Bad customer type for new consumer");

                fillLicenseAgreement(sorsCustomer);
                // Збереження Customer
                Customer destConsumer = new Customer();
                _dbContext.Customer.Add(destConsumer);

                InternalUpdateConsumer(sorsCustomer, destConsumer);

                tran = _dbContext.Database.BeginTransaction();
                _dbContext.SaveChanges();
                tran.Commit();
                tran = null;

                return await GetConsumerById(destConsumer.CustId);
            }
            catch (Exception ex)
            {
                if (tran != null)
                    tran.Rollback();
                return BadRequest(ex.Message);
            }

        }

        public enum ConsumerFilterEnum : int
        {
            /// <summary>
            /// Не визначено
            /// </summary>
            None = 0,
            /// <summary>
            /// Діючі
            /// </summary>
            Working = 1,
            /// <summary>
            /// Для акцепту
            /// </summary>
            NotAccepted = 2,
            /// <summary>
            /// Не активні
            /// </summary>
            NotActive = 3,
            /// <summary>
            /// Для пролонгації
            /// </summary>
            ForProlongation = 4,
            /// <summary>
            /// Для розподілу
            /// </summary>
            ForDistribution = 5,
            /// <summary>
            /// Активні
            /// </summary>
            // Active = 2,
            /// <summary>
            /// Заборгованість
            /// </summary>
            Debt = 6,
            /// <summary>
            /// В роботі(прийом звітів)
            /// </summary>
            UnattachData = 7,
            /// <summary>
            /// Всі
            /// </summary>
            All
        }

        /// <summary>
        /// Типи документів Великих прав для запиту
        /// </summary>
        public enum TypeBRDocument
        {
            None = 0,
            // General agreement
            GenAgreement = 2,
            // License agreement
            LicAgreement = 3,
            // Request
            Request = 4,
            // Certificate
            Reference = 5,
            // All documents
            All

        }

        /// <summary>
        /// Отримати список Споживачів малих прав
        /// </summary>
        /// <returns></returns>
        [HttpGet("listSR/{whatId}")]
        public async Task<IActionResult> GetListSR(int whatId)
        {
            ConsumerFilterEnum what = Enum.Parse<ConsumerFilterEnum>(whatId.ToString());

            string queue = "select * from vTsk_1_ListConsumer01";
            switch (what)
            {
                case ConsumerFilterEnum.All:
                case ConsumerFilterEnum.None:
                    break;
                case ConsumerFilterEnum.Working:
                    queue = string.Concat(queue, " ", "where cntActive > 0");
                    break;
                case ConsumerFilterEnum.NotAccepted:
                    queue = string.Concat(queue, " ", "where cntOnAccepting > 0");
                    break;
                case ConsumerFilterEnum.ForProlongation:
                    queue = string.Concat(queue, " ", "where cntExtraAgr > 0");
                    break;
                case ConsumerFilterEnum.ForDistribution:
                    queue = string.Concat(queue, " ", "where undistribamount > 0");
                    break;
            }
            var List = await _dbContext.getViewData(queue, null);
            return Json(List);
        }

        #region Зміні для фільтрів
        Dictionary<ConsumerFilterEnum, string> validQueryForAllDocs = new Dictionary<ConsumerFilterEnum, string> {
            { ConsumerFilterEnum.ForDistribution, "statusUndistribute=1"},
            { ConsumerFilterEnum.Debt, "isnull(borg,0)>0"},
            { ConsumerFilterEnum.UnattachData, "isnull(unattachAmount,0)>0"}
        };

        Dictionary<TypeBRDocument, Dictionary<ConsumerFilterEnum, string>> validDocRequest = new Dictionary<TypeBRDocument, Dictionary<ConsumerFilterEnum, string>> {
            { TypeBRDocument.GenAgreement, new Dictionary<ConsumerFilterEnum, string> {
                { ConsumerFilterEnum.All, ""  },
                { ConsumerFilterEnum.Working, "statusMasterActive=1"  },
                { ConsumerFilterEnum.NotActive, "statusMasterNoactive=1"},
                { ConsumerFilterEnum.ForProlongation, "statusMasterProlong=1"} } },
            { TypeBRDocument.LicAgreement, new Dictionary<ConsumerFilterEnum, string> {
                { ConsumerFilterEnum.All, "countLic1NoActive+countLic1Active>0"  },
                { ConsumerFilterEnum.Working, "statusLic1Active=1"  },
                { ConsumerFilterEnum.NotActive, "statusLic1Noactive=1"},
                { ConsumerFilterEnum.ForProlongation, "statusLic1Prolong=1"}
            } },
            { TypeBRDocument.Request, new Dictionary<ConsumerFilterEnum, string> {
                { ConsumerFilterEnum.All, "countLic2Active+countLic2NoActive>0"  },
                { ConsumerFilterEnum.Working, "statusLic2Active=1"  },
                { ConsumerFilterEnum.NotActive, "statusLic2Noactive=1"}
            } },
            { TypeBRDocument.Reference, new Dictionary<ConsumerFilterEnum, string> {
                { ConsumerFilterEnum.All, "countLic3Active+countLic3NoActive>0"  },
                { ConsumerFilterEnum.Working, "statusLic3Active=1"  },
                { ConsumerFilterEnum.NotActive, "statusLic3Noactive=1"}
            } }
        };
        #endregion

        /// <summary>
        /// Отримати список Споживачів Великих прав
        /// </summary>
        /// <returns></returns>
        [HttpGet("listBR")]
        public async Task<IActionResult> GetListBR([FromQuery(Name = "whatId")] int whatId, [FromQuery(Name = "typeDocId")] int typeDocId)
        {
            ConsumerFilterEnum what = Enum.Parse<ConsumerFilterEnum>(whatId.ToString());
            TypeBRDocument typeDoc = Enum.Parse<TypeBRDocument>(typeDocId.ToString());
            string queue = "select * from vtsk_1_MasterListBR";


            if (validDocRequest.Keys.Contains(typeDoc))
            {
                Dictionary<ConsumerFilterEnum, string> filterObject = validDocRequest[typeDoc];
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
            else if (typeDoc == TypeBRDocument.All && validQueryForAllDocs.Keys.Contains(what))
                queue = $"{queue} where {validQueryForAllDocs[what]}";
            else
                queue = queue + " where 1 != 0";  // условие для вібора пустого множества


            var List = await _dbContext.getViewData(queue, null);


            return Json(List);
        }

        /// <summary>
        /// Список представлень для великих прав
        /// </summary>
        private Dictionary<string, string> listBrView = new Dictionary<string, string> {
            { "vTsk_vBRLicense", "vTsk_vBRLicense" },
            { "vTsk_1_ListConsumer01", "vTsk_1_ListConsumer01" },
            { "vTsk_1_ListConsumer02", "vTsk_1_ListConsumer02" },
            { "vTsk_1_BRBid", "vTsk_1_BRBid" },
            { "vTsk_1_BRBidAuthors", "vTsk_1_BRBidAuthors" },
            { "vTsk_1_BRNotice", "vTsk_1_BRNotice" },
            { "vTSK_1_BRMaster", "vTSK_1_BRMaster" },
            { "vTSK_1_BRRegister", "vTSK_1_BRRegister" },
            { "vTsk_1_MoneyUndescrib", "vTsk_1_MoneyUndescrib" },
            { "vTSK_1_BRMoneyPrepay", "vTSK_1_BRMoneyPrepay" }
        };
        #region BigRight view
        [HttpGet("BR/view/list")]
        public async Task<IActionResult> getBigRightView([FromQuery] string viewName, [FromQuery] int? custId)
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
                var list = await _dbContext.getViewData(QueryStr, new[] { new SqlParameter("@custId", custId ) });
                return Json(list);

            }
        }
        #endregion

        //TODO test method
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


        [HttpGet("listAll/{filter}")]
        public async Task<IActionResult> GetFilteredList(string filter)
        {
            string normalizeFilter = string.Concat(filter, "%");
            var list = await _dbContext.getViewData("select name, custid from vCustomer where custType = 3 and name like @filter", new[] { new SqlParameter("@filter", normalizeFilter) });

            var retList = list.Select(rec => new { displayValue = rec["name"], value = rec["custid"] }).ToArray();

            return Json(retList);
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

        #region Action FOR LICENSEAGREEMENT

        /// <summary>
        /// 
        /// </summary>
        /// <param name="licid"></param>
        /// <param name="version"></param>
        /// <param name="status"></param>
        private async Task<LicenseAgreement> setLicAgrStatus(int licid, int version, int? oldStatus, int status, bool toChangeVersion)
        {
            var licAgreement = await _dbContext.LicenseAgreement.Where(rec => rec.LicId == licid && rec.LicStatus != 4).SingleOrDefaultAsync();
            await _dbContext.Entry(licAgreement).Collection(item => item.LicenseAgrParam)
                .Query()
                .Where(rec => rec.LicVersion == version).LoadAsync();

            LicenseAgrParam licParam = null;

            licParam = licAgreement.LicenseAgrParam.Where(rec => rec.LicVersion == version && rec.LicStatus != 4
                            && (rec.LicStatus == (oldStatus == null ? rec.LicStatus : oldStatus))).SingleOrDefault();
            if (licParam == null)
                throw new ArgumentException("Bad Verion or Status License Agreement For Accept");

            if (toChangeVersion)
            {
                licAgreement.LicStatus = status;
                licAgreement.LicVersion = version;
            }
            licParam.LicStatus = status;
            licParam.ModifyDate = DateTime.Now;

            return licAgreement;

        }
        /// <summary>
        /// Акцептувати Ліценз. Договір або Доп договір до нього
        /// </summary>
        /// <param name="licid">Id Ліцензійного договору</param>
        /// <param name="version">Версія доп угоди</param>
        /// <returns></returns>
        [HttpPost("license/accept/{licid}/{version}")]
        public async Task<IActionResult> LicenseActionAccept(int licid, int version)
        {
            IDbContextTransaction tran = null;
            try
            {

                await setLicAgrStatus(licid, version, 1, 2, true);
                tran = await _dbContext.Database.BeginTransactionAsync();
                await _dbContext.SaveChangesAsync();
                tran.Commit();
                tran = null;

                return Ok();
            }
            catch (Exception ex)
            {
                tran?.Rollback();
                return BadRequest(ex.InnerException.Message);
            }
        }

        /// <summary>
        /// Закрити Ліценз. Договір або Доп договір до нього
        /// </summary>
        /// <param name="licid">Id Ліцензійного договору</param>
        /// <param name="version">Версія доп угоди</param>
        /// <returns></returns>
        [HttpPost("license/close/{licid}/{version}")]
        public async Task<IActionResult> LicenseActionClose(int licid, int version)
        {
            IDbContextTransaction tran = null;
            try
            {

                var licAgreement = await setLicAgrStatus(licid, version, null, 4, false);
                if (licAgreement.LicenseAgrParam.Where(rec => rec.LicStatus != 4).Count() == 0)
                    licAgreement.LicStatus = 4;

                tran = await _dbContext.Database.BeginTransactionAsync();
                await _dbContext.SaveChangesAsync();
                tran.Commit();
                tran = null;

                return Ok();
            }
            catch (Exception ex)
            {
                tran?.Rollback();
                return BadRequest(ex.InnerException.Message);
            }
        }


        #endregion 
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
        public async Task<ActionResult> UploadDocument(int custId, int typeDocument, string comment,  IFormFile file)
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
                    System.IO.File.Move(consumerSavePath, consumerPath );
                return BadRequest();
            }

            return Ok();
        }


        /// <summary>
        /// Завантаження файлу(ів) на сервер
        /// </summary>
        /// <param name="custId"></param>
        /// <param name="typeDocument"></param>
        /// <returns></returns>
        [HttpGet("Document/{custId}/{typeDocument}/{fileName}")]
        public IActionResult DownloadDocument(int custId, int typeDocument, string fileName, CancellationToken token)
        {

            string documentsFolder = _config.GetValue<string>("DocumentsFolder");
            string consumerPath = Path.Combine(documentsFolder, custId.ToString());
            if (!Directory.Exists(consumerPath))
                return BadRequest();

            consumerPath = Path.Combine(consumerPath, "Consumer", typeDocument.ToString());
            if (!Directory.Exists(consumerPath))
                return BadRequest();

            consumerPath = Path.Combine(consumerPath, fileName);

            if (!System.IO.File.Exists(consumerPath))
                return null;

            var file = System.IO.File.OpenRead(consumerPath);
            var retStream = File(file, "application/vnd.ms-word", Path.GetFileName(consumerPath));

            return retStream;

            //try
            //{
            //    //var memoryStream = new MemoryStream();
            //    using (var stream = new FileStream(consumerPath, FileMode.Open))
            //    //var stream = new FileStream(consumerPath, FileMode.Open);
            //    {
            //        await stream.CopyToAsync(memoryStream);

            //        memoryStream.Position = 0;
            //        var retStream = File(memoryStream, "application/vnd.ms-word", Path.GetFileName(consumerPath));
            //        return retStream;
            //    }
            //}
            //catch(Exception ex)
            //{
            //    return BadRequest(ex.InnerException.Message);
            //}
        }



        #endregion
        #region PaydPariod Services
        /// <summary>
        /// Отримати Нерозподілені Платежі Споживача
        /// </summary>
        /// <param name="custId"></param>
        /// <returns></returns>
        [HttpGet("PaydPeriod/GetPayments/{custId}")]
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
#if DEBUG
        [HttpPut("PaydPeriod/GetPayments/{custId}")]
        public async Task<IActionResult> PutExternalPay(int custId, [FromBody] List<ExternalPay> pays )
        {
            List<ExternalPay> dest = new List<ExternalPay>();
            foreach( var item in pays.Where( rec => rec.PaidId == 0))
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
                foreach( var item in dest )
                {
                    MoneyReceived addRec = new MoneyReceived {
                        PaidId = item.PaidId,
                        MoneyType = 1,
                        CustId = custId,
                        DateInvoice = item.DocDate ?? DateTime.Today,
                        NumberInvoice = item.DocNum,
                        GoalInvoice = item.Nplat,
                        Amount = Convert.ToDecimal( item.SCredit ),
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
#endif
#endregion
    } // public class ConsumerController : Controller
}