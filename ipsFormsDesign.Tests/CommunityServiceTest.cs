using System;
using System.Linq;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ipsFormsDesign.Tests
{
    [TestClass]
    public class CommunityServiceTest
    {
        private readonly CommunityService _communityService = CommunityService.GetInstance();

        [TestMethod]
        public void GetCommunityAuthorsView_Test()
        {
            var query = new RightholdersQuery
            {
                SearchText = string.Empty,
                Page = 1,
                PageSize = 225,
            };
            var result = _communityService.GetCommunityAuthorsView<RightholdersResponse>("vTsk_1_ListRHCommunity", query);
            
            Assert.IsNotNull(result, "vTsk_1_ListRHCommunity");
            Assert.AreEqual(225, result.List.Count);
        }

        [TestMethod]
        public void GetTemplateComunity_test()
        {
            var result = _communityService.GetTemplateComunity();
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetCommunityRightList_and_GetView_test()
        {
            var community = _communityService.GetView<CommunityListView>(typeof(CommunityListView), "vTsk_1_ListCommunity");
            Assert.IsNotNull(community, "vTsk_1_ListCommunity");

            if (community.Any())
            {
                // ReSharper disable once PossibleNullReferenceException
                var id = community.FirstOrDefault().CustId;
                var result = _communityService.GetCommunityRightList(id);
                Assert.IsNotNull(result);
            }
        }
    }
}
