using Newtonsoft.Json;
using SmRoPermitCommonLib;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SmartRoyaltyAccessAdmin
{
    public class PermitApiProxy
    {
        public static string UserLogin { get; set; }
        public static string UserPassword { get; set; }

        static HttpClient client = new HttpClient();

        private static ResponseT Put<ResponseT>(string uri, string json) where ResponseT: Response
        {
            using (var content = new StringContent(json, Encoding.UTF8, "application/json"))
            {
                HttpResponseMessage result = client.PutAsync($"{ConfigurationManager.AppSettings["BaseUri"]}api/{uri}", content).Result;
                string returnValue = result.Content.ReadAsStringAsync().Result;
                if (result.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception(returnValue);
                }
                var retVal = JsonConvert.DeserializeObject<ResponseT>(returnValue);
                if (retVal.Code == -1)
                    throw new Exception(retVal.Message);
                return retVal;
            }
        }

        private static ResponseT Post<ResponseT>(string uri, string json) where ResponseT : Response
        {
            using (var content = new StringContent(json, Encoding.UTF8, "application/json"))
            {
                HttpResponseMessage result = client.PostAsync($"{ConfigurationManager.AppSettings["BaseUri"]}api/{uri}", content).Result;
                string returnValue = result.Content.ReadAsStringAsync().Result;
                if (result.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception(returnValue);
                }
                var retVal = JsonConvert.DeserializeObject<ResponseT>(returnValue);
                if (retVal.Code == -1)
                    throw new Exception(retVal.Message);
                return retVal;
            }
        }

        private static ResponseT Get<ResponseT>(string uri) where ResponseT: Response
        {
            HttpResponseMessage result = client.GetAsync($"{ConfigurationManager.AppSettings["BaseUri"]}api/{uri}").Result;
            string returnValue = result.Content.ReadAsStringAsync().Result;
            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception(returnValue);
            }
            var retVal = JsonConvert.DeserializeObject<ResponseT>(returnValue);
            if (retVal.Code == -1)
                throw new Exception(retVal.Message);
            return retVal;
        }

        private static ResponseT Delete<ResponseT>(string uri) where ResponseT : Response
        {
            HttpResponseMessage result = client.DeleteAsync($"{ConfigurationManager.AppSettings["BaseUri"]}api/{uri}").Result;
            string returnValue = result.Content.ReadAsStringAsync().Result;
            if (result.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new Exception(returnValue);
            }
            var retVal = JsonConvert.DeserializeObject<ResponseT>(returnValue);
            if (retVal.Code == -1)
                throw new Exception(retVal.Message);
            return retVal;
        }

        public static RspLogin Login(string login, string password)
        {
            var rq = new Request { UserLogin = login, UserPassword = password };
            string json = JsonConvert.SerializeObject(rq);
            var rsp = Put<RspLogin>($"Login/{login}", json);
            return rsp;
        }

        public static RspLogin ChangePasswordAndLogin(string login, string password, string newPassword)
        {
            var rq = new RqChangePasswordAndLogin { UserLogin = login, UserPassword = password, NewPassword = newPassword };
            string json = JsonConvert.SerializeObject(rq);
            return Put<RspLogin>($"Login/Password/{login}", json);
        }

        public static List<User> GetAllUsers()
        {
            var rsp = Get<RspGetAllUsers>("Permit/Users");
            return rsp.Result;
        }

        public static List<Role> GetUserRoles(int userCodeI)
        {
            var rsp = Get<RspGetUserRoles>($"Permit/UserRoles/{userCodeI}");
            return rsp.Result;
        }

        public static void SaveUser(User user, List<Role> roles)
        {
            var rq = new RqSaveUser { UserLogin = UserLogin, UserPassword = UserPassword, User = user, Roles = roles };
            string json = JsonConvert.SerializeObject(rq);
            Post<Response>($"Permit/User/{user.CodeI}", json);
        }

        public static RspAddUser.AddUserResult AddUser(User user, List<Role> roles)
        {
            var rq = new RqAddUser { UserLogin = UserLogin, UserPassword = UserPassword, User = user, Roles = roles};
            string json = JsonConvert.SerializeObject(rq);
            return Put<RspAddUser>($"Permit/User", json).Result;
        }

        public static void DeleteUser(int codeI)
        {
            Delete<Response>($"Permit/User/{codeI}");
        }

        public static string ResetPassword(int codeI)
        {
            return Post<RspResetPassword>($"Permit/User/{codeI}/ResetPassword", "").NewPassword;
        }

        public static List<UserPermission> GetUserPermissions(int codeI)
        {
            var rsp = Get<RspGetUserPermissions>($"Permit/User/{codeI}/Permissions");
            return rsp.UserParmissions;
        }
    }
}
