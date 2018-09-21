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
using IpsViewComponentLibrary.ConsumerForms;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.PartnerControls
{
    public partial class PartnerControl : UserControl
    {
        public delegate List<T> ReturnViewEventHandler<T>();
        public event ReturnViewEventHandler<PartnerView> GetPartnersView;

        public delegate Customer CreateNewCustomerEventHandler(int customerType);
        public event CreateNewCustomerEventHandler OnCreateNewCustomerNeed;
        public event SaveCustomerEventHandler OnSaveCustomer;
        public event GetCustomerEventHandler GetPartnerById;

        public PartnerControl()
        {
            InitializeComponent();
            InitTemplate();
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
                    //додавання/збереження
                    var result = OnSaveCustomer?.Invoke(customer);
                    if (result ?? false)
                        ExtensionUtils.ShowInfoMessage("Успішно збережено!", "Успішно", MessageBoxIcon.Information);
                    else
                        ExtensionUtils.ShowInfoMessage("Не можливо зберегти!", "Помилка", MessageBoxIcon.Error);
                }
            }
            else if (customer.CustType == 3)
            {
                //some code
                //call juridical form
            }
        }


        #region ФІЛЬТРАЦІЯ (пошук)

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            gvViewPartners.MasterTemplate.Refresh();
        }

        private void gvViewConsumers_CustomFiltering(object sender, Telerik.WinControls.UI.GridViewCustomFilteringEventArgs e)
        {
            //пустий фільтер - всі дані
            if (string.IsNullOrEmpty(txtSearch.Text))
            {
                gvViewPartners.BeginUpdate();
                e.Visible = true;
                for (int i = 0; i < gvViewPartners.ColumnCount; i++)
                {
                    e.Row.Cells[i].Style.Reset();
                }
                gvViewPartners.EndUpdate(false);
                return;
            }
            //фільтр не пустий
            gvViewPartners.BeginUpdate();
            e.Visible = false;
            for (int i = 0; i < gvViewPartners.ColumnCount; i++)
            {
                //якщо поле пусте
                if (e.Row.Cells[i].Value == null)
                    continue;

                string text = e.Row.Cells[i].Value.ToString();
                if (text.IndexOf(txtSearch.Text, 0, StringComparison.InvariantCultureIgnoreCase) >= 0)
                {
                    e.Visible = true;
                    e.Row.Cells[i].Style.CustomizeFill = true;
                    e.Row.Cells[i].Style.DrawFill = true;
                    e.Row.Cells[i].Style.BackColor = Color.FromArgb(201, 252, 254);
                }
                else
                {
                    e.Row.Cells[i].Style.Reset();
                }
                gvViewPartners.EndUpdate(false);
            }
        }

        #endregion

        private void gvViewPartners_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            var row = e.Row.DataBoundItem as PartnerView;
            switch (e.Column.FieldName)
            {
                case "viewBtn":
                    var customer = GetPartnerById?.Invoke(row?.CustId ?? throw new ArgumentException("Не можливо отримати представника по ідентифікатору!"));
                    LoadForm(customer, FLoadType.Edit);
                    break;
                case "deleteBtn":
                    if (MessageBox.Show("Закрити анкету та договір обраного представника?", "Повідомлення", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        //action
                    }
                    break;
            }
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
