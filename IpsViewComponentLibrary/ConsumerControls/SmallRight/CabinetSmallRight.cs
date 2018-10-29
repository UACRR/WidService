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

        public delegate void CallEditCustomer(int id);

        public event UpdateCustomerDataEventHandler OnUpdateCustomerNeed;
        public event SaveCustomerEventHandler OnSaveCustomer;
        public event LisenseStatusChangeEventHandler OnChangeLicenseStatus;
        public event ReturnObjectEventHandler<Customer> GetPartner;
        public event ReturnObjectEventHandler<Customer> GetCustomer;


        #region ПРЕДСТАВНИК events

        public event SetPartnerEventHandler OnSetPartner;
        public event SetPartnerEventHandler OnRemovePartner;
        public event ChangePartnerEventHandler OnChangePartner;
        public event GetPartnerList OnGetPartnerListNeed;

        #endregion


        public TypeRights Rights { get; set; }

        public CabinetSmallRight()
        {
            InitializeComponent();
            pagesControl.SetDictionary(IpsGlobal.AnketaDictionaties);
            pagesControl.Rights = TypeRights.SmallRights;
            pagesControl.OnCustomerSave += SaveCustomer;
            pagesControl.OnChangeLicenseStatus += PagesControlOnChangeLicenseStatus;
            pagesControl.GetPartner += PagesControl_GetPartner;
            pagesControl.OnSetPartner += PagesControl_OnSetPartner;
            pagesControl.OnChangePartner += PagesControl_OnChangePartner;
            pagesControl.OnRemovePartner += PagesControl_OnRemovePartner;
            pagesControl.OnGetPartnerListNeed += PagesControl_OnGetPartnerListNeed;
            pagesControl.UpdateData += UpdateCustomer;
            pagesControl.calculationCtrl.UpdateData += UpdateCustomer;
        }

        private List<Customer> PagesControl_OnGetPartnerListNeed()
        {
            return OnGetPartnerListNeed?.Invoke();
        }

        private bool PagesControl_OnRemovePartner(int clientId, int partnerId)
        {
            return OnRemovePartner?.Invoke(clientId, partnerId) ?? false;
        }

        private bool PagesControl_OnChangePartner(int clientId, int partnerId, int oldPartnerId)
        {
            return OnChangePartner?.Invoke(clientId, partnerId, oldPartnerId) ?? false;
        }

        private bool PagesControl_OnSetPartner(int clientId, int partnerId)
        {
            return OnSetPartner?.Invoke(clientId, partnerId) ?? false;
        }

        private Customer PagesControl_GetPartner(int custId)
        {
            return GetPartner?.Invoke(custId);
        }

        private void UpdateCustomer()
        {
            OnUpdateCustomerNeed?.Invoke(_customerId);
        }

        public void SetCustomerData(Customer customer)
        {
            _customer = customer;
            _customerId = _customer.CustId;
            pagesControl.SetCustomerData(_customer);
        }

        //зміна статусу ліцензії
        private bool PagesControlOnChangeLicenseStatus(LicenseAgreement agr, int version, int status, bool changeVer)
        {
            return OnChangeLicenseStatus?.Invoke(agr, version, status, changeVer) ?? false;
        }

        //збереження
        private void SaveCustomer(Customer customer)
        {
            var result = OnSaveCustomer?.Invoke(customer) ?? false;
            if (result)
                MessageBox.Show("Успішно збережено!", "Збережено", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Не можливо зберегти!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }
}
