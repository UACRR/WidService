using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ipsFormsDesign.Enums;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IpsViewComponentLibrary.CommunityControls;
using IpsViewComponentLibrary.ConsumerForms;
using IpsViewComponentLibrary.PartnerControls;

namespace RightholderWorkplace.Presenters
{
    public class CommunityPresenter
    {
        private readonly CommunityService _service;
        private readonly CommunityControl _community;
        public CommunityPresenter(CommunityControl community)
        {
            _service = CommunityService.GetInstance();
            _community = community;
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            _community.SetCommunityList += SetCommunityList;
            _community.GetTemplateCommunity += CreateNewCommunity;
            _community.SaveCommunity += SaveCommunity;
            _community.SaveAgreementChanges += SaveAgreementChanges;
            _community.GetCommunity += GetCommunity;
            _community.GetCommunityAutorsList += GetCommunityAutorsView;
            _community.GetCommunityRightList += GetCommunityRightList;
            _community.SaveLimitRights += SaveLimitRights;
            _community.ChangeStatusAgr += ChangeStatusAgr;
        }

        private bool ChangeStatusAgr(int communityId, CPartnerObjectStatus status)
        {
            return _service.ChangeStatusAgr(communityId, status);
        }

        private bool SaveLimitRights(int cmCustId, int custId, List<CustCmRight> listObj)
        {
            return _service.SaveLimitRights(cmCustId, custId, listObj);
        }

        private List<CustCmRight> GetCommunityRightList(int custId)
        {
            return _service.GetCommunityRightList(custId);
        }

        private Customer GetCommunity(int custId)
        {
            return _service.GetComunity(custId);
        }

        /// <summary>
        /// Збереження товариства
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        private bool SaveCommunity(Customer customer)
        {
            return _service.SaveCommunity(customer);
        }

        /// <summary>
        /// Збереження договору товариства
        /// </summary>
        /// <param name="arg"></param>
        /// <returns></returns>
        private bool SaveAgreementChanges(AgreementAddCommunity arg)
        {
            return _service.SaveAgreement(arg);
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

        private List<CommunityAuthorsView> GetCommunityAutorsView(int cmId)
        {
            return _service.GetView<CommunityAuthorsView>(typeof(CommunityAuthorsView), "vTsk_1_ListRHCommunity", cmId, "cmCustId");
        }
    }
}
