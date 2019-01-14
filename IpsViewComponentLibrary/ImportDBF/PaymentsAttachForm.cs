using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Model;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.ImportDBF
{
    public partial class PaymentsAttachForm : RadForm
    {
        public PaymentsAttachForm(ExternalPay externalPay)
        {
            InitializeComponent();
            txtIpnokpo.Text = externalPay.OkpoCorr;
            txtName.Text = externalPay.NameCorr;
            txtDestinationPay.Text = externalPay.Nplat;
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            //gvCustomers.CurrentRow.DataBoundItem
        }
    }
}
