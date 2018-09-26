using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Interfaces;

namespace IpsViewComponentLibrary.CommunityControls
{
    public partial class CommunityControl : UserControl
    {
        public event ReturnViewEventHandler<CommunytiListView> SetCommunityList;
        public CommunityControl()
        {
            InitializeComponent();
            ctrlSearch.SetUsageGrid(gvViewPartners);
            Load += CommunityControlLoad;
        }

        private void CommunityControlLoad(object sender, EventArgs e)
        {
            gvViewPartners.DataSource = SetCommunityList?.Invoke(-1);
        }

        private void btnAddCommunity_Click(object sender, EventArgs e)
        {

        }

        private void gvViewPartners_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            // load cabinet
        }
    }
}
