using ipsFormsDesign.Dictionary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace sysAdminwp.ComplexParamForms
{
    public partial class KLR030Params : Telerik.WinControls.UI.RadForm
    {
        //for send data to 'ComplexDictionaryControl'
        public event EventHandler KLR030Item;
        public KLR030Params(List<DictBaseTypeI> list)
        {
            InitializeComponent();
            //show data for dropDownList
            dictBaseTypeIBindingSource.DataSource = list;
        }

        //when select item into dropDownList
        private void ddlCountry_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            //interrupt if selected item is not exist
            if (e.Position == -1)
            {
                return;
            }
            //send value of the selected item
            KLR030Item?.Invoke(ddlCountry.Items[e.Position].Value, e);
        }
    }
}
