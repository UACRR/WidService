using System;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign;
using ipsFormsDesign.Model;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.ConsumerDialogForms
{
    public partial class ProlongationBigRight : RadForm
    {
        private AgreementAddBr _newAgreementAddBr = null;
        private LicenseAgrParam _licenseAgrParam = null;
        private LicenseAgreement _licenseAgreement;

        public ProlongationBigRight(LicenseAgreement licenseAgreement, string clientName)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            DialogResult = DialogResult.None;

            _licenseAgreement = licenseAgreement;

            lblTitleClientName.Text = clientName;
            CreateAgreement();
        }

        private void CreateAgreement()
        {
            //_newAgreementAddBr = new AgreementAddBr();
            //_newAgreementAddBr.SetFields(_licenseAgreement.Agr.AgreementAddBr.LastOrDefault());
            //_newAgreementAddBr.Version++;
            //_newAgreementAddBr.DateBegin = DateTime.Today;
            //_newAgreementAddBr.DateEnd = DateTime.Today.AddYears(1);
            _licenseAgrParam = new LicenseAgrParam();
            _licenseAgrParam.SetFields(_licenseAgreement.LicenseAgrParam.LastOrDefault());
            _licenseAgrParam.LicVersion++;
            _licenseAgrParam.DateBegin = DateTime.Today;
            _licenseAgrParam.DateEnd = DateTime.Today.AddYears(1);

            //_licenseAgreement.Agr.AgreementAddBr.Add(_newAgreementAddBr);
            _licenseAgreement.LicenseAgrParam.Add(_licenseAgrParam);

            ctrlAgrMain.DataSource = _licenseAgreement.LicenseAgrParam.LastOrDefault();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void ProlongationBigRight_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
                _licenseAgreement.Agr.AgreementAddBr.Remove(_newAgreementAddBr);
        }
    }
}
