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
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;

namespace IpsViewComponentLibrary.ConsumerControls
{
    public partial class ConsumerAgrDetailInfo : UserControl
    {
        private const string NullNumberString = "0,00";

        private readonly AnketaDictionaties _dictionaties;
        public event EventHandler OnSaveCommentNeed;
        public ConsumerAgrDetailInfo()
        {
            InitializeComponent();
            if(IpsGlobal.AnketaDictionaties != null)
                _dictionaties = IpsGlobal.AnketaDictionaties;
        }

        public void SetDataInfo(LicenseAgrParam licenseParam)
        {
            bsComment.DataSource = licenseParam ?? new LicenseAgrParam();
            //шапка
            txtAgrNumber.Text = licenseParam?.LicNum ?? string.Empty;
            txtAgrDate.Text = licenseParam?.LicDate?.ToShortDateString() ?? string.Empty;
            txtDelegate.Text = "";// представник
            txtReportPeriod.Text = _dictionaties?.period?.SingleOrDefault(p => p.CodeI == licenseParam?.PeriodCode)?.Name ?? string.Empty;
            //блок 1
            txtDateBegin.Text = licenseParam?.DateBegin?.ToShortDateString() ?? string.Empty;
            txtDateEnd.Text = licenseParam?.DateEnd?.ToShortDateString() ?? string.Empty;
            txtIsProlong.Text = licenseParam?.IsAutoprolog ?? false ? "Так" : "Ні";
            //блок 2
            txtRate.Text = licenseParam?.RateAmount?.ToString("N2") ?? NullNumberString;
            txtMinAmount.Text = licenseParam?.MinAmount?.ToString("N2") ?? NullNumberString;
            txtPercentAutoprolongation.Text = licenseParam?.AddRate?.ToString("N2") ?? string.Empty;

            //блок 3
            txtState.Text = _dictionaties?.agreementStatus.SingleOrDefault(rec => rec.CodeI == licenseParam?.LicStatus)?.Name ?? string.Empty;
            //TODO: заповнити відсутні дані
            txtAction.Text = "";
            txtIsPaid.Text = "";
            //блок 4
            txtBank.Text = "";
            txtAmount.Text = "";
            txtDistribAmount.Text = "";

            btnSaveComment.Enabled = true;
            txtNotation.Enabled = true;
        }

        public void ClearData()
        {
            txtAgrNumber.Text = string.Empty;
            txtAgrDate.Text = string.Empty;
            txtDelegate.Text = string.Empty;
            txtReportPeriod.Text = string.Empty;
            txtDateBegin.Text = string.Empty;
            txtDateEnd.Text = string.Empty;
            txtIsProlong.Text = string.Empty;
            txtState.Text = string.Empty;
            txtAction.Text = string.Empty;
            txtIsPaid.Text = string.Empty;
            txtBank.Text = string.Empty;

            txtRate.Text = NullNumberString;
            txtMinAmount.Text = NullNumberString;
            txtPercentAutoprolongation.Text = NullNumberString;

            txtAmount.Text = string.Empty;
            txtDistribAmount.Text = string.Empty;
            txtNotation.Text = string.Empty;
            btnSaveComment.Enabled = false;
            txtNotation.Enabled = false;
        }

        private void btnSaveComment_Click(object sender, EventArgs e)
        {
            if (txtNotation.Text != string.Empty)
                OnSaveCommentNeed?.Invoke(sender, e);
        }
    }
}
