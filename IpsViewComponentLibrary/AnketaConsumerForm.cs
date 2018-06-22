using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using Telerik.WinControls;

namespace IpsViewComponentLibrary
{
    public partial class AnketaConsumerForm : Telerik.WinControls.UI.RadForm
    {
        private Customer _customer;
        private AnketaDictionaties _dictionaties;

        public delegate bool ReturnSaveCustomer(Customer cust);
        public event ReturnSaveCustomer OnSaveCustomerNeed;

        public AnketaConsumerForm()
        {
            InitializeComponent();
            
        }

        public AnketaConsumerForm(Customer customer, AnketaDictionaties dictionaties)
        {
            InitializeComponent();
            ctrlConsumerAnketa.OnBtnSaveClick += CtrlConsumerAnketa_OnBtnSaveClick;
            _customer = customer;
            _dictionaties = dictionaties;
            ctrlConsumerAnketa.SetDataAndDictionaries(customer, dictionaties);
            ctrlConsumerAnketa.InitializeControl(true);
        }


        private void CtrlConsumerAnketa_OnBtnSaveClick(Customer cust)
        {
            var result = OnSaveCustomerNeed?.Invoke(cust) ?? false;
            if (result)
            {
                MessageBox.Show("Нового споживача додано!", "Успішно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
                MessageBox.Show("Не вдалося додати нового користувача!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

    }
}
