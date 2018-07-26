using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using Telerik.WinControls;

namespace IpsViewComponentLibrary
{
    public partial class ViewAndPrintAgreement : Telerik.WinControls.UI.RadForm
    {
        WordEngine wordEngine = null;
        public ViewAndPrintAgreement()
        {
            InitializeComponent();
        }// = new WordEngine();

        private async Task LoadDocument(AnketaDictionaties dictionaties, Customer customer, LicenseAgreement licenseAgreement)
        {
            radWaitingBar1.StartWaiting();
            wordEngine = new WordEngine(dictionaties);
            int version = licenseAgreement?.LicVersion ?? default(int);
            string templateName = dictionaties?.agrLicenseType?.SingleOrDefault(rec => rec.CodeI == licenseAgreement?.LicCode)?.TemplateName ?? "F_Тестовий шаблон.docx";
            templateName = string.Concat(@"Templates\", templateName);


            await wordEngine.ProcessConsumer(templateName, customer, licenseAgreement, version);
            var pdf = wordEngine.Pdf;
            radWaitingBar1.StopWaiting();
            radPdfViewer.LoadDocument(pdf);
        }

        public ViewAndPrintAgreement(AnketaDictionaties dictionaties, Customer customer, LicenseAgreement licenseAgreement)
        {
            InitializeComponent();
            var task = LoadDocument(dictionaties, customer, licenseAgreement);
        }

        public void ShowDocument(string path)
        {
            radPdfViewer.LoadDocument(path);
            Show();
        }

        private void radWaitingBar1_WaitingStarted(object sender, EventArgs e)
        {
            radWaitingBar1.Visible = true;
        }

        private void radWaitingBar1_WaitingStopped(object sender, EventArgs e)
        {
            radWaitingBar1.Visible = false;
        }

        private void radWaitingBar1_ParentChanged(object sender, EventArgs e)
        {
            var clnSize = radWaitingBar1.Size;
            radWaitingBar1.Location = new Point(Size.Width / 2 - clnSize.Width / 2, Size.Height / 2 - clnSize.Height / 2); 
        }
    }
}
