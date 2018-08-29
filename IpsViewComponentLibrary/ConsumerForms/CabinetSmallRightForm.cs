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
        }
        public CabinetSmallRightForm(Customer customer)
        {
            InitializeComponent();
            _customer = customer;
            cabinet.Rights = TypeRights.SmallRights;
            cabinet.SetCustomerData(_customer);
            cabinet.OnUpdateCustomerNeed += Cabinet_OnUpdateCustomerNeed;
        }

        //оновлення даних
        private void Cabinet_OnUpdateCustomerNeed(int id)
        {
            _customer = OnGetCustomerNeed?.Invoke(id);
            cabinet.SetCustomerData(_customer);
        }
    }
}
