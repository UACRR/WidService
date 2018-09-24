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
        public event ReturnViewEventHandler<PartnerAllFreeClientsView> GetFreeClientList;

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
                if (value is AnketaPerson anketa)
                {
                    _partnerId = anketa.CustId;
                    lblPartnerName.Text = anketa.LastName + " " + anketa.FirstName + " " + anketa.SurName;
                }
            }
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            //add client
            var list = GetFreeClientList?.Invoke(-1);
            SelectClient selectClient = new SelectClient(list);
            selectClient.OnAddSelectedClient += SelectClient_OnAddSelectedClient;
            selectClient.ShowDialog();
        }

        private bool SelectClient_OnAddSelectedClient(int clientId)
        {
            return OnAddClientToPartner?.Invoke(clientId, _partnerId) ?? false;
        }

        private void gvViewConsumers_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            // open client cabinet
        }
    }
}
