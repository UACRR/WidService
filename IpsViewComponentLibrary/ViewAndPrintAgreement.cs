using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using Telerik.WinControls;

namespace IpsViewComponentLibrary
{
    public partial class ViewAndPrintAgreement : Telerik.WinControls.UI.RadForm, IPreviewView
    {
        WordEngine wordEngine = null;
        public ViewAndPrintAgreement()
        {
            InitializeComponent();
        }// = new WordEngine();

        private void LoadDocument(AnketaDictionaties dictionaties, Customer customer, LicenseAgreement licenseAgreement)
        {
            radWaitingBar1.StartWaiting();
            wordEngine = new WordEngine(dictionaties);
            int version = licenseAgreement?.LicVersion ?? default(int);
            string templateName = dictionaties?.agrLicenseType?.SingleOrDefault(rec => rec.CodeI == licenseAgreement?.LicCode)?.TemplateName ?? "F_Тестовий шаблон.docx";
            templateName = string.Concat(@"Templates\", templateName);
            // Ліцензія не належить великим правам
            if (!(licenseAgreement.Agr != null && licenseAgreement.Agr.AgreementAddBr != null && licenseAgreement.Agr.AgreementAddBr.Count() > 0))
                wordEngine.ProcessConsumer(templateName, customer, licenseAgreement, version);
            else // Належить великим правам
            {
                wordEngine.processConsumerBR(templateName, customer, licenseAgreement.Agr, licenseAgreement);


            }

            var pdf = wordEngine.Pdf;
            radWaitingBar1.StopWaiting();
            radPdfViewer.LoadDocument(pdf);
        }

        public ViewAndPrintAgreement(AnketaDictionaties dictionaties, Customer customer, LicenseAgreement licenseAgreement)
        {
            InitializeComponent();
            LoadDocument(dictionaties, customer, licenseAgreement);
        }

        public async void ShowCopyrightRequest(RightolderWithNotAcceptedCopyrightViewModel rightholder, IEnumerable<ObjectRightNotAccepted> objectRightList)
        {
            Show();

            radWaitingBar1.StartWaiting();

            var wordEngine = new WordEngine(IpsGlobal.AnketaDictionaties);

            var template = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", "F_Copyright-Request.docx");

            await wordEngine.ProcessCopyrightRequest(template, rightholder, objectRightList);

            radPdfViewer.LoadDocument(wordEngine.Pdf);

            radWaitingBar1.StopWaiting();
        }

        public async void ShowFixationOrder(Fixation fixation)
        {
            Show();

            radWaitingBar1.StartWaiting();

            var wordEngine = new WordEngine(IpsGlobal.AnketaDictionaties);

            var template = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", "F_Наказ на фіксацію.docx");

            await wordEngine.ProcessFixationOrder(template, fixation);

            radPdfViewer.LoadDocument(wordEngine.Pdf);

            radWaitingBar1.StopWaiting();
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

        #region implementation IPreviewView interface

        public void StartWaiting()
        {
            radWaitingBar1.StartWaiting();
        }

        public void StopWaiting()
        {
            radWaitingBar1.StopWaiting();
        }

        public void LoadPdf(string path)
        {
            radPdfViewer.LoadDocument(path);
        }

        public void SetHeader(string header)
        {
            Text = header;
        }

        #endregion
    }
}
