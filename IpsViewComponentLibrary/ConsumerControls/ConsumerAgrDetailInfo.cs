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
        private AnketaDictionaties _dictionaties = null;
        public event EventHandler OnSaveCommentNeed;
        public ConsumerAgrDetailInfo()
        {
            InitializeComponent();
            if(IpsGlobal.AnketaDictionaties != null)
                _dictionaties = IpsGlobal.AnketaDictionaties;
        }

        /// <summary>
        /// Закріпляти, навіть якщо прострочений
        /// </summary>
        public bool IsAttached
        {
            get => checkAttach.Checked;
            set => checkAttach.Checked = value;
        }

        public void SetDataInfo(LicenseAgrParam licenseParam)
        {
            bindingSourceComment.DataSource = licenseParam;
            //шапка
            txtAgrNumber.Text = licenseParam?.LicNum;
            txtAgrDate.Text = licenseParam?.LicDate?.ToShortDateString();
            txtDelegate.Text = "";// представник
            txtReportPeriod.Text = _dictionaties?.period?.SingleOrDefault(p => p.CodeI == licenseParam?.PeriodCode)?.Name;
            //блок 1
            txtDateBegin.Text = licenseParam?.DateBegin?.ToShortDateString();
            txtDateEnd.Text = licenseParam?.DateEnd?.ToShortDateString();
            txtIsProlong.Text = licenseParam?.IsAutoprolog ?? false ? "Так" : "Ні";
            //блок 2
            txtRate.Text = licenseParam?.RateAmount?.ToString();
            txtMinAmount.Text = licenseParam?.MinAmount.ToString();
            //блок 3
            txtState.Text = _dictionaties?.agreementStatus.SingleOrDefault(rec => rec.CodeI == licenseParam?.LicStatus)?.Name;
            //TODO: заповнити відсутні дані
            txtAction.Text = "";
            txtIsPaid.Text = "";
            //блок 4
            txtBank.Text = "";
            txtAmount.Text = "";
            txtDistribAmount.Text = "";
        }

        private void btnSaveComment_Click(object sender, EventArgs e)
        {
            if (txtNotation.Text != string.Empty)
                OnSaveCommentNeed?.Invoke(sender, e);
        }
    }
}
