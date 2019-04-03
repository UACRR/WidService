using System;
using ipsFormsDesign.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ipsFormsDesign.Tests
{
    [TestClass]
    public class ConsumerSmallRightServiceTest
    {
        private ConsumerSmallRightService _smallRightService;

        [TestInitialize]
        public void TestInit()
        {
            _smallRightService = ConsumerSmallRightService.GetInstance();
        }

        [TestMethod]
        public void getMainView_test()
        {
            var result = _smallRightService.getMainView();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetListAll_test()
        {
            var result = _smallRightService.GetListAll();
            Assert.IsNotNull(result);
        }

        public void test()
        {

        }
    }
}
