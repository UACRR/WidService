using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IpsViewComponentLibrary;
//using ipsAnketaClient;
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
using ipsFormsDesign.Data;
//using Autofac;

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

        public interface Interface01
        {
            string body { get; set; }
        }
        public interface Interface02
        {
            string body { get; set; }
        }
        [TestMethod]
        public void TestIpsGlobal()
        {
            IpsGlobal.addInstance(typeof(Interface01), "interface01");
            Assert.AreEqual(IpsGlobal.Instances[typeof(Interface01)], "interface01");

        }


    }
}
