using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
            List<T> list = array.Select( rec => rec.ToObject<T>()).ToList();
            
            return list;
        }

       


        /// <summary>
        /// Получити об'єкт з серверу додатків по ID
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public T GetItemById<T>(string url, string id )
        {
            string idUrl = $"{url}/{id}";
            string retApiString = client.GetStringAsync(idUrl).GetAwaiter().GetResult();
            JObject retObj = JObject.Parse(retApiString);

            return retObj.ToObject<T>();
        }


        /// <summary>
        /// Створити об'єкт на сервері додатків
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public HttpResponseMessage NewItem<T>(string url, T data)
        {

            StringContent content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var result = client.PostAsync( url, content ).GetAwaiter().GetResult();

            return result;
        }

        /// <summary>
        /// змінити об'єкт на сервері додатків
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public HttpResponseMessage UpdateItem<T>(string url, string id, T data)
        {

            string idUrl = $"{url}/{id}";
            StringContent content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var result = client.PutAsync(idUrl, content).GetAwaiter().GetResult();

            return result;
        }

        /// <summary>
        /// Видалити об'єкт на сервері додатків
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public HttpResponseMessage DeleteItem<T>(string url, string id)
        {

            string idUrl = $"{url}/{id}";
            var result = client.DeleteAsync(idUrl).GetAwaiter().GetResult();

            return result;
        }


    }
}
