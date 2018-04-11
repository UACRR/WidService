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

        /// <summary>
        /// Получити список об'єктів з серверу додатків
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public List<T> GetList<T>( string url )
        {
            string retApiString = client.GetStringAsync(url).GetAwaiter().GetResult();
            JArray array = JArray.Parse(retApiString);

            List<T> list = array.Select( rec => rec.ToObject<T>()).ToList<T>();

            return list;
        }
    }
}
