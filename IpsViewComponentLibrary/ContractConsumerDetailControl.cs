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

        public bool Validator()
        {
            bool isValid = true;

            if (rtxtBoxAuthorPaymentPercent.Text == string.Empty)
            {
                isValid = false;
                radLabel1.ForeColor = Color.FromArgb(180, 255, 0, 2); ;
            }
            else
                radLabel1.ForeColor = Color.Black;

            if (rtxtBoxMinAuthorPayment.Text == string.Empty)
            {
                isValid = false;
                radLabel2.ForeColor = Color.FromArgb(180, 255, 0, 2); ;
            }
            else
                radLabel2.ForeColor = Color.Black;


            return isValid;
        }
    }
}
