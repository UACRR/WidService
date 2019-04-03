using System;
using System.Linq;
using ipsFormsDesign.Dictionary;
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
            
            Assert.IsNotNull(result);
            Assert.AreEqual(225, result.List.Count);
        }
    }
}
