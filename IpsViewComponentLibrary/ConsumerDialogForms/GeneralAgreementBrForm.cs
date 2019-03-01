using System;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Model;

namespace IpsViewComponentLibrary.ConsumerDialogForms
{
    public partial class GeneralAgreementBrForm : Telerik.WinControls.UI.RadForm
    {
        public GeneralAgreementBrForm(AgreementAddBr agreementAddBr, string dialogFormText = null)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            DialogResult = DialogResult.None;
            if (IpsGlobal.AnketaDictionaties != null)
                ctrlAgreement.PaidPeriodDictionaryDataSource = IpsGlobal.AnketaDictionaties.period;
            ctrlAgreement.AgreementDataSource = agreementAddBr;

            if (!string.IsNullOrEmpty(dialogFormText))
                Text = dialogFormText;
        }

        public sealed override string Text
        {
            get => base.Text;
            set => base.Text = value;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
