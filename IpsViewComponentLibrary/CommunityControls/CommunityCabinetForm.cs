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
using IpsViewComponentLibrary.Extensions;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.CommunityControls
{
    public partial class CommunityCabinetForm : RadForm
    {
        public event SaveCustomerEventHandler SaveCustomer;
        public event AgreementStatusChangeEventHandler ChangeStatusAgr;
        public event GetCustomerByIdEventHandler UpdateCustomer;
        public event ReturnFullViewEventHandler<CommunityAutorsListView> GetAutorsList;
        public event ReturnFullViewEventHandler<CommunityAutorsListView> UpdateAutorsList;
        public event GetCommunityRightList GetCommunityRightList;
        public event SaveLimitedRightEventHandler<CustCmRight> SaveLimitedRights; 

        private List<CommunityAutorsListView> _list;
        private Customer _customer;

        public CommunityCabinetForm(Customer customer, List<CommunityAutorsListView> list)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            _customer = customer;
            _list = list;
            ctrlTabNavigation.SetDefaultState(pageViewAnketa, FLoadType.Edit);
            ctrlTabNavigation.SaveClick += CtrlTabNavigation_SaveClick;
            ctrlTabNavigation.CancelClick += CtrlTabNavigation_CancelClick;
            ctrlSearch.SetUsageGrid(gvViewAutors);

            BeginBindings();
        }

        private void CtrlTabNavigation_CancelClick()
        {
            _customer = UpdateCustomer?.Invoke(_customer.CustId);
            BeginBindings();
        }

        private void CtrlTabNavigation_SaveClick(object sender, EventArgs e)
        {
            var result = SaveCustomer?.Invoke(_customer) ?? false;
            MessageShow.ShowInfoAfterChanges(result);
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
            if(empl == null)
            {
                empl = new Employee();
                _customer.Company.RelEmployee.Add(new RelEmployee { PositionCode = 3, Empl = empl });
            }
            ctrlContactPerson.DataSource = empl;
            ctrlContactPerson.OutsidePhone = true;
            ctrlContactPerson.PhoneNullText = string.Empty;

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
            if (!_customer.BankAccount.Any())
                _customer.BankAccount.Add(new BankAccount
                {
                    CustId = _customer.CustId,
                });
            var bank = _customer.BankAccount.SingleOrDefault();

            ctrlBankAccount.DataSource = bank;

            // договір
            ctrlAgreement.AgreementDataSource = agreement;
            var statusid = agreement.AgrStatus;
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

        private List<CustCmRight> AddAutorForm_GetCommunityRightList(int custId)
        {
            return GetCommunityRightList?.Invoke(custId);
        }

        //додати автора
        private void btnAddCommunity_Click(object sender, EventArgs e)
        {
            LimitationFormShow();
        }

        private void gvViewAutors_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            var row = e.Row.DataBoundItem as CommunityAutorsListView;
            LimitationFormShow(row);
        }

        private void LimitationFormShow(CommunityAutorsListView currentRow = null)
        {
            var autorsList = GetAutorsList?.Invoke().DistinctBy(rec => rec.CustId).ToList();
            var addAutorForm = new CommunityAddAutorForm(autorsList, _customer.CustId) {CurrentRow = currentRow};
            addAutorForm.GetCommunityRightList += AddAutorForm_GetCommunityRightList;

            if (addAutorForm.ShowDialog() == DialogResult.OK)
            {
                var result = SaveLimitedRights?.Invoke(_customer.CustId, addAutorForm.AuthorId, addAutorForm.LimitRights) ?? false;
                MessageShow.ShowInfoAfterChanges(result);
                if (result)
                {
                    _customer = UpdateCustomer?.Invoke(_customer.CustId);
                    _list = UpdateAutorsList?.Invoke();
                    BeginBindings();
                }
            }
        }
    }
}
