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

        /// <summary>
        /// InnerException = {System.Data.SqlClient.SqlException (0x80131904): Конфликт инструкции UPDATE с ограничением FOREIGN KEY "FK_REGRATEDLIST_REF_PAIDPER". Конфликт произошел в базе данных "MediaServiceTest", таблица "dbo.PaidPeriod", column 'periodId'.
        ///Выполнение данной инстр...
        /// </summary>
        //[TestMethod]
        //public void TestSaveRegisterRatedList()
        //{
        //    //RegisterRatedList define for parameter 'regRatedList'
        //    RegisterRatedList regRatedList = new RegisterRatedList
        //    {
        //        RmId = 216
        //    };
        //    //RegisterRatedList define for parameter 'retObject'
        //    RegisterRatedList retObject = new RegisterRatedList
        //    {
        //        PeriodId = 666,
        //        RmId = 666,
        //        UserId = "testUserId2"
        //    };
        //    //save data
        //    bool result = _consumerService.SaveRegisterRatedList(regRatedList, out retObject);
        //    //check on access action
        //    Assert.IsTrue(result, "data is not saved");
        //}

        ///InnerException = {System.Data.SqlClient.SqlException(0x80131904): Конфликт инструкции UPDATE с ограничением FOREIGN KEY "FK_REG_REF_CLIENT". Конфликт произошел в базе данных "MediaServiceTest", таблица "dbo.Client", column 'custId'.
        ///Конфликт инструкции INSERT с ограничени...
        //[TestMethod]
        //public void TestSaveRegister()
        //{
        //    //default Register instance
        //    Register register = new Register { RegId = 1330,
        //                                       Number = "testNumber"};
        //    register.RegisterItem.Add(new RegisterItem { });
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
        //        RegId = 1329,
        //        Number = "testNumber"
        //    };
        //    register.RegisterItem.Add(new RegisterItem { });
        //    //delete data
        //    bool result = _consumerService.DeleteRegister(register);
        //    //check on success action
        //    Assert.IsTrue(result, "Register not deleted");
        //}

        //[TestMethod]
        //public void TestGetRegister()
        //{
        //    //default regId
        //    int regId = 1271;
        //    //get data
        //    Register result = _consumerService.GetRegister(regId);
        //    //check on null state
        //    Assert.IsNotNull(result, "result is null");
        //}


        /// <summary>
        /// RequestMessage = {Method: POST, RequestUri: 'http://localhost:54867/api/consumer/period/register/state', Version: 1.1, Content: System.Net.Http.StringContent, Headers:
        ///{
        ///  Accept: application/json
        ///  Content-Type: application/json; charset=utf-8
        ///  Content-Length: 487
        ///}
        ///}
        /// </summary>
        //[TestMethod]
        //public void TestSetRegisterState()
        //{
        //    //default RegisterState
        //    RegisterState state = new RegisterState();
        //    //newItem
        //    state = 0;
        //    //default list
        //    List<Register> list = new List<Register>() { new Register {
        //        RegId = 1268,
        //        Number = "testNumber" }
        //    };
        //    //set data
        //    List<Register> result = _consumerService.SetRegisterState(state, list);
        //    //check on null state
        //    Assert.IsNotNull(result, "result is null");
        //}

        //can't wait result data
        //[TestMethod]
        //public void TestSetPeriodState()
        //{
        //    //default RegisterState
        //    PeriodState state = new PeriodState();
        //    state = 0;
        //    //default PaidPeriod
        //    PaidPeriod period = new PaidPeriod { PeriodId = 1561 };
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

        //[TestMethod]
        //public void TestSave()
        //{
        //    //default customer for save
        //    Customer customer = new Customer { CustId = 130, Status = 2, UserId = null };
        //    //save customer
        //    bool result = _consumerService.Save(customer);
        //    //check on success action
        //    Assert.IsTrue(result, "customer is not saved");
        //}

        //[TestMethod]
        //public void TestSaveAgreementAddBrById()
        //{
        //    //default agrId
        //    int agrId = 101;
        //    //default agreement
        //    LicenseAgreement agreement = new LicenseAgreement();
        //    //save data to LicenseAgreement
        //    bool result = _consumerService.SaveAgreementAddBrById(agrId, agreement);
        //    //check on success action
        //    Assert.IsTrue(result, "LicenseAgreement is not saved");
        //}

        //[TestMethod]
        //public void TestuploadDocument()
        //{
        //    //default custId
        //    //default typeDocument
        //    //default comment
        //    //default Document
        //    //add element to the server
        //    //check on null state
        //}

        //[TestMethod]
        //public void TestdownloadDocument()
        //{
        //    //default custId
        //    //default typeDocument
        //    //default fileName
        //    //get document from server
        //    //check on null state
        //}

        //[TestMethod]
        //public void TestDeleteFileById()
        //{
        //    //default fileId
        //    //delete element
        //    //check on success action
        //}

        //[TestMethod]
        //public void TestGetCustomerPays()
        //{
        //    //default custId
        //    int custId = 1345;
        //    //get external objects
        //    List<ExternalPay> result = _consumerService.GetCustomerPays(custId);
        //    //check on null state
        //    Assert.IsNotNull(result, "result is null");
        //    //check on amount elements
        //    Assert.IsTrue(result.Count != 0, "ExternalPay collection is empty");
        //}

        //[TestMethod]
        //public void TestSaveBRWorkRH()
        //{
        //    //default licId
        //    //default List<WorkRh>
        //    //save data
        //    //check on success action
        //}

        //[TestMethod]
        //public void TestSaveNewPayments()
        //{
        //    //default custId
        //    //default List<ExternalPay>
        //    //save External Pay list
        //    //check on success action
        //}

        //[TestMethod]
        //public void TestSetLicenseType()
        //{
        //    //default LicenseAgreement
        //    //default LicType
        //    //change type
        //    //check on success action
        //}

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

        //[TestMethod]
        //public void TestSavePeriods()
        //{
        //    //default custId
        //    //defualt List<PaidPeriod>
        //    //save data
        //    //check on null sate
        //    //check on amount elements
        //}

        //[TestMethod]
        //public void TestSetLicAgreementStatus()
        //{
        //    //default LicenseAgreement
        //    //default version
        //    //default status
        //    //set data
        //    //check on success action
        //}

        //[TestMethod]
        //public void TestSaveLink()
        //{
        //    //default custId
        //    //default List<MoneyPeriodLink>
        //    //save data
        //    //check on null state
        //    //check on amount elements
        //}
    }
}
