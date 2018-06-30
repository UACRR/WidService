using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
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

        public ViewAndPrintAgreement(AnketaDictionaties dictionaties, Customer customer, LicenseAgreement licenseAgreement)
        {
            InitializeComponent();
            wordEngine = new WordEngine(dictionaties);
            int version = licenseAgreement?.LicVersion ?? default(int);
            string templateName = dictionaties?.agrLicenseType?.SingleOrDefault(rec => rec.CodeI == licenseAgreement?.LicCode)?.TemplateName ?? "F_Тестовий шаблон.docx";
            templateName = string.Concat(@"Templates\", templateName);


            wordEngine.ProcessConsumer(templateName, customer, licenseAgreement, version);
            var pdf = wordEngine.Pdf;
            radPdfViewer.LoadDocument(pdf);
        }
    }
}
