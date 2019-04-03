using System;
using ipsFormsDesign.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ipsFormsDesign.Tests
{
    [TestClass]
    public class ConsumerBigRightServiceTest
    {
        private ConsumerBigRightService _bigRightService;

        [TestInitialize]
        public void TestInit()
        {
            _bigRightService = ConsumerBigRightService.GetInstance();
        }

        [TestMethod]
        public void GetData_test()
        {
            var result = _bigRightService.GetData(0);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetMainViewBR_test()
        {
            var result = _bigRightService.getMainViewBR();
            Assert.IsNotNull(result);
        }
    }
}
