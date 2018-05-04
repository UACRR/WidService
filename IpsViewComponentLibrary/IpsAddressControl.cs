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
    public partial class IpsAddressControl : UserControl
    {
        /// <summary>
        /// Підключення до обїекту анкети
        /// </summary>
        /// <param name="value"></param>
        private void setDataSource( object value )
        {
            radDropDownList1.ValueMember = value.GetType().GetProperty(CountryCodeFieldName).GetValue(value, null).ToString();
            radDropDownList2.ValueMember = value.GetType().GetProperty(CityCodeFieldName).GetValue(value, null).ToString();

        }
        [Bindable(true)]
        public string AddressField { get; set; }
        [Bindable(true)]
        public string CountryCodeFieldName { get; set; }
        [Bindable(true)]
        public string CityCodeFieldName { get; set; }
        private object _dataSource;
        [Bindable(true)]
        public object DataSource { get { return _dataSource; }
                                   set {  }
                                 }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RadDropDownList radDropDownListCountry
        {
            get
            {
                return radDropDownList1;
            }
        }
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public RadDropDownList radDropDownListCity
        {
            get
            {
                return radDropDownList2;
            }
        }


        public IpsAddressControl()
        {
            InitializeComponent();
        }
    }
}
