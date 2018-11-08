using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Model;

namespace IpsViewComponentLibrary.ConsumerControls.BigRight
{
    public partial class AgreementBigRight : UserControl
    {
        public AgreementBigRight()
        {
            InitializeComponent();
            rdtPickerAgrDate.SetUserCalendarSettingsm();
            rdtPickerDateBegin.SetUserCalendarSettingsm();
            rdtPickerDateEnd.SetUserCalendarSettingsm();
            rdtPickerDateBegin.ValueChanged += rdtPickerDateBegin_ValueChanged;
            txtDayForPay.KeyPress += txtDayForPay_KeyPress;
            txtDayForPay.TextChanged += txtDayForPay_TextChanged;
        }

        /// <summary>
        /// DataSource генеральної угоди
        /// </summary>
        public object AgreementDataSource
        {
            get => bsAgreementAddBr.DataSource;
            set => bsAgreementAddBr.DataSource = value;
        }

        /// <summary>
        /// Dictionary періодів оплати
        /// </summary>
        public object PaidPeriodDictionaryDataSource
        {
            get => bsDictPaidPeriod.DataSource;
            set => bsDictPaidPeriod.DataSource = value;
        }

        public object AnketaCompanyDataSource
        {
            get => bsAnketaCompany.DataSource;
            set => bsAnketaCompany.DataSource = value;
        }

        public bool Validator()
        {
            bool isValid = true;

            if (rtxtBoxContrNumber.Text == string.Empty)
            {
                lblContrNumb.ForeColor = Color.FromArgb(180, 255, 0, 2);
                isValid = false;
            }
            else
                lblContrNumb.ForeColor = Color.Black;

            return isValid;
        }

        private void rdtPickerDateBegin_ValueChanged(object sender, EventArgs e)
        {
            if (rdtPickerDateBegin.Value.AddDays(1) is DateTime newDate)
                rdtPickerDateEnd.MinDate = new DateTime(newDate.Year, newDate.Month, newDate.Day);
        }

        // допускати тільки числа
        private void txtDayForPay_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 44)
            {
                e.Handled = true;
            }
        }

        // допускати числа не більші 31
        private void txtDayForPay_TextChanged(object sender, EventArgs e)
        {
            if (Int32.TryParse(txtDayForPay.Text, out int val) && val > 31)
                txtDayForPay.Text = "31";
        }
    }
}
