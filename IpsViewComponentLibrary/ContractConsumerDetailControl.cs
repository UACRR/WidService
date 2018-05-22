using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IpsViewComponentLibrary
{
    public partial class ContractConsumerDetailControl : UserControl
    {
        public object DataSource
        {
            get;
            set;
        }

        public ContractConsumerDetailControl()
        {
            InitializeComponent();
            rddListTypeAutoProl.Enabled = false;
            rtxtboxPercentAutoProl.Enabled = false;
        }

        private void rCheckBoxAutoprolongation_CheckStateChanged(object sender, EventArgs e)
        {
            if (rCheckBoxAutoprolongation.Checked)
            {
                rddListTypeAutoProl.Enabled = true;
                rtxtboxPercentAutoProl.Enabled = true;
            }
            else
            {
                rtxtboxPercentAutoProl.Clear();
                rddListTypeAutoProl.SelectedItem = rddListTypeAutoProl.Items[0];
                rddListTypeAutoProl.Enabled = false;
                rtxtboxPercentAutoProl.Enabled = false;
            }
        }
    }
}
