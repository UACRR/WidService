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
            var licenseAgrParam = _licenseAgreement.LicenseAgrParam.SingleOrDefault(rec => rec.LicVersion == _licenseAgreement.LicVersion);
            if (licenseAgrParam == null)
            {
                DialogResult = DialogResult.Cancel;
                return;
            }

            _licenseAgrParam = new LicenseAgrParam();
            _licenseAgrParam.SetFields(licenseAgrParam);
            _licenseAgrParam.LicVersion++;

            var license = licenseAgrParam.License;
            foreach (var lic in license)
            {
                var newlicense = new License();
                newlicense.SetFields(lic, new[] { "LId" });
                newlicense.LicVersion = _licenseAgrParam.LicVersion;
                _licenseAgrParam.License.Add(newlicense);
            }

            if (licenseAgrParam.DateEnd != null)
                _licenseAgrParam.LicDate = licenseAgrParam.DateEnd.Value.AddDays(1);

            if (licenseAgrParam.DateEnd != null)
                _licenseAgrParam.DateBegin = licenseAgrParam.DateEnd.Value.AddDays(1);

            if (_licenseAgrParam.DateBegin != null)
                _licenseAgrParam.DateEnd = _licenseAgrParam.DateBegin.Value.AddYears(1);

            ctrlAgrMain.DataSource = _licenseAgrParam;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // змінити статус старої ліцензії на закритий
            var oldAgrParam = _licenseAgreement.LicenseAgrParam.SingleOrDefault(rec => rec.LicVersion == _licenseAgreement.LicVersion);
            if (oldAgrParam != null)
                oldAgrParam.LicStatus = 4;
            
            // вказати нову версію
            _licenseAgreement.LicVersion = _licenseAgrParam.LicVersion;
            _licenseAgreement.LicenseAgrParam.Add(_licenseAgrParam);
            DialogResult = DialogResult.OK;
        }
    }
}
