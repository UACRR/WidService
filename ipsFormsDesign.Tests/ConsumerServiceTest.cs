using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Enums;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ipsFormsDesign.Tests
{
    [TestClass]
    public class ConsumerServiceTest
    {
        private ConsumerService _consumerService;

        [TestInitialize]
        public void TestInit()
        {
            _consumerService = new ConsumerService();
            //check on null state
            Assert.IsNotNull(_consumerService, "ConsumerService is not initialized, state -null");
        }
        
        [TestMethod]
        public void TestGetDictionary()
        {
            //save returned data dictionaries
            AnketaDictionaties result = _consumerService.GetDictionary();
            //check on null state
            Assert.IsNotNull(result, "AnketaDictionaties is null");
            //check collection 'activityType' on amount elements
            Assert.IsTrue(result.activityType.Count != 0, "activityType is empty");
            //check collection 'algorithmType' on amount elements
            Assert.IsTrue(result.algorithmType.Count != 0, "algorithmType is empty");
            //check collection 'agrLicenseType' on amount elements
            Assert.IsTrue(result.agrLicenseType.Count != 0, "agrLicenseType is empty");
            //check collection 'agreementStatus' on amount elements
            Assert.IsTrue(result.agreementStatus.Count != 0, "agreementStatus is empty");
            //check collection 'agreementType' on amount elements
            Assert.IsTrue(result.agreementType.Count != 0, "agreementType is empty");
            //check collection 'anketaStatus' on amount elements
            Assert.IsTrue(result.anketaStatus.Count != 0, "anketaStatus is empty");
            //check collection 'copyrightKind' on amount elements
            Assert.IsTrue(result.copyrightKind.Count != 0, "copyrightKind is empty");
            //check collection 'copyrightType' on amount elements
            Assert.IsTrue(result.copyrightType.Count != 0, "copyrightType is empty");
            //check collection 'country' on amount elements
            Assert.IsTrue(result.country.Count != 0, "country is empty");
            //check collection 'creativeRoleType' on amount elements
            Assert.IsTrue(result.creativeRoleType.Count != 0, "creativeRoleType is empty");
            //check collection 'crkindGroup' on amount elements
            Assert.IsTrue(result.crkindGroup.Count != 0, "crkindGroup is empty");
            //check collection 'customerStatus' on amount elements
            Assert.IsTrue(result.customerStatus.Count != 0, "customerStatus is empty");
            //check collection 'customerType' on amount elements
            Assert.IsTrue(result.customerType.Count != 0, "customerType is empty");
            //check collection 'fileType' on amount elements
            Assert.IsTrue(result.fileType.Count != 0, "fileType is empty");
            //check collection 'klR030' on amount elements
            Assert.IsTrue(result.klR030.Count != 0, "klR030 is empty");
            //check collection 'licenseClass' on amount elements
            Assert.IsTrue(result.licenseClass.Count != 0, "licenseClass is empty");
            //check collection 'licenseType' on amount elements
            Assert.IsTrue(result.licenseType.Count != 0, "licenseType is empty");
            //check collection 'period' on amount elements
            Assert.IsTrue(result.period.Count != 0, "period is empty");
            //check collection 'periodStatus' on amount elements
            Assert.IsTrue(result.periodStatus.Count != 0, "periodStatus is empty");
            //check collection 'positionType' on amount elements
            Assert.IsTrue(result.positionType.Count != 0, "positionType is empty");
            //check collection 'PrePayType' on amount elements
            Assert.IsTrue(result.PrePayType.Count != 0, "PrePayType is empty");
            //check collection 'region' on amount elements
            Assert.IsTrue(result.region.Count != 0, "region is empty");
            //check collection 'registerStatus' on amount elements
            Assert.IsTrue(result.registerStatus.Count != 0, "registerStatus is empty");
            //check collection 'registerListStatus' on amount elements
            Assert.IsTrue(result.registerListStatus.Count != 0, "registerListStatus is empty");
            //check collection 'residentType' on amount elements
            Assert.IsTrue(result.residentType.Count != 0, "residentType is empty");
            //check collection 'rholderType' on amount elements
            Assert.IsTrue(result.rholderType.Count != 0, "rholderType is empty");
            //check collection 'sexType' on amount elements
            Assert.IsTrue(result.sexType.Count != 0, "sexType is empty");
            //check collection 'typePlace' on amount elements
            Assert.IsTrue(result.typePlace.Count != 0, "typePlace is empty");
            //check collection 'typePlaceParam' on amount elements
            Assert.IsTrue(result.typePlaceParam.Count != 0, "typePlaceParam is empty");
            //check collection 'typeVat' on amount elements
            Assert.IsTrue(result.typeVat.Count != 0, "typeVat is empty");
            //check collection 'userRoleType' on amount elements
            Assert.IsTrue(result.userRoleType.Count != 0, "userRoleType is empty");
            //check collection 'usesKind' on amount elements
            Assert.IsTrue(result.usesKind.Count != 0, "usesKind is empty");
            //check collection 'usesType' on amount elements
            Assert.IsTrue(result.usesType.Count != 0, "usesType is empty");
            //check collection 'workType' on amount elements
            Assert.IsTrue(result.workType.Count != 0, "workType is empty");
            //check collection 'typeMethodGet' on amount elements
            Assert.IsTrue(result.typeMethodGet.Count != 0, "typeMethodGet is empty");
            //check collection 'communities' on amount elements
            Assert.IsTrue(result.communities.Count != 0, "communities is empty");
            //check collection 'objAct' on amount elements
            Assert.IsTrue(result.objAct.Count != 0, "objAct is empty");
            //check collection 'performType' on amount elements
            Assert.IsTrue(result.performType.Count != 0, "performType is empty");
            //check collection 'genreType' on amount elements
            Assert.IsTrue(result.genreType.Count != 0, "genreType is empty");
            //check collection 'language' on amount elements
            Assert.IsTrue(result.language.Count != 0, "language is empty");
            //check collection 'relGenrePercent' on amount elements
            Assert.IsTrue(result.relGenrePercent.Count != 0, "relGenrePercent is empty");
            //check collection 'fixStageStatus' on amount elements
            Assert.IsTrue(result.fixStageStatus.Count != 0, "fixStageStatus is empty");
        }

        [TestMethod]
        public void TestGetObjectRightDictionaries()
        {
            //save returned data ObjectRightDictionaries
            ObjectRightDictionaries result = _consumerService.GetObjectRightDictionaries();
            //check on null state result
            Assert.IsNotNull(result, "ObjectRightDictionaries is null");
            //check collection 'category' on amount elements
            Assert.IsTrue(result.category.Count != 0, "category is empty");
            //check collection 'copyrightType' on amount elements
            Assert.IsTrue(result.copyrightType.Count != 0, "copyrightType is empty");
            //check collection 'creativeRoleType' on amount elements
            Assert.IsTrue(result.creativeRoleType.Count != 0, "creativeRoleType is empty");
            //check collection 'etGenre' on amount elements
            Assert.IsTrue(result.etGenre.Count != 0, "etGenre is empty");
            //check collection 'etRole' on amount elements
            Assert.IsTrue(result.etRole.Count != 0, "etRole is empty");
            //check collection 'genreType' on amount elements
            Assert.IsTrue(result.genreType.Count != 0, "genreType is empty");
            //check collection 'legalBasis' on amount elements
            Assert.IsTrue(result.legalBasis.Count != 0, "legalBasis is empty");
            //check collection 'objAct' on amount elements
            Assert.IsTrue(result.objAct.Count != 0, "objAct is empty");
            //check collection 'objectStatus' on amount elements
            Assert.IsTrue(result.objectStatus.Count != 0, "objectStatus is empty");
            //check collection 'permitType' on amount elements
            Assert.IsTrue(result.permitType.Count != 0, "permitType is empty");
            //check collection 'seekType' on amount elements
            Assert.IsTrue(result.seekType.Count != 0, "seekType is empty");
            //check collection 'specType' on amount elements
            Assert.IsTrue(result.specType.Count != 0, "specType is empty");
            //check collection 'folkType' on amount elements
            Assert.IsTrue(result.folkType.Count != 0, "folkType is empty");
            //check collection 'RegisterStatuses' on amount elements
            Assert.IsTrue(result.RegisterStatuses.Count != 0, "RegisterStatuses is empty");
        }

        /// <summary>
        /// unusable code
        /// </summary>
        //[TestMethod]
        //public void TestGetMainView()
        //{
        //    //save returned data 'objectright/view/list_01'
        //    IList<ConsumerSmallRightView> result = _consumerService.GetMainView();
        //    //check result on null state
        //    Assert.IsNotNull(result, "result data is null");
        //    //check collection on amount elements
        //    Assert.IsTrue(result.Count != 0, "collection is empty");
        //}

        /// <summary>
        /// unusable code
        /// </summary>
        //[TestMethod]
        //public void TestGetListAll()
        //{
        //    //save returned collection
        //    IList<ConsumerSmallRightView> result = _consumerService.GetListAll();
        //    //check result on null state
        //    Assert.IsNotNull(result, "IList<ConsumerSmallRightView> result is null ");
        //    //check collection on amount elements
        //    Assert.IsTrue(result.Count != 0, "collection is empty");
        //}

        [TestMethod]
        public void TestGetData()
        {
            //default custId
            int custId = 6;
            //get result customer by objId
            Customer result = _consumerService.GetData(custId);
            //check on exist data
            Assert.IsNotNull(result, "result is null");
        }

        [TestMethod]
        public void TestGetShortInfoById()
        {
            //default custId
            int custId = 6;
            //get result data
            ConsumerSmallRightView result = _consumerService.GetShortInfoById(custId);
            //check on null state
            Assert.IsNotNull(result, "result is null");
        }

        [TestMethod]
        public void TestGetExternalById()
        {
            //default custId
            int custId = 6;
            //get result data
            Customer result = _consumerService.GetExternalById(custId);
            //check on null state
            Assert.IsNotNull(result, "result is null");
        }

        [TestMethod]
        public void TestSaveExternal()
        {
            //default customer data
            Customer customer = new Customer { CustId = 666,
                                               Status = 2,
                                               UserId = "testUserId"};
            //save customer
            bool result = _consumerService.SaveExternal(customer);
            //check on success save
            Assert.IsTrue(result, "customer not saved");
        }

        [TestMethod]
        public void TestGetRegisterItems()
        {
            //default regId
            int regId = 1221;
            //get data by regId
            List<RegisterItem> result = _consumerService.GetRegisterItems(regId);
            //check on null state
            Assert.IsNotNull(result, "result is null");
            //check on amount elements
            Assert.IsTrue(result.Count != 0, "collection is empty");
        }

        [TestMethod]
        public void TestGetRatedListForCust()
        {
            //default custId
            int custId = 6;
            //get data by custId
            Customer result = _consumerService.GetRatedListForCust(custId);
            //check on null state
            Assert.IsNotNull(result, "customer is null");
        }

        [TestMethod]
        public void TestGetRatedList()
        {
            //default custId
            int rmId = 140;
            //get data by rmId
            RegisterRatedList result = _consumerService.GetRatedList(rmId);
            //check on null state
            Assert.IsNotNull(result, "result is null");
        }
        
        [TestMethod]
        public void TestSaveRegisterRatedList()
        {
            //RegisterRatedList define for parameter 'regRatedList'
            RegisterRatedList regRatedList = new RegisterRatedList
            {
                PeriodId = 1560,
                RmId = 216
            };
            //RegisterRatedList define for parameter 'retObject'
            RegisterRatedList retObject = new RegisterRatedList
            {
                PeriodId = 666,
                RmId = 666,
                UserId = "testUserId2"
            };
            //save data
            bool result = _consumerService.SaveRegisterRatedList(regRatedList, out retObject);
            //check on access action
            Assert.IsTrue(result, "data is not saved");
        }

        ///Message = "Конфликт инструкции UPDATE с ограничением FOREIGN KEY \"FK_REGISTER_REFERENCE_ASPNETUS\". Конфликт произошел в базе данных \"MediaServiceTest\", таблица \"dbo.AspNetUsers\", column 'id'.\r\nВыполнение данной инструкции было прервано."
        //[TestMethod]
        //public void TestSaveRegister()
        //{
        //    //default Register instance
        //    Register register = new Register
        //    {
        //        RegId = 1330
        //    };
        //    //register.RegisterItem.Add(new RegisterItem
        //    //{
        //    //    RegId = 1330,
        //    //    RegIitemId = 1,
        //    //    CodeItem = 1,
        //    //    ItemName = "TestName",
        //    //    Performer = "TestPerformer",
        //    //    AuthorMusic = "TestAuthor",
        //    //    AuthorText = "TestTextAuthor",
        //    //    ModifyLogin = "TestModify",
        //    //    Ticks = 10,
        //    //    IsAuto = false
        //    //});
        //    //register.User = new AspNetUsers
        //    //{
        //    //    Id = "TestId",
        //    //    AccessFailedCount = 1,
        //    //    ConcurrencyStamp = "TestStamp",
        //    //    Email = "testStrEmail",
        //    //    EmailConfirmed = false,
        //    //    FirstName = "TestFirstName",
        //    //    LastName = "TestLastName",
        //    //    LockoutEnabled = false,
        //    //    NormalizedEmail = "TestNormalizedEmail",
        //    //    NormalizedUserName = "TestNormalizedUserName",
        //    //    PasswordHash = "TestPasswordHash",
        //    //    PhoneNumber = "TestPhoneNumber",
        //    //    PhoneNumberConfirmed = false,
        //    //    SecurityStamp = "TestSecurityStamp",
        //    //    SurName = "TestSurName",
        //    //    TwoFactorEnabled = false,
        //    //    UserName = "TestUserName"
        //    //};
        //    //save data
        //    bool result = _consumerService.SaveRegister(register);
        //    //check on success action
        //    Assert.IsTrue(result, "Register not saved");
        //}

        //[TestMethod]
        //public void TestDeleteRegister()
        //{
        //    //default Register instance
        //    Register register = new Register
        //    {
        //        RegId = 1319
        //    };
        //    register.RegisterItem.Add(new RegisterItem { });
        //    //delete data
        //    bool result = _consumerService.DeleteRegister(register);
        //    //check on success action
        //    Assert.IsTrue(result, "Register not deleted");
        //}

        [TestMethod]
        public void TestGetRegister()
        {
            //default regId
            int regId = 1271;
            //get data
            Register result = _consumerService.GetRegister(regId);
            //check on null state
            Assert.IsNotNull(result, "result is null");
        }

        [TestMethod]
        public void TestSetRegisterState()
        {
            //default RegisterState
            RegisterState state = new RegisterState();
            //newItem
            state = (RegisterState)1;
            //default list
            List<Register> list = new List<Register>() { new Register {
                RegId = 1319,
                Number = "testNumber",
                CountRows = 3,
                CustId = 1375,
                Durationticks = 3,
                FileName = "TestName",
                UserId = "TestId"}
            };
            //set data
            List<Register> result = _consumerService.SetRegisterState(state, list);
            //check on null state
            Assert.IsNotNull(result, "result is null");
        }

        /// <summary>
        /// can't call method into ConsumerController
        /// </summary>
        //[TestMethod]
        //public void TestSetPeriodState()
        //{
        //    //default RegisterState
        //    PeriodState state = new PeriodState();
        //    state = 0;
        //    //default PaidPeriod
        //    PaidPeriod period = new PaidPeriod
        //    {
        //        PeriodId = 1196
        //    };
        //    //set data
        //    var result = _consumerService.SetPeriodState(state, period);
        //    //check on success action
        //    Assert.IsTrue(result, "data is not set");
        //}

        [TestMethod]
        public void TestGetAutoCompleteList()
        {
            //default string
            string defaultStr = "a";
            //get result data
            IList<AutoCompleteData> result = _consumerService.GetAutoCompleteList(defaultStr);
            //check on null state
            Assert.IsNotNull(result, "result is null");
            //check on amount elements
            Assert.IsTrue(result.Count != 0, "collection is empty");
        }

        [TestMethod]
        public void TestNewCustomer()
        {
            //default custType
            int custType = 1;
            //get result data
            Customer result = _consumerService.NewCustomer(custType);
            //check on null state
            Assert.IsNotNull(result, "Customer is not created");
        }

        /// <summary>
        /// can't save data because 'dest' is null -> method SetFields() is return, data is not saved
        /// </summary>
        //[TestMethod]
        //public void TestSave()
        //{
        //    //default customer for save
        //    Customer customer = new Customer
        //    {
        //        CustId = 138,
        //        Status = 1,
        //        UserId = "testUserId"
        //    };
        //    //save customer
        //    bool result = _consumerService.Save(customer);
        //    //check on success action
        //    Assert.IsTrue(result, "customer is not saved");
        //}

        [TestMethod]
        public void TestSaveAgreementAddBrById()
        {
            //default agrId
            int agrId = 2286;
            //default agreement
            LicenseAgreement agreement = new LicenseAgreement {
                LicId = 23,
                LicCode = 23,
                LicClass = 23,
                AgrId = 3
            };
            agreement.Agr = new AgreementMaster
            {
                AgrId = 2286,
                CustId = 226,
                ModifyLogin = null
            };
            agreement.Agr.AgreementAddBr = new ObservableListSource<AgreementAddBr>
            {
                new AgreementAddBr
                {
                    AgrId = 2286,
                    Version = 1,
                    AgrNumber = "БП_2/2018",
                    ModifyLogin = null
                }
            };
            //save data to LicenseAgreement
            bool result = _consumerService.SaveAgreementAddBrById(agrId, agreement);
            //check on success action
            Assert.IsTrue(result, "LicenseAgreement is not saved");
        }

        /// <summary>
        /// work with test file
        /// </summary>
        //[TestMethod]
        //public void TestuploadDocument()
        //{
        //    //default custId
        //    int custId = 226;
        //    //default typeDocument
        //    int typeDocument = 1;
        //    //default comment
        //    string comment = "testcomment";
        //    //default Document
        //    string Document = "testDocument";
        //    //add element to the server
        //    _consumerService.uploadDocument(custId, typeDocument, comment, Document);
        //    //check on null state
        //}

        //[TestMethod]
        //public void TestdownloadDocument()
        //{
        //    //default custId
        //    int custId = 142;
        //    //default typeDocument
        //    int typeDocument = 5;
        //    //default fileName
        //    string fileName = "Жанры произведений МП.xlsx";
        //    //get document from server
        //    var result = _consumerService.DownloadDocument(custId, typeDocument, fileName);
        //    //check on null state
        //    Assert.IsNotNull(result, "result is null");
        //}

        //[TestMethod]
        //public void TestDeleteFileById()
        //{
        //    //default fileId
        //    //delete element
        //    //check on success action
        //}

        //table ExternalPay have field custId = null
        //[TestMethod]
        //public void TestGetCustomerPays()
        //{
        //    //default custId
        //    int custId = 1839;
        //    //get external objects
        //    List<ExternalPay> result = _consumerService.GetCustomerPays(custId);
        //    //check on null state
        //    Assert.IsNotNull(result, "result is null");
        //    //check on amount elements
        //    Assert.IsTrue(result.Count != 0, "ExternalPay collection is empty");
        //}
        

        [TestMethod]
        public void TestSaveBRWorkRH()
        {
            //default licId
            int licId = 1202;
            //default List<WorkRh>
            List<WorkRh> worrh = new List<WorkRh>
            {
                new WorkRh
                {
                    CRightId = 2251
                }
            };
            //save data
            bool result = _consumerService.SaveBRWorkRH(licId, worrh);
            //check on success action
            Assert.IsTrue(result, "action 'save' failed");
        }

        [TestMethod]
        public void TestSaveNewPayments()
        {
            //default custId
            int custId = 1345;
            //default List<ExternalPay>
            List<ExternalPay> pays = new List<ExternalPay> {
                new ExternalPay {
                    PaidId = 355,
                    Mfo = "sd",
                    Okpol = "sd",
                    Account = "sd",
                    R030 = "d",
                    CodeOper = "sd",
                    MfoCorr = "d",
                    NameMfoCorr = "d"
                }
            };
            //save External Pay list
            bool result = _consumerService.SaveNewPayments(custId, pays);
            //check on success action
            Assert.IsTrue(result, "payments is not saved");
        }

        [TestMethod]
        public void TestSetLicenseType()
        {
            //default LicenseAgreement
            LicenseAgreement lic = new LicenseAgreement
            {
                LicId = 1236,
                LicCode = 10,
                LicClass = 2,
                AgrId = 2370
            };
            //default LicType
            LicType typeId = new LicType();
            typeId = (LicType)1;
            //change type
            bool result = _consumerService.SetLicenseType(lic, typeId);
            //check on success action
            Assert.IsTrue(result, "License type is not set");
        }

        [TestMethod]
        public void TestgetPaidInfo()
        {
            //default custId
            int custId = 138;
            //get detail data
            Customer result = _consumerService.getPaidInfo(custId);
            //check on null state
            Assert.IsNotNull(result, "result is null");
        }

        [TestMethod]
        public void TestSavePeriods()
        {
            //default custId
            int custId = 135;
            //defualt List<PaidPeriod>
            List<PaidPeriod> periods = new List<PaidPeriod>
            {
                new PaidPeriod
                {
                    PeriodId = 1497,
                    CustId = 135,
                    PeriodType = 3,
                    LicId = 1,
                    Status = 1,
                    PeriodName = "testPeriodName"
                }
            };
            //save data
            List<PaidPeriod> result = _consumerService.SavePeriods(custId, periods);
            //check on null sate
            Assert.IsNotNull(result, "result is null");
            //check on amount elements
            Assert.IsTrue(result.Count != 0, "collection in empty");
        }

        [TestMethod]
        public void TestSetLicAgreementStatus()
        {
            //default LicenseAgreement
            LicenseAgreement agr = new LicenseAgreement
            {
                LicId = 1236,
                LicCode = 10,
                LicClass = 2,
                AgrId = 2370
            };
            //default version
            int version = 3;
            //default status
            int status = 1;
            //set data
            bool result = _consumerService.SetLicAgreementStatus(agr, version, status);
            //check on success action
            Assert.IsTrue(result, "status is not saved");
        }

        /// Message = "Конфликт инструкции INSERT с ограничением FOREIGN KEY \"FK_MONEYPER_REFERENCE_PAIDPERI\". 
        /// Конфликт произошел в базе данных \"MediaServiceTest\", таблица \"dbo.PaidPeriod\", column 'periodId'.
        /// \r\nВыполнение данной инструкции было прервано."
        /// </summary>
        //[TestMethod]
        //public void TestSaveLink()
        //{
        //    //default custId
        //    int custId = 134;
        //    //default List<MoneyPeriodLink>
        //    List<MoneyPeriodLink> listLinks = new List<MoneyPeriodLink>
        //    {
        //        new MoneyPeriodLink
        //        {
        //            PeriodId = 1,
        //            PaidId = 3,
        //            LicId = 1158
        //        }
        //    };
        //    //save data
        //    List<MoneyPeriodLink> result = _consumerService.SaveLink(custId, listLinks);
        //    //check on null state
        //    Assert.IsNotNull(result, "result is null");
        //    //check on amount elements
        //    Assert.IsTrue(result.Count != 0, "collection is empty");
        //}
    }
}
