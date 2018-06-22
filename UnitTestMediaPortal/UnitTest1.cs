using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IpsViewComponentLibrary;
using ipsAnketaClient;
using System.Windows.Forms;
using ipsFormsDesign.Model;


namespace UnitTestMediaPortal
{
    [TestClass]
    public class UnitTestBinding
    {

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


    }
}
