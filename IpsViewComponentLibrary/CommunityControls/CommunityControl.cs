using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Enums;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary.CommunityControls.InternalModel;
using IpsViewComponentLibrary.Extensions;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.CommunityControls
{
    public partial class CommunityControl : UserControl
    {
        private const string ErrorMsg = "Неможливо додати нове товариство!";
        private const string SeccessMsg = "Нове товариство додано!";

        public event ReturnViewEventHandler<CommunityListView> SetCommunityList;
        public event ReturnViewEventHandler<CommunityAuthorsView> GetCommunityAutorsList;
        public event AgreementStatusChangeEventHandler ChangeStatusAgr;
        public event GetCustomerEventHandler GetTemplateCommunity;
        public event GetCustomerByIdEventHandler GetCommunity;
        public event SaveCustomerEventHandler SaveCommunity;
        public event Func<AgreementAddCommunity, bool> SaveAgreementChanges;
        public event GetCommunityRightList GetCommunityRightList;
        public event Func<int, List<TermsOfService>> GetTermsOfService;
        public event Func<int, int, List<CustCmRight>, bool> SaveCustCmRightLimitedRights;
        public event Func<int, int, List<TermsOfService>, bool> SaveTermsOfServiceLimitedRights;

        public CommunityControl()
        {
            InitializeComponent();
            ctrlGridRowCount.RadGridViewDataSource = gvViewPartners;
            panelBottom.PanelElement.PanelBorder.Width = 0f;
            ctrlSearch.SetUsageGrid(gvViewPartners);
            Load += CommunityControlLoad;
        }

        private void CommunityControlLoad(object sender, EventArgs e)
        {
            UpdateDataGrid();
        }

        // оновлення даних на грід зі збереженням обраного рядка
        private void UpdateDataGrid()
        {
            var communityList = SetCommunityList?.Invoke(-1);
            bsCommunityListView.DataSource = communityList;
            InternalCommunity.InternalCommunityInfo = communityList?.SingleOrDefault(rec => rec.IsMy == 1);
            bsCommunityListView.ResetBindings(false);
        }

        private void btnAddCommunity_Click(object sender, EventArgs e)
        {
            var community = GetTemplateCommunity?.Invoke();
            var communityForm = new CommunityForm(community);
            if (communityForm.ShowDialog() == DialogResult.OK)
            {
                var result = SaveCommunity?.Invoke(community) ?? false;
                MessageShow.ShowInfoByResult(SeccessMsg, ErrorMsg, result);
                UpdateDataGrid();
            }
        }

        // командна кнопка
        private void gvViewPartners_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            OpenCommunityCabinet(e);
        }

        // даблклік по рядку
        private void gvViewPartners_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Column.Name == "viewBtn")
                return;
            OpenCommunityCabinet(e);
        }

        /// <summary>
        /// Відкрити кабінет спільноти
        /// </summary>
        /// <param name="currentCell"></param>
        private void OpenCommunityCabinet(GridViewCellEventArgs currentCell)
        {
            if (!(currentCell.Row.DataBoundItem is CommunityListView item))
                return;

            var customer = GetCommunity?.Invoke(item.CustId);
            var autors = GetCommunityAutorsList?.Invoke(item.CustId);

            var cabinetForm = new CommunityCabinetForm(customer, autors);
            cabinetForm.SaveCustomer += CabinetForm_SaveCustomer;
            cabinetForm.SaveAgreementChanges += CabinetForm_SaveAgreementChanges;
            cabinetForm.UpdateCustomer += CabinetForm_UpdateCustomer;
            cabinetForm.ChangeStatusAgr += CabinetForm_ChangeStatusAgr;
            cabinetForm.GetCommunityRightList += CabinetForm_GetCommunityRightList;
            cabinetForm.GetTermsOfService += CabinetForm_GetTermsOfService;
            cabinetForm.SaveCustCmRightLimitedRights += CabinetFormSaveCustCmRightLimitedRights;
            cabinetForm.SaveTermsOfServiceLimitedRights += CabinetForm_SaveTermsOfServiceLimitedRights;
            cabinetForm.UpdateAutorsList += CabinetForm_UpdateAutorsList;
            cabinetForm.Show();
        }

        private List<CommunityAuthorsView> CabinetForm_UpdateAutorsList()
        {
            if (gvViewPartners.CurrentRow.DataBoundItem is CommunityListView item)
                return GetCommunityAutorsList?.Invoke(item.CustId);
            return null;
        }

        private bool CabinetFormSaveCustCmRightLimitedRights(int cmCustId, int custId, List<CustCmRight> listObj)
        {
            return SaveCustCmRightLimitedRights?.Invoke(cmCustId, custId, listObj) ?? false;
        }

        private bool CabinetForm_SaveTermsOfServiceLimitedRights(int cmCustId, int custId, List<TermsOfService> termsOfServices)
        {
            return SaveTermsOfServiceLimitedRights?.Invoke(cmCustId, custId, termsOfServices) ?? false;
        }

        private List<CustCmRight> CabinetForm_GetCommunityRightList(int custId)
        {
            return GetCommunityRightList?.Invoke(custId);
        }

        private List<TermsOfService> CabinetForm_GetTermsOfService(int arg)
        {
            return GetTermsOfService?.Invoke(arg);
        }

        private bool CabinetForm_ChangeStatusAgr(int communityId, CPartnerObjectStatus status)
        {
            return ChangeStatusAgr?.Invoke(communityId, status) ?? false;
        }

        private Customer CabinetForm_UpdateCustomer(int custId)
        {
            return GetCommunity?.Invoke(custId);
        }

        private bool CabinetForm_SaveCustomer(Customer customer)
        {
            var result = SaveCommunity?.Invoke(customer) ?? false;
            if (result)
                UpdateDataGrid();
            return result;
        }

        private bool CabinetForm_SaveAgreementChanges(AgreementAddCommunity arg)
        {
            var result = SaveAgreementChanges?.Invoke(arg) ?? false;
            if (result)
                UpdateDataGrid();
            return result;
        }
    }
}
