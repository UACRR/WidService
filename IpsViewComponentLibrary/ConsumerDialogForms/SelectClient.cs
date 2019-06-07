using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign.Interfaces;
using IpsViewComponentLibrary.Extensions;
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
        private SuccessErrorMsg _msg = new SuccessErrorMsg("Нового користувача додано!", "Неможливо додати користувача!");

        public SelectClient(List<PartnerAllFreeClientsView> clientsList, SuccessErrorMsg msg = null)
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;

            if (msg != null)
                _msg = msg;

            DialogResult = DialogResult.None;
            gvViewFreeClientList.DataSource = clientsList;
            ctrlSearch.SetUsageGrid(gvViewFreeClientList);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!(gvViewFreeClientList.CurrentRow.DataBoundItem is PartnerAllFreeClientsView item))
                return;
            
            var result = OnAddSelectedClient?.Invoke(item.ClCustId) ?? false;
            MessageShow.ShowInfoByResult(_msg.Success, _msg.Error, result);
            if (result)
                DialogResult = DialogResult.OK;
        }
    }
}
