using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TestWord_1
{
    public partial class RadForm1 : Telerik.WinControls.UI.RadForm
    {
        //      private RightholderService service = new RightholderService();
        private ConsumerService service = new ConsumerService();
        private WordEngine wordApp = null;

        public RadForm1()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e) {

            base.OnLoad(e);
            string template = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "F_7_Г готелі.docx");

            ProcessWord(template);



        }

        private void ProcessWord(string template)
        {
            Customer cust = service.GetData(135);
            wordApp = new WordEngine(service.GetDictionary());

//            wordApp.processRightHolder(template, cust, cust.AgreementMaster.First());
            wordApp.processConsumer(template, cust, cust.AgreementMaster.First());
            radPdfViewer1.LoadDocument(wordApp.Pdf);
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
