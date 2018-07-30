using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign;
using ipsFormsDesign.Data;
using ipsFormsDesign.Model;
using Telerik.WinControls;

namespace IpsViewComponentLibrary.ConsumerDialogForms
{
    public partial class ProlongationBigRight : Telerik.WinControls.UI.RadForm
    {
        private AgreementAddBr _newAgreementAddBr = null;
        private LicenseAgrParam _licenseAgrParam = null;
        private Customer _customer;
        private LicenseAgreement _licenseAgreement;
        public ProlongationBigRight()
        {
            InitializeComponent();
        }

        public ProlongationBigRight(Customer customer, LicenseAgreement licenseAgreement, string clientName)
        {
            InitializeComponent();
            DialogResult = DialogResult.None;

            _customer = customer;
            _licenseAgreement = licenseAgreement;

            lblTitleClientName.Text = clientName;
            CreateAgreement();
        }

        private void CreateAgreement()
        {
            _newAgreementAddBr = new AgreementAddBr();
            _newAgreementAddBr.SetFields(_licenseAgreement.Agr.AgreementAddBr.LastOrDefault());
            _newAgreementAddBr.Version++;
            _newAgreementAddBr.DateBegin = DateTime.Today;
            _newAgreementAddBr.DateEnd = DateTime.Today.AddYears(1);
            _licenseAgrParam = new LicenseAgrParam();
            _licenseAgrParam.SetFields(_licenseAgreement.LicenseAgrParam);//TODO реконстр
            _licenseAgrParam.LicVersion++;
            
            _licenseAgreement.Agr.AgreementAddBr.Add(_newAgreementAddBr);
            _licenseAgreement.LicenseAgrParam.Add(_licenseAgrParam);

            ctrlAgrMain.DataSourceBr = _licenseAgreement.Agr.AgreementAddBr.LastOrDefault();
            ctrlAgrMain.DataSourceBrLicNumber = _licenseAgreement.LicenseAgrParam.LastOrDefault();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnPrintAgr_Click(object sender, EventArgs e)
        {
            ViewAndPrintAgreement print = new ViewAndPrintAgreement(dictionaties: IpsGlobal.AnketaDictionaties, customer: _customer, licenseAgreement: _licenseAgreement)
            {
                WindowState = FormWindowState.Maximized,
                StartPosition = FormStartPosition.CenterScreen
            };
            print.ShowDialog();
        }

        private void ProlongationBigRight_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
                _licenseAgreement.Agr.AgreementAddBr.Remove(_newAgreementAddBr);
        }
    }
}
