using System;
using System.Collections.Generic;
using System.Linq;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ipsFormsDesign.Tests
{
    [TestClass]
    public class RightHolderServiceTest
    {
        private RightholderService _service;
        private IList<RightholderMainView> _rhList;

        [TestInitialize]
        public void TestInit()
        {
            _service = new RightholderService();
            _rhList = _service.GetMainView();
        }
        [TestMethod]
        public void TestGetOwnerName()
        {
            var owner = _service.GetOwnerName();
            Assert.IsNotNull(owner);
        }

        [TestMethod]
        public void TestGetDictionary()
        {
            var dict = _service.GetDictionary();
            Assert.IsNotNull(dict);
        }

        // GetMainViewByStatus(RightholderStatusType rightholderStatus)
        [TestMethod]
        public void TestGetMainViewByStatus()
        {
            RightholderStatusType checkValue = RightholderStatusType.Active;
            var list = _service.GetMainViewByStatus(checkValue);
            var count = list.Count(rec => rec.CustStatus != (int)checkValue);
            Assert.AreEqual(count, 0, "Failed Active Status");

            checkValue = RightholderStatusType.Blocked;
            list = _service.GetMainViewByStatus(checkValue);
            count = list.Count(rec => rec.CustStatus != (int)checkValue);
            Assert.AreEqual(count, 0, "Failed Blocked Status");

            checkValue = RightholderStatusType.Closed;
            list = _service.GetMainViewByStatus(checkValue);
            count = list.Count(rec => rec.CustStatus != (int)checkValue);
            Assert.AreEqual(count, 0, "Failed Closed Status");

            checkValue = RightholderStatusType.Inheritance;
            list = _service.GetMainViewByStatus(checkValue);
            count = list.Count(rec => rec.CustStatus != (int)checkValue);
            Assert.AreEqual(count, 0, "Failed Inheritance Status");

            checkValue = RightholderStatusType.New;
            list = _service.GetMainViewByStatus(checkValue);
            count = list.Count(rec => rec.CustStatus != (int)checkValue);
            Assert.AreEqual(count, 0, "Failed New Status");

            checkValue = RightholderStatusType.NotAccepted;
            list = _service.GetMainViewByStatus(checkValue);
            count = list.Count(rec => rec.CustStatus != (int)checkValue);
            Assert.AreEqual(count, 0, "Failed NotAccepted Status");

        }
        // NewCustomer
        [TestMethod]
        public void TestNewCustomer()
        {
            // Фізична особа
            var newRH = _service.NewCustomer(1);
            Assert.IsNotNull(newRH, "Type 1");
            // Фізична особа -підприємець
            newRH = _service.NewCustomer(2);
            Assert.IsNotNull(newRH, "Type 2");
            // Юридична особа
            newRH = _service.NewCustomer(3);
            Assert.IsNotNull(newRH, "Type 3");
            // Невизначена особа
            newRH = _service.NewCustomer(4);
            Assert.IsNull(newRH, "Type 4");
            // Зовнішній Правовласник
            newRH = _service.NewCustomer(5);
            Assert.IsNotNull(newRH, "Type 5");
            // Зовнішній споживач
            newRH = _service.NewCustomer(6);
            Assert.IsNull(newRH, "Type 6");
        }

        [TestMethod]
        public void MyTestMethod()
        {

        }

        [TestMethod()]
        public void GetDataTest()
        {
            var cust = _service.GetData(42349);
            Assert.IsNotNull(cust);
        }

        [TestMethod()]
        public void GetRightholdersTest()
        {
            RightholderListQuery query = new RightholderListQuery
            {
                SearchString = "UniTest",
                RowsPerPage = 20,
                PageNumber = 1
            };

            var list = _service.GetRightholders(query);
            Assert.AreNotEqual(list.Count, 0);
        }

        [TestMethod()]
        public void GetRightholdersPageTest()
        {
            RightholderListQuery query = new RightholderListQuery
            {
                SearchString = "UniTest",
                RowsPerPage = 20,
                PageNumber = 1
            };

            var list = _service.GetRightholdersPage(query);
            Assert.AreNotEqual(list.list.Count(), 0);
        }
    }
}
