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
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary.Extensions;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.CommunityControls
{
    public partial class CommunityControl : UserControl
    {
        private const string ErrorMsg = "Неможливо додати нову Спільноту!";
        private const string SeccessMsg = "Нова Спільнота додана!";
        private readonly GridStateRecorder _gridStateRecorder = new GridStateRecorder();

        public event ReturnViewEventHandler<CommunityListView> SetCommunityList;
        public event ReturnViewEventHandler<CommunityAuthorsView> GetCommunityAutorsList;
        public event AgreementStatusChangeEventHandler ChangeStatusAgr;
        public event GetCustomerEventHandler GetTemplateCommunity;
        public event GetCustomerByIdEventHandler GetCommunity;
        public event SaveCustomerEventHandler SaveCommunity;
        public event GetCommunityRightList GetCommunityRightList;
        public event SaveLimitedRightEventHandler<CustCmRight> SaveLimitRights;

        public CommunityControl()
        {
            InitializeComponent();
            _gridStateRecorder.AddGrid(gvViewPartners);
            ctrlSearch.SetUsageGrid(gvViewPartners);
            Load += CommunityControlLoad;
        }

        // оновлення даних на грід зі збереженням обраного рядка
        private void UpdateDataGrid()
        {
            _gridStateRecorder.RecordState();
            gvViewPartners.DataSource = SetCommunityList?.Invoke(-1);
            //show count Partners
            lblCountPartners.Text = gvViewPartners.RowCount.ToString();
            gvViewPartners.ResetBindings();
            _gridStateRecorder.RestoreState();
        }

        private void CommunityControlLoad(object sender, EventArgs e)
        {
            gvViewPartners.DataSource = SetCommunityList?.Invoke(-1);
            //show count Partners
            lblCountPartners.Text = gvViewPartners.RowCount.ToString();
        }

        private void btnAddCommunity_Click(object sender, EventArgs e)
        {
            var community = GetTemplateCommunity?.Invoke();
            var communityForm = new CommunityForm(community);
            if (communityForm.ShowDialog() == DialogResult.OK)
            {
                var result = SaveCommunity?.Invoke(community) ?? false;
                MessageShow.ShowInfoByResult(SeccessMsg, ErrorMsg, result);
                if (result)
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
            cabinetForm.UpdateCustomer += CabinetForm_UpdateCustomer;
            cabinetForm.ChangeStatusAgr += CabinetForm_ChangeStatusAgr;
            cabinetForm.GetCommunityRightList += CabinetForm_GetCommunityRightList;
            cabinetForm.SaveLimitedRights += CabinetFormSaveLimitedRights;
            cabinetForm.UpdateAutorsList += CabinetForm_UpdateAutorsList;
            cabinetForm.Show();
        }

        private List<CommunityAuthorsView> CabinetForm_UpdateAutorsList()
        {
            if (gvViewPartners.CurrentRow.DataBoundItem is CommunityListView item)
                return GetCommunityAutorsList?.Invoke(item.CustId);
            return null;
        }

        private bool CabinetFormSaveLimitedRights(int cmCustId, int custId, List<CustCmRight> listObj)
        {
            return SaveLimitRights?.Invoke(cmCustId, custId, listObj) ?? false;
        }

        private List<CustCmRight> CabinetForm_GetCommunityRightList(int custId)
        {
            return GetCommunityRightList?.Invoke(custId);
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
    }
}
