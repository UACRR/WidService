using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign.Model;
using Telerik.WinControls;

namespace IpsViewComponentLibrary.ConsumerForms
{
    public partial class CabinetBigRightForm : Telerik.WinControls.UI.RadForm
    {
        private Customer _customer;
        public CabinetBigRightForm()
        {
            InitializeComponent();
        }

        public void SetCustomerData(Customer customer)
        {
            _customer = customer;
        }

        private void CabinetBigRightForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();
        }
    }
}
