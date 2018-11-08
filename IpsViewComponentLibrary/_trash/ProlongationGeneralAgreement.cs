using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Model;
using Telerik.WinControls;

namespace IpsViewComponentLibrary.ConsumerDialogForms
{
    public partial class ProlongationGeneralAgreement : Telerik.WinControls.UI.RadForm
    {
        private LicenseAgreement _licenseAgreement;
        protected bool IsDesignMode => DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime;

        // delete this
        public ProlongationGeneralAgreement(LicenseAgreement licenseAgreement, string clientName)
        {
            InitializeComponent();
            DialogResult = DialogResult.None;
            _licenseAgreement = licenseAgreement;
            ctrlAgreementMain.AgreementLabelType = TypeRights.BigRights;
            lblTitle.Text = clientName;
            if (!IsDesignMode)
                bsDictPaidPeriod.DataSource = IpsGlobal.AnketaDictionaties.period;
            BeginBindings();

        }

        private void BeginBindings()
        {
            var agr = _licenseAgreement.Agr.AgreementAddBr.SingleOrDefault();
            ctrlAgreementMain.DataSourceBr = agr;
            bsAgreementAddBr.DataSource = agr;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
