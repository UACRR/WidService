using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IpsViewComponentLibrary.CommunityControls
{
    public partial class CommunityAutorsControl : UserControl
    {
        public CommunityAutorsControl()
        {
            InitializeComponent();
            ctrlSearch.SetUsageGrid(gvViewAutors);
        }

        private void btnAddAutor_Click(object sender, EventArgs e)
        {

        }
    }
}
