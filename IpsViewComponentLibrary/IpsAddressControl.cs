using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary
{
    [ComplexBindingProperties("DataSource", "DataMember")]
    public partial class IpsAddressControl : UserControl
    {
        BindingSource _bindingSource;
        string _countryDataMember;
        string _regionDataMember;
        string _cityDataMember;
        string _addressDataMember;

        public IpsAddressControl()
        {
            InitializeComponent();

            _bindingSource = new BindingSource();
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

        #region Country dictionary

        [Category("Dictionaries")]
        [AttributeProvider(typeof(IListSource))]
        public object CountriesDataSource
        {
            get { return ddlCountry.DataSource; }
            set
            {
                if (ddlCountry.DataSource != value)
                    ddlCountry.DataSource = value;
            }
        }

        [Category("Dictionaries")]
        public string CountriesDataMember
        {
            get { return ddlCountry.DataMember; }
            set { ddlCountry.DataMember = value; }
        }

        [Category("Dictionaries")]
        public string CountriesDisplayMember
        {
            get { return ddlCountry.DisplayMember; }
            set { ddlCountry.DisplayMember = value; }
        }

        [Category("Dictionaries")]
        public string CountriesValueMember
        {
            get { return ddlCountry.ValueMember; }
            set { ddlCountry.ValueMember = value; }
        }

        #endregion

        #region Region dictionary

        [Category("Dictionaries")]
        [AttributeProvider(typeof(IListSource))]
        public object RegionsDataSource
        {
            get { return ddlRegion.DataSource; }
            set
            {
                if (ddlRegion.DataSource != value)
                    ddlRegion.DataSource = value;
            }
        }

        [Category("Dictionaries")]
        public string RegionsDataMember
        {
            get { return ddlRegion.DataMember; }
            set { ddlRegion.DataMember = value; }
        }

        [Category("Dictionaries")]
        public string RegionsDisplayMember
        {
            get { return ddlRegion.DisplayMember; }
            set { ddlRegion.DisplayMember = value; }
        }

        [Category("Dictionaries")]
        public string RegionsValueMember
        {
            get { return ddlRegion.ValueMember; }
            set { ddlRegion.ValueMember = value; }
        }

        #endregion

        #region Edit controls

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RadDropDownList DdlCountry
        {
            get
            {
                return ddlCountry;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RadDropDownList DdlRegion
        {
            get
            {
                return ddlRegion;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RadTextBox TxtCity
        {
            get
            {
                return txtCity;
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
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
    }
}
