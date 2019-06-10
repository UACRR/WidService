using System.ComponentModel;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using IpsViewComponentLibrary.Utilities;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.Shared.Controls
{
    [ComplexBindingProperties("DataSource")]
    public partial class AddressLetter : UserControl
    {
        private readonly BindingSource _bindingSource;
        private string _countryDataMember;
        private string _regionDataMember;
        private string _cityDataMember;
        private string _addressDataMember;
        private string _postIndexDataMember;

        public AddressLetter()
        {
            InitializeComponent();

            _bindingSource = new BindingSource();

            if (IpsGlobal.AnketaDictionaties != null)
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
                    ddlCountry.DataBindings.Add("SelectedValue", _bindingSource, _countryDataMember, true, DataSourceUpdateMode.OnPropertyChanged);
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
                    ddlRegion.DataBindings.Add("SelectedValue", _bindingSource, _regionDataMember, true, DataSourceUpdateMode.OnPropertyChanged);
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
                    txtCity.DataBindings.Add("Text", _bindingSource, _cityDataMember, true, DataSourceUpdateMode.OnPropertyChanged);
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
                    txtAddress.DataBindings.Add("Text", _bindingSource, _addressDataMember, true, DataSourceUpdateMode.OnPropertyChanged);
                }
            }
        }

        [Category("DataBinding")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        public string PostIndexDataMember
        {
            get => _postIndexDataMember;
            set
            {
                if (_postIndexDataMember != value)
                {
                    _postIndexDataMember = value;
                    txtPostIndex.DataBindings.Clear();
                    txtPostIndex.DataBindings.Add("Text", _bindingSource, _postIndexDataMember, true, DataSourceUpdateMode.OnPropertyChanged);
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
