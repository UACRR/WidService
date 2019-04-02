using System;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign;
using ipsFormsDesign.Model;
using Telerik.WinControls.UI;
using DateTime = System.DateTime;

namespace IpsViewComponentLibrary.ConsumerDialogForms
{
    public partial class ProlongationBigRight : RadForm
    {
        private readonly LicenseAgreement _licenseAgreement;
        private LicenseAgrParam _licenseAgrParam;

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
            var licenseAgrParam = _licenseAgreement.LicenseAgrParam.LastOrDefault();

            _licenseAgrParam = new LicenseAgrParam();
            _licenseAgrParam.SetFields(licenseAgrParam);

            _licenseAgrParam.LicVersion++;
            _licenseAgrParam.LicDate = licenseAgrParam.DateEnd.Value.AddDays(1);
            _licenseAgrParam.DateBegin = licenseAgrParam.DateEnd.Value.AddDays(1);
            _licenseAgrParam.DateEnd = _licenseAgrParam.DateBegin.Value.AddYears(1);

            ctrlAgrMain.DataSource = _licenseAgrParam;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _licenseAgreement.LicVersion = _licenseAgrParam.LicVersion;
            _licenseAgreement.LicenseAgrParam.Add(_licenseAgrParam);
            DialogResult = DialogResult.OK;
        }
    }
}
