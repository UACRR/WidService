using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IpsViewComponentLibrary
{
    public partial class MiddleControlAgreementBigRights : UserControl
    {
        public MiddleControlAgreementBigRights()
        {
            InitializeComponent();
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
        public object LicAgrDataSource
        {
            get => licenseAgreementBindingSource.DataSource;
            set => licenseAgreementBindingSource.DataSource = value;
        }

        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object AnketaCompanyDataSource
        {
            get => bsAnketaCompany.DataSource;
            set => bsAnketaCompany.DataSource = value;
        }

        private void txtDayForPay_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!char.IsDigit(ch) && ch != 8 && ch != 44)
            {
                e.Handled = true;
            }

            if (Convert.ToInt32(txtDayForPay.Text) > 31)
                txtDayForPay.Text = "31";
        }
    }
}
