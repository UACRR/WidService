using System;
using System.Collections.Generic;
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



    }
}
