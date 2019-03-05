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
    public partial class CopyRightKindParamsForm : Telerik.WinControls.UI.RadForm
    {
        //for send data to 'ComplexDictionaryControl'
        public event EventHandler CopyRightKindItem;
        public CopyRightKindParamsForm(List<DictBaseTypeI> list)
        {
            InitializeComponent();
            //show data for dropDownList
            dictBaseTypeIBindingSource.DataSource = list;
        }

        //when select item into dropDownList
        private void ddlCrkindGroup_SelectedIndexChanged(object sender, Telerik.WinControls.UI.Data.PositionChangedEventArgs e)
        {
            //interrupt if selected item is not exist
            if (e.Position == -1)
            {
                return;
            }
            //send value of the selected item
            CopyRightKindItem?.Invoke(ddlCrkindGroup.Items[e.Position].Value, e);
        }
    }
}
