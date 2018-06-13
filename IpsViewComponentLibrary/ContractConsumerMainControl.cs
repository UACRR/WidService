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
    public partial class ContractConsumerMainControl : UserControl
    {
        private DateTime _pickerAgrDate;
        private DateTime _pickerDateBegin;
        private DateTime _pickerDateEnd;

        private string _agrDate;
        private string _dateBegin;
        private string _dateEnd;
        private string _contrNumber;
        private BindingSource _bindingSource = new BindingSource();
        private BindingSource _dateBindingSource = new BindingSource();

        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object DataSource
        {
            get => _bindingSource.DataSource;
            set => _bindingSource.DataSource = value;
        }

        public string ContractNumber => rtxtBoxContrNumber.Text;
        public string ContractBeginDate => rdtPickerAgrDate.Value.ToString("dd.MM.yyyy");


        [Category("Data")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        public string ContrNumber
        {
            get => _contrNumber;
            set
            {
                _contrNumber = value;
                rtxtBoxContrNumber.DataBindings.Clear();
                rtxtBoxContrNumber.DataBindings.Add("Text", _bindingSource, _contrNumber, true, DataSourceUpdateMode.OnPropertyChanged, string.Empty);
            }
        }

        [Category("Data")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        public string AgrDateDataMember
        {
            get => _agrDate;
            set
            {
                    _agrDate = value;
                    rdtPickerAgrDate.DataBindings.Clear();
                    rdtPickerAgrDate.DataBindings.Add("Value", _bindingSource, _agrDate, true, DataSourceUpdateMode.OnPropertyChanged, value);
            }
        }


        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object DateDataSource
        {
            get => _dateBindingSource.DataSource;
            set => _dateBindingSource.DataSource = value;
        }

        [Category("Data")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        public string BeginDateDataMember
        {
            get => _dateBegin;
            set
            {
                _dateBegin = value;
                rdtPickerDateBegin.DataBindings.Clear();
                rdtPickerDateBegin.DataBindings.Add("Value", _dateBindingSource, _dateBegin, true, DataSourceUpdateMode.OnPropertyChanged, value);
            }
        }
        [Category("Data")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        public string EndDateDataMember
        {
            get => _dateEnd;
            set
            {
                _dateEnd = value;
                rdtPickerDateEnd.DataBindings.Clear();
                rdtPickerDateEnd.DataBindings.Add("Value", _dateBindingSource, _dateEnd, true, DataSourceUpdateMode.OnPropertyChanged, value);
            }
        }


        //ContrNumber
        public ContractConsumerMainControl()
        {
            InitializeComponent();
            rdtPickerAgrDate.Value = DateTime.Now;
            rdtPickerDateBegin.Value = DateTime.Now;
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

        public void ClearData()
        {
            rtxtBoxContrNumber.Text = string.Empty;
            rdtPickerAgrDate.Text = string.Empty;
            rdtPickerDateBegin.Text = string.Empty;
            rdtPickerDateEnd.Text = string.Empty;
        }

        private void rdtPickerDateBegin_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                rdtPickerDateEnd.MinDate = rdtPickerDateBegin.Value.Add(new TimeSpan(1, 0, 0, 0));

            }
            catch (Exception exception)
            {
                ;
            }
        }
    }
}
