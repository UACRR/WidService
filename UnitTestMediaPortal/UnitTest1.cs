using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IpsViewComponentLibrary;
using ipsAnketaClient;
using System.Windows.Forms;
using ipsFormsDesign.Model;
using NUnit.Extensions.Forms;
using NUnit.Framework;

namespace UnitTestMediaPortal
{
    [TestClass]
    [TestFixture]
    public class UnitTest1 : NUnitFormTest
    {
        [TestMethod]
        public void TestMethodBindingControls()
        {
            try
            {
                FormBinding1 form = new FormBinding1();
                
                var anketa = new AnketaCompany();
                form.bindingSource1.DataSource = anketa;

                form.Show();
            }
            catch(Exception ex)
            {
                Microsoft.VisualStudio.TestTools.UnitTesting.Assert.Fail(ex.Message);
            }
        }




    }
}
