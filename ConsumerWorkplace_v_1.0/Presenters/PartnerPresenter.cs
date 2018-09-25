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
        private readonly CabinetBigRightForm _cabinetBigRightForm;
        private readonly CabinetSmallRightForm _cabinetSmallRightForm;
        public PartnerPresenter(ConsumerService service, PartnerControl partner, CabinetBigRightForm cabinetBigRightForm, CabinetSmallRightForm cabinetSmallRightForm)
        {
            _service = service;
            _partner = partner;
            _cabinetBigRightForm = cabinetBigRightForm;
            _cabinetSmallRightForm = cabinetSmallRightForm;
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
            _partner.OnLoadCustomerCabinetNeed += LoadCustomerCabinet;
        }

        private void LoadCustomerCabinet(int id)
        {
            // великі права
            var customer = _service.GetData(id);
            var mainGridView = _service.getMainViewBR().SingleOrDefault(rec=>rec.CustId == id);//- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - view основного гріда
            var generalAgrView = _service.getBRView(typeof(GeneralAgreementBigRightView), "vTSK_1_BRMaster", id).ToListOfType<GeneralAgreementBigRightView>(); // - - - - генеральні угоди
            var licenseView = _service.getBRView(typeof(LicenseAgreementBigRightView), "vTsk_vBRLicense", id).ToListOfType<LicenseAgreementBigRightView>();// - - - - - - ліцензії
            var requestView = _service.getBRView(typeof(RequestsOrReferenceBigRightView), "vTsk_1_BRBid", id).ToListOfType<RequestsOrReferenceBigRightView>(); //- - - - - - заявки
            var referenceView = _service.getBRView(typeof(RequestsOrReferenceBigRightView), "vTsk_1_BRNotice", id).ToListOfType<RequestsOrReferenceBigRightView>(); // - - - довідки
            var licAutorsView = _service.getBRView(typeof(AuthorsForLicenseBigRightView), "vTsk_1_BRBidAuthors", id).ToListOfType<AuthorsForLicenseBigRightView>(); // - - автори для всіх типів ліцензій
            var moneyUnattachedView = _service.getBRView(typeof(UnattachedMoneyView), "vTsk_1_MoneyUndescrib", id).ToListOfType<UnattachedMoneyView>(); // - - - незакріплені кошти користувачів великих прав
            var ratedListMainView = _service.getBRView(typeof(RatedListMainBigRightView), "vTSK_1_BRRegister", id).ToListOfType<RatedListMainBigRightView>(); // - - - Р/Л основні дані
            var rlSpectacleView = _service.getBRView(typeof(RatedListSpectacleBigRightView), "vTsk_1_BRAuthorsDistributed", null).ToListOfType<RatedListSpectacleBigRightView>();// Р/Л вистави

            _cabinetBigRightForm.cabinet.SetAllLoadData(customer, mainGridView, generalAgrView, licenseView, requestView, referenceView, licAutorsView, moneyUnattachedView, ratedListMainView, rlSpectacleView);
            if (!_cabinetBigRightForm.Visible)
                _cabinetBigRightForm.Show();

            _cabinetBigRightForm.cabinet.UpdateCurentTab(CabinetTabType.Anketa);

            ////малі права

            //_cabinetSmallRightForm.SetCustomer(_service.GetData(id));
            //_cabinetSmallRightForm.cabinet.pagesControl.reportsControl.Customer = _service.GetRatedListForCust(id);
            //if (!_cabinetSmallRightForm.Visible)
            //    _cabinetSmallRightForm.Show();

            //GC.Collect();
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
