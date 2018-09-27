using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary;
using IpsViewComponentLibrary.ConsumerForms;
using IpsViewComponentLibrary.PartnerControls;

namespace ConsumerWorkplace_v_1._0.Presenters
{
    class PartnerPresenter
    {
        private readonly ConsumerService _service;
        private readonly PartnerControl _partner;
        public PartnerPresenter(ConsumerService service, PartnerControl partner)
        {
            _service = service;
            _partner = partner;
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            _partner.GetPartnersView += GetPartnersView;
            _partner.LoadData();
            _partner.OnCreateNewCustomerNeed += CreateNewCustomer;
            _partner.OnSaveCustomer += SaveCustomer;
            _partner.GetPartnerById += GetPartner;
            _partner.GetFreeClientList += GetClientsView;
            _partner.GetPartnerClientList += GetPartnerClientsView;
            _partner.OnAddClientToPartner += AddClientToPartner;
            _partner.OnDetachClientInPartner += _partner_OnDetachClientInPartner;
            _partner.ChangeStatusAgr += AgreementPartnerStatusChange;
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
            return _service.getBRView(typeof(PartnerView), "vTsk_6_ListPartner", null).ToListOfType<PartnerView>();
        }

        private List<PartnerClientListView> GetPartnerClientsView(int custId)
        {
            return _service.getBRView(typeof(PartnerClientListView), "vTsk_6_ListPClient", custId).ToListOfType<PartnerClientListView>();
        }

        private List<PartnerAllFreeClientsView> GetClientsView(int custid)
        {
            return _service.getBRView(typeof(PartnerAllFreeClientsView), "vTsk_6_ListFreeCln", null).ToListOfType<PartnerAllFreeClientsView>();
        }

        //створити Customer
        private Customer CreateNewCustomer(int customerType)
        {
            var customer = _service.GetPartnerTemplate(customerType);
            return customer;
        }

        //зберегти Customer
        private bool SaveCustomer(Customer customer)
        {
            var relust = _service.SavePartner(customer);
            //UpdateData(customer.CustId);
            return relust;
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
