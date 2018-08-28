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
    public partial class ContractConsumerMainControl : UserControl
    {
        private string _numberDataMember = "";
        private string _dateDataMember = "";
        private string _dateBeginDataMember = "";
        private string _dateEndDataMember = "";
        private string _agreemnentName = "";
        private DateTime _dateEndNullDate = new DateTime(1,1,1);
        private string _dateEndNullText = "";
        private ConsumerAgreementInitType _type = ConsumerAgreementInitType.None;
        private TypeRights _rights = TypeRights.SmallRights;

        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object DataSource
        {
            get => bsLicenseAgrParam.DataSource;
            set
            {
                rtxtBoxContrNumber.DataBindings.Clear();
                rdtPickerAgrDate.DataBindings.Clear();
                rdtPickerDateBegin.DataBindings.Clear();
                rdtPickerDateEnd.DataBindings.Clear();

                bsLicenseAgrParam.DataSource = value;

                rtxtBoxContrNumber.DataBindings.Add(new Binding("Text", bsLicenseAgrParam, "LicNum", true, DataSourceUpdateMode.OnPropertyChanged));
                rdtPickerAgrDate.DataBindings.Add(new Binding("Value", bsLicenseAgrParam, "LicDate", true, DataSourceUpdateMode.OnPropertyChanged));
                rdtPickerDateBegin.DataBindings.Add(new Binding("Value", bsLicenseAgrParam, "DateBegin", true, DataSourceUpdateMode.OnPropertyChanged));
                rdtPickerDateEnd.DataBindings.Add(new Binding("Value", bsLicenseAgrParam, "DateEnd", true, DataSourceUpdateMode.OnPropertyChanged));
            }
        }

        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object DataSourceBr
        {
            get => bsAgreementAddBr.DataSource;
            set
            {
                rtxtBoxContrNumber.DataBindings.Clear();
                rdtPickerAgrDate.DataBindings.Clear();
                rdtPickerDateBegin.DataBindings.Clear();
                rdtPickerDateEnd.DataBindings.Clear();

                bsAgreementAddBr.DataSource = value;

                rtxtBoxContrNumber.DataBindings.Add(new Binding("Text", bsAgreementAddBr, "AgrNumber", true, DataSourceUpdateMode.OnPropertyChanged));
                rdtPickerAgrDate.DataBindings.Add(new Binding("Value", bsAgreementAddBr, "AgrDate", true, DataSourceUpdateMode.OnPropertyChanged));
                rdtPickerDateBegin.DataBindings.Add(new Binding("Value", bsAgreementAddBr, "DateBegin", true, DataSourceUpdateMode.OnPropertyChanged));
                rdtPickerDateEnd.DataBindings.Add(new Binding("Value", bsAgreementAddBr, "DateEnd", true, DataSourceUpdateMode.OnPropertyChanged));
            }
        }

        #region Data members

        [Category("Data")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        public string NumberDataMember
        {
            get { return _numberDataMember; }
            set
            {
                if (_numberDataMember != value)
                {
                    _numberDataMember = value;
                    rtxtBoxContrNumber.DataBindings.Clear();
                    rtxtBoxContrNumber.DataBindings.Add("Text", bsLicenseAgrParam, _numberDataMember, true, DataSourceUpdateMode.OnPropertyChanged);
                }
            }
        }

        [Category("Data")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        public string DateDataMember
        {
            get { return _dateDataMember; }
            set
            {
                if (_dateDataMember != value)
                {
                    _dateDataMember = value;
                    rdtPickerAgrDate.DataBindings.Clear();
                    rdtPickerAgrDate.DataBindings.Add("Value", bsLicenseAgrParam, _dateDataMember, true, DataSourceUpdateMode.OnPropertyChanged, new DateTime(1, 1, 1));
                }
            }
        }

        [Category("Data")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        public string DateBeginDataMember
        {
            get { return _dateBeginDataMember; }
            set
            {
                if (_dateBeginDataMember != value)
                {
                    _dateBeginDataMember = value;
                    rdtPickerDateBegin.DataBindings.Clear();
                    rdtPickerDateBegin.DataBindings.Add("Value", bsLicenseAgrParam, _dateBeginDataMember, true, DataSourceUpdateMode.OnPropertyChanged, new DateTime(1, 1, 1));
                }
            }
        }

        [Category("Data")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        public string DateEndDataMember
        {
            get { return _dateEndDataMember; }
            set
            {
                if (_dateEndDataMember != value)
                {
                    _dateEndDataMember = value;
                    rdtPickerDateEnd.DataBindings.Clear();
                    rdtPickerDateEnd.DataBindings.Add("Value", bsLicenseAgrParam, _dateEndDataMember, true, DataSourceUpdateMode.OnPropertyChanged, _dateEndNullDate);
                }
            }
        }

        #endregion

        [Browsable(true)]
        public string AgreementName
        {
            get { return _agreemnentName; }
            set
            {
                if (_agreemnentName != value)
                {
                    _agreemnentName = value;
                    lblContrNumb.Text = value;
                }
            }
        }

        [Browsable(true)]
        public DateTime DateEndNullDate
        {
            get { return _dateEndNullDate; }
            set
            {
                if (_dateEndNullDate != value)
                {
                    _dateEndNullDate = value;
                    rdtPickerDateEnd.NullDate = value;

                    // update binding
                    rdtPickerDateEnd.DataBindings.Clear();
                    rdtPickerDateEnd.DataBindings.Add("Value", bsLicenseAgrParam, _dateEndDataMember, true, DataSourceUpdateMode.OnPropertyChanged, _dateEndNullDate);
                }
            }
        }

        [Browsable(true)]
        public string DateEndNullText
        {
            get { return _dateEndNullText; }
            set
            {
                if (_dateEndNullText != value)
                {
                    _dateEndNullText = value;
                    rdtPickerDateEnd.NullText = value;
                }
            }
        }

        public ConsumerAgreementInitType DateTimeType
        {
            get => _type;
            set
            {
                _type = value;
                switch (_type)
                {
                    case ConsumerAgreementInitType.AddNewAgreement:
                        break;
                    case ConsumerAgreementInitType.ChangeAgreement:
                    {
                        rdtPickerDateEnd.DateTimePickerElement.Calendar.TodayButton.Enabled = false;
                        rdtPickerDateEnd.ReadOnly = true;
                    }
                        break;
                    case ConsumerAgreementInitType.Prolongation:
                    {
                        rdtPickerDateBegin.ReadOnly = true;
                        rdtPickerDateEnd.ReadOnly = true;
                        rdtPickerDateBegin.DateTimePickerElement.Calendar.TodayButton.Enabled = false;
                        rdtPickerDateEnd.DateTimePickerElement.Calendar.TodayButton.Enabled = false;
                    }
                        break;
                }
            }
        }

        //ContrNumber
        public ContractConsumerMainControl()
        {
            InitializeComponent();
            //rdtPickerAgrDate.Value = DateTime.Now;
            //rdtPickerDateBegin.Value = DateTime.Now;
            rdtPickerAgrDate.SetUserCalendarSettingsm();
            rdtPickerDateBegin.SetUserCalendarSettingsm();
            rdtPickerDateEnd.SetUserCalendarSettingsm();
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
            if(rdtPickerDateBegin.Value.AddDays(1) is DateTime newDate)
                rdtPickerDateEnd.MinDate =  new DateTime(newDate.Year, newDate.Month, newDate.Day);
        }

        /// <summary>
        /// Тип ліцензії
        /// </summary>
        public TypeRights AgreementLabelType
        {
            get => _rights;
            set
            {
                _rights = value;
                if(_rights == TypeRights.SmallRights)
                    lblContrNumb.Text = "ЛІЦЕНЗІЙНИЙ ДОГОВІР №";
                else if (_rights == TypeRights.BigRights)
                    lblContrNumb.Text = "ГЕНЕРАЛЬНИЙ ДОГОВІР №";
            }
        }
    }
}
