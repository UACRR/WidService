using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Model;
using Telerik.WinControls;

namespace IpsViewComponentLibrary.ConsumerForms
{
    public partial class CabinetSmallRightForm : Telerik.WinControls.UI.RadForm
    {
        private Customer _customer;

        public delegate Customer GetCustomerEventHandler(int custId);
        public event GetCustomerEventHandler OnGetCustomerNeed;

        public CabinetSmallRightForm()
        {
            InitializeComponent();
            cabinet.Rights = TypeRights.SmallRights;
            cabinet.OnUpdateCustomerNeed += Cabinet_OnUpdateCustomerNeed;
        }

        public void SetCustomer(Customer customer)
        {
            _customer = customer;
            cabinet.SetCustomerData(_customer);
        }

        //оновлення даних
        private void Cabinet_OnUpdateCustomerNeed(int id)
        {
            _customer = OnGetCustomerNeed?.Invoke(id);
            cabinet.SetCustomerData(_customer);
        }

        private void CabinetSmallRightForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
