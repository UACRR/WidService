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
using ipsmedserviceapp.Model.SQLViewsData;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.ImportDBF
{
    public partial class PaymentsAttachForm : RadForm
    {
        private const string CaptionMsg = "Підтвердження";
        private ExternalPay _externalPay;

        public PaymentsAttachForm(List<vCustomer> clintList, ExternalPay externalPay)
        {
            InitializeComponent();
            ctrlSearch.SetUsageGrid(gvCustomers);
            _externalPay = externalPay;
            txtIpnokpo.Text = _externalPay.OkpoCorr;
            txtName.Text = _externalPay.NameCorr;
            txtDestinationPay.Text = _externalPay.Nplat;
            gvCustomers.DataSource = clintList;
            btnAttach.Enabled = clintList.Any();
        }

        private void AttachPay()
        {
            var row = gvCustomers.CurrentRow.DataBoundItem as vCustomer;
            string textMsg = $"Прив'язаи платіж до обраного клієнта \"{row.Name}\", ЄДРПОУ: {row.INNOKPO}?";
            if (MessageBox.Show(textMsg, CaptionMsg, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _externalPay.CustId = row.CustId;
                DialogResult = DialogResult.OK;
            }
        }

        private void btnAttach_Click(object sender, EventArgs e)
        {
            AttachPay();
        }

        private void gvCustomers_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            AttachPay();
        }
    }
}
