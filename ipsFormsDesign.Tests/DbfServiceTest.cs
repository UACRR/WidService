using System;
using System.Collections.Generic;
using ipsFormsDesign.Model;
using ipsFormsDesign.Model.SQLViewsData;
using ipsFormsDesign.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ipsFormsDesign.Tests
{
    [TestClass]
    public class DbfServiceTest
    {
        private DbfService _dbfService;

        [TestInitialize]
        public void TestInit()
        {
            _dbfService = DbfService.GetInstance();
        }

        [TestMethod]
        public void GetListOfConsumers_test()
        {
            var list = _dbfService.GetListOfConsumers();
            Assert.IsNotNull(list);
        }

        [TestMethod]
        public void TestGetUnlinkPays()
        {
            //get data
            List<ExternalPay> result = _dbfService.GetUnlinkPays();
            //check on null state
            Assert.IsNotNull(result, "result is null");
            //check on amount elements
            Assert.IsTrue(result.Count != 0, "collection is empty");
        }

        /// <summary>
        /// method wait put request(ExpayController -> 149 row) 
        /// but make post request(ApiConnector -> 397 row)
        /// </summary>
        //[TestMethod]
        //public void TestSaveListLinkedPays()
        //{
        //    //default list External Pay
        //    List<ExternalPay> list = new List<ExternalPay> {
        //        new ExternalPay {
        //            PaidId = 352
        //        }
        //    };
        //    //get data
        //    List<ExternalPay> result = _dbfService.SaveListLinkedPays(list);
        //    //check on null state
        //    Assert.IsNotNull(result, "result is null");
        //    //check on amount elements
        //    Assert.IsTrue(result.Count != 0, "collection is empty");
        //}

        [TestMethod]
        public void TestSaveLinkedPay()
        {
            //default pay
            ExternalPay pay = new ExternalPay {
                PaidId = 353
            };
            //get data
            ExternalPay result = _dbfService.SaveLinkedPay(pay);
            //check on null state
            Assert.IsNotNull(result, "result is null");
        }

        [TestMethod]
        public void TestCheckInputFile()
        {
            //default InputFile
            InputFile file = new InputFile
            {
                FileName = "testFileName",
                InputTime = new DateTime(2019, 01, 15, 17, 02, 48, 893)
            };
            //get data
            InputFile result = _dbfService.CheckInputFile(file);
            //check on null state
            Assert.IsNotNull(result, "result is null");
        }

        [TestMethod]
        public void TestSaveInputFile()
        {
            //default InputFile
            InputFile file = new InputFile
            {
                FileId = 37,
                FileName = "testFileName2",
                InputTime = new DateTime(2018, 01, 14, 16, 01, 47, 892)
            };
            //get data
            InputFile result = _dbfService.SaveInputFile(file);
            //check on null state
            Assert.IsNotNull(result, "result is null");
        }

        [TestMethod]
        public void TestDeleteInputFile()
        {
            //default InputFile
            InputFile file = new InputFile
            {
                FileId = 8
            };
            //get data
            bool result = _dbfService.DeleteInputFile(file);
            //check on success
            Assert.IsNotNull(result, "result is null");
        }

        [TestMethod]
        public void TestGetListOfConsumers()
        {
            //get data
            List<vCustomer> result = _dbfService.GetListOfConsumers();
            //check on null state
            Assert.IsNotNull(result, "result is null");
            //check on amount elements
            Assert.IsTrue(result.Count != 0, "collection is empty");
        }
    }
}
