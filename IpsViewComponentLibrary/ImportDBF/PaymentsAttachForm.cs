using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.ImportDBF
{
    public partial class PaymentsAttachForm : RadForm
    {
        public PaymentsAttachForm(string[] data)
        {
            InitializeComponent();
            txtIpnokpo.Text = data[0];
            txtName.Text = data[1];
            txtDestinationPay.Text = data[2];
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {

        }
    }
}
