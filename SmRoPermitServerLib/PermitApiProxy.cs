using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SmRoPermitServerLib
{
    /*
    public class PermitApiProxy
    {
        public static string UserLogin { get; set; }
        public static string UserPassword { get; set; }

        private static ResponseT Get<ResponseT>(string uri) where ResponseT : Response
        {
            using (HttpClient client = new HttpClient())
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
        }

        public static List<UserPermission> GetUserPermissions(int codeI)
        {
            var rsp = Get<RspGetUserPermissions>($"Permit/AllPermissions");
            return rsp.UserParmissions;
        }
    }
    */
}
