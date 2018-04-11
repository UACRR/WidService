using ipsFormsDesign.Definition;
using ipsmedserviceapp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace sysAdminwp.model
{
    public class ApiCategory : IFormModel<Category>
    {
        static HttpClient client;
        private string appUrl = @"api/dictionary/category";

        public ApiCategory()
        {
            client = new HttpClient();
        }

        public async Task<List<Category>> getData()
        {
            client.BaseAddress = new Uri("http://localhost:54867/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage responce = await client.GetAsync(appUrl);
            List<Category> retList = null;
            if ( responce.IsSuccessStatusCode )
            {
                var retDataString = await responce.Content.ReadAsStringAsync();
                var jsonList = JObject.Parse(retDataString);
                retList = jsonList.ToObject<List<Category>>();
            }

            return retList;
        }
    }
}
