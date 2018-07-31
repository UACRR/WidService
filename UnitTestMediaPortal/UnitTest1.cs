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
            //form.DataSource = cust.Client;
            //Assert.AreEqual(form.usersMoney.RowCount, cust.Client.MoneyReceived.Count);
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
            //var checData = service.InheritDebug(checkCustId, inheritData);
            // Перевірити передачу прав
            //Assert.AreEqual(checData.listCopyRight.Count, inheritData.Count);
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
            // Customer cust = service.GetData( 135 );
            string comment = "test--test";
            service.uploadDocument(135, 1, comment, ".\\Documents\\F_6_МТЦ.docx");
            Customer cust = service.GetData(135);
            Assert.IsNotNull(cust, "Cust");
            var file = cust.FileCustomer.Where(rec => rec.DocType == 1 && rec.DocComment == comment).FirstOrDefault();
            Assert.IsNotNull(file, "File");
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
            // form.Visible = true;
            form.Show(null);
        }

        [TestMethod]
        public void TestExpandoObject()
        {
            ConsumerService _service = new ConsumerService();
            var list = _service.getBRView(typeof(object), "vTSK_1_BRRegister", null );
            RadTestExpandoObject form = new RadTestExpandoObject();
            form.DataSource = list;

            form.ShowDialog();
        }

        [TestMethod]
        public void TestReportControl()
        {
            var service = new ConsumerService();
            var cust = service.GetCustomerRegisterRatedList(135);

            var form = new TestCalculation(service);
            form.Customer = cust;
            
            form.ShowDialog();
        }

        [TestMethod]
        public void TestGenAgreementStatus()
        {
            var _service = new ConsumerService();
            var custid = 244;
            var status = 2;
            var licId = 75;

            var consumer = _service.GetData(custid);

            // Отримати ген угоди
            var agr = consumer.Client.LicenseAgreement.FirstOrDefault(rec => rec.LicId == licId);
            // Змінити статус ген угоди
            var ret = _service.SetLicAgreementStatus(agr, (int)agr.LicVersion,  status, false);
            // Змінити статус на Ліцензійний договір
            Assert.IsTrue(ret);
            consumer = _service.GetData(custid);
            agr = consumer.Client.LicenseAgreement.FirstOrDefault(rec=>rec.LicId == licId );
            Assert.AreEqual(agr.LicStatus,status);
        }

        [TestMethod]
        public void TestBrWorkRH()
        {
            var _service = new ConsumerService();
            int custId = 142;
            var items = _service.GetData(custId);

            var licenseBr = items.Client.LicenseAgreement.Where(rec => rec.LicClass == 2 && rec.LicStatus == 2).First().LicenseBigR.First();
            var worrh = licenseBr.Obj.CopyRight.Select(rec=> rec.WorkRh ).ToList();
            var testWorkRh = worrh[0];
            testWorkRh.WorkDateCl = DateTime.Today;

            var ret = _service.SaveBRWorkRH(licenseBr.LicId, worrh);
            Assert.IsTrue(ret);
            items = _service.GetData(custId);
            licenseBr = items.Client.LicenseAgreement.Where(rec => rec.LicId == licenseBr.LicId ).First().LicenseBigR.First();
            worrh = licenseBr.Obj.CopyRight.Where(rec => rec.WorkRh != null ).Select(rec => rec.WorkRh).ToList();
            var checkrh = worrh.Where(rec => rec.CRightId == testWorkRh.CRightId).Single();

            Assert.AreEqual(checkrh.WorkDateCl, testWorkRh.WorkDateCl);
        }

        [TestMethod]
        public void TestChangeLicType()
        {
            var service = new ConsumerService();
            var cust = service.GetData(142);

            var lic = cust.Client.LicenseAgreement.First(rec => rec.LicStatus != 4 && rec.LicType == 3);
            service.SetLicenseType(lic, ConsumerService.LicType.Reference );

            cust = service.GetData(142);
            service.SetLicenseType(lic, ConsumerService.LicType.Request );

            var licCheck = cust.Client.LicenseAgreement.First(rec => rec.LicId == lic.LicId );

            Assert.AreEqual(licCheck.LicType, 2);
        }

        [TestMethod]
        public void testLoadBigXls()
        {
            ExcelEngine engine = new ExcelEngine();
            var list = engine.GetReportItems(@"G:\MediaService\Звіти\Отчет для УААСП_СТБ_1 кв 2018.xls");
            Console.Write($"Count rows = {list.Count() }");
        }

    }
}
