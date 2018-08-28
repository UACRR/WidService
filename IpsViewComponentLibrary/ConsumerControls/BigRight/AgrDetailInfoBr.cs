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

        public void SetDataInfo(LicenseAgrParam licenseParam, VbrLicense license)
        {
            bindingSourceComment.DataSource = licenseParam;
            //шапка
            txtAgrNumber.Text = license.AgrNumber ?? string.Empty;
            txtAgrDate.Text = license.AgrDate?.ToShortDateString() ?? string.Empty;
            txtIsProlong.Text = license.ToProlong;
            
            //блок 1
            txtValuta.Text = license.R030;
            txtAmount.Text = license.PrepayPaush?.ToString("F");
            //блок 2
            txtAvanceAgr.Text = license.PrepayAvans?.ToString("F");
            txtAvanceRemnant.Text = license.PrepayRest?.ToString("F");
            //блок 3
            txtDatePremiere.Text = license.DatePremiere?.ToShortDateString();
            txtCount.Text = license.PerformNumb?.ToString();
            //блок 4
            txtRatePlace.Text = license.FillingRate?.ToString(); // %
            txtTicketPrice.Text = license.TicketPriceNC.ToString(); // UAH
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
            txtValuta.Text = string.Empty;
            txtAmount.Text = string.Empty;
            //блок 2
            txtAvanceAgr.Text = string.Empty;
            txtAvanceRemnant.Text = string.Empty;
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
