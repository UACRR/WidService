using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.ConsumerForms
{
    public partial class ViewAndPrintAgreementForm : RadForm
    {
        private WordEngine _wordEngine;
        private readonly AnketaDictionaties _dictionaties;
        private const string DefaultTemplate = "F_Тестовий шаблон.docx";
        private string _pdf;
        private string _docx;

        protected new bool IsDesignMode => DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime;

        public ViewAndPrintAgreementForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            StartPosition = FormStartPosition.CenterScreen;
            if (!IsDesignMode)
                _dictionaties = IpsGlobal.AnketaDictionaties;
            SetupCustomSaveAsButton();
        }

        public ViewAndPrintAgreementForm(Customer customer, LicenseAgreement licenseAgreement) : this()
        {
            LoadDocument(customer, licenseAgreement);
        }

        public ViewAndPrintAgreementForm(Customer customer, LicenseAgreement licenseAgreement, int version) : this()
        {
            LoadDocument(customer, licenseAgreement, version);
        }

        private void SetupCustomSaveAsButton()
        {
            // replace standart Save As button to custom
            var standardBtnSaveAs = radPdfViewerNavigator.CommandBarElement.Rows[0].Strips[0].Items[3];
            standardBtnSaveAs.Visibility = ElementVisibility.Collapsed;
            var customBtnSaveAs = new CommandBarButton();
            radPdfViewerNavigator.CommandBarElement.Rows[0].Strips[0].Items.Insert(3, customBtnSaveAs);
            customBtnSaveAs.Text = standardBtnSaveAs.Text;
            customBtnSaveAs.Image = standardBtnSaveAs.Image;
            customBtnSaveAs.Click += BtnSaveAs_Click;
        }

        private void BtnSaveAs_Click(object sender, EventArgs e)
        {
            saveFileDialog.ShowDialog();
        }

        private void saveFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            string fileName = saveFileDialog.FileName;

            if (saveFileDialog.FilterIndex == 1) // docx
                File.Copy(_docx, fileName, true);
            else if (saveFileDialog.FilterIndex == 2) // pdf
                File.Copy(_pdf, fileName, true);
        }

        private void LoadDocument(Customer customer, LicenseAgreement licenseAgreement)
        {
            radWaitingBar1.StartWaiting();
            _wordEngine = new WordEngine(_dictionaties);
            int version = licenseAgreement?.LicVersion ?? default(int);
            string templateName = _dictionaties?.agrLicenseType?.SingleOrDefault(rec => rec.CodeI == licenseAgreement?.LicCode)?.TemplateName ?? DefaultTemplate;
            templateName = string.Concat(@"Templates\", templateName);
            // Ліцензія не належить великим правам
            if (!(licenseAgreement?.Agr?.AgreementAddBr != null && licenseAgreement.Agr.AgreementAddBr.Any()))
                _wordEngine.ProcessConsumer(templateName, customer, licenseAgreement, version);
            else // Належить великим правам
            {
                _wordEngine.ProcessConsumerBR(templateName, customer, licenseAgreement.Agr, licenseAgreement);
            }

            SetResult(_wordEngine.Pdf, _wordEngine.Docx);
            radWaitingBar1.StopWaiting();
        }

        // друк договору з вибором версії
        private void LoadDocument(Customer customer, LicenseAgreement licenseAgreement, int version)
        {
            radWaitingBar1.StartWaiting();
            _wordEngine = new WordEngine(_dictionaties);
            string templateName = _dictionaties?.agrLicenseType?.SingleOrDefault(rec => rec.CodeI == licenseAgreement?.LicCode)?.TemplateName ?? DefaultTemplate;
            templateName = string.Concat(@"Templates\", templateName);
            // Ліцензія не належить великим правам
            if (licenseAgreement.Agr?.AgreementAddBr != null && licenseAgreement.Agr.AgreementAddBr.Any())
                _wordEngine.ProcessConsumer(templateName, customer, licenseAgreement, version);
            else // Належить великим правам
            {
                _wordEngine.ProcessConsumerBR(templateName, customer, licenseAgreement.Agr, licenseAgreement);
            }

            SetResult(_wordEngine.Pdf, _wordEngine.Docx);
            radWaitingBar1.StopWaiting();
        }

        public async void ShowCopyrightRequest(RightolderWithNotAcceptedCopyrightViewModel rightholder, IEnumerable<ObjectRightNotAccepted> objectRightList)
        {
            Show();

            radWaitingBar1.StartWaiting();

            _wordEngine = new WordEngine(IpsGlobal.AnketaDictionaties);

            var template = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Templates", "F_Copyright-Request.docx");

            await _wordEngine.ProcessCopyrightRequest(template, rightholder, objectRightList);

            SetResult(_wordEngine.Pdf, _wordEngine.Docx);

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

        public void SetResult(string pathPdf, string pathDocx)
        {
            _pdf = pathPdf;
            _docx = pathDocx;

            radPdfViewer.LoadDocument(pathPdf);
        }

        public void SetHeader(string header)
        {
            Text = header;
        }

        #endregion
    }
}
