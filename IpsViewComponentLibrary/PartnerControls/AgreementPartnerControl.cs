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
using IpsViewComponentLibrary.Extensions;

namespace IpsViewComponentLibrary.PartnerControls
{
    public partial class AgreementPartnerControl : UserControl
    {
        private readonly DateTime _maxDate = new DateTime(3000, 1, 1, 0, 0, 0, 0);
        private bool _isReadOnlyMode;
        public AgreementPartnerControl()
        {
            InitializeComponent();
            txtDayForPay.KeyPress += ExtensionUtils.TextBoxPercentRate_KeyPressEvent;
        }

        public bool IsReadOnly
        {
            get => _isReadOnlyMode;
            set
            {
                _isReadOnlyMode = value;
                txtAgrNumber.ReadOnly = value;
                dtAgrDate.ReadOnly = value;
                dtDateBegin.ReadOnly = value;
                dtDateEnd.ReadOnly = value;
                ddlPeriodPayment.ReadOnly = value;
                txtDayForPay.ReadOnly = value;
                checkForever.ReadOnly = value;
            }
        }

        public object AgreementDataSource
        {
            get => bsAgreementAddPartner.DataSource;
            set
            {
                if (IpsGlobal.AnketaDictionaties?.period != null)
                    bsDictPaidPeriod.DataSource = IpsGlobal.AnketaDictionaties.period;
                bsAgreementAddPartner.DataSource = value;
                checkForever.Checked = (bsAgreementAddPartner.DataSource as AgreementAddPartner)?.DateEnd == _maxDate;
            }
        }

        public object AgreementCommunityDataSource
        {
            get => bsAgreementAddPartner.DataSource;
            set
            {
                if (IpsGlobal.AnketaDictionaties?.period != null)
                    bsDictPaidPeriod.DataSource = IpsGlobal.AnketaDictionaties.period;
                bsAgreementAddPartner.DataSource = value;
            }
        }

        private void txtDayForPay_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtDayForPay.Text, out int val) && val > 31)
                txtDayForPay.Text = "31";
        }

        private void checkForever_CheckStateChanged(object sender, EventArgs e)
        {
            dtDateEnd.Value = checkForever.Checked ? dtDateEnd.MaxDate : DateTime.Today;
            dtDateEnd.ReadOnly = true;
            dtDateEnd.Enabled = !checkForever.Checked;
        }

        private void dtDateBegin_ValueChanged(object sender, EventArgs e)
        {
            var date = dtDateBegin.Value.AddDays(1);
            dtDateEnd.MinDate = date;
        }

    }
}
