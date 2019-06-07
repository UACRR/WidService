using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ipsFormsDesign.Services;
using ipsFormsDesign.ViewModels.Users;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ipsFormsDesign.Tests
{
    [TestClass]
    public class UserServiceTest
    {
        private UserService _userService;

        [TestInitialize]
        public void TestInit()
        {
            _userService = new UserService();
            //check on null state
            Assert.IsNotNull(_userService, "UserService is not initialized, state -null");
        }

        [TestMethod]
        public void TestGetUsersWithRoleFixation()
        {
            //save returned data
            List<UserViewModel> result = _userService.GetUsersWithRoleFixation();
            //check on null state result
            Assert.IsNotNull(result, "List<UserViewModel> data is null");
            //check collection on amount elements
            Assert.IsTrue(result.Count != 0, "collection List<UserViewModel> is empty");
        }

        [TestMethod]
        public void TestGetUsersWithRoleFixationAsync()
        {
            //save returned data
            Task<List<UserViewModel>> result = _userService.GetUsersWithRoleFixationAsync();
            //check on null state
            Assert.IsNotNull(result, "result Task<List<UserViewModel>> is null");
        }

        [TestMethod]
        public void TestGetById()
        {
            //default userId
            string userId = "8f1f2428-48b4-4209-a577-1fab339c0d82";
            //get data
            UserViewModel result = _userService.GetById(userId);
            //check on null state
            Assert.IsNotNull(result, "result is null");
        }
    }
}
