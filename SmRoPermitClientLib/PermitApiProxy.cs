using Newtonsoft.Json;
using SmRoPermitCommonLib;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using LanguageLibrary;
using System.Text.RegularExpressions;

namespace SmRoPermitClientLib
{
    public class PermitApiProxy
    {
        public static string UserLogin { get; set; }
        public static string UserPassword { get; set; }

        public static string BaseUri { get; set; }

        public static bool IsPasswordStrong(string password)
        {
            return password.Length >= 8
                && Regex.IsMatch(password, @"[0-9]+(\.[0-9][0-9]?)?", RegexOptions.ECMAScript)
                && Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z]).+$", RegexOptions.ECMAScript)
                && Regex.IsMatch(password, @"[!,@,#,$,%,^,&,*,?,_,~,-,£,(,)]", RegexOptions.ECMAScript);
        }

        private static ResponseT MakeRequest<ResponseT>(string uri, string json, string requestType) where ResponseT : Response
        {
            using (HttpClient client = new HttpClient(new HttpClientHandler() { UseDefaultCredentials = true }))
            {
                if (!string.IsNullOrEmpty(UserPassword))
                {
                    var authToken = Encoding.ASCII.GetBytes($"{UserLogin}:{UserPassword}");
                    client.DefaultRequestHeaders.Add("Basic", Convert.ToBase64String(authToken));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic",
                            Convert.ToBase64String(authToken));
                }

                ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

                string fullUri = $"{BaseUri}api/{uri}";

                HttpResponseMessage result = null;
                if (requestType.Equals("Put"))
                {
                    using (var content = new StringContent(json, Encoding.UTF8, "application/json"))
                    {
                        result = client.PutAsync(fullUri, content).Result;
                    }
                }
                else if (requestType.Equals("Post"))
                {
                    using (var content = new StringContent(json, Encoding.UTF8, "application/json"))
                    {
                        result = client.PostAsync(fullUri, content).Result;
                    }
                }
                else if (requestType.Equals("Get"))
                {
                    result = client.GetAsync(fullUri).Result;
                }
                else if (requestType.Equals("Delete"))
                {
                    result = client.DeleteAsync(fullUri).Result;
                }
                else
                {
                    return null;
                }

                string returnValue = result.Content.ReadAsStringAsync().Result;
                if (result.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    throw new Exception("Application server returned error - " + result.StatusCode.ToString());
                }
                var retVal = JsonConvert.DeserializeObject<ResponseT>(returnValue);
                if (retVal.Code == -1)
                    throw new Exception(retVal.Message);
                else if (retVal.Code == -2)
                    throw new LoginNotUniqueException();
                return retVal;
            }
        }

        private static ResponseT Put<ResponseT>(string uri, string json) where ResponseT : Response
        {
            return MakeRequest<ResponseT>(uri, json, "Put");
        }

        private static ResponseT Post<ResponseT>(string uri, string json) where ResponseT : Response
        {
            return MakeRequest<ResponseT>(uri, json, "Post");
        }

        private static ResponseT Get<ResponseT>(string uri) where ResponseT : Response
        {
            return MakeRequest<ResponseT>(uri, null, "Get");
        }

        private static ResponseT Delete<ResponseT>(string uri) where ResponseT : Response
        {
            return MakeRequest<ResponseT>(uri, null, "Delete");
        }

        public static RspLogin Login()
        {
            var rsp = Get<RspLogin>($"Login");
            return rsp;
        }

        public static RspLogin ChangePasswordAndLogin(string login, string password, string newPassword)
        {
            var rq = new RqChangePasswordAndLogin { UserLogin = login, UserPassword = password, NewPassword = newPassword };
            string json = JsonConvert.SerializeObject(rq);
            return Put<RspLogin>($"Login/Password/{login}", json);
        }

        public static List<User> GetAllUsers(string lang)
        {
            var rsp = Get<RspGetAllUsers>($"Permit/Users?lang={lang}");
            return rsp.Result;
        }

        public static List<Role> GetUserRoles(int userCodeI, string lang)
        {
            var rsp = Get<RspGetUserRoles>($"Permit/UserRoles/{userCodeI}?lang={lang}");
            return rsp.Result;
        }

        public static void SaveUser(User user, List<Role> roles)
        {
            var rq = new RqSaveUser { User = user, Roles = roles };
            string json = JsonConvert.SerializeObject(rq);
            Post<Response>($"Permit/User/{user.CodeI}", json);
        }

        public static RspAddUser.AddUserResult AddUser(User user, List<Role> roles)
        {
            var rq = new RqAddUser { User = user, Roles = roles};
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
