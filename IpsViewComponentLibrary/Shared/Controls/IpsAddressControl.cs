using System.ComponentModel;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using IpsViewComponentLibrary.Utilities;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.Shared.Controls
{
    [ComplexBindingProperties("DataSource")]
    public partial class IpsAddressControl : UserControl
    {
        private readonly BindingSource _bindingSource;
        string _countryDataMember;
        string _regionDataMember;
        string _cityDataMember;
        string _addressDataMember;

        protected bool IsDesignMode => DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime;

        public IpsAddressControl()
        {
            InitializeComponent();

            _bindingSource = new BindingSource();

            if (!IsDesignMode)
            {
                ddlCountry.SetDataSource(IpsGlobal.AnketaDictionaties.country, "CountryCode", "CountryName");
                ddlRegion.SetDataSource(IpsGlobal.AnketaDictionaties.region);
            }
            
        }

        [Category("DataBinding")]
        [AttributeProvider(typeof(IListSource))]
        public object DataSource
        {
            get => _bindingSource.DataSource;
            set
            {
                if (_bindingSource.DataSource != value)
                    _bindingSource.DataSource = value;
            }
        }

        [Category("DataBinding")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        public string CountryDataMember
        {
            get => _countryDataMember;
            set
            {
                if (_countryDataMember != value)
                {
                    _countryDataMember = value;
                    ddlCountry.DataBindings.Clear();
                    ddlCountry.DataBindings.Add("SelectedValue", _bindingSource, _countryDataMember, true, DataSourceUpdateMode.OnPropertyChanged, 0);
                }
            }
        }

        [Category("DataBinding")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        public string RegionDataMember
        {
            get => _regionDataMember;
            set
            {
                if (_regionDataMember != value)
                {
                    _regionDataMember = value;
                    ddlRegion.DataBindings.Clear();
                    ddlRegion.DataBindings.Add("SelectedValue", _bindingSource, _regionDataMember, true, DataSourceUpdateMode.OnPropertyChanged, 0);
                }
            }
        }

        [Category("DataBinding")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        public string CityDataMember
        {
            get => _cityDataMember;
            set
            {
                if (_cityDataMember != value)
                {
                    _cityDataMember = value;
                    txtCity.DataBindings.Clear();
                    txtCity.DataBindings.Add("Text", _bindingSource, _cityDataMember, true, DataSourceUpdateMode.OnPropertyChanged, string.Empty);
                }
            }
        }

        [Category("DataBinding")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        public string AddressDataMember
        {
            get => _addressDataMember;
            set
            {
                if (_addressDataMember != value)
                {
                    _addressDataMember = value;
                    txtAddress.DataBindings.Clear();
                    txtAddress.DataBindings.Add("Text", _bindingSource, _addressDataMember, true, DataSourceUpdateMode.OnPropertyChanged, string.Empty);
                }
            }
        }

        public bool Validator()
        {
            bool isValid = true;

            //if (rtxtBoxAuthorPaymentPercent.Text == string.Empty)
            //{
            //    isValid = false;
            //    radLabel1.ForeColor = Color.FromArgb(180, 255, 0, 2); ;
            //}
            //else
            //    radLabel1.ForeColor = Color.Black;

            return isValid;
        }
    }
}
