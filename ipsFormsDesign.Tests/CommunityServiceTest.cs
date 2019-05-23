using System;
using System.Collections.Generic;
using System.Linq;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Enums;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
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
            var query = new PaginateAndSearchQuery
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

        [TestMethod]
        public void TestGetView()
        {
            //result for 'vTsk_1_ListCommunity'
            List<object> resultCommunity = new List<object>();
            //result for 'vTsk_1_ListRHCommunity'
            List<object> resultRHCommunity = new List<object>();
            //default typeResult
            Type typeResult = typeof(object);
            //default viewName
            List<string> viewName = new List<string> { "vTsk_1_ListCommunity", "vTsk_1_ListRHCommunity" };
            //test for every 'view'
            foreach(string view in viewName)
            {
                switch(view)
                {
                    case "vTsk_1_ListCommunity":
                        resultCommunity = _communityService.GetView<object>(typeResult: typeResult, viewName: view, paramId: null, columnName: null);
                        break;
                    case "vTsk_1_ListRHCommunity":
                        resultRHCommunity = _communityService.GetView<object>(typeResult: typeResult, viewName: view, paramId: null, columnName: null);
                        break;
                }
            }
            //check on null state for 'vTsk_1_ListCommunity'
            Assert.IsNotNull(resultCommunity, "resultCommunity is null");
            //check on amount elements
            Assert.IsTrue(resultCommunity.Count != 0, "collection is empty");
            //check on null state for 'vTsk_1_ListRHCommunity'
            Assert.IsNotNull(resultRHCommunity, "vTsk_1_ListRHCommunity is null");
            //check on amount elements
            Assert.IsTrue(resultRHCommunity.Count != 0, "collection is empty");
        }

        //[TestMethod]
        //public void TestSaveCommunity()
        //{
        //    //result when add new Customer
        //    bool resultNew = false;
        //    //result when update Customer
        //    bool resultUpdate = false;
        //    //list of 'CustId'
        //    List<int> custIdPossible = new List<int> { 0, 1 };
        //    //for check action -> add
        //    Customer newCust = new Customer {
        //        CustId = 0,
        //        Status = 2,
        //        CustType = 1,
        //        UserId = "testUserId"
        //    };
        //    newCust.Company = new Company {
        //        CustId = 0,
        //        Version = 1
        //    };
        //    newCust.Community = new Community {
        //        CustId = 0,
        //        InterCode = "sd",
        //        InnerCode = "sd"
        //    };
        //    newCust.Community.AgreementAddCommunity = new ObservableListSource<AgreementAddCommunity> {
        //    new AgreementAddCommunity {
        //        AgrId = 134,
        //        Version = 1,
        //        CustId = 0
        //    } };
        //    //for check action -> update
        //    Customer updateCust = new Customer
        //    {
        //        CustId = 134,
        //        Status = 2,
        //        CustType = 3,
        //        UserId = "testUserId"
        //    };
        //    updateCust.Company = new Company
        //    {
        //        CustId = 134,
        //        Version = 1
        //    };
        //    updateCust.Community = new Community
        //    {
        //        CustId = 0,
        //        InterCode = "sd",
        //        InnerCode = "sd"
        //    };
        //    updateCust.Community.AgreementAddCommunity = new ObservableListSource<AgreementAddCommunity> {
        //    new AgreementAddCommunity {
        //        AgrId = 134,
        //        Version = 1,
        //        CustId = 0
        //    } };
        //    //check every action
        //    foreach (int custId in custIdPossible)
        //    {
        //        //get data
        //        switch(custId)
        //        {
        //            case 0:
        //                resultNew = _communityService.SaveCommunity(newCust);
        //                break;
        //            case 1:
        //                resultUpdate = _communityService.SaveCommunity(updateCust);
        //                break;
        //        }
        //    }
        //    //check result success after Add new Customer
        //    Assert.IsTrue(resultNew, "customer is not added");
        //    //check result success after update Customer
        //    Assert.IsTrue(resultUpdate, "customer is not updated");
        //}

        [TestMethod]
        public void TestSaveLimitRights()
        {
            //default cmCustId
            int cmCustId = 138;
            //default custId
            int custId = 7;
            //listObj
            List<CustCmRight> listObj = new List<CustCmRight> {
                new CustCmRight {
                    CustId = 7,
                    CRkindCode = 1,
                    CmCustId = 138
                }
            };
            //save data
            bool result = _communityService.SaveLimitRights(cmCustId, custId, listObj);
            //check on success
        }

        [TestMethod]
        public void TestGetComunity()
        {
            //default custId
            int custId = 7;
            //get data
            Customer result = _communityService.GetComunity(custId);
            //check on null state
            Assert.IsNotNull(result, "result is null");
        }

        [TestMethod]
        public void TestGetCommunityRightList()
        {
            //default custId
            int custId = 7;
            //get data
            List<CustCmRight> result = _communityService.GetCommunityRightList(custId);
            //check on null state
            Assert.IsNotNull(result, "result is null");
            //check on amount elements
            Assert.IsTrue(result.Count != 0, "collection is empty");
        }

        [TestMethod]
        public void TestChangeStatusAgr()
        {
            //default communityId
            int communityId = 136;
            //default status
            CPartnerObjectStatus status = (CPartnerObjectStatus)2;
            //change data
            bool result = _communityService.ChangeStatusAgr(communityId, status);
            //check on success
        }
    }
}
