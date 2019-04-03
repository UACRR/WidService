using System;
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
    }
}
