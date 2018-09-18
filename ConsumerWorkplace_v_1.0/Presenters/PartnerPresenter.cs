using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary;
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
        }

        private List<PartnerView> GetPartnersView()
        {
            return _service.getBRView(typeof(PartnerView), "vTsk_6_ListPartner", null).ToListOfType<PartnerView>();
        }
    }
}
