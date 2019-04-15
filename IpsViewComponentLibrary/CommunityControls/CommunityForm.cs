using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ipsFormsDesign.Model;
using IpsViewComponentLibrary.Extensions;
using Telerik.WinControls.UI;

namespace IpsViewComponentLibrary.CommunityControls
{
    public partial class CommunityForm : RadForm
    {
        private readonly Customer _customer;

        public CommunityForm(Customer customer)
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            _customer = customer;
            DialogResult = DialogResult.None;
            ctrlTabNavigation.SetDefaultState(pageView, FLoadType.Create);
            ctrlContactPerson.UnsubscribePhoneVldt();
            ctrlClientName.SetLabelName("Назва товариства: ");
            SetBindings();
        }

        private void SetBindings()
        {
            bsCommunity.DataSource = _customer.Community;

            var anketaCompany = _customer.Company.AnketaCompany.SingleOrDefault();
            var agreement = _customer.Community.AgreementAddCommunity.SingleOrDefault();

            //спільнота
            ctrlClientName.DataSource = anketaCompany;

            // контактна особа
            var relEmployeeContact = _customer.Company.RelEmployee.SingleOrDefault(rec => rec.PositionCode == 3);
            if (relEmployeeContact == null)
                _customer.Company.RelEmployee.Add(new RelEmployee { PositionCode = 3, Empl = new Employee() });

            var employeeContact = _customer.Company.RelEmployee.SingleOrDefault(rec => rec.PositionCode == 3);

            var relEmployeeHead = _customer.Company.RelEmployee.SingleOrDefault(rec => rec.PositionCode == 1);
            if (relEmployeeHead == null)
                _customer.Company.RelEmployee.Add(new RelEmployee { PositionCode = 1, Empl = new Employee() });

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
            ctrlAddressJu.CountryDataMember = "JaCountry";;
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

        }

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

    }
}
