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

namespace IpsViewComponentLibrary.CommunityControls
{
    public partial class CommunityAddressControl : UserControl
    {
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
            get => ddlCountry.DataMember;
            set
            {
                    ddlCountry.DataBindings.Clear();
                    ddlCountry.DataBindings.Add("SelectedValue", bsAnketaCompany, value, true, DataSourceUpdateMode.OnPropertyChanged, 0);
            }
        }
        
        public string CityDataMember
        {
            get => txtCity.DataBindings["DataMember"]?.PropertyName;
            set
            {
                    txtCity.DataBindings.Clear();
                    txtCity.DataBindings.Add("Text", bsAnketaCompany, value, true, DataSourceUpdateMode.OnPropertyChanged, string.Empty);
            }
        }

        public string AddressDataMember
        {
            get => txtAddress.DataBindings["DataMember"]?.PropertyName;
            set
            {
                    txtAddress.DataBindings.Clear();
                    txtAddress.DataBindings.Add("Text", bsAnketaCompany, value, true, DataSourceUpdateMode.OnPropertyChanged, string.Empty);
            }
        }
    }
}
