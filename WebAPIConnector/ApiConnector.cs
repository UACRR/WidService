using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WebAPIConnector
{
    /// <summary>
    /// Клас підключення до WebAPI серверу додатків
    /// </summary>
    public class ApiConnector
    {
        private HttpClient client = new HttpClient();

        public ApiConnector( string api)
        {
            client.BaseAddress = new Uri(api);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public List<T> GetList<T>( string url )
        {
            string retApiString = client.GetStringAsync(url).GetAwaiter().GetResult();
            JArray array = JArray.Parse(retApiString);
            // List<object> list = JObject.Parse(retApiString).ToObject<List<object>>();
            List<T> list = new List<T>();

            foreach( var item in array )
            {
                T newItem = item.ToObject<T>();
                list.Add(newItem);
            }
            return list;
        }
    }
}
