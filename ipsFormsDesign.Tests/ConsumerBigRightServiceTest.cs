using System;
using System.Linq;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary.Extensions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ipsFormsDesign.Tests
{
    [TestClass]
    public class ConsumerBigRightServiceTest
    {
        private ConsumerBigRightService _bigRightService;

        private const string StringTextTest = "_test";
        private const int IntTextTest = 3;
        private const decimal DecimalTextTest = 1.75m;
        private readonly string[] exFields = { "CustId" };

        private const int Id = 1345;
        private Customer _customer;

        /// <summary>
        /// Singletone test
        /// </summary>
        [TestInitialize]
        public void TestInit()
        {
            _bigRightService = ConsumerBigRightService.GetInstance();
        }

        /// <summary>
        /// Отримати дані customer по CustId
        /// </summary>
        [TestMethod]
        public void GetData_test()
        {
            _customer = _bigRightService.GetData(Id);
            Assert.IsNotNull(_customer);
        }

        /// <summary>
        /// VIEWs test
        /// </summary>
        [TestMethod]
        public void getBRView_all_views_test()
        {
            var result = _bigRightService.GetMainBigRightView();
            Assert.IsNotNull(result, "GetMainBigRightView");

            var generalAgreementBigRightViews = _bigRightService.GetBigRightViewByName(typeof(GeneralAgreementBigRightView), "vTSK_1_BRMaster", Id).ToListOfType<GeneralAgreementBigRightView>();
            Assert.IsNotNull(generalAgreementBigRightViews, "vTSK_1_BRMaster");

            var licenseAgreementBigRightViews = _bigRightService.GetBigRightViewByName(typeof(LicenseAgreementBigRightView), "vTsk_vBRLicense", Id).ToListOfType<LicenseAgreementBigRightView>();
            Assert.IsNotNull(licenseAgreementBigRightViews, "vTsk_vBRLicense");

            var requestsBigRightViews = _bigRightService.GetBigRightViewByName(typeof(RequestsOrReferenceBigRightView), "vTsk_1_BRBid", Id).ToListOfType<RequestsOrReferenceBigRightView>();
            Assert.IsNotNull(requestsBigRightViews, "vTsk_1_BRBid");

            var referenceBigRightViews = _bigRightService.GetBigRightViewByName(typeof(RequestsOrReferenceBigRightView), "vTsk_1_BRNotice", Id).ToListOfType<RequestsOrReferenceBigRightView>();
            Assert.IsNotNull(referenceBigRightViews, "vTsk_1_BRNotice");

            var ratedListBigRightViews = _bigRightService.GetBigRightViewByName(typeof(RatedListBigRightView), "vTSK_1_BRRegister", Id).ToListOfType<RatedListBigRightView>();
            Assert.IsNotNull(ratedListBigRightViews, "vTSK_1_BRRegister");

            var spectacleBigRightViews = _bigRightService.GetBigRightViewByName(typeof(RatedListSpectacleBigRightView), "vTsk_1_BRAuthorsDistributed", null).ToListOfType<RatedListSpectacleBigRightView>();
            Assert.IsNotNull(spectacleBigRightViews, "vTsk_1_BRAuthorsDistributed");

            var authorsForLicenseBigRightViews = _bigRightService.GetBigRightViewByName(typeof(AuthorsForLicenseBigRightView), "vTsk_1_BRBidAuthors", Id).ToListOfType<AuthorsForLicenseBigRightView>();
            Assert.IsNotNull(authorsForLicenseBigRightViews, "vTsk_1_BRBidAuthors");

            var ratedListMusicDesignBigRightViews = _bigRightService.GetBigRightViewByName(typeof(RatedListMusicDesignBigRightView), "vTsk_1_BRMusic", null).ToListOfType<RatedListMusicDesignBigRightView>();
            Assert.IsNotNull(ratedListMusicDesignBigRightViews, "vTsk_1_BRMusic");
        }

        [TestMethod]
        public void GetNewCustomer_template_test()
        {
            var resultCustType_1 = _bigRightService.NewCustomer(1);
            Assert.IsNotNull(resultCustType_1);

            var resultCustType_3 = _bigRightService.NewCustomer(3);
            Assert.IsNotNull(resultCustType_3);
        }

        /// <summary>
        /// Збереження існуючого
        /// </summary>
        [TestMethod]
        public void SaveCustomer_test()
        {
            if (_customer == null)
                _customer = _bigRightService.GetData(Id);

            ChangeCustomerForTest();

            var result = _bigRightService.Save(_customer);
            Assert.IsTrue(result, "Customer save error");

            var customer = _bigRightService.GetData(Id);

            Company_ObjectEquals(customer, _customer);
        }

        private void ChangeCustomerForTest()
        {
            // анкета
            var anketa = _customer.Company.AnketaCompany.FirstOrDefault();
            if (anketa == null)
            {
                Assert.Fail("Anketa is empty!");
                return;
            }
            anketa.Name += StringTextTest;
            anketa.ShortName += StringTextTest;
            anketa.LeAddress += StringTextTest;
            anketa.FaAddress += StringTextTest;
            anketa.JaAddress += StringTextTest;

            // контакти
            var rempl_1 = _customer.Company.RelEmployee.SingleOrDefault(rec => rec.PositionCode == 1);
            if (rempl_1 != null)
            {
                rempl_1.RelDocument += StringTextTest;
                rempl_1.Empl.LastName += StringTextTest;
            }

            var rempl_2 = _customer.Company.RelEmployee.SingleOrDefault(rec => rec.PositionCode == 2);
            if (rempl_2 != null)
            {
                rempl_2.RelDocument += StringTextTest;
                rempl_2.Empl.LastName += StringTextTest;
            }

            var rempl_3 = _customer.Company.RelEmployee.SingleOrDefault(rec => rec.PositionCode == 3);
            if (rempl_3 != null)
            {
                rempl_3.RelDocument += StringTextTest;
                rempl_3.Empl.LastName += StringTextTest;
            }
        }


        /// <summary>
        /// Створити нового та зберегти
        /// </summary>
        //[TestMethod]
        public void CreateCustomer_JUR_test()
        {
            var templateCustomer = GetTemplate(3);

            var savedCustomer = _bigRightService.SaveNewConsumer(templateCustomer);
            Assert.IsNotNull(savedCustomer);
        }

        [TestMethod]
        public void CreateCustomer_PHIS_test()
        {
            var templateCustomer = GetTemplate(1);

        }


        private Customer GetTemplate(int custType)
        {
            var customer = new Customer
            {
                CustType = custType,
                AnkVersion = 1,
                Status = 2,
                Client = new Client
                {
                    
                }
            };
            var agreementMaster = new AgreementMaster
            {
                AgrStatus = 0,
                AgrType = 2,
                Version = 1
            };
            var licenseAgreement = new LicenseAgreement
            {
                LicStatus = 0,
                Agr = agreementMaster,
                LicVersion = 1
            };

            licenseAgreement.LicenseAgrParam.Add(new LicenseAgrParam
            {
                LicVersion = 1,
                LicStatus = 0,
            });

            agreementMaster.LicenseAgreement.Add(licenseAgreement);
            customer.AgreementMaster.Add(agreementMaster);

            customer.Client.LicenseAgreement.Add(licenseAgreement);

            // юр особа
            if (customer.CustType == 3)
            {
                customer.Company = new Company();
                customer.Company.AnketaCompany.Add(new AnketaCompany
                {
                    Version = 1,
                    Status = 2,
                    TypeVat = 1
                });
            }
            // Фіз. особа
            else
            {
                customer.Person = new Person();
                customer.Person.AnketaPerson.Add(new AnketaPerson
                {
                    Version = 1,
                    Status = 2
                });
            }

            return customer;
        }

        [TestMethod]
        public void GetRatedList_test()
        {
            var result = _bigRightService.GetRatedList(1235);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetRegister_test()
        {
            var result = _bigRightService.GetRegister(2347);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetRegisterItems_test()
        {
            var result = _bigRightService.GetRegisterItems(2347);
            Assert.IsNotNull(result);
        }


        #region * * * ПЕРЕВІРКА ЗБЕРЕЖЕННЯ ПОЛІВ * * * 

        private void Company_ObjectEquals(Customer dbCustomer, Customer localCustomer)
        {
            var anketaCompany = dbCustomer.Company.AnketaCompany.FirstOrDefault();
            var anketaCompanyTemp = localCustomer.Company.AnketaCompany.FirstOrDefault();
            if (anketaCompany == null || anketaCompanyTemp == null)
                return;

            var anketaCompanyResult = anketaCompany.ObjectEquals(anketaCompanyTemp);
            Assert.IsTrue(anketaCompanyResult, "Some values of Anketa not changed!");

            var rempl_1 = dbCustomer.Company.RelEmployee.SingleOrDefault(rec => rec.PositionCode == 1);
            var rempl_1_temp = localCustomer.Company.RelEmployee.SingleOrDefault(rec => rec.PositionCode == 1);
            var rempl_1_result = rempl_1.ObjectEquals(rempl_1_temp);
            Assert.IsTrue(rempl_1_result, "RelEmployee PositionCode 1");

            var rempl_2 = dbCustomer.Company.RelEmployee.SingleOrDefault(rec => rec.PositionCode == 2);
            var rempl_2_temp = localCustomer.Company.RelEmployee.SingleOrDefault(rec => rec.PositionCode == 2);
            var rempl_2_result = rempl_2.ObjectEquals(rempl_2_temp);
            Assert.IsTrue(rempl_2_result, "RelEmployee PositionCode 2");

            var rempl_3 = dbCustomer.Company.RelEmployee.SingleOrDefault(rec => rec.PositionCode == 3);
            var rempl_3_temp = localCustomer.Company.RelEmployee.SingleOrDefault(rec => rec.PositionCode == 3);
            var rempl_3_result = rempl_3.ObjectEquals(rempl_3_temp);
            Assert.IsTrue(rempl_3_result, "RelEmployee PositionCode 3");
        }

        private void Client_ObjectEquals(Customer dbCustomer, Customer localCustomer)
        {

        }

        private void BankAccount_ObjectEquals(Customer dbCustomer, Customer localCustomer)
        {
            var bank = dbCustomer.BankAccount.SingleOrDefault();
            var bank_temp = localCustomer.BankAccount.SingleOrDefault();
            var bankSaveAuditResult = bank.ObjectEquals(bank_temp, exFields);
            Assert.IsTrue(bankSaveAuditResult);
        }


        #endregion
    }
}
