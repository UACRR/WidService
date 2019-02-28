using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IpsViewComponentLibrary.Extensions;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary
{
    public partial class ContractConsumerDetailControl : UserControl
    {
        private string _authorPaymentPercent;
        private string _minAuthorPayment;
        private string _percentAutoprolongation;
        private string _periodPaymentDataMember;
        private BindingSource _bindingSource = new BindingSource();

        public ContractConsumerDetailControl()
        {
            InitializeComponent();
            rddListTypeAutoProl.Enabled = false;
            txtPercentAutoProl.Enabled = false;

            txtPercentAutoProl.KeyPress += ExtensionUtils.TextBoxPercentRate_KeyPressEvent;
            rtxtBoxAuthorPaymentPercent.KeyPress += ExtensionUtils.TextBoxPercentRate_KeyPressEvent;
            rtxtBoxMinAuthorPayment.KeyPress += ExtensionUtils.TextBoxPercentRate_KeyPressEvent;
        }
        //rtxtBoxMinAuthorPayment
        public void SetDefaultState()
        {
            rddListTypeAutoProl.Enabled = false;
            txtPercentAutoProl.Enabled = false;

            if (ddlPeriodPayment.Items.Count != 0)
            {
                ddlPeriodPayment.SelectedIndex = ddlPeriodPayment.Items.Last.Index;
                ddlPeriodPayment.SelectedIndex = ddlPeriodPayment.Items.First.Index;
            }
        }

        [Category("Dictionaries")]
        [AttributeProvider(typeof(IListSource))]
        public object AutoprolongationDataSource
        {
            get => bsCheckedProlongation.DataSource;
            set => bsCheckedProlongation.DataSource = value;
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

        /// <summary>
        /// Мінімальна сума оплати
        /// </summary>
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

        /// <summary>
        /// Якщо є автопролонгація, обраний тип кріпити сюди
        /// </summary>
        [Category("Data")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        public string AutoprolongationPercent
        {
            get => _percentAutoprolongation;
            set
            {
                if (value == null)
                {
                    txtPercentAutoProl.TextBoxElement.Text = string.Empty;

                    return;
                }
                _percentAutoprolongation = value;
                txtPercentAutoProl.DataBindings.Clear();
                txtPercentAutoProl.DataBindings.Add("Text", _bindingSource,
                    _percentAutoprolongation, true, DataSourceUpdateMode.OnPropertyChanged, string.Empty);
            }
        }

        [Category("Dictionaries")]
        [AttributeProvider(typeof(IListSource))]
        public object PeriodPaymentDataSource
        {
            get => ddlPeriodPayment.DataSource;
            set
            {
                if (ddlPeriodPayment.DataSource != value)
                    ddlPeriodPayment.DataSource = value;
            }
        }

        [Category("Dictionaries")]
        public string PeriodPaymentDisplayMember
        {
            get => ddlPeriodPayment.DisplayMember;
            set => ddlPeriodPayment.DisplayMember = value;
        }

        [Category("Dictionaries")]
        public string PeriodPaymentValueMember
        {
            get => ddlPeriodPayment.ValueMember;
            set => ddlPeriodPayment.ValueMember = value;
        }

        [Category("Dictionary")]
        public string PeriodPaymentDataMember
        {
            get => _periodPaymentDataMember;
            set
            {
                _periodPaymentDataMember = value;
                ddlPeriodPayment.DataBindings.Clear();
                ddlPeriodPayment.DataBindings.Add("SelectedValue", _bindingSource, _periodPaymentDataMember, true, DataSourceUpdateMode.OnPropertyChanged, value);
            }
        }

        [Category("Dictionary")]
        public object PeriodPaymentSelectedValue
        {
            get => ddlPeriodPayment.SelectedValue;
            set => ddlPeriodPayment.SelectedValue = value;
        }


        /// <summary>
        /// Чи встановлена автопролонгація
        /// </summary>
        [Category("Data")]
        public bool IsAutoprolongation
        {
            get => rCheckBoxAutoprolongation.IsChecked;
            set => rCheckBoxAutoprolongation.IsChecked = value;
        }

        public void SelectDefaultItem()
        {
            ddlPeriodPayment.SelectedIndex = 0;
        }
        
        private void rCheckBoxAutoprolongation_CheckStateChanged(object sender, EventArgs e)
        {
            if (rCheckBoxAutoprolongation.Checked)
            {
                rddListTypeAutoProl.Enabled = true;
                txtPercentAutoProl.Enabled = true;
            }
            else
            {
                txtPercentAutoProl.Clear();
                rddListTypeAutoProl.Enabled = false;
                txtPercentAutoProl.Enabled = false;
            }
        }

        public bool Validator()
        {
            bool isValid = true;

            if (rtxtBoxAuthorPaymentPercent.Text == string.Empty)
            {
                isValid = false;
                radLabel1.ForeColor = Color.FromArgb(180, 255, 0, 2);
            }
            else
                radLabel1.ForeColor = Color.Black;

            if (rtxtBoxMinAuthorPayment.Text == string.Empty)
            {
                isValid = false;
                radLabel2.ForeColor = Color.FromArgb(180, 255, 0, 2);
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

        /// <summary>
        /// Мінімальна допустима сума
        /// </summary>
        public decimal MinAmount { get; set; }

        private void rtxtBoxMinAuthorPayment_TextChanged(object sender, EventArgs e)
        {
            //TODO: перевірка мін суми
        }
    }
}
