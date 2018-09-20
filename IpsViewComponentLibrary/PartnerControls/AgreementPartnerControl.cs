using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Data;

namespace IpsViewComponentLibrary.PartnerControls
{
    public partial class AgreementPartnerControl : UserControl
    {
        public AgreementPartnerControl()
        {
            InitializeComponent();
            txtDayForPay.KeyPress += ExtensionUtils.TextBoxPercentRate_KeyPressEvent;
        }

        public object AgreementDataSource
        {
            get => bsAgreementAddPartner.DataSource;
            set => bsAgreementAddPartner.DataSource = value;
        }

        private void txtDayForPay_TextChanged(object sender, EventArgs e)
        {
            if (Int32.TryParse(txtDayForPay.Text, out int val) && val > 31)
                txtDayForPay.Text = "31";
        }

        private void AgreementWithPartnerControl_Load(object sender, EventArgs e)
        {
            if(IpsGlobal.AnketaDictionaties?.period != null)
                bsDictPaidPeriod.DataSource = IpsGlobal.AnketaDictionaties.period;
        }
    }
}
