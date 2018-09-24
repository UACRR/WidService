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

namespace IpsViewComponentLibrary.PartnerControls
{
    public partial class PartnerClientsControl : UserControl
    {
        public event ReturnViewEventHandler<PartnerAllFreeClientsView> GetFreeClientList;
        public PartnerClientsControl()
        {
            InitializeComponent();
            ctrlSearch.SetUsageGrid(gvViewConsumers);
        }

        public void SetData(List<PartnerClientListView> list)
        {
            gvViewConsumers.DataSource = list;
        }

        public object ClientName
        {
            get => lblPartnerName.Text;
            set
            {
                if (value is AnketaPerson anketa)
                {
                    lblPartnerName.Text = anketa.LastName + " " + anketa.FirstName + " " + anketa.SurName;
                }
            }
        }

        private void btnAddClient_Click(object sender, EventArgs e)
        {
            //add client
            var list = GetFreeClientList?.Invoke(-1);

        }

        private void gvViewConsumers_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            // open client cabinet
        }
    }
}
