using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary
{
    public partial class ContractConsumerDetailControl : UserControl
    {
        private string _authorPaymentPercent;
        private string _minAuthorPayment;
        private string _percentAutoprolongation;
        private BindingSource _bindingSource = new BindingSource();

        public ContractConsumerDetailControl()
        {
            InitializeComponent();
            rddListTypeAutoProl.Enabled = false;
            rtxtboxPercentAutoProl.Enabled = false;
            //rddListTypeAutoProl.SelectedItem = rddListTypeAutoProl.Items.First;
        }

        /// <summary>
        /// UPD binding
        /// </summary>
        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object DataSourceBinding
        {
            get => _bindingSource.DataSource;
            set => _bindingSource.DataSource = value;
        }

        [Category("Data")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        public string PercentPayment
        {
            get => _authorPaymentPercent;
            set
            {
                _authorPaymentPercent = value;
                rtxtBoxAuthorPaymentPercent.DataBindings.Clear();
                rtxtBoxAuthorPaymentPercent.DataBindings.Add("Text", _bindingSource,
                    _authorPaymentPercent, true, DataSourceUpdateMode.OnPropertyChanged, string.Empty);
            }
        }

        [Category("Data")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        public string MinPayment
        {
            get => _minAuthorPayment;
            set
            {
                _minAuthorPayment = value;
                rtxtBoxMinAuthorPayment.DataBindings.Clear();
                rtxtBoxMinAuthorPayment.DataBindings.Add("Text", _bindingSource,
                    _minAuthorPayment, true, DataSourceUpdateMode.OnPropertyChanged, string.Empty);
            }
        }

        [Category("Data")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        public string AutoprolongationPercent
        {
            get => _percentAutoprolongation;
            set
            {
                _percentAutoprolongation = value;
                rtxtboxPercentAutoProl.DataBindings.Clear();
                rtxtboxPercentAutoProl.DataBindings.Add("Text", _bindingSource,
                    _percentAutoprolongation, true, DataSourceUpdateMode.OnPropertyChanged, string.Empty);
            }
        }

        [Category("Dictionaries")]
        [AttributeProvider(typeof(IListSource))]
        public object PeriodPaymentDataSource
        {
            get => rddListPeriodPayment.DataSource;
            set
            {
                if (rddListPeriodPayment.DataSource != value)
                    rddListPeriodPayment.DataSource = value;
            }
        }

        [Category("Dictionaries")]
        public string PeriodPaymentDisplayMember
        {
            get => rddListPeriodPayment.DisplayMember;
            set => rddListPeriodPayment.DisplayMember = value;
        }

        [Category("Dictionaries")]
        public string PeriodPaymentValueMember
        {
            get => rddListPeriodPayment.ValueMember;
            set => rddListPeriodPayment.ValueMember = value;
        }

        [Category("Data")]
        public bool IsAutoprolongation
        {
            get => rCheckBoxAutoprolongation.Checked;
            set => rCheckBoxAutoprolongation.Checked = value;
        }

        ////old * * * * * * * * * *  * * * * * * * * * * * *
        //[Category("Data")]
        //[AttributeProvider(typeof(IListSource))]
        //public object DataSource
        //{
        //    get => iLicenseAgreementBindingSource.DataSource;
        //    set => iLicenseAgreementBindingSource.DataSource = value;
        //}

        //[Category("Data")]
        //[AttributeProvider(typeof(IListSource))]
        //public object DataSourcePaidPeriod
        //{
        //    get => rddListPeriodPayment.DataSource;
        //    set => rddListPeriodPayment.DataSource = value;
        //}

        //[Category("Dictionaries")]
        //public string PaidPeriodValueMember
        //{
        //    get => rddListPeriodPayment.ValueMember;
        //    set => rddListPeriodPayment.ValueMember = value;
        //}

        //[Category("Dictionaries")]
        //public string PaidPeroidDisplayMember
        //{
        //    get => rddListPeriodPayment.DisplayMember;
        //    set => rddListPeriodPayment.DisplayMember = value;
        //}



        //[Category("Data")]
        //public bool IsAutoprolongation
        //{
        //    get => rCheckBoxAutoprolongation.Checked;
        //    set => rCheckBoxAutoprolongation.Checked = value;
        //}


        //[Category("Data")]
        //[Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        //public string AuthorPaymentPercent
        //{
        //    get => _authorPaymentPercent;
        //    set
        //    {
        //        _authorPaymentPercent = value;
        //        rtxtBoxAuthorPaymentPercent.DataBindings.Clear();
        //        rtxtBoxAuthorPaymentPercent.DataBindings.Add("Text", iLicenseAgreementBindingSource,
        //            _authorPaymentPercent, true, DataSourceUpdateMode.OnPropertyChanged, string.Empty);
        //    }
        //}

        ////MinAuthorPayment
        //[Category("Data")]
        //[Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        //public string MinAuthorPayment
        //{
        //    get => _minAuthorPayment;
        //    set
        //    {
        //        _minAuthorPayment = value;
        //        rtxtBoxMinAuthorPayment.DataBindings.Clear();
        //        rtxtBoxMinAuthorPayment.DataBindings.Add("Text", iLicenseAgreementBindingSource,
        //            _minAuthorPayment, true, DataSourceUpdateMode.OnPropertyChanged, string.Empty);
        //    }
        //}


        //[Category("Data")]
        //[Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        //public string PercentAutoprolongation
        //{
        //    get => _percentAutoprolongation;
        //    set
        //    {
        //        _percentAutoprolongation = value;
        //        rtxtboxPercentAutoProl.DataBindings.Clear();
        //        rtxtboxPercentAutoProl.DataBindings.Add("Text", iLicenseAgreementBindingSource,
        //            _percentAutoprolongation, true, DataSourceUpdateMode.OnPropertyChanged, string.Empty);
        //    }
        //}

        //[Category("Dictionaries")]
        //[AttributeProvider(typeof(IListSource))]
        //public object PeriodDataSource
        //{
        //    get => rddListPeriodPayment.DataSource;
        //    set
        //    {
        //        if (rddListPeriodPayment.DataSource != value)
        //            rddListPeriodPayment.DataSource = value;
        //    }
        //}

        //[Category("Dictionaries")]
        //public string PeriodDisplayMember
        //{
        //    get => rddListPeriodPayment.DisplayMember;
        //    set => rddListPeriodPayment.DisplayMember = value;
        //}

        //[Category("Dictionaries")]
        //public string PeriodValueMember
        //{
        //    get => rddListPeriodPayment.ValueMember;
        //    set => rddListPeriodPayment.ValueMember = value;
        //}


        //rtxtboxPercentAutoProl

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

        private void rddListTypeAutoProl_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            switch (rddListTypeAutoProl.SelectedItem.Index)
            {
                case 0:
                    AutoprolongationPercent = "AddRate";
                    break;
                case 1:
                    AutoprolongationPercent = "IndxInfl";
                    break;
            }
        }

        public int SelectedItem
        {
            set => rddListTypeAutoProl.SelectedItem = rddListTypeAutoProl.Items[value];
        }
    }
}
