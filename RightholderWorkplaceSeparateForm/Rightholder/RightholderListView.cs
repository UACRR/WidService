using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;

namespace RightholderWorkplaceSeparateForm.Rightholder
{
    public partial class RightholderListView : Telerik.WinControls.UI.RadForm
    {
        public RightholderListView()
        {
            InitializeComponent();
        }

        private void miAddRightholderPerson_Click(object sender, EventArgs e)
        {
            var rightholderItemView = new RightholderItemView();
            rightholderItemView.TopLevel = false;
            rightholderItemView.Dock = DockStyle.Fill;
        }
    }
}
