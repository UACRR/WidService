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
using Telerik.WinControls;

namespace IpsViewComponentLibrary.ConsumerForms
{
    public partial class CabinetSmallRightForm : Telerik.WinControls.UI.RadForm
    {
        private Customer _customer;
        public event UpdateCustomerDataEventHandler Update;

        public CabinetSmallRightForm()
        {
            InitializeComponent();
            cabinet.Rights = TypeRights.SmallRights;
            cabinet.UpdateData += UpdateData;
        }

        public void SetCustomer(Customer customer)
        {
            _customer = customer;
            cabinet.SetCustomerData(_customer);
        }

        //оновлення даних
        private void UpdateData(int id)
        {
            Update?.Invoke(id);
        }

        private void CabinetSmallRightForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
