using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IpsViewComponentLibrary;
using ipsAnketaClient;
using System.Windows.Forms;
using ipsFormsDesign.Model;
using WebAPIConnector;
using ipsFormsDesign.Interfaces;
using System.ComponentModel;

namespace UnitTestMediaPortal
{
    [TestClass]
    public class UnitTestBinding
    {
        private ApiConnector api = null;
        private Customer testCust = null;

        [TestInitialize]
        public void Initialize()
        {
            api = new ApiConnector();
        }
        
        [TestMethod]
        public void TestBindingControlsToAnketaPerson()
        {
            FormBinding1 form = new FormBinding1();
            form.Show(null);
            var anketa = new AnketaPerson();
            form.bindingSource1.DataSource = anketa;

            form.Close();
            form.Dispose();
        }

        [TestMethod]
        public void TestIBindingList()
        {
            Customer cust = api.GetItemById<Customer>("consumer/detail", "134");
            FormIBindingList form = new FormIBindingList();
            form.Show(null);
            form.DataSource = cust.Client;
            Assert.AreEqual(form.usersMoney.RowCount, cust.Client.MoneyReceived.Count);
            form.Close();
            form.Dispose();
        }


    }
}
