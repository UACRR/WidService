using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Interfaces;
using IpsViewComponentLibrary.Utilities;
using Telerik.WinControls;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.CommunityControls
{
    public partial class CommunityAddAutorForm : Telerik.WinControls.UI.RadForm
    {
        protected bool IsDesignMode => DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime; 
        

        public CommunityAddAutorForm(List<CommunityAutorsListView> autorList)
        {
            InitializeComponent();
            ctrlSearch.SetUsageGrid(gvViewAutors);
            gvViewAutors.DataSource = autorList;
            if (!IsDesignMode)
                gvRightLimitations.DataSource = IpsGlobal.AnketaDictionaties.copyrightKind;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void gvViewAutors_CurrentRowChanged(object sender, CurrentRowChangedEventArgs e)
        {
            if (e?.CurrentRow?.DataBoundItem is CommunityAutorsListView item)
            {
                gvRightLimitations.DataSource = IpsGlobal.AnketaDictionaties.copyrightKind;
            }
            else
                gvRightLimitations.DataSource = null;
        }
    }

    public class RightLimitationsView
    {

    }
}
