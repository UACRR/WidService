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

namespace IpsViewComponentLibrary.ConsumerControls.BigRight
{
    public partial class AgrDetailInfoBr : UserControl
    {
        private AnketaDictionaties _dictionaties = null;
        public event EventHandler OnSaveCommentNeed;
        public AgrDetailInfoBr()
        {
            InitializeComponent();

            if (IpsGlobal.AnketaDictionaties != null)
                _dictionaties = IpsGlobal.AnketaDictionaties;
        }

        public void SetDataInfo(LicenseAgrParam licenseParam, LicenseAgreementBigRightView licenseAgreementBigRightView)
        {
            bindingSourceComment.DataSource = licenseParam;
            //шапка
            txtAgrNumber.Text = licenseAgreementBigRightView.LicNum?? string.Empty;
            txtAgrDate.Text = licenseAgreementBigRightView.LicDate?.ToShortDateString() ?? string.Empty;
            txtIsProlong.Text = licenseAgreementBigRightView.ToProlong;
            
            //блок 1
            var currencyPaush = IpsGlobal.AnketaDictionaties.klR030.SingleOrDefault(rec => rec.R030 == licenseAgreementBigRightView.R030Paush);
            txtValutaPaush.Text = currencyPaush?.A3;
            txtAmountPaush.Text = licenseAgreementBigRightView.PrepayPaush?.ToString("N2");
            //блок 2
            var currencyPrepay = IpsGlobal.AnketaDictionaties.klR030.SingleOrDefault(rec => rec.R030 == licenseAgreementBigRightView.R030Avans);
            txtValutaPrepay.Text = currencyPrepay?.A3;
            txtAmountPrepay.Text = licenseAgreementBigRightView.PrepayAvans?.ToString("N2");
            //блок 3
            txtDatePremiere.Text = licenseAgreementBigRightView.DatePremiere?.ToShortDateString();
            txtCount.Text = licenseAgreementBigRightView.PerformNumb?.ToString();
            //блок 4
            txtRatePlace.Text = licenseAgreementBigRightView.FillingRate?.ToString("#0.00 '%'"); // %
            txtTicketPrice.Text = licenseAgreementBigRightView.TicketPriceNC?.ToString("N2"); // UAH
        }

        /// <summary>
        /// Очищення даних
        /// </summary>
        public void ClearData()
        {
            txtAgrNumber.Text = string.Empty;
            txtAgrDate.Text = string.Empty;
            txtIsProlong.Text = string.Empty;

            //блок 1
            txtValutaPaush.Text = string.Empty;
            txtAmountPaush.Text = string.Empty;
            //блок 2
            txtValutaPrepay.Text = string.Empty;
            txtAmountPrepay.Text = string.Empty;
            //блок 3
            txtDatePremiere.Text = string.Empty;
            txtCount.Text = string.Empty;
            //блок 4
            txtRatePlace.Text = string.Empty;
            txtTicketPrice.Text = string.Empty;
            //комент
            txtNotation.Text = string.Empty;
        }

        private void btnSaveComment_Click(object sender, EventArgs e)
        {
            if (txtNotation.Text != string.Empty)
                OnSaveCommentNeed?.Invoke(sender, e);
        }
    }
}
