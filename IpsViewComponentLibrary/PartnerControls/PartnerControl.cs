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
        }

        public void LoadData()
        {
            treeView.SelectedNodeChanged += TreeView_SelectedNodeChanged;
            treeView.SelectedNode = treeView.Nodes[0];

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
            var partnerList = GetPartnersView?.Invoke();
            if (partnerList == null) return;

            switch (e.Node.Value is PartnerFilter @enum ? @enum : PartnerFilter.None)
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

        private void btnNewPartnerJur_Click(object sender, EventArgs e)
        {
            var customer = OnCreateNewCustomerNeed?.Invoke(3);
            LoadForm(customer, FLoadType.Create);
        }

        private void btnNewPartnerPhis_Click(object sender, EventArgs e)
        {
            var customer = OnCreateNewCustomerNeed?.Invoke(1);
            LoadForm(customer, FLoadType.Create);
        }

        private void LoadForm(Customer customer, FLoadType loadFormType)
        {
            if (customer.CustType == 1)
            {
                PartnerPhisForm partnerPhis = new PartnerPhisForm(customer, loadFormType)
                {
                    StartPosition = FormStartPosition.CenterScreen,
                };
                if (partnerPhis.ShowDialog() == DialogResult.OK)
                {
                    //додавання
                    SaveAnketaPartner(customer);
                }
            }
            else if (customer.CustType == 3)
            {
                //some code
                //call juridical form
            }
        }

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

                    cabinetPartner.Show();
                    break;
            }
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
            var result = OnSaveCustomer?.Invoke(customer);
            if (result ?? false)
                ExtensionUtils.ShowInfoMessage("Успішно збережено!", "Успішно", MessageBoxIcon.Information);
            else
                ExtensionUtils.ShowInfoMessage("Не можливо зберегти!", "Помилка", MessageBoxIcon.Error);

            return result ?? false;
        }

        private void gvViewPartners_HyperlinkOpening(object sender, HyperlinkOpeningEventArgs e)
        {
            if (e.Row.DataBoundItem is PartnerView item)
            {
                //TODO: call partner cabinet
            }
            
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
