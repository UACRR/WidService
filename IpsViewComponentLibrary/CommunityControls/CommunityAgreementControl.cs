using System;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.Extensions;

namespace IpsViewComponentLibrary.CommunityControls
{
    public partial class CommunityAgreementControl : UserControl
    {
        private const string MaxDateBeginWarning = "Перевищено максимальне значення дати \"від\"!";
        private readonly DateTime MaxBeginDateTime = new DateTime(2999, 12, 31);
        private bool _isReadOnlyMode;

        public CommunityAgreementControl()
        {
            InitializeComponent();

            if (IpsGlobal.AnketaDictionaties?.period != null)
                bsDictPaidPeriod.DataSource = IpsGlobal.AnketaDictionaties.period;

            txtDayForPay.KeyPress += ExtensionUtils.TextBoxPercentRate_KeyPressEvent;
            dtDateBeginPER.Enabled = false;
            dtDateEndPER.Enabled = false;
            dtDateBeginMEC.Enabled = false;
            dtDateEndMEC.Enabled = false;
            SetupObjects();
        }

        public bool IsReadOnly
        {
            get => _isReadOnlyMode;
            set
            {
                _isReadOnlyMode = value;
                txtAgrNumber.ReadOnly = value;
                txtDayForPay.ReadOnly = value;
                txtRateCommis.ReadOnly = value;
                txtRateCourt.ReadOnly = value;
                dtAgrDate.ReadOnly = value;
                dtDateBegin.ReadOnly = value;
                dtDateEnd.ReadOnly = value;
                ddlPeriodPayment.ReadOnly = value;
                dtDateBeginMEC.ReadOnly = value;
                dtDateEndMEC.ReadOnly = value;
                dtDateBeginPER.ReadOnly = value;
                dtDateEndPER.ReadOnly = value;
                checkPER.ReadOnly = value;
                checkMEC.ReadOnly = value;
            }
        }

        private void SetupObjects()
        {
            var ownerName = IpsGlobal.GetProperty("OwnerName");
            radLabel7.Text = $"від сум, отриманих {ownerName ?? "Компанією"} для Автора";
        }

        public object AgreementDataSource
        {
            get => bsAgreementAddCommunity.DataSource;
            set
            {
                bsAgreementAddCommunity.DataSource = value;

                if (value is AgreementAddCommunity item)
                {
                    if (item.DateBeginPer == null)
                        dtDateBeginPER.Text = null;

                    if (item.DateEndPer == null)
                        dtDateEndPER.Text = null;

                    if (item.DateBeginMec == null)
                        dtDateBeginMEC.Text = null;

                    if (item.DateEndMec == null)
                        dtDateEndMEC.Text = null;

                    if (item.AgrDate == null)
                        dtAgrDate.Text = null;

                    if (item.DateBegin == null)
                        dtDateBegin.Text = null;

                    if (item.DateEnd == null)
                        dtDateEnd.Text = null;
                }

                bsAgreementAddCommunity.ResetBindings(false);
            }
        }

        private void txtDayForPay_TextChanged(object sender, EventArgs e)
        {
            if (int.TryParse(txtDayForPay.Text, out int val) && val > 31)
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

        private void dtDateBegin_Leave(object sender, EventArgs e)
        {
            if (dtDateBegin.Value >= MaxBeginDateTime)
            {
                MessageShow.ShowWarning(MaxDateBeginWarning);
                dtDateBegin.Value = DateTime.Today;
            }

            if (dtDateBegin.Value.AddDays(1) is DateTime newDate)
                dtDateEnd.MinDate = new DateTime(newDate.Year, newDate.Month, newDate.Day);
        }

        private void checkPER_CheckStateChanged(object sender, EventArgs e)
        {
            dtDateBeginPER.Enabled = checkPER.Checked;
            dtDateEndPER.Enabled = checkPER.Checked;
        }

        private void checkMEC_CheckStateChanged(object sender, EventArgs e)
        {
            dtDateBeginMEC.Enabled = checkMEC.Checked;
            dtDateEndMEC.Enabled = checkMEC.Checked;
        }
    }
}
