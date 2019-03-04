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
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.ConsumerDialogForms;

namespace IpsViewComponentLibrary.PartnerControls
{
    public partial class PartnerClientsControl : UserControl
    {
        public event SetPartnerEventHandler OnAddClientToPartner;
        public event SetPartnerEventHandler OnDetachClientInPartner;
        public event ReturnViewEventHandler<PartnerAllFreeClientsView> GetFreeClientList;
        public event EventHandler UpdateData;


        private int _partnerId = default(int);
        public PartnerClientsControl()
        {
            InitializeComponent();
            ctrlSearch.SetUsageGrid(gvViewClientsOfPartner);
        }

        public void SetData(List<PartnerClientListView> list)
        {
            gvViewClientsOfPartner.DataSource = list;
        }

        public object ClientName
        {
            get => lblPartnerName.Text;
            set
            {
                if (value is AnketaPerson person)
                {
                    _partnerId = person.CustId;
                    lblPartnerName.Text = person.LastName + " " + person.FirstName + " " + person.SurName;
                }
                else if (value is AnketaCompany company)
                {
                    _partnerId = company.CustId;
                    lblPartnerName.Text = company.Name;
                }
            }
        }

        // додати новго клієнта
        private void btnAddClient_Click(object sender, EventArgs e)
        {
            var list = GetFreeClientList?.Invoke(-1);
            SelectClient selectClient = new SelectClient(list);
            selectClient.OnAddSelectedClient += SelectClient_OnAddSelectedClient;
            if(selectClient.ShowDialog() == DialogResult.OK)
                UpdateData?.Invoke(sender, e);
        }

        private bool SelectClient_OnAddSelectedClient(int clientId)
        {
            return OnAddClientToPartner?.Invoke(clientId, _partnerId) ?? false;
        }

        private void btnDetach_Click(object sender, EventArgs e)
        {
            if (!(gvViewClientsOfPartner.CurrentRow.DataBoundItem is PartnerClientListView item)) return;
            if (MessageBox.Show("Відв'язати обраного клієнта від представника?","Підтвердження",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var result = OnDetachClientInPartner?.Invoke(item.ClCustId, _partnerId);
                if (result ?? false)
                    UpdateData?.Invoke(sender, e);
            }
        }
    }
}
