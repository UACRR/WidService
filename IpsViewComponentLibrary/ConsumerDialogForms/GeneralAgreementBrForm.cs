using System;
using System.Windows.Forms;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;

namespace IpsViewComponentLibrary.ConsumerDialogForms
{
    public partial class GeneralAgreementBrForm : Telerik.WinControls.UI.RadForm
    {
        public GeneralAgreementBrForm(AnketaDictionaties dictionaties, AgreementAddBr agreementAddBr, string dialogFormText = null)
        {
            InitializeComponent();
            DialogResult = DialogResult.None;
            ctrlAgreement.PaidPeriodDictionaryDataSource = dictionaties.period;// typeof(Period);
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
