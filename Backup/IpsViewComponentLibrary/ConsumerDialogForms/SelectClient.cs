using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign.Interfaces;
using IpsViewComponentLibrary.Utilities;
using Telerik.WinControls;

namespace IpsViewComponentLibrary.ConsumerDialogForms
{
    public partial class SelectClient : Telerik.WinControls.UI.RadForm
    {
        public delegate bool SetClientId(int clientId);
        public event SetClientId OnAddSelectedClient;

        /// <summary>
        /// Для настройки виводу діалогу у різних випадках
        /// </summary>
        private SuccessErrorMsg _msg = new SuccessErrorMsg("Нового клієнта додано!", "Неможливо додати клієнта!");

        public SelectClient(List<PartnerAllFreeClientsView> clientsList, SuccessErrorMsg msg = null )
        {
            InitializeComponent();

            if (msg != null)
                _msg = msg;

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
                    ExtensionUtils.ShowInfoMessage(_msg.Success, "Успішно", MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
                else
                    ExtensionUtils.ShowInfoMessage(_msg.Error, "Помилка", MessageBoxIcon.Error);
            }
        }
    }
}
