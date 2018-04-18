using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace sysAdminwp
{
    public partial class DataEditControl : UserControl
    {
        public DataEditControl()
        {
            InitializeComponent();
            rBtnAdd.Click += RBtnAdd_Click;
        }

        private void RBtnAdd_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Клац клац");
        }

        public RadTreeView TreeSourse { get; set; }

        public void UpdateData()
        {
            MessageBox.Show("Update!");
            
        }
        
    }
}
