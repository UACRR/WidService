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

namespace IpsViewComponentLibrary.CommunityControls
{
    public partial class CommunityAgreementControl : UserControl
    {
        public CommunityAgreementControl()
        {
            InitializeComponent();
            txtDayForPay.KeyPress += ExtensionUtils.TextBoxPercentRate_KeyPressEvent;

        }

        public object AgreementDataSource
        {
            get => bsAgreementAddCommunity.DataSource;
            set
            {
                if (IpsGlobal.AnketaDictionaties?.period != null)
                    bsDictPaidPeriod.DataSource = IpsGlobal.AnketaDictionaties.period;
                bsAgreementAddCommunity.DataSource = value;
            }
        }

        private void txtDayForPay_TextChanged(object sender, EventArgs e)
        {
            if (Int32.TryParse(txtDayForPay.Text, out int val) && val > 31)
                txtDayForPay.Text = "31";
        }

        private void checkForever_CheckStateChanged(object sender, EventArgs e)
        {
            dtDateEnd.Value = checkForever.Checked ? dtDateEnd.MaxDate : DateTime.Today;
            dtDateEnd.Enabled = !checkForever.Checked;
        }

        private void dtDateBegin_ValueChanged(object sender, EventArgs e)
        {
            dtDateEnd.MinDate = dtDateBegin.Value.AddDays(1);
        }
    }
}
