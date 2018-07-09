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
            radTextBoxAuto1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            radTextBoxAuto1.TextChanged += radTextBoxAuto1_TextChanged;


        }

        private void radTextBoxAuto1_TextChanged(object sender, EventArgs e)
        {
            if (radTextBoxAuto1.Text.Length >= 1 && radTextBoxAuto1.AutoCompleteItems.Count == 0)
            {
                var dataSource = new List<RadListDataItem>();
                dataSource.AddRange(new[]             {
                    new RadListDataItem("Luke", 1 ),
                    new RadListDataItem("Max", 2),
                    new RadListDataItem("Adam 1", 3),
                    new RadListDataItem("Adam 2", 4),
                    new RadListDataItem("Adam 3", 5),
                    new RadListDataItem("Henry", 6),
                    new RadListDataItem("Jack", 7),
                    new RadListDataItem("Ben", 8),
                    new RadListDataItem("Tyler", 9),
                    new RadListDataItem("Ethan", 10),
                    new RadListDataItem("David", 11),
                    new RadListDataItem("Mike", 12)}
                    );

                // RadListDataItem test = null;

                radTextBoxAuto1.AutoCompleteDataSource = dataSource;
                radTextBoxAuto1.AutoCompleteDisplayMember = "DisplayValue";

            }



        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            if (radTextBoxAuto1.isKeyDownEnterOrTab == true)
                DialogResult = DialogResult.None;
            else
                DialogResult = DialogResult.OK;

            radTextBoxAuto1.isKeyDownEnterOrTab = false;
        }
    }

}