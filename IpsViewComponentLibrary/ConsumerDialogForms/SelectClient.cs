using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign.Interfaces;
using Telerik.WinControls;

namespace IpsViewComponentLibrary.ConsumerDialogForms
{
    public partial class SelectClient : Telerik.WinControls.UI.RadForm
    {
        public delegate bool SetClientId(int clientId);
        public event SetClientId OnAddSelectedClient;

        public SelectClient(List<PartnerAllFreeClientsView> clientsList)
        {
            InitializeComponent();
            DialogResult = DialogResult.None;
            gvViewFreeClientList.DataSource = clientsList;
            ctrlSearch.SetUsageGrid(gvViewFreeClientList);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if(gvViewFreeClientList.CurrentRow.DataBoundItem is PartnerAllFreeClientsView item)
            {
                var result = OnAddSelectedClient?.Invoke(item.ClCustId);
                if (result ?? false)
                {
                    ExtensionUtils.ShowInfoMessage("Нового клієнта додано!", "Успішно", MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
                else
                    ExtensionUtils.ShowInfoMessage("Неможливо додати клієнта!", "Помилка", MessageBoxIcon.Error);
            }
        }
    }
}
