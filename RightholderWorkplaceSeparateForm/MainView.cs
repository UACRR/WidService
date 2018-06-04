using RightholderWorkplaceSeparateForm.Rightholder;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace RightholderWorkplaceSeparateForm
{
    public partial class MainView : Telerik.WinControls.UI.RadForm
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void MainView_Load(object sender, EventArgs e)
        {
            var rightholderView = new RightholderView();
            rightholderView.TopLevel = false;
            rightholderView.Dock = DockStyle.Fill;
            rightholderView.Show();

            rightholderPanel.Controls.Clear();
            rightholderPanel.Controls.Add(rightholderView);
        }
    }
}
