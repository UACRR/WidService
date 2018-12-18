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
using ipsFormsDesign.Model;

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
            if (checkForever.Checked)
            {
                dtDateEnd.Value = dtDateEnd.MaxDate;
                dtDateEnd.Select();
            }
            else
                dtDateEnd.Value = DateTime.Today;
            dtDateEnd.Enabled = !checkForever.Checked;

            if(bsAgreementAddCommunity.DataSource is AgreementAddCommunity item)
                item.DateEnd = dtDateEnd.Value.Date;
        }

        private void dtDateBegin_ValueChanged(object sender, EventArgs e)
        {
            dtDateEnd.MinDate = dtDateBegin.Value.AddDays(1);
        }
    }
}
