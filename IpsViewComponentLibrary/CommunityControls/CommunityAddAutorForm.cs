using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign.Interfaces;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.CommunityControls
{
    public partial class CommunityAddAutorForm : Telerik.WinControls.UI.RadForm
    {

        public CommunityAddAutorForm(List<CommunityAutorsListView> autorList)
        {
            InitializeComponent();
            ctrlSearch.SetUsageGrid(gvViewAutors);
            gvViewAutors.DataSource = autorList;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }
    }
}
