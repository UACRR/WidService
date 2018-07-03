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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="dictionaties"></param>
        /// <param name="isNew"></param>
        /// <param name="isBigRights"></param>
        public AnketaConsumerForm(Customer customer, AnketaDictionaties dictionaties, bool isNew = true, TypeRights typeRights = TypeRights.SmallRights )
        {
            InitializeComponent();
            
            ctrlConsumerAnketa.OnBtnSaveClick += CtrlConsumerAnketa_OnBtnSaveClick;
            _customer = customer;
            _dictionaties = dictionaties;
            ctrlConsumerAnketa.typeRights = typeRights;
            ctrlConsumerAnketa.SetDataAndDictionaries(customer, dictionaties);
            ctrlConsumerAnketa.InitializeControl(isNew);
            if (!isNew)
            {
                btnSave.Visible = true;
                btnCancel.Visible = true;
                Text = "Редагування анкети споживача";
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cust"></param>
        private void CtrlConsumerAnketa_OnBtnSaveClick(Customer cust)
        {
            var result = OnSaveCustomerNeed?.Invoke(cust) ?? false;
            if (result)
            {
                MessageBox.Show("Нового споживача додано!", "Успішно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
                MessageBox.Show("Не вдалося додати нового споживача дані!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Дійсно скасувати всі зміни та вийти?","Повідомлення",MessageBoxButtons.YesNo,MessageBoxIcon.Question) == DialogResult.Yes)
                Close();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {

            var result = OnSaveCustomerNeed?.Invoke(ctrlConsumerAnketa.GetCustomer) ?? false;
            if (result)
            {
                MessageBox.Show("Зміни збережено!", "Успішно", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Close();
            }
            else
                MessageBox.Show("Не вдалося зберегти дані!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
    }
}
