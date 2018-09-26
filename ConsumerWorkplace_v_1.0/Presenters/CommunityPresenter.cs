using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary;
using IpsViewComponentLibrary.CommunityControls;
using IpsViewComponentLibrary.ConsumerForms;
using IpsViewComponentLibrary.PartnerControls;

namespace ConsumerWorkplace_v_1._0.Presenters
{
    public class CommunityPresenter
    {
        private readonly CommunityService _service;
        private readonly CommunityControl _community;
        public CommunityPresenter(CommunityService service, CommunityControl community)
        {
            _service = service;
            _community = community;
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            _community.SetCommunityList += SetCommunityList;
        }

        // завантажити список спільнот на грід
        private List<CommunytiListView> SetCommunityList(int custId)
        {
            return _service.GetView<CommunytiListView>(typeof(CommunytiListView), "vTsk_1_ListCommunity", custId);
        }
    }
}
