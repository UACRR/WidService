using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;
using ipsFormsDesign.Data;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Enums;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.CommunityControls.Presenters;
using IpsViewComponentLibrary.Extensions;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.CommunityControls
{
    public partial class CommunityCabinetForm : RadForm
    {
        public event SaveCustomerEventHandler SaveCustomer;
        public event AgreementStatusChangeEventHandler ChangeStatusAgr;
        public event Func<AgreementAddCommunity, bool> SaveAgreementChanges;
        public event GetCustomerByIdEventHandler UpdateCustomer;
        public event ReturnFullViewEventHandler<CommunityAuthorsView> UpdateAutorsList;
        public event GetCommunityRightList GetCommunityRightList;
        public event SaveLimitedRightEventHandler<CustCmRight> SaveLimitedRights; 

        private Customer _customer;
        private readonly CommunityViewsPresenter _presenter;

        protected new bool IsDesignMode => DesignMode || LicenseManager.UsageMode == LicenseUsageMode.Designtime;

        public CommunityCabinetForm(Customer customer, List<CommunityAuthorsView> list)
        {
            InitializeComponent();
            if (!IsDesignMode)
                _presenter = new CommunityViewsPresenter();
            WindowState = FormWindowState.Maximized;
            parentGridPanel.PanelElement.PanelBorder.Width = 0f;
            _customer = customer;
            bsCommunityAuthorsView.DataSource = list;
            ctrlTabNavigation.SetDefaultState(pageViewAnketa, FLoadType.Edit);
            ctrlTabNavigation.SaveClick += CtrlTabNavigation_SaveClick;
            ctrlTabNavigation.CancelClick += CtrlTabNavigation_CancelClick;
            ctrlSaveCancelButtons.SaveClck += CtrlSaveCancelButtons_SaveClck;
            ctrlSaveCancelButtons.CancelClick += CancelClick;
            ctrlSearch.SetUsageGrid(gvViewAutors);

            BeginBindings();
        }

        // agreement cancel
        private void CancelClick(object sender, EventArgs e)
        {
            CtrlTabNavigation_CancelClick();
        }

        private void CtrlTabNavigation_CancelClick()
        {
            _customer = UpdateCustomer?.Invoke(_customer.CustId);
            BeginBindings();
        }

        // agreement save
        private void CtrlSaveCancelButtons_SaveClck(object sender, EventArgs e)
        {
            var ageement = _customer.Community.AgreementAddCommunity.SingleOrDefault();
            var result = SaveAgreementChanges?.Invoke(ageement) ?? false;
            //var result = SaveCustomer?.Invoke(_customer) ?? false;
            MessageShow.ShowInfoAfterChanges(result);
        }

        // anketa save
        private void CtrlTabNavigation_SaveClick(object sender, EventArgs e)
        {
            var result = SaveCustomer?.Invoke(_customer) ?? false;
            MessageShow.ShowInfoAfterChanges(result);
        }

        private void BeginBindings()
        {
            bsCommunity.DataSource = _customer.Community;
            
            var anketaCompany = _customer.Company.AnketaCompany.SingleOrDefault();
            var agreement = _customer.Community.AgreementAddCommunity.SingleOrDefault();

            // спільнота
            ctrlClientName.DataSource = anketaCompany;

            // контактна особа
            var relEmployeeContact = _customer.Company.RelEmployee.SingleOrDefault(rec => rec.PositionCode == 3);
            if (relEmployeeContact == null)
                _customer.Company.RelEmployee.Add(new RelEmployee {PositionCode = 3, Empl = new Employee()});

            var employeeContact = _customer.Company.RelEmployee.SingleOrDefault(rec => rec.PositionCode == 3);

            var relEmployeeHead = _customer.Company.RelEmployee.SingleOrDefault(rec => rec.PositionCode == 1);
            if (relEmployeeHead == null)
                _customer.Company.RelEmployee.Add(new RelEmployee {PositionCode = 1, Empl = new Employee()});

            var employeeHead = _customer.Company.RelEmployee.SingleOrDefault(rec => rec.PositionCode == 1);

            ctrlContactPerson.DataSource = employeeContact.Empl;
            ctrlContactPerson.OutsidePhone = true;
            ctrlContactPerson.PhoneNullText = string.Empty;

            bsRelEmployee.DataSource = employeeHead;
            ctrlHeadBoss.DataSource = employeeHead.Empl;
            ctrlHeadBoss.OutsidePhone = true;
            ctrlHeadBoss.PhoneNullText = string.Empty;

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

            ctrlAgreement.IsReadOnly = statusid == 2;
            ctrlSaveCancelButtons.Enabled = statusid != 2;

            btnAcceptAgr.Enabled = statusid != 2;
            btnCloseAgr.Enabled = statusid == 2;
            lblStatusName.Text = IpsGlobal.AnketaDictionaties.agreementStatus.SingleOrDefault(rec => rec.CodeI == statusid)?.Name;
            lblCommunityName.Text = anketaCompany?.Name;
        }

        #region * * * КОПІЮВАННЯ АДРЕС * * *

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
        private async void btnAddCommunity_Click(object sender, EventArgs e)
        {
            var query = new RightholdersQuery
            {
                SearchText = string.Empty,
                Page = 1,
                PageSize = 200,
            };
            waitingBar.StartWaiting();
            var result = await _presenter.GetAllAutorsView(query);
            var autorsList = result.List.DistinctBy(rec => rec.CustId).ToList();
            var addAuthorForm = new CommunityLimitsAddForm(autorsList, _customer.CustId);
            addAuthorForm.UpdateTotalPages(result.TotalItems);
            addAuthorForm.GetCommunityRightList += AddAutorForm_GetCommunityRightList;
            waitingBar.StopWaiting();
            if (addAuthorForm.ShowDialog() == DialogResult.OK)
            {
                SaveChanges(addAuthorForm.AuthorId, addAuthorForm.LimitRights);
            }
        }

        private void gvViewAutors_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
            if (e.Column.FieldName == "btnsEdit")
                return;

            var row = e.Row.DataBoundItem as CommunityAuthorsView;
            LimitationEditFormShow(row);
        }

        private void gvViewAutors_CommandCellClick(object sender, GridViewCellEventArgs e)
        {
            var row = e.Row.DataBoundItem as CommunityAuthorsView;
            LimitationEditFormShow(row);
        }

        private void LimitationEditFormShow(CommunityAuthorsView item)
        {
            var rights = GetCommunityRightList?.Invoke(item.CustId);
            var editAutorForm = new CommunityLimitsEditForm(item, rights, _customer.CustId);

            if (editAutorForm.ShowDialog() == DialogResult.OK)
            {
                SaveChanges(item.CustId, editAutorForm.LimitRights);
            }
        }

        private void SaveChanges(int authorId, List<CustCmRight> cmRights)
        {
            var result = SaveLimitedRights?.Invoke(_customer.CustId, authorId, cmRights) ?? false;
            MessageShow.ShowInfoAfterChanges(result);
            if (result)
            {
                _customer = UpdateCustomer?.Invoke(_customer.CustId);
                bsCommunityAuthorsView.DataSource = UpdateAutorsList?.Invoke();
                bsCommunityAuthorsView.ResetBindings(false);
                BeginBindings();
            }
        }
    }
}
