using System;
using System.Collections.Generic;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ipsFormsDesign.Tests
{
    [TestClass]
    public class PartnerServiceTest
    {
        private PartnerService _partnerService;

        [TestInitialize]
        public void TestGetInstance()
        {
            _partnerService = PartnerService.GetInstance();
        }

        [TestMethod]
        public void TestGetView()
        {
            //default arguments
            List<string> listBrView = new List<string>
            {
                "vTsk_vBRLicense",
                "vTsk_1_ListConsumer01",
                "vTsk_1_ListConsumer02",
                "vTsk_1_BRBid",
                "vTsk_1_BRBidAuthors",
                "vTsk_1_BRNotice",
                "vTSK_1_BRMaster",
                "vTSK_1_BRRegister",
                "vTsk_1_MoneyUndescrib",
                "vTSK_1_BRMoneyPrepay",
                "vTSK_1_BRObjects",
                "vTsk_1_BRAuthorsDistributed",
                "vTsk_1_BRMusic",
                "vTsk_6_ListPartner",
                "vTsk_6_ListPClient",
                "vTsk_6_ListFreeCln"
            };
            Type typeResult = typeof(object);
            //get data
            foreach(string brView in listBrView) {
                IList<object> result = _partnerService.GetView(typeResult, brView, null);
                //checks for result data
                Assert.IsNotNull(result, $"{brView} result is null");
                Assert.IsTrue(result.Count != 0, $"{brView} collection is empty");
            }
        }

        [TestMethod]
        public void TestGetPartnerTemplate()
        {
            //default arguments
            List<int> custType = new List<int> { 3, 1 };
            //get data
            foreach(int cust in custType)
            {
                Customer result = _partnerService.GetPartnerTemplate(cust);
                Assert.IsNotNull(result, "Customer is not exist");
            }
        }

        [TestMethod]
        public void TestGetPartnerList()
        {
            //get data
            List<Customer> result = _partnerService.GetPartnerList();
            //checks for result data
            Assert.IsNotNull(result, "result is null");
            Assert.IsTrue(result.Count != 0, "collection is empty");
        }

        [TestMethod]
        public void TestGetPartnerAnketa()
        {
            //default arguments
            int clientId = 134;
            //get data
            Customer result = _partnerService.GetPartnerAnketa(clientId);
            //checks for result data
            Assert.IsNotNull(result, "Customer not found");
        }

        [TestMethod]
        public void TestGetPartner()
        {
            //default arguments
            int custId = 130;
            //get result data
            Customer result = _partnerService.GetPartner(custId);
            //checks for result data
            Assert.IsNotNull(result, "Customer not found");
        }

        [TestMethod]
        public void TestSavePartner()
        {
            //default Customer
            Customer customer = new Customer
            {
                CustId = 130,
                Status = 2,
                CustType = 1
            };
            customer.Person = new Person {
                CustId = 130,
                Version = 1
            };
            customer.Person.AnketaPerson = new ObservableListSource<AnketaPerson> {
                new AnketaPerson {  CustId = 130,
                                    Version = 1,
                                    Status = 0 }
            };
            //save customer
            bool result = _partnerService.SavePartner(customer);
            //checks for result data
            Assert.IsTrue(result, "Customer is not saved");
        }

        [TestMethod]
        public void TestUpdateAgreement()
        {
            //default 'AgreementAddPartner'
            AgreementAddPartner agreement = new AgreementAddPartner {
                AgrId = 2315,
                CustId = 300,
                Version = 1,
                AnkVersion = 1
            };
            //get result data
            bool result = _partnerService.UpdateAgreement(agreement);
            //checks for result data
            Assert.IsTrue(result, "AgreementAddPartner is not saved");
        }

        [TestMethod]
        public void TestSetPartnerForCustomer()
        {
            //default arguments
            _partnerService.RemovePartnerForCustomer(1373, 300);
            int clientId = 1373;
            int partnerId = 300;
            //set data
            bool result = _partnerService.SetPartnerForCustomer(clientId, partnerId);
            _partnerService.RemovePartnerForCustomer(1373, 300);
            //checks for result data
            Assert.IsTrue(result, "Partnert is not seted");
        }

        [TestMethod]
        public void TestChangePartnerForCustomer()
        {
            //default argument
            int clientId = 134;
            int partnerId = 130;
            int oldClientId = 302;
            //change data
            bool result = _partnerService.ChangePartnerForCustomer(clientId, partnerId, oldClientId);
            _partnerService.ChangePartnerForCustomer(clientId, oldClientId, partnerId);
            //checks result data
            Assert.IsTrue(result, "data is not changed");
        }

        [TestMethod]
        public void TestRemovePartnerForCustomer()
        {
            //default argument
            _partnerService.SetPartnerForCustomer(1373, 300);
            int clientId = 1373;
            int partnerId = 300;
            bool result = _partnerService.RemovePartnerForCustomer(clientId, partnerId);
            Assert.IsTrue(result, "Parent is not removed");
        }
    }
}
