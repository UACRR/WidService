using System;
using System.Windows.Forms;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;

namespace IpsViewComponentLibrary
{
    public partial class AddGeneralAgreementBrForm : Telerik.WinControls.UI.RadForm
    {
        public AddGeneralAgreementBrForm()
        {
            InitializeComponent();
        }

        public AddGeneralAgreementBrForm(AnketaDictionaties dictionaties, LicenseAgreement agreement, AgreementAddBr agreementAddBr, AnketaCompany company)
        {
            InitializeComponent();
            DialogResult = DialogResult.None;
            ctrlAgreement.PaidPeriodDictionaryDataSource = dictionaties.period;// typeof(Period);
            ctrlAgreement.AgreementDataSource = agreementAddBr;
            ctrlAgreement.AnketaCompanyDataSource = company;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
