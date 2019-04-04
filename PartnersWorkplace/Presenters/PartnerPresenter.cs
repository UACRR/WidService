using System.Collections.Generic;
using ipsFormsDesign.Enums;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary.Extensions;
using IpsViewComponentLibrary.PartnerControls;

namespace PartnersWorkplace.Presenters
{
    class PartnerPresenter
    {
        private readonly PartnerService _service;
        private readonly PartnerControl _partner;
        public PartnerPresenter(PartnerControl partnerControl)
        {
            _service = PartnerService.GetInstance();
            _partner = partnerControl;
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            _partner.GetPartnersView += GetPartnersView;
            _partner.LoadData();
            _partner.OnCreateNewCustomerNeed += CreateNewCustomer;
            _partner.OnSaveCustomer += SaveCustomer;
            _partner.OnSaveAgreement += SaveAgreement;
            _partner.GetPartnerById += GetPartner;
            _partner.GetFreeClientList += GetClientsView;
            _partner.GetPartnerClientList += GetPartnerClientsView;
            _partner.OnAddClientToPartner += AddClientToPartner;
            _partner.OnDetachClientInPartner += _partner_OnDetachClientInPartner;
            _partner.ChangeStatusAgr += AgreementPartnerStatusChange;
        }

        private bool SaveAgreement(AgreementAddPartner saveObj)
        {
            return _service.UpdateAgreement(saveObj);
        }

        private bool _partner_OnDetachClientInPartner(int clientId, int partnerId)
        {
            return _service.RemovePartnerForCustomer(clientId, partnerId);
        }

        private bool AddClientToPartner(int clientId, int partnerId)
        {
            return _service.SetPartnerForCustomer(clientId, partnerId);
        }

        private List<PartnerView> GetPartnersView()
        {
            return _service.GetView(typeof(PartnerView), "vTsk_6_ListPartner", null).ToListOfType<PartnerView>();
        }

        private List<PartnerClientListView> GetPartnerClientsView(int custId)
        {
            return _service.GetView(typeof(PartnerClientListView), "vTsk_6_ListPClient", custId).ToListOfType<PartnerClientListView>();
        }

        private List<PartnerAllFreeClientsView> GetClientsView(int custid)
        {
            return _service.GetView(typeof(PartnerAllFreeClientsView), "vTsk_6_ListFreeCln", null).ToListOfType<PartnerAllFreeClientsView>();
        }

        //створити Customer
        private Customer CreateNewCustomer(int customerType)
        {
            return _service.GetPartnerTemplate(customerType);
        }

        //зберегти Customer
        private bool SaveCustomer(Customer customer)
        {
            return _service.SavePartner(customer);
        }

        //отримати представника по його ID
        private Customer GetPartner(int custId)
        {
            return _service.GetPartner(custId);
        }

        //зміна статусу договору
        private bool AgreementPartnerStatusChange(int partnerId, CPartnerObjectStatus status)
        {
            return _service.AgreementPartnerStatusChange(partnerId, status);
        }
    }
}
