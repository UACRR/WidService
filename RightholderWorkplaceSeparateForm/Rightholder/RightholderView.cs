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
    public partial class RightholderView : Telerik.WinControls.UI.RadForm
    {
        public RightholderView()
        {
            InitializeComponent();
        }

        private void RightholderView_Load(object sender, EventArgs e)
        {
            var rightholderListView = new RightholderListView();
            rightholderListView.TopLevel = false;
            rightholderListView.Dock = DockStyle.Fill;
            rightholderListView.Show();

            mainPanel.Controls.Clear();
            mainPanel.Controls.Add(rightholderListView);
        }
    }
}
