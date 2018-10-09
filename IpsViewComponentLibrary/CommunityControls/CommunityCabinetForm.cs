using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using Telerik.WinControls;

namespace IpsViewComponentLibrary.CommunityControls
{
    public partial class CommunityCabinetForm : Telerik.WinControls.UI.RadForm
    {
        public event SaveCustomerEventHandler SaveCustomer;
        public event AgreementStatusChangeEventHandler ChangeStatusAgr;
        public event GetCustomerByIdEventHandler UpdateCustomer;
        public event ReturnFullViewEventHandler<CommunityAutorsListView> GetAutorsList;
        public event GetCommunityRightList GetCommunityRightList;
        public event SaveObjectListEventHandler<CustCmRight> SaveLimitRights; 


        private List<CommunityAutorsListView> _list;
        private Customer _customer;
        public CommunityCabinetForm(Customer customer, List<CommunityAutorsListView> list)
        {
            InitializeComponent();
            _customer = customer;
            _list = list;
            ctrlTabNavigation.SetDefaultState(pageViewAnketa, FLoadType.Edit);
            ctrlTabNavigation.SaveClick += CtrlTabNavigation_SaveClick;
            ctrlSearch.SetUsageGrid(gvViewAutors);

            BeginBindings();
        }

        private void CtrlTabNavigation_SaveClick(object sender, EventArgs e)
        {
            var result = SaveCustomer?.Invoke(_customer) ?? false;
            if(result)
                ExtensionUtils.ShowInfoMessage("Зміни збережено!", "Успішно", MessageBoxIcon.Information);
        }

        private void BeginBindings()
        {
            //grid
            gvViewAutors.DataSource = _list;


            var anketaCompany = _customer.Company.AnketaCompany.SingleOrDefault();
            var agreement = _customer.Community.AgreementAddCommunity.SingleOrDefault();

            //спільнота
            ctrlClientName.DataSource = anketaCompany;
            var empl = _customer.Company.RelEmployee.SingleOrDefault(rec => rec.PositionCode == 3)?.Empl;
            ctrlContactPerson.DataSource = empl;
            ctrlContactPerson.OutsidePhone = true;
            ctrlContactPerson.TxtPhone.NullText = string.Empty;

            // - - адреса
            // юридична
            ctrlAddressJu.AnketaCompanyDataSource = anketaCompany;
            ctrlAddressJu.AddressDataMember = "JaAddress";
            ctrlAddressJu.CityDataMember = "JaCity";
            ctrlAddressJu.CountryDataMember = "JaCountry"; ;
            // фактична
            ctrlAddressFa.AnketaCompanyDataSource = anketaCompany;
            ctrlAddressFa.AddressDataMember = "FaAddress";
            ctrlAddressFa.CityDataMember = "FaCity";
            ctrlAddressFa.CountryDataMember = "FaCountry";
            // для листування
            ctrlAddressLe.AnketaCompanyDataSource = anketaCompany;
            ctrlAddressLe.AddressDataMember = "LeAddress";
            ctrlAddressLe.CityDataMember = "LeCity";
            ctrlAddressLe.CountryDataMember = "LeCountry";
            ctrlAddressLe.PostIndexDataMember = "LePostIndex";

            // банківські дані
            var bank = _customer.BankAccount.SingleOrDefault();
            ctrlBankAccount.DataSource = bank;

            // договір
            ctrlAgreement.AgreementDataSource = agreement;
            var statusid = _customer?.Community?.AgreementAddCommunity?.SingleOrDefault()?.AgrStatus;
            lblStatusName.Text = IpsGlobal.AnketaDictionaties.agreementStatus.SingleOrDefault(rec => rec.CodeI == statusid)?.Name;
            lblCommunityName.Text = anketaCompany?.Name;
        }

        #region КОПІЮВАННЯ АДРЕС

        private void btnCopyFromLiveToReg_Click(object sender, EventArgs e)
        {
            ctrlAddressFa.DdlCountry.SelectedValue = ctrlAddressJu.DdlCountry.SelectedValue;
            ctrlAddressFa.TxtCity.Select();
            ctrlAddressFa.TxtCity.Text = ctrlAddressJu.TxtCity.Text;
            ctrlAddressFa.TxtAddress.Select();
            ctrlAddressFa.TxtAddress.Text = ctrlAddressJu.TxtAddress.Text;
        }

        private void btnCopyFromLiveToLett_Click(object sender, EventArgs e)
        {
            ctrlAddressLe.DdlCountry.SelectedValue = ctrlAddressJu.DdlCountry.SelectedValue;
            ctrlAddressLe.TxtCity.Select();
            ctrlAddressLe.TxtCity.Text = ctrlAddressJu.TxtCity.Text;
            ctrlAddressLe.TxtAddress.Select();
            ctrlAddressLe.TxtAddress.Text = ctrlAddressJu.TxtAddress.Text;
            ctrlAddressLe.TxtPostIndex.Select();
        }

        private void btnCopyFromRegToLett_Click(object sender, EventArgs e)
        {
            ctrlAddressLe.DdlCountry.SelectedValue = ctrlAddressFa.DdlCountry.SelectedValue;
            ctrlAddressLe.TxtCity.Select();
            ctrlAddressLe.TxtCity.Text = ctrlAddressFa.TxtCity.Text;
            ctrlAddressLe.TxtAddress.Select();
            ctrlAddressLe.TxtAddress.Text = ctrlAddressFa.TxtAddress.Text;
            ctrlAddressLe.TxtPostIndex.Select();
        }

        #endregion

        // підтвердження договору
        private void btnAcceptAgr_Click(object sender, EventArgs e)
        {
            var result = ChangeStatusAgr?.Invoke(_customer.CustId, CPartnerObjectStatus.Activate);
            if (result ?? false)
            {
                _customer = UpdateCustomer?.Invoke(_customer.CustId);
                BeginBindings();
            }
        }

        // закривання договору
        private void btnCloseAgr_Click(object sender, EventArgs e)
        {
            var result = ChangeStatusAgr?.Invoke(_customer.CustId, CPartnerObjectStatus.Close);
            if (result ?? false)
            {
                _customer = UpdateCustomer?.Invoke(_customer.CustId);
                BeginBindings();
            }
        }

        //додати автора
        private void btnAddCommunity_Click(object sender, EventArgs e)
        {
            var autorsList = GetAutorsList?.Invoke().DistinctBy(rec => rec.CustId).ToList();
            var addAutorForm = new CommunityAddAutorForm(autorsList, _customer.CustId)
            {
                StartPosition = FormStartPosition.CenterScreen,
            };
            addAutorForm.GetCommunityRightList += AddAutorForm_GetCommunityRightList;

            if (addAutorForm.ShowDialog() == DialogResult.OK)
            {
                var result = SaveLimitRights?.Invoke(_customer.CustId, addAutorForm.LimitRights) ?? false;
                if(result)
                {
                    ExtensionUtils.ShowInfoMessage("Внесені зміни збережено!", "Успішно", MessageBoxIcon.Information);
                    _customer = UpdateCustomer?.Invoke(_customer.CustId);
                    BeginBindings();
                }
                else
                    ExtensionUtils.ShowInfoMessage("Неможливо зберегти внесені зміни!", "Помика", MessageBoxIcon.Error);
            }
        }

        private List<CustCmRight> AddAutorForm_GetCommunityRightList(int custId)
        {
            return GetCommunityRightList?.Invoke(custId);
        }
    }
}
