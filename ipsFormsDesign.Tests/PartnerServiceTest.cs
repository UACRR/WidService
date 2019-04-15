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
    }
}
