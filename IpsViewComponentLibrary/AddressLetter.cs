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

namespace IpsViewComponentLibrary
{
    [ComplexBindingProperties("DataSource", "DataMember")]
    public partial class AddressLetter : UserControl
    {

        BindingSource _bindingSource;
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

        [Category("Data")]
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

        [Category("Data")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        public string DataMember
        {
            get => _bindingSource.DataMember;
            set => _bindingSource.DataMember = value;
        }

        [Category("Data")]
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

        [Category("Data")]
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

        [Category("Data")]
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
                    txtCity.DataBindings.Add("Text", _bindingSource, _cityDataMember);
                }
            }
        }

        [Category("Data")]
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
                    txtAddress.DataBindings.Add("Text", _bindingSource, _addressDataMember);
                }
            }
        }

        [Category("Data")]
        [Editor("System.Windows.Forms.Design.DataMemberFieldEditor, System.Design", "System.Drawing.Design.UITypeEditor, System.Drawing")]
        public string PostIndexDataMember
        {
            get => _addressDataMember;
            set
            {
                if (_postIndexDataMember != value)
                {
                    _postIndexDataMember = value;
                    txtPostIndex.DataBindings.Clear();
                    txtPostIndex.DataBindings.Add("Text", _bindingSource, _postIndexDataMember);
                }
            }
        }

        #region Country dictionary

        [Category("Dictionaries")]
        [AttributeProvider(typeof(IListSource))]
        public object CountriesDataSource
        {
            get => ddlCountry.DataSource;
            set
            {
                if (ddlCountry.DataSource != value)
                    ddlCountry.DataSource = value;
            }
        }

        [Category("Dictionaries")]
        public string CountriesDataMember
        {
            get => ddlCountry.DataMember;
            set => ddlCountry.DataMember = value;
        }

        [Category("Dictionaries")]
        public string CountriesDisplayMember
        {
            get => ddlCountry.DisplayMember;
            set => ddlCountry.DisplayMember = value;
        }

        [Category("Dictionaries")]
        public string CountriesValueMember
        {
            get => ddlCountry.ValueMember;
            set => ddlCountry.ValueMember = value;
        }

        #endregion

        #region Region dictionary

        [Category("Dictionaries")]
        [AttributeProvider(typeof(IListSource))]
        public object RegionsDataSource
        {
            get => ddlRegion.DataSource;
            set
            {
                if (ddlRegion.DataSource != value)
                    ddlRegion.DataSource = value;
            }
        }

        [Category("Dictionaries")]
        public string RegionsDataMember
        {
            get => ddlRegion.DataMember;
            set => ddlRegion.DataMember = value;
        }

        [Category("Dictionaries")]
        public string RegionsDisplayMember
        {
            get => ddlRegion.DisplayMember;
            set => ddlRegion.DisplayMember = value;
        }

        [Category("Dictionaries")]
        public string RegionsValueMember
        {
            get => ddlRegion.ValueMember;
            set => ddlRegion.ValueMember = value;
        }

        #endregion

        #region Edit controls

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RadDropDownList DdlCountry => ddlCountry;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RadDropDownList DdlRegion => ddlRegion;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RadTextBox TxtCity => txtCity;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RadTextBox TxtAddress => txtAddress;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RadTextBox TxtPostIndex => txtPostIndex;

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
                ddlRegion.SelectedIndex = ddlCountry.Items.Last.Index;
                ddlRegion.SelectedIndex = ddlCountry.Items.First.Index;
            }
        }
    }
}
