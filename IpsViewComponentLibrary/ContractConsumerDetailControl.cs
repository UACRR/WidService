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
    public partial class ContractConsumerDetailControl : UserControl
    {
        private string _authorPaymentPercent;
        private string _minAuthorPayment;


        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object DataSource
        {
            get => iLicenseAgreementBindingSource.DataSource;
            set => iLicenseAgreementBindingSource.DataSource = value;
        }

        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object DataSourcePaidPeriod
        {
            get => rddListPeriodPayment.DataSource;
            set => rddListPeriodPayment.DataSource = value;
        }

        [Category("Dictionaries")]
        public string PaidPeriodValueMember
        {
            get => rddListPeriodPayment.ValueMember;
            set => rddListPeriodPayment.ValueMember = value;
        }

        [Category("Dictionaries")]
        public string PaidPeroidDisplayMember
        {
            get => rddListPeriodPayment.DisplayMember;
            set => rddListPeriodPayment.DisplayMember = value;
        }

        public ContractConsumerDetailControl()
        {
            InitializeComponent();
            rddListTypeAutoProl.Enabled = false;
            rtxtboxPercentAutoProl.Enabled = false;
        }


        [Category("Data")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        public string AuthorPaymentPercent
        {
            get => _authorPaymentPercent;
            set
            {
                _authorPaymentPercent = value;
                rtxtBoxAuthorPaymentPercent.DataBindings.Clear();
                rtxtBoxAuthorPaymentPercent.DataBindings.Add("Text", iLicenseAgreementBindingSource,
                    _authorPaymentPercent, true, DataSourceUpdateMode.OnPropertyChanged, string.Empty);
            }
        }

        //MinAuthorPayment
        [Category("Data")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        public string MinAuthorPayment
        {
            get => _minAuthorPayment;
            set
            {
                _minAuthorPayment = value;
                rtxtBoxMinAuthorPayment.DataBindings.Clear();
                rtxtBoxMinAuthorPayment.DataBindings.Add("Text", iLicenseAgreementBindingSource,
                    _minAuthorPayment, true, DataSourceUpdateMode.OnPropertyChanged, string.Empty);
            }
        }



        private void rCheckBoxAutoprolongation_CheckStateChanged(object sender, EventArgs e)
        {
            if (rCheckBoxAutoprolongation.Checked)
            {
                rddListTypeAutoProl.Enabled = true;
                rtxtboxPercentAutoProl.Enabled = true;
            }
            else
            {
                rtxtboxPercentAutoProl.Clear();
                rddListTypeAutoProl.SelectedItem = rddListTypeAutoProl.Items[0];
                rddListTypeAutoProl.Enabled = false;
                rtxtboxPercentAutoProl.Enabled = false;
            }
        }

        public bool Validator()
        {
            bool isValid = true;

            if (rtxtBoxAuthorPaymentPercent.Text == string.Empty)
            {
                isValid = false;
                radLabel1.ForeColor = Color.FromArgb(180, 255, 0, 2); ;
            }
            else
                radLabel1.ForeColor = Color.Black;

            if (rtxtBoxMinAuthorPayment.Text == string.Empty)
            {
                isValid = false;
                radLabel2.ForeColor = Color.FromArgb(180, 255, 0, 2); ;
            }
            else
                radLabel2.ForeColor = Color.Black;


            return isValid;
        }
    }
}
