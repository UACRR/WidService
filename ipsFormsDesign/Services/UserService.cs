using ipsFormsDesign.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIConnector;

namespace ipsFormsDesign.Services
{
    public class UserService
    {
        private readonly ApiConnector _webApi;

        public UserService()
        {
            _webApi = new ApiConnector();
        }

        public List<UserViewModel> GetUsersWithRoleFixation()
        {
            var list = _webApi.GetList<UserViewModel>("users/byroles/fixation");
            return list;
        }

        public Task<List<UserViewModel>> GetUsersWithRoleFixationAsync()
        {
            return Task.Factory.StartNew(() => GetUsersWithRoleFixation());
        }

        public UserViewModel GetById(string userId)
        {
            var item = _webApi.GetItemById<UserViewModel>("users", userId);
            return item;
        }
    }
}
