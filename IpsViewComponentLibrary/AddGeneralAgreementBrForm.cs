using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using Telerik.WinControls;

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
            ctrlAgreement.DictionaryAgrLicTypeDataSource = dictionaties.agrLicenseType.Where(rec => rec.UsesKind == 1);// typeof(AgrLicenseType);
            ctrlAgreement.DictionaryPeriodPaymentDataSource = dictionaties.period;// typeof(Period);
            ctrlAgreement.LicAgrDataSource = agreement;// typeof(LicenseAgreementChange);
            ctrlAgreement.AgreementAddBrDataSource = agreementAddBr;
            ctrlAgreement.AnketaCompanyDataSource = company;

            ctrlAgreement.SetBigRightsLicenseAgrType();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
