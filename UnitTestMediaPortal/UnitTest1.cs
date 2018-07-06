using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using IpsViewComponentLibrary;
using ipsAnketaClient;
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

        [TestMethod]
        public void TestInherit()
        {
            int checkCustId = 148;
            var service = new RightholderService();
            // Сформувати дані по старому правовласнику
            Customer cust = service.GetData(checkCustId);
            // Отримати Список Правовласників
            var inherCust = service.GetMainView().Where(rec => rec.CustId != checkCustId).FirstOrDefault();
            // Записати дані по старому правовласнику
            List<RightHolder> inheritData = new List<RightHolder>();
            var oldRightHolder = new RightHolder();

            inheritData.Add(oldRightHolder);

            oldRightHolder.SetFields(cust.RightHolder);
            oldRightHolder.Cust = new Customer();
            oldRightHolder.Cust.SetFields(cust);
            oldRightHolder.Cust.Status = 9;

            oldRightHolder.CopyRight.Add(new CopyRight { EndDate = DateTime.Today.AddDays(-1) });

            // записати дані по новому правовласнику
            var inherRh = new RightHolder { CustId = inherCust.CustId };
            inheritData.Add(inherRh);

            foreach (var item in cust.RightHolder.CopyRight)
            {
                CopyRight addCopyRight = new CopyRight();
                addCopyRight.SetFields(item);
                addCopyRight.CustId = inherCust.CustId;
                addCopyRight.RoleCode = 8;

                inherRh.CopyRight.Add(addCopyRight);
            }

            // Виконати передачу прав
            var checData = service.InheritDebug(checkCustId, inheritData);
            // Перевірити передачу прав
            Assert.AreEqual(checData.listCopyRight.Count, inheritData.Count);
        }

        [TestMethod]  
        public void testAuthorsFilteredList()
        {
            var rhService = new RightholderService();
            var testList = rhService.getAuthorsByFilter("П");
            Assert.IsNotNull(testList);
        }

        [TestMethod]
        public void TestAutoCombleteTextBox()
        {
            TestTextBoxAuto form = new TestTextBoxAuto();
            form.Load+= (sender, e) => (sender as TestTextBoxAuto).Visible = true;
            var retCode = form.ShowDialog();

            Assert.AreEqual(retCode, DialogResult.OK);
        }

        [TestMethod]
        public void TestPutDocument()
        {
            ConsumerService service = new ConsumerService();
            Customer cust = service.GetData( 135 );
            service.uploadDocument(135, 1, "F_6_МТЦ.docx", new FileStream("Documents\\F_6_МТЦ.docx", FileMode.Open));
        }

        [TestMethod]
        public void TestDownLoad()
        {
            ConsumerService service = new ConsumerService();
            var dic = service.GetDictionary();
            WordEngine eng = new WordEngine(dic);
            Customer cust = service.GetData(135);
            Stream fileStream = service.downloadDocument(135, 1, "F_6_МТЦ.docx");
            Assert.IsNotNull(fileStream);
            var licAgr = cust.Client.LicenseAgreement.First();
            eng.ProcessConsumer( fileStream, cust, licAgr, licAgr.LicVersion ?? 1);

            Assert.IsTrue(File.Exists(eng.Pdf));
        }

        [TestMethod]
        public void TestGlobal()
        {
            ConsumerService _service = new ConsumerService();
            TestGlobalcs form = new TestGlobalcs();
            form.SetDic(_service.GetDictionary());
            form.ShowDialog();
        }

    }
}
