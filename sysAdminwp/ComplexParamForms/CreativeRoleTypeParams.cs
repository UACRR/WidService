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
    public partial class CreativeRoleTypeParams : Telerik.WinControls.UI.RadForm
    {
        //for send data to 'ComplexDictionaryControl'
        public event EventHandler CreativeRoleTypeItem;
        public CreativeRoleTypeParams(List<DictBaseTypeI> list)
        {
            InitializeComponent();
            //show data for dropDownList
            dictBaseTypeIBindingSource.DataSource = list;
        }

        //when select item into dropDownList
        private void ddlCategory_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            //interrupt if selected item is not exist
            if (e.Position == -1)
            {
                return;
            }
            //send value of the selected item
            CreativeRoleTypeItem?.Invoke(ddlCategory.Items[e.Position].Value, e);

        }
    }
}
