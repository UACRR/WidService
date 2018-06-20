using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IpsViewComponentLibrary;
using ipsAnketaClient;
using System.Windows.Forms;
using ipsFormsDesign.Model;
using NUnit.Extensions.Forms;

namespace UnitTestMediaPortal
{

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethodBindingControls()
        {
            FormBinding1 form = new FormBinding1();
            var anketa = new AnketaPerson();
            form.bindingSource1.DataSource = anketa;

            form.Show();

        }

    }
}
