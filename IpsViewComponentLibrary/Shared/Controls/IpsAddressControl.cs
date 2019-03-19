using System.ComponentModel;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using IpsViewComponentLibrary.Utilities;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.Shared.Controls
{
    [ComplexBindingProperties("DataSource", "DataMember")]
    public partial class IpsAddressControl : UserControl
    {
        BindingSource _bindingSource;
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

        [Category("Data")]
        [AttributeProvider(typeof(IListSource))]
        public object DataSource
        {
            get { return _bindingSource.DataSource; }
            set
            {
                if (_bindingSource.DataSource != value)
                    _bindingSource.DataSource = value;
            }
        }

        [Category("Data")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        public string DataMember
        {
            get { return _bindingSource.DataMember; }
            set { _bindingSource.DataMember = value; }
        }

        [Category("Data")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        public string CountryDataMember
        {
            get { return _countryDataMember; }
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

        [Category("Data")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        public string RegionDataMember
        {
            get { return _regionDataMember; }
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

        [Category("Data")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        public string CityDataMember
        {
            get { return _cityDataMember; }
            set
            {
                if (_cityDataMember != value)
                {
                    _cityDataMember = value;
                    txtCity.DataBindings.Clear();
                    txtCity.DataBindings.Add("Text", _bindingSource, _cityDataMember);
                }
            }
        }

        [Category("Data")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        public string AddressDataMember
        {
            get { return _addressDataMember; }
            set
            {
                if (_addressDataMember != value)
                {
                    _addressDataMember = value;
                    txtAddress.DataBindings.Clear();
                    txtAddress.DataBindings.Add("Text", _bindingSource, _addressDataMember);
                }
            }
        }

        #region Edit controls


        public RadDropDownList DdlCountry
        {
            get
            {
                return ddlCountry;
            }
        }

        public RadDropDownList DdlRegion
        {
            get
            {
                return ddlRegion;
            }
        }

        public RadTextBox TxtCity
        {
            get
            {
                return txtCity;
            }
        }

        public RadTextBox TxtAddress
        {
            get
            {
                return txtAddress;
            }
        }


        #endregion

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

        internal void SetDefaultState()
        {
            if (ddlCountry.Items.Count != 0)
            {
                ddlCountry.SelectedIndex = ddlCountry.Items.Last.Index;
                ddlCountry.SelectedIndex = ddlCountry.Items.First.Index;
            }
            if (ddlRegion.Items.Count != 0)
            {
                ddlRegion.SelectedIndex = ddlRegion.Items.Last.Index;
                ddlRegion.SelectedIndex = ddlRegion.Items.First.Index;
            }
        }
    }
}
