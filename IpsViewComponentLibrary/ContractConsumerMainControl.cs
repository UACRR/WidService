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
        private string _contrNumber;

        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object DataSource
        {
            get => iAgreementMasterBindingSource.DataSource;
            set => iAgreementMasterBindingSource.DataSource = value;
        }

        public string ContractNumber => rtxtBoxContrNumber.Text;
        public string ContractBeginDate => rdtPickerAgrDate.Value.ToString("dd.MM.yyyy");

        [Category("Data")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        public DateTime PickerAgrDate
        {
            get => _pickerAgrDate;
            set
            {
                _pickerAgrDate = value;
                rdtPickerAgrDate.DataBindings.Clear();
                rdtPickerAgrDate.DataBindings.Add("Value", iAgreementMasterBindingSource, "AgrDate", true,DataSourceUpdateMode.OnPropertyChanged, DateTime.Today );
            }
        }

        [Category("Data")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        public DateTime PickerDateBegin
        {
            get => _pickerDateBegin;
            set
            {
                _pickerDateBegin = value;
                rdtPickerDateBegin.DataBindings.Clear();
                rdtPickerDateBegin.DataBindings.Add("Value", iAgreementMasterBindingSource, "DateBegin", true, DataSourceUpdateMode.OnPropertyChanged, DateTime.Today);
            }
        }

        [Category("Data")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        public DateTime PickerDateEnd
        {
            get => _pickerDateEnd;
            set
            {
                _pickerDateEnd = value;
                rdtPickerDateEnd.DataBindings.Clear();
                rdtPickerDateEnd.DataBindings.Add("Value", iAgreementMasterBindingSource, "DateEnd", true,  DataSourceUpdateMode.OnPropertyChanged, DateTime.Today);
            }
        }

        [Category("Data")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        public string ContrNumber
        {
            get => _contrNumber;
            set
            {
                _contrNumber = value;
                rtxtBoxContrNumber.DataBindings.Clear();
                rtxtBoxContrNumber.DataBindings.Add("Text", iAgreementMasterBindingSource, _contrNumber, true, DataSourceUpdateMode.OnPropertyChanged, "Договір №");
            }
        }


        //ContrNumber
        public ContractConsumerMainControl()
        {
            InitializeComponent();
            
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
    }
}
