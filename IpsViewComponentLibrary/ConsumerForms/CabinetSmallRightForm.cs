using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.Extensions;
using Telerik.WinControls;

namespace IpsViewComponentLibrary.ConsumerForms
{
    public partial class CabinetSmallRightForm : Telerik.WinControls.UI.RadForm
    {
        private const string DefaultTitle = "Кабінет користувача";
        private Customer _customer;
        public event UpdateCustomerDataEventHandler OnUpdate;

        public CabinetSmallRightForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            cabinet.Rights = TypeRights.SmallRights;
            cabinet.UpdateData += UpdateData;
        }

        public string Title
        {
            get => Text;
            set => Text = string.IsNullOrWhiteSpace(value) ? DefaultTitle : string.Concat(DefaultTitle, $": {value}");
        }

        public void SetCustomer(Customer customer)
        {
            _customer = customer;
            cabinet.SetCustomerData(_customer);
        }

        //оновлення даних
        private void UpdateData(int id)
        {
            OnUpdate?.Invoke(id);
        }

        private void CabinetSmallRightForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
