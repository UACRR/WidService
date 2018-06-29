using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace UnitTestMediaPortal
{
    public partial class TestTextBoxAuto : Telerik.WinControls.UI.RadForm
    {
        internal void fireAuto(RadListDataItem element)
        {
            radLabel1.Text = element.Text;
        }


        public TestTextBoxAuto()
        {
            InitializeComponent();
            radTextBoxAuto1.AcceptAuto = fireAuto;
            radTextBoxAuto1.AutoCompleteMode = AutoCompleteMode.Suggest;
            radTextBoxAuto1.TextChanged += radTextBoxAuto1_TextChanged; 


        }

        private void radTextBoxAuto1_TextChanged(object sender, EventArgs e)
        {
            if (radTextBoxAuto1.Text.Length >= 2 && radTextBoxAuto1.AutoCompleteItems.Count == 0)
            {
                RadListDataItemCollection autoCompleteItems = this.radTextBoxAuto1.AutoCompleteItems;
                autoCompleteItems.Add(new RadListDataItem("Luke", 1));
                autoCompleteItems.Add(new RadListDataItem("Max", 2));
                autoCompleteItems.Add(new RadListDataItem("Adam 1",3));
                autoCompleteItems.Add(new RadListDataItem("Adam 2",4));
                autoCompleteItems.Add(new RadListDataItem("Adam 3",5));
                autoCompleteItems.Add(new RadListDataItem("Henry",6));
                autoCompleteItems.Add(new RadListDataItem("Jack",7));
                autoCompleteItems.Add(new RadListDataItem("Ben",8));
                autoCompleteItems.Add(new RadListDataItem("Tyler",9));
                autoCompleteItems.Add(new RadListDataItem("Ethan",10));
                autoCompleteItems.Add(new RadListDataItem("David",11));
                autoCompleteItems.Add(new RadListDataItem("Mike",12));
            };
        }
    }
}
