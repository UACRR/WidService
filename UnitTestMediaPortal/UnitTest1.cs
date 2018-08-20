using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IpsViewComponentLibrary;
using ipsAnketaClient;
using System.Windows.Forms;
using ipsFormsDesign.Model;
using WebAPIConnector;
using ipsFormsDesign;
using ipsFormsDesign.Interfaces;
using System.ComponentModel;
using ipsFormsDesign.Services;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace UnitTestMediaPortal
{
    [TestClass]
    public class UnitTestBinding
    {
        private ApiConnector api = null;


        [TestInitialize]
        public void Initialize()
        {
            api = new ApiConnector();
        }

        [TestMethod]
        public void TestRegisterRatedList()
        {
            var service = new ConsumerService();
            var cust = service.GetData(135);
            // Отримати Р/Л Споживача
            var regRatedList = service.GetRatedListForCust(135);
            Assert.IsNotNull(regRatedList);

            var period = cust.Client.LicenseAgreement.Where(rec => rec.LicStatus == 2 && rec.PaidPeriod.Count() > 0).Select(rec => rec.PaidPeriod.First()).FirstOrDefault();
            RegisterRatedList addRate = new RegisterRatedList { PeriodId = period.PeriodId, Status = 0 };

            service.SaveRegisterRatedList(addRate, out addRate);
            Assert.IsNotNull(addRate);
            string fileName = DateTime.Now.ToLongTimeString();
            addRate.Register.Add( new Register { FileName = fileName, Durationticks = 1, RgStatus = 0, CustId = cust.CustId });

            service.SaveRegisterRatedList(addRate, out addRate);
            Assert.IsNotNull(addRate);
            Assert.AreEqual(addRate.Register.First().FileName, fileName);

            var ret = service.DeleteRatedList(addRate.RmId);
            Assert.IsTrue(ret);


        }

        [TestMethod]
        public void TestNestedGrid()
        {
            ConsumerService service = new ConsumerService();
            var register = service.GetRegister(1105);

            TestNesttedList form = new TestNesttedList();
            form.Register = register;

            form.ShowDialog();
        }

        [TestMethod]
        public void TestLayout()
        {
            TestLayout form = new TestLayout();
            form.ShowDialog();
        }


    }
}
