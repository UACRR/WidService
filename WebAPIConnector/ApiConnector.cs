using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Configuration;
using System.IO;

namespace WebAPIConnector
{
    /// <summary>
    /// Клас підключення до WebAPI серверу додатків
    /// </summary>
    public class ApiConnector
    {
        private HttpClient client = new HttpClient();

        public ApiConnector( )
        {
            string Uri = configUrl();

            client.BaseAddress = new Uri(Uri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

        }

        private string configUrl()
        {
            string configName = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "workplace.config");
            ExeConfigurationFileMap configFile = new ExeConfigurationFileMap();
            configFile.ExeConfigFilename = configName;
            Configuration config = ConfigurationManager.OpenMappedExeConfiguration(configFile, ConfigurationUserLevel.None);

            string url = config.ConnectionStrings.ConnectionStrings["WebApiConnection"].ConnectionString;

            return url;

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
            List<T> list = array.Select(rec => {
                var item = rec.ToObject<T>();
                return item;
            }).ToList();

            return list;

        }

        public bool ApiAction<T>(string url, int rhId, List<T> inheritData)
        {
            string idUrl = $"{url}/{rhId}";
            StringContent content = new StringContent(JsonConvert.SerializeObject(inheritData), Encoding.UTF8, "application/json");
            var responce = client.PostAsync(idUrl, content).GetAwaiter().GetResult();
            return responce.IsSuccessStatusCode;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="url"></param>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public TResult ApiFunc<T, TResult>( string url, int id, List<T> data) where TResult : class
        {
            string idUrl = $"{url}/{id}";
            StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var responce = client.PostAsync(idUrl, content) .GetAwaiter().GetResult();
            if(responce.IsSuccessStatusCode == true)
            {
                string contentResponce = responce.Content.ReadAsStringAsync().Result;
                JObject retObj = JObject.Parse(contentResponce);

                return retObj.ToObject<TResult>();

            }

            return null;

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
        public bool NewItem<T>(string url, T data)
        {

            StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var result = client.PostAsync( url, content ).GetAwaiter().GetResult();

            return result.IsSuccessStatusCode;
        }

        /// <summary>
        /// змінити об'єкт на сервері додатків
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public bool UpdateItem<T>(string url, string id, T data)
        {

            string idUrl = $"{url}/{id}";
            StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            HttpResponseMessage result = client.PutAsync(idUrl, content).GetAwaiter().GetResult();

            var retCode = result.IsSuccessStatusCode;

            return retCode;
        }

        /// <summary>
        /// Видалити об'єкт на сервері додатків
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public bool DeleteItem(string url, string id)
        {

            string idUrl = $"{url}/{id}";
            var result = client.DeleteAsync(idUrl).GetAwaiter().GetResult();

            return result.IsSuccessStatusCode;
        }


    }
}
