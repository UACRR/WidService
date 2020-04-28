using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Enums;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary.Extensions;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.PartnerControls
{
    public partial class PartnerControl : UserControl
    {
        //public delegate Customer CreateNewCustomerEventHandler(int customerType);
        //public event CreateNewCustomerEventHandler OnCreateNewCustomerNeed;
        //public event SaveCustomerEventHandler OnSaveCustomer;
        //public event SaveObjectEventHandler<AgreementAddPartner> OnSaveAgreement;
        //public event Func<AgreementAddPartner, Partner, bool> OnSaveAgreement;

        //public event GetCustomerByIdEventHandler GetPartnerById;
        //public delegate List<T> ReturnPartnerViewEventHandler<T>();
        //public event ReturnPartnerViewEventHandler<PartnerView> GetPartnersView;
        //public event ReturnViewEventHandler<PartnerAllFreeClientsView> GetFreeClientList;
        //public event SetPartnerEventHandler OnAddClientToPartner;
        //public event SetPartnerEventHandler OnDetachClientInPartner;
        //public event AgreementStatusChangeEventHandler ChangeStatusAgr;

        private readonly PartnerService _service;

        public PartnerControl()
        {
            InitializeComponent();
            _service = PartnerService.GetInstance();
            InitTemplate();
            ctrlSearch.SetUsageGrid(gvViewPartners);
            ctrlGridRowCount.RadGridViewDataSource = gvViewPartners;
        }

        public void LoadData()
        {
            treeView.SelectedNodeChanged += TreeView_SelectedNodeChanged;
            treeView.SelectedNode = treeView.Nodes[0];
        }

        /// <summary>
        /// Оновлення даних
        /// </summary>
        /// <param name="node"></param>
        private void UpdateGridData()
        {
            var node = treeView.SelectedNode;

            var partnerList = _service.GetView(typeof(PartnerView), "vTsk_6_ListPartner", null).ToListOfType<PartnerView>();
            
            if (partnerList == null)
                return;
            
            switch (node.Value is PartnerFilter @enum ? @enum : PartnerFilter.None)
            {
                case PartnerFilter.None:
                    break;
                case PartnerFilter.All:
                    bsPartnerView.DataSource = partnerList;
                    break;
                case PartnerFilter.Active:
                    bsPartnerView.DataSource = partnerList.Where(rec => rec.AgrStatus == 2).ToList();
                    break;
                case PartnerFilter.OnAccept:
                    bsPartnerView.DataSource = partnerList.Where(rec => rec.AgrStatus == 1).ToList();
                    break;
                case PartnerFilter.NotAccept:
                    bsPartnerView.DataSource = partnerList.Where(rec => rec.AgrStatus == 0).ToList();
                    break;
            }
            bsPartnerView.ResetBindings(false);
        }

        private void InitTemplate()
        {
            RadTreeNode[] list = 
            {
                new RadTreeNode {Text = "Всі", Value = PartnerFilter.All},
                new RadTreeNode {Text = "Активні", Value = PartnerFilter.Active},
                new RadTreeNode {Text = "На акцепті", Value = PartnerFilter.OnAccept},
                new RadTreeNode {Text = "Не підтверджені", Value = PartnerFilter.NotAccept}
            };

            foreach (var item in list)
                treeView.Nodes.Add(item);   
        }

        private void TreeView_SelectedNodeChanged(object sender, RadTreeViewEventArgs e)
        {
            UpdateGridData();
        }

        #region * * * СТВОРЕННЯ НОВОГО ПРЕДСТАВНИКА * * *

        // юридична особа
        private void btnNewPartnerJur_Click(object sender, EventArgs e)
        {
            LoadForm(3);
        }

        //фізична особа
        private void btnNewPartnerPhis_Click(object sender, EventArgs e)
        {
            LoadForm(1);
        }

        // виклик форми необхідної форми
        private void LoadForm(int customerType)
        {
            var customer = _service.GetPartnerTemplate(customerType);
            var newPartner = new CreatePartnerForm(customer);
            if (newPartner.ShowDialog() == DialogResult.OK)
            {
                var result = _service.SavePartner(customer);
                UpdateGridData();
                // handle result;
            }
        }

        #endregion

        // кнопка перегляду/редагування на грід
        private void gvViewPartners_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            if(e.Column.FieldName == "viewBtn")
                OpenPartnerCabinet(e);
        }

        // дабл клік перегляду/редагування на грід
        private void gvViewPartners_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if(e.Column.FieldName == "viewBtn")
                return;
            OpenPartnerCabinet(e);
        }

        private void OpenPartnerCabinet(GridViewCellEventArgs cell)
        {
            if (!(cell.Row.DataBoundItem is PartnerView row))
                return;

            var customer = _service.GetPartner(row.CustId.Value);

            var cabinetPartner = new CabinetPartnerForm(customer);
            cabinetPartner.UpdateDataAction = UpdateGridData;

            //cabinetPartner.OnSaveCustomer += SaveAnketaPartner;

            //cabinetPartner.GetPartnerClientList += (custId) => _service.GetView(typeof(PartnerClientListView), "vTsk_6_ListPClient", custId).ToListOfType<PartnerClientListView>();
            //cabinetPartner.GetFreeClientList += (e) => _service.GetView(typeof(PartnerAllFreeClientsView), "vTsk_6_ListFreeCln", null).ToListOfType<PartnerAllFreeClientsView>();
            //cabinetPartner.OnAddClientToPartner += (clientId, partnerId) => _service.SetPartnerForCustomer(clientId, partnerId);
            //cabinetPartner.OnDetachClientInPartner += (clientId, partnerId) => _service.RemovePartnerForCustomer(clientId, partnerId);
            
            //cabinetPartner.ChangeStatusAgr += (partnerId, status) => _service.AgreementPartnerStatusChange(partnerId, status);

            //cabinetPartner.UpdateCustomer += (custId) =>
            //{
            //    UpdateGridData();
            //    var result = _service.GetPartner(custId);
            //    return result;
            //};
            
            //cabinetPartner.OnSaveAgreement += (saveObj, partner) =>
            //{
            //    var result =  _service.UpdateAgreement(saveObj, partner);
            //    UpdateGridData();
            //    return result;
            //};

            cabinetPartner.Show();
        }

        // збереження змін договору
        //private bool CabinetPartner_OnSaveAgreement(AgreementAddPartner saveObj, Partner partner)
        //{
        //    var result = OnSaveAgreement?.Invoke(saveObj, partner) ?? false;
        //    UpdateGridData(treeView.SelectedNode);
        //    return result;
        //}

        //private Customer CabinetPartner_UpdateCustomer(int custId)
        //{
        //    UpdateGridData(treeView.SelectedNode);
        //    var result = _service.GetPartner(custId);
        //    return result;
        //}

        //private bool CabinetPartner_ChangeStatusAgr(int partnerId, CPartnerObjectStatus status)
        //{
        //    return ChangeStatusAgr?.Invoke(partnerId, status) ?? false;
        //}

        //private bool CabinetPartner_OnDetachClientInPartner(int clientId, int partnerId)
        //{
        //    return OnDetachClientInPartner?.Invoke(clientId, partnerId) ?? false;
        //}

        //private bool CabinetPartner_OnAddClientToPartner(int clientId, int partnerId)
        //{
        //    return OnAddClientToPartner?.Invoke(clientId, partnerId) ?? false;
        //}

        //private List<PartnerAllFreeClientsView> CabinetPartner_GetFreeClientList(int custId)
        //{
        //    return GetFreeClientList?.Invoke(custId);
        //}

        // збереження даних по анкеті
        //private bool SaveAnketaPartner(Customer customer)
        //{
        //    //var result = OnSaveCustomer?.Invoke(customer) ?? false;
        //    var result  = _service.SavePartner(customer);
        //    UpdateGridData();
        //    return result;
        //}
    }
}
