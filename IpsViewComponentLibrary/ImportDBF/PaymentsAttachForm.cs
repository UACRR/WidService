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
using ipsFormsDesign.Model.SQLViewsData;
using IpsViewComponentLibrary.Extensions;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.ImportDBF
{
    public partial class PaymentsAttachForm : RadForm
    {
        private readonly ExternalPay _externalPay;

        public PaymentsAttachForm(List<vCustomer> clintList, ExternalPay externalPay)
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            StartPosition = FormStartPosition.CenterScreen;

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
            if (!(gvCustomers.CurrentRow.DataBoundItem is vCustomer item))
                return;
            
            string textMsg = $"Прив'язаи платіж до обраного користувача \"{item.Name}\", ЄДРПОУ: {item.INNOKPO}?";
            if (MessageShow.ConfirmAction(textMsg) == DialogResult.Yes)
            {
                _externalPay.CustId = item.CustId;
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
