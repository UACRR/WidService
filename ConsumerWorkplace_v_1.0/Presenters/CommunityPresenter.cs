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
            _community.GetTemplateCommunity += CreateNewCommunity;
            _community.SaveCommunity += SaveCommunity;
            _community.GetCommunity += GetCommunity;
            _community.GetCommunityAutorsList += GetCommunityAutorsView;
            _community.GetAutorsList += GetAllAutorsView;
        }

        private Customer GetCommunity(int custId)
        {
            return _service.GetComunity(custId);
        }

        /// <summary>
        /// збереження спільноти
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        private bool SaveCommunity(Customer customer)
        {
            return _service.SaveCommunity(customer);
        }

        // завантажити список спільнот на грід
        private List<CommunityListView> SetCommunityList(int paramId)
        {
            return _service.GetView<CommunityListView>(typeof(CommunityListView), "vTsk_1_ListCommunity");
        }

        private Customer CreateNewCommunity()
        {
            return _service.GetTemplateComunity();
        }

        private List<CommunityAutorsListView> GetCommunityAutorsView(int cmId)
        {
            return _service.GetView<CommunityAutorsListView>(typeof(CommunityAutorsListView), "vTsk_1_ListRHCommunity", cmId, "cmCustId");
        }

        private List<CommunityAutorsListView> GetAllAutorsView()
        {
            return _service.GetView<CommunityAutorsListView>(typeof(CommunityAutorsListView), "vTsk_1_ListRHCommunity");
        }
    }
}
