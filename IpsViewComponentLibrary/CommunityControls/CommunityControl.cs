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

namespace IpsViewComponentLibrary.CommunityControls
{
    public partial class CommunityControl : UserControl
    {
        public event ReturnViewEventHandler<CommunityListView> SetCommunityList;
        public event GetCustomerEventHandler GetTemplateCommunity;
        public event GetCustomerByIdEventHandler GetCommunity;
        public event SaveCustomerEventHandler SaveCommunity;
        

        public CommunityControl()
        {
            InitializeComponent();
            ctrlSearch.SetUsageGrid(gvViewPartners);
            Load += CommunityControlLoad;
        }

        private void CommunityControlLoad(object sender, EventArgs e)
        {
            gvViewPartners.DataSource = SetCommunityList?.Invoke(-1);
        }

        private void btnAddCommunity_Click(object sender, EventArgs e)
        {
            var community = GetTemplateCommunity?.Invoke();
            var communityForm = new CommunityForm(community);
            if (communityForm.ShowDialog() == DialogResult.OK)
            {
                var result = SaveCommunity?.Invoke(community);
                if (result ?? false) // true -> update data
                    gvViewPartners.DataSource = SetCommunityList?.Invoke(-1);
            }
        }

        private void gvViewPartners_CommandCellClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.Row.DataBoundItem is CommunityListView item)
            {
                var customer = GetCommunity?.Invoke(item.CustId);
                var cabinetForm = new CommunityCabinetForm(customer)
                {
                    StartPosition = FormStartPosition.CenterScreen,
                };
                cabinetForm.SaveCustomer += CabinetForm_SaveCustomer;
                cabinetForm.UpdateCustomer += CabinetForm_UpdateCustomer;
                cabinetForm.ChangeStatusAgr += CabinetForm_ChangeStatusAgr;

                cabinetForm.Show();
            }
        }

        private bool CabinetForm_ChangeStatusAgr(int partnerId, ipsFormsDesign.Services.CPartnerObjectStatus status)
        {
            throw new NotImplementedException();
        }

        private Customer CabinetForm_UpdateCustomer(int custId)
        {
            throw new NotImplementedException();
        }

        private bool CabinetForm_SaveCustomer(Customer customer)
        {
            return SaveCommunity?.Invoke(customer) ?? false;
        }
    }
}
