using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.Common.Enums;
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
        private AgreementModifyType _agreementModifyType = AgreementModifyType.CreateNewAgreement;
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
            dtAgreementDate.SetUserCalendarSettingsm();
            dtDateBegin.SetUserCalendarSettingsm();
            dtDateEnd.SetUserCalendarSettingsm();
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
                    txtAgreementNumber.DataBindings.Clear();
                    dtAgreementDate.DataBindings.Clear();
                    dtDateBegin.DataBindings.Clear();
                    dtDateEnd.DataBindings.Clear();

                    bsLicenseAgrParam.DataSource = value;

                    txtAgreementNumber.DataBindings.Add(new Binding("Text", bsLicenseAgrParam, "LicNum", true,
                        DataSourceUpdateMode.OnPropertyChanged, string.Empty));
                    dtAgreementDate.DataBindings.Add(new Binding("Value", bsLicenseAgrParam, "LicDate", true,
                        DataSourceUpdateMode.OnPropertyChanged));
                    dtDateBegin.DataBindings.Add(new Binding("Value", bsLicenseAgrParam, "DateBegin", true,
                        DataSourceUpdateMode.OnPropertyChanged));
                    dtDateEnd.DataBindings.Add(new Binding("Value", bsLicenseAgrParam, "DateEnd", true,
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
                txtAgreementNumber.DataBindings.Clear();
                dtAgreementDate.DataBindings.Clear();
                dtDateBegin.DataBindings.Clear();
                dtDateEnd.DataBindings.Clear();

                bsAgreementAddRh.DataSource = value;

                txtAgreementNumber.DataBindings.Add(new Binding("Text", bsAgreementAddRh, "AgrNumber", true,
                    DataSourceUpdateMode.OnPropertyChanged, string.Empty));
                dtAgreementDate.DataBindings.Add(new Binding("Value", bsAgreementAddRh, "AgrDate", true,
                    DataSourceUpdateMode.OnPropertyChanged));
                dtDateBegin.DataBindings.Add(new Binding("Value", bsAgreementAddRh, "DateBegin", true,
                    DataSourceUpdateMode.OnPropertyChanged));
                dtDateEnd.DataBindings.Add(new Binding("Value", bsAgreementAddRh, "DateEnd", true,
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
                    dtDateEnd.NullDate = value;

                    // update binding
                    dtDateEnd.DataBindings.Clear();
                    dtDateEnd.DataBindings.Add("Value", bsLicenseAgrParam, _dateEndDataMember, true, DataSourceUpdateMode.OnPropertyChanged, _dateEndNullDate);
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
                    dtDateEnd.NullText = value;
                }
            }
        }

        public AgreementModifyType DateTimeType
        {
            get => _agreementModifyType;
            set
            {
                _agreementModifyType = value;
                switch (_agreementModifyType)
                {
                    //case ConsumerAgreementInitType.AddNewAgreement:
                    case AgreementModifyType.CreateNewAgreement:
                        break;
                    //case ConsumerAgreementInitType.ChangeAgreement: 
                    case AgreementModifyType.CreateAgreementVersion:
                    case AgreementModifyType.CreateAgreementProlongation:
                        dtDateEnd.DateTimePickerElement.Calendar.TodayButton.Enabled = false;
                        dtDateEnd.ReadOnly = true;
                        break;
                    //case ConsumerAgreementInitType.Prolongation:
                    case AgreementModifyType.EditAgreementProlongation:
                        dtDateBegin.ReadOnly = true;
                        dtDateBegin.DateTimePickerElement.Calendar.TodayButton.Enabled = false;
                        dtDateEnd.ReadOnly = true;
                        dtDateEnd.DateTimePickerElement.Calendar.TodayButton.Enabled = false;
                        break;
                }
            }
        }

        public bool Validator()
        {
            bool isValid = true;

            if (txtAgreementNumber.Text == string.Empty)
            {
                lblContrNumb.ForeColor = Color.FromArgb(180, 255, 0, 2);
                isValid = false;
            }
            else
                lblContrNumb.ForeColor = Color.Black;

            return isValid;
        }

        private void dtDateBegin_Leave(object sender, EventArgs e)
        {
            if (dtDateBegin.Value >= MaxBeginDateTime)
            {
                MessageShow.ShowWarning(MaxDateBeginWarning);
                dtDateBegin.Value = DateTime.Today;
            }

            if(dtDateBegin.Value.AddDays(1) is DateTime newDate)
                dtDateEnd.MinDate = new DateTime(newDate.Year, newDate.Month, newDate.Day);
        }
    }
}
