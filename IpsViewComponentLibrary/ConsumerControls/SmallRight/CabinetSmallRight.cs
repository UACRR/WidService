using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;

namespace IpsViewComponentLibrary
{
    /// <inheritdoc cref="" />
    /// 1. Передати  AnketaDictionaties,
    /// 2. Передати джерело даних в грід
    /// 3. Підписатись на подію (викликати метод, що повертає Customer)
    public partial class CabinetSmallRight : UserControl
    {
        private int _customerId;
        private Customer _customer;

        // на майбутнє (при зміні рядка оновлення даних)
        public event UpdateCustomerDataEventHandler OnGridRowSelectedChaged;



        public delegate void CallEditCustomer(int id);
        public event CallEditCustomer OnEditCustomer;

        public event UpdateCustomerDataEventHandler OnUpdateCustomerNeed;
        public event SaveCustomerEventHandler OnSaveCustomer;
        public event LisenseStatusChangeEventHandler OnChangeLicenseStatus;

        public TypeRights Rights { get; set; }

        public CabinetSmallRight()
        {
            InitializeComponent();

            mсInfoAgrCalc.Rights = Rights;
            mсInfoAgrCalc.OnCustomerSave += SaveCustomer;
            mсInfoAgrCalc.OnChangeLicenseStatus += MсInfoAgrCalc_OnChangeLicenseStatus;
        }

        public void SetCustomerData(Customer customer)
        {
            _customer = customer;
            _customerId = _customer.CustId;
            mсInfoAgrCalc.SetDictionary(IpsGlobal.AnketaDictionaties);
            mсInfoAgrCalc.SetCustomerData(_customer);
        }

        private bool MсInfoAgrCalc_OnChangeLicenseStatus(LicenseAgreement agr, int version, int status, bool changeVer)
        {
            return OnChangeLicenseStatus?.Invoke(agr, version, status, changeVer) ?? false;
        }


        //збереження
        private void SaveCustomer(Customer customer)
        {
            var result = OnSaveCustomer?.Invoke(customer) ?? false;
            if (result)
            {
                MessageBox.Show("Успішно збережено!", "Збережено", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Не можливо зберегти!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //оновлення 
        private void UpdateCustomer_Click(object sender, EventArgs e)
        {
            OnUpdateCustomerNeed?.Invoke(_customerId);
        }

        //редагування 
        private void EditExistCustomer_Click(object sender, EventArgs e)
        {
            OnEditCustomer?.Invoke(_customerId);
        }
    }
}
