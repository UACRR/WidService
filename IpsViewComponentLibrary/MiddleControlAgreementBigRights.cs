using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Dictionary;

namespace IpsViewComponentLibrary
{
    public partial class MiddleControlAgreementBigRights : UserControl
    {
        public MiddleControlAgreementBigRights()
        {
            InitializeComponent();
            ctrlAgreementMain.AgreementLabelType = TypeRights.BigRights;
        }

        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object AnketaCompanyDataSource
        {
            get => bsAnketaCompany.DataSource;
            set => bsAnketaCompany.DataSource = value;
        }

        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object DictionaryAgrLicTypeDataSource
        {
            get => bsDictAgrLicType.DataSource;
            set => bsDictAgrLicType.DataSource = value;
        }

        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object DictionaryPeriodPaymentDataSource
        {
            get => bsDictPaidPeriod.DataSource;
            set => bsDictPaidPeriod.DataSource = value;
        }

        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object LicenseAgrParamDataSource
        {
            get => bsLicAgrParam.DataSource;
            set => bsLicAgrParam.DataSource = value;
        }

        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object AgreementAddBrDataSource
        {
            get => bsAgreementAddBr.DataSource;
            set => bsAgreementAddBr.DataSource = value;
        }

        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object LicAgrDataSource
        {
            get => licenseAgreementBindingSource.DataSource;
            set => licenseAgreementBindingSource.DataSource = value;
        }

        /// <summary>
        /// Перевірка на правильність введених полів
        /// </summary>
        /// <returns></returns>
        public bool Validator()
        {
            return ctrlAgreementMain.Validator();
        }

        /// <summary>
        /// Для великих прав в режимі додавання нової анкети доступні тільки генеральні договора
        /// </summary>
        internal void SetBigRightsLicenseAgrType()
        {
            ddlLicType.ReadOnly = true;
        }

        private void txtDayForPay_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 44)
            {
                e.Handled = true;
            }
        }

        private void txtDayForPay_TextChanged(object sender, EventArgs e)
        {
            if (Int32.TryParse(txtDayForPay.Text, out int val) && val > 31)
                txtDayForPay.Text = "31";
        }
    }
}
