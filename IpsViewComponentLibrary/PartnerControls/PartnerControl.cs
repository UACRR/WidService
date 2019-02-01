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
using IpsViewComponentLibrary.ConsumerForms;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.PartnerControls
{
    public partial class PartnerControl : UserControl
    {
        public delegate Customer CreateNewCustomerEventHandler(int customerType);
        public event CreateNewCustomerEventHandler OnCreateNewCustomerNeed;
        public event SaveCustomerEventHandler OnSaveCustomer;
        public event SaveObjectEventHandler<AgreementAddPartner> OnSaveAgreement;
        public event GetCustomerByIdEventHandler GetPartnerById;
        public delegate List<T> ReturnPartnerViewEventHandler<T>();
        public event ReturnPartnerViewEventHandler<PartnerView> GetPartnersView;
        public event ReturnViewEventHandler<PartnerClientListView> GetPartnerClientList;
        public event ReturnViewEventHandler<PartnerAllFreeClientsView> GetFreeClientList;
        public event SetPartnerEventHandler OnAddClientToPartner;
        public event SetPartnerEventHandler OnDetachClientInPartner;
        public event AgreementStatusChangeEventHandler ChangeStatusAgr;

        public PartnerControl()
        {
            InitializeComponent();
            InitTemplate();
            ctrlSearch.SetUsageGrid(gvViewPartners);
            //btnNewPartnerJur.Enabled = false; // заблокувати кнопку
        }

        public void LoadData()
        {
            treeView.SelectedNodeChanged += TreeView_SelectedNodeChanged;
            treeView.SelectedNode = treeView.Nodes[0];
        }

        // оновлення даних
        private void SetDataOfFilter(RadTreeNode node)
        {
            var partnerList = GetPartnersView?.Invoke();
            if (partnerList == null) return;

            switch (node.Value is PartnerFilter @enum ? @enum : PartnerFilter.None)
            {
                case PartnerFilter.None:
                    break;
                case PartnerFilter.All:
                    gvViewPartners.DataSource = partnerList;
                    break;
                case PartnerFilter.Active:
                    gvViewPartners.DataSource = partnerList.Where(rec => rec.AgrStatus == 2);
                    break;
                case PartnerFilter.OnAccept:
                    gvViewPartners.DataSource = partnerList.Where(rec => rec.AgrStatus == 1);
                    break;
                case PartnerFilter.NotAccept:
                    gvViewPartners.DataSource = partnerList.Where(rec => rec.AgrStatus == 0);
                    break;
            }
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
            SetDataOfFilter(e.Node);
        }

        #region * * * СТВОРЕННЯ НОВОГО ПРЕДСТАВНИКА * * *

        // юридична особа
        private void btnNewPartnerJur_Click(object sender, EventArgs e)
        {
            var customer = OnCreateNewCustomerNeed?.Invoke(3);
            LoadForm(customer);
        }

        //фізична особа
        private void btnNewPartnerPhis_Click(object sender, EventArgs e)
        {
            var customer = OnCreateNewCustomerNeed?.Invoke(1);
            LoadForm(customer);
        }

        // виклик форми необхідної форми
        private void LoadForm(Customer customer)
        {
            var newPartner = new CreatePartnerForm(customer) {
                StartPosition = FormStartPosition.CenterScreen,
            };

            if (newPartner.ShowDialog() == DialogResult.OK)
                SaveAnketaPartner(customer);
        }

        #endregion

        // кнопка перегляду/редагування на грід
        private void gvViewPartners_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            var row = e.Row.DataBoundItem as PartnerView;
            switch (e.Column.FieldName)
            {
                case "viewBtn":
                    var customer = GetPartnerById?.Invoke(row?.CustId ?? throw new ArgumentException("Не можливо отримати представника по ідентифікатору!"));
                    CabinetPartnerForm cabinetPartner = new CabinetPartnerForm(customer)
                    {
                        StartPosition = FormStartPosition.CenterScreen,
                    };
                    cabinetPartner.OnSaveCustomer += SaveAnketaPartner;
                    cabinetPartner.GetPartnerClientList += CabinetPartner_GetPartnerClientList;
                    cabinetPartner.GetFreeClientList += CabinetPartner_GetFreeClientList;
                    cabinetPartner.OnAddClientToPartner += CabinetPartner_OnAddClientToPartner;
                    cabinetPartner.OnDetachClientInPartner += CabinetPartner_OnDetachClientInPartner;
                    cabinetPartner.ChangeStatusAgr += CabinetPartner_ChangeStatusAgr;
                    cabinetPartner.UpdateCustomer += CabinetPartner_UpdateCustomer;
                    cabinetPartner.OnSaveAgreement += CabinetPartner_OnSaveAgreement;

                    cabinetPartner.Show();
                    break;
            }
        }

        private bool CabinetPartner_OnSaveAgreement(AgreementAddPartner saveObj)
        {
            return OnSaveAgreement?.Invoke(saveObj) ?? false;
        }

        private Customer CabinetPartner_UpdateCustomer(int custId)
        {
            return GetPartnerById?.Invoke(custId);
        }

        private bool CabinetPartner_ChangeStatusAgr(int partnerId, CPartnerObjectStatus status)
        {
            return ChangeStatusAgr?.Invoke(partnerId, status) ?? false;
        }

        private bool CabinetPartner_OnDetachClientInPartner(int clientId, int partnerId)
        {
            return OnDetachClientInPartner?.Invoke(clientId, partnerId) ?? false;
        }

        private bool CabinetPartner_OnAddClientToPartner(int clientId, int partnerId)
        {
            return OnAddClientToPartner?.Invoke(clientId, partnerId) ?? false;
        }

        private List<PartnerAllFreeClientsView> CabinetPartner_GetFreeClientList(int custId)
        {
            return GetFreeClientList?.Invoke(custId);
        }

        private List<PartnerClientListView> CabinetPartner_GetPartnerClientList(int custId)
        {
            return GetPartnerClientList?.Invoke(custId);
        }

        private bool SaveAnketaPartner(Customer customer)
        {
            var result = OnSaveCustomer?.Invoke(customer) ?? false;
            if (result)
            {
                ExtensionUtils.ShowInfoMessage("Успішно збережено!", "Успішно", MessageBoxIcon.Information);
                SetDataOfFilter(treeView.SelectedNode);
            }
            else
                ExtensionUtils.ShowInfoMessage("Не можливо зберегти!", "Помилка", MessageBoxIcon.Error);

            return result;
        }
    }

    public enum PartnerFilter
    {
        /// <summary>
        /// Empty
        /// </summary>
        None,
        /// <summary>
        /// Всі
        /// </summary>
        All,
        /// <summary>
        /// Активні
        /// </summary>
        Active,
        /// <summary>
        /// На акцепті
        /// </summary>
        OnAccept,
        /// <summary>
        /// Не підтверджені
        /// </summary>
        NotAccept
    }
}
