using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using IpsViewComponentLibrary.Utilities;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.CommunityControls
{
    public partial class CommunityAddressControl : UserControl
    {
        private string _cityMember = string.Empty;
        private string _addressMember = string.Empty;
        private string _countryMember = string.Empty;

        protected bool IsDesignMode => DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime;

        public CommunityAddressControl()
        {
            InitializeComponent();
            if (!IsDesignMode)
                ddlCountry.SetDataSource(IpsGlobal.AnketaDictionaties.country, "CountryCode", "CountryName");
        }
        
        public object AnketaCompanyDataSource
        {
            get => bsAnketaCompany.DataSource;
            set => bsAnketaCompany.DataSource = value;
        }

        public string CountryDataMember
        {
            get => _countryMember;
            set
            {
                _countryMember = value;
                ddlCountry.DataBindings.Clear();
                ddlCountry.DataBindings.Add("SelectedValue", bsAnketaCompany, _countryMember, true, DataSourceUpdateMode.OnPropertyChanged, 0);
            }
        }
        
        public string CityDataMember
        {
            get => _cityMember;
            set
            {
                _cityMember = value;
                txtCity.DataBindings.Clear();
                txtCity.DataBindings.Add("Text", bsAnketaCompany, _cityMember, true, DataSourceUpdateMode.OnPropertyChanged, string.Empty);
            }
        }

        public string AddressDataMember
        {
            get => _addressMember;
            set
            {
                _addressMember = value;
                txtAddress.DataBindings.Clear();
                txtAddress.DataBindings.Add("Text", bsAnketaCompany, _addressMember, true, DataSourceUpdateMode.OnPropertyChanged, string.Empty);
            }
        }

        public RadDropDownList DdlCountry => ddlCountry;
        public RadTextBox TxtCity => txtCity;
        public RadTextBox TxtAddress => txtAddress;
    }
}
