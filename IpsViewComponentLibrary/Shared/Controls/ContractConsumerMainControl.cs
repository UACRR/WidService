using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.Extensions;

namespace IpsViewComponentLibrary.Shared.Controls
{
    public partial class ContractConsumerMainControl : UserControl
    {
        private const string MaxDateBeginWarning = "Перевищено максимальне значення дати \"від\"!";
        private readonly DateTime MaxBeginDateTime = new DateTime(2999, 12, 31);

        private string _dateEndDataMember = "";
        private string _agreemnentName = "";
        private DateTime _dateEndNullDate = new DateTime(1,1,1);
        private string _dateEndNullText = "";
        private ConsumerAgreementInitType _type = ConsumerAgreementInitType.None;
        private TypeRights _rights = TypeRights.SmallRights;

        /// <summary>
        /// Тип ліцензії
        /// </summary>
        [Browsable(true)]
        public TypeRights AgreementLabelType
        {
            get => _rights;
            set
            {
                _rights = value;
                if (_rights == TypeRights.SmallRights)
                    lblContrNumb.Text = "ЛІЦЕНЗІЙНИЙ ДОГОВІР №";
                else if (_rights == TypeRights.BigRights)
                    lblContrNumb.Text = "ЛІЦЕНЗІЯ №";
            }
        }

        public ContractConsumerMainControl()
        {
            InitializeComponent();
            rdtPickerAgrDate.SetUserCalendarSettingsm();
            dtDateBegin.SetUserCalendarSettingsm();
            rdtPickerDateEnd.SetUserCalendarSettingsm();
        }

        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        [DefaultValue(typeof(LicenseAgrParam))]
        public object DataSource
        {
            get => bsLicenseAgrParam.DataSource;
            set
            {
                if(value is LicenseAgrParam)
                {
                    rtxtBoxContrNumber.DataBindings.Clear();
                    rdtPickerAgrDate.DataBindings.Clear();
                    dtDateBegin.DataBindings.Clear();
                    rdtPickerDateEnd.DataBindings.Clear();

                    bsLicenseAgrParam.DataSource = value;

                    rtxtBoxContrNumber.DataBindings.Add(new Binding("Text", bsLicenseAgrParam, "LicNum", true,
                        DataSourceUpdateMode.OnPropertyChanged, string.Empty));
                    rdtPickerAgrDate.DataBindings.Add(new Binding("Value", bsLicenseAgrParam, "LicDate", true,
                        DataSourceUpdateMode.OnPropertyChanged));
                    dtDateBegin.DataBindings.Add(new Binding("Value", bsLicenseAgrParam, "DateBegin", true,
                        DataSourceUpdateMode.OnPropertyChanged));
                    rdtPickerDateEnd.DataBindings.Add(new Binding("Value", bsLicenseAgrParam, "DateEnd", true,
                        DataSourceUpdateMode.OnPropertyChanged));
                }
            }
        }

        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        [DefaultValue(typeof(AgreementAddRh))]
        public object DataSourceRh
        {
            get => bsAgreementAddRh.DataSource;
            set
            {
                rtxtBoxContrNumber.DataBindings.Clear();
                rdtPickerAgrDate.DataBindings.Clear();
                dtDateBegin.DataBindings.Clear();
                rdtPickerDateEnd.DataBindings.Clear();

                bsAgreementAddRh.DataSource = value;

                rtxtBoxContrNumber.DataBindings.Add(new Binding("Text", bsAgreementAddRh, "AgrNumber", true,
                    DataSourceUpdateMode.OnPropertyChanged, string.Empty));
                rdtPickerAgrDate.DataBindings.Add(new Binding("Value", bsAgreementAddRh, "AgrDate", true,
                    DataSourceUpdateMode.OnPropertyChanged));
                dtDateBegin.DataBindings.Add(new Binding("Value", bsAgreementAddRh, "DateBegin", true,
                    DataSourceUpdateMode.OnPropertyChanged));
                rdtPickerDateEnd.DataBindings.Add(new Binding("Value", bsAgreementAddRh, "DateEnd", true,
                    DataSourceUpdateMode.OnPropertyChanged));
            }
        }

        [Browsable(true)]
        public string AgreementName
        {
            get => _agreemnentName;
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
            get => _dateEndNullDate;
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
            get => _dateEndNullText;
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
                        dtDateBegin.ReadOnly = true;
                        rdtPickerDateEnd.ReadOnly = true;
                        dtDateBegin.DateTimePickerElement.Calendar.TodayButton.Enabled = false;
                        rdtPickerDateEnd.DateTimePickerElement.Calendar.TodayButton.Enabled = false;
                    }
                        break;
                }
            }
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

        private void dtDateBegin_ValueChanged(object sender, EventArgs e)
        {
            if (dtDateBegin.Value >= MaxBeginDateTime)
            {
                MessageShow.ShowWarning(MaxDateBeginWarning);
                dtDateBegin.Value = DateTime.Today;
            }

            if(dtDateBegin.Value.AddDays(1) is DateTime newDate)
                rdtPickerDateEnd.MinDate = new DateTime(newDate.Year, newDate.Month, newDate.Day);
        }
    }
}
