using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Configuration;
using System.IO;
using System.Web;
using System.Net;

namespace WebAPIConnector
{
    /// <summary>
    /// Клас підключення до WebAPI серверу додатків
    /// </summary>
    public class ApiConnector
    {
        private readonly HttpClient client;
        public string ErrorCode { get; private set; }
        public string ErrorMessage { get; private set; }

        public ApiConnector()
        {
            string Uri = configUrl();
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            client = new HttpClient(handler);

            client.BaseAddress = new Uri(Uri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            client.Timeout = TimeSpan.FromSeconds(1200);
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

        private string AsQueryString(IEnumerable<KeyValuePair<string, string>> parameters)
        {
            if (!parameters.Any())
                return "";

            var builder = new StringBuilder("?");

            var separator = "";
            foreach (var kvp in parameters.Where(kvp => kvp.Value != null))
            {
                builder.AppendFormat("{0}{1}={2}", separator, WebUtility.UrlEncode(kvp.Key), WebUtility.UrlEncode(kvp.Value.ToString()));

                separator = "&";
            }

            return builder.ToString();
        }

        /// <summary>
        /// Получити список об'єктів з серверу додатків
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="listParam"></param>
        /// <returns></returns>
        public List<T> GetList<T>(string url, params KeyValuePair<string, string>[] listParam)
        {
            string runUrl = url;
            try
            {
                if (listParam.Any())
                    runUrl = string.Concat(runUrl, AsQueryString(listParam));

                string retApiString;
                retApiString = client.GetStringAsync(runUrl).GetAwaiter().GetResult();

                JArray array = JArray.Parse(retApiString);
                List<T> list = array.Select(rec =>
                {
                    var item = rec.ToObject<T>();
                    return item;
                }).ToList();

                return list;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Получити список об'єктів з серверу додатків
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public List<object> GetTypedList(Type typeResult, string url, params KeyValuePair<string, string>[] listParam)
        {
            string runUrl = url;
            if (listParam.Count() > 0)
                runUrl = string.Concat(runUrl, AsQueryString(listParam));

            string retApiString = client.GetStringAsync(runUrl).GetAwaiter().GetResult();
            JArray array = JArray.Parse(retApiString);
            List<object> list = array.Select(rec =>
            {
                var item = rec.ToObject(typeResult);
                return item;
            }).ToList();

            return list;

        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public List<T> GetListAgreement<T>(string url)
        {
            string runUrl = url;

            string retApiString = client.GetStringAsync(runUrl).GetAwaiter().GetResult();
            JArray array = JArray.Parse(retApiString);
            List<T> list = array.Select(rec =>
            {
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
        public TResult ApiFunc<T, TResult>(string url, int id, List<T> data) where TResult : class
        {
            string idUrl = $"{url}/{id}";
            StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var responce = client.PostAsync(idUrl, content).GetAwaiter().GetResult();
            if (responce.IsSuccessStatusCode == true)
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
        public T GetItemById<T>(string url, string id)
        {
            string idUrl = !string.IsNullOrEmpty(id) ? $"{url}/{id}" : $"{url}";

            try
            {
                HttpResponseMessage response = client.GetAsync(idUrl).GetAwaiter().GetResult();
                if (response.IsSuccessStatusCode)
                {
                    string retApiString = response.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                    if (retApiString == "null")
                        retApiString = string.Empty;


                    if (string.IsNullOrEmpty(retApiString))
                        return default(T);

                    JObject retObj = JObject.Parse(retApiString);

                    return retObj.ToObject<T>();
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                    return default(T);
                else
                    return default(T);
            }
            catch
            {
                // some code
                throw;
            }
        }


        /// <summary>
        /// Отримати об'єкт з серверу додатків по ID
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public T GetItemByIdWithParam<T>(string url, string id, params KeyValuePair<string, string>[] listParam)
        {
            string idUrl = string.IsNullOrEmpty(id) ? url : $"{url}/{id}";
            if (listParam.Length > 0)
                idUrl = string.Concat(idUrl, AsQueryString(listParam));

            string retApiString = client.GetStringAsync(idUrl).GetAwaiter().GetResult();
            if (retApiString == "null")
                retApiString = string.Empty;


            if (string.IsNullOrEmpty(retApiString))
                return default(T);

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
            var result = client.PostAsync(url, content).GetAwaiter().GetResult();

            return result.IsSuccessStatusCode;
        }

        public T NewItemWithReturn<T>(string url, T data) where T : class
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var result = client.PostAsync(url, content).GetAwaiter().GetResult();

            if (result.IsSuccessStatusCode)
            {
                return result.Content.ReadAs<T>();
            }
            else
                return null;
        }

        public T NewItemWithResult<T>(string url, T data) where T : class
        {
            var result = client.PostAsJson(url, data);

            if (result.IsSuccessStatusCode)
            {
                return result.Content.ReadAs<T>();
            }
            else
                return null;
        }

        public List<T> NewListItemWithResult<T>(string url, List<T> data) where T : class
        {
            var result = client.PostAsJson(url, data);

            if (result.IsSuccessStatusCode)
            {
                return result.Content.ReadAsList<T>();
            }
            else
                return null;
        }

        public T UpdateItemWithResult<T>(string url, string id, T data) where T : class
        {
            string idUrl = $"{url}/{id}";

            var result = client.PutAsJson(idUrl, data);

            if (result.IsSuccessStatusCode)
            {
                return result.Content.ReadAs<T>();
            }
            else
                return null;
        }


        /// <summary>
        /// Змінити об'єкт на сервері додатків
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="id"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public bool UpdateItem<T>(string url, string id, T data)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            string idUrl = string.IsNullOrEmpty(id) ? url : $"{url}/{id}";

            HttpResponseMessage result = null;
            if (data != null)
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(data, settings), Encoding.UTF8, "application/json");
                result = client.PutAsync(idUrl, content).GetAwaiter().GetResult();
            }
            else
            {
                result = client.PutAsync(idUrl, null).GetAwaiter().GetResult();
            }

            var msg = result.RequestMessage;

            var retCode = result.IsSuccessStatusCode;
            return retCode;
        }

        /// <summary>
        /// змінити об'єкт на сервері додатків
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public bool UpdateItemWithResult<T>(string url, string id, T data, out T retObject)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            StringContent content = new StringContent(JsonConvert.SerializeObject(data, settings), Encoding.UTF8, "application/json");
            HttpResponseMessage result;

            if (string.IsNullOrEmpty(id) || id == "0")
            {
                result = client.PostAsync(url, content).GetAwaiter().GetResult();
            }
            else
            {
                string idUrl = $"{url}/{id}";
                result = client.PutAsync(idUrl, content).GetAwaiter().GetResult();
            }

            var retCode = result.IsSuccessStatusCode;
            if (retCode)
            {
                var jobject = JObject.Parse(result.Content.ReadAsStringAsync().GetAwaiter().GetResult());
                retObject = jobject.ToObject<T>();
            }
            else
                retObject = default(T);
            return retCode;
        }

        /// <summary>
        /// змінити об'єкт на сервері додатків
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public bool UpdateListItemWithReturn<T>(string url, string id, List<T> data, out List<T> retData)
        {

            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            StringContent content = new StringContent(JsonConvert.SerializeObject(data, settings), Encoding.UTF8, "application/json");
            HttpResponseMessage result;

            if (string.IsNullOrEmpty(id) || id == "0") // create
            {
                result = client.PostAsync(url, content).GetAwaiter().GetResult();
            }
            else // Update
            {
                string idUrl = $"{url}/{id}";
                result = client.PutAsync(idUrl, content).GetAwaiter().GetResult();
            }
            var retCode = result.IsSuccessStatusCode;
            if (retCode == true)
            {
                var retString = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                var jarray = JArray.Parse(retString);
                retData = jarray.ToObject<List<T>>();

                return retCode;
            }

            retData = null;
            return retCode;
        }

        /// <summary>
        /// змінити об'єкт на сервері додатків
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public bool UpdateItemWithReturn<T>(string url, string id, T data, out T retData)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            string idUrl = url;

            StringContent content = new StringContent(JsonConvert.SerializeObject(data, settings), Encoding.UTF8, "application/json");
            HttpResponseMessage result;
            // Редагування
            if (!string.IsNullOrEmpty(id) || id == "0")
            {
                idUrl = string.Concat(idUrl, "/", id);
                result = client.PutAsync(idUrl, content).GetAwaiter().GetResult();
            }
            else // Create
            {
                result = client.PostAsync(idUrl, content).GetAwaiter().GetResult();

            }

            var retCode = result.IsSuccessStatusCode;
            if (retCode)
            {
                var retString = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                var jobject = JObject.Parse(retString);
                retData = jobject.ToObject<T>();
            }
            else
                retData = default(T);

            return retCode;
        }

        /// <summary>
        /// змінити об'єкт на сервері додатків
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public bool PatchItemWithReturn<T>(string url, string id, T data, out T retData)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };
            string idUrl = url;

            StringContent content = new StringContent(JsonConvert.SerializeObject(data, settings), Encoding.UTF8, "application/json");
            HttpResponseMessage result;
            // Редагування
            idUrl = string.Concat(idUrl, "/", id);
            result = client.PatchAsync(idUrl, content).GetAwaiter().GetResult();

            var retCode = result.IsSuccessStatusCode;
            if (retCode)
            {
                var retString = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                var jobject = JObject.Parse(retString);
                retData = jobject.ToObject<T>();
            }
            else
                retData = default(T);

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

        /// <summary>
        /// Збереження файлу в папці споживача
        /// </summary>
        /// <param name="url"></param>
        /// <param name="fileName"></param>
        /// <param name="fileStream"></param>
        public async Task uploadFile(string url, string fileName, string comment, Stream fileStream)
        {
            using (var content = new MultipartFormDataContent())
            {
                content.Headers.ContentType.MediaType = "multipart/form-data";

                // fileContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("text/pot"); // "gettext" POT format

                content.Add(new StringContent(comment), "comment");
                content.Add(new StreamContent(fileStream), "file", fileName);


                var statusResult = await client.PostAsync(url, content);
                var statusString = await statusResult.Content.ReadAsStringAsync();
            }
        }

        /// <summary>
        /// Отримати файл із папки Споживача
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<Stream> downloadFile(string url)
        {
            Stream stream = null;
            try
            {
                stream = await client.GetStreamAsync(url);
                return stream;
            }
            catch
            {
                stream?.Dispose();
                throw;
            }
            finally
            {
                // stream?.Dispose();
            }
        }

        /// <summary>
        /// Змінити 'представника' для 'клієнта'
        /// </summary>
        /// <param name="url"></param>
        /// <param name="clientId"></param>
        /// <param name="partnerId"></param>
        /// <param name="oldClientId"></param>
        /// <returns></returns>
        public bool ChangePartnerForCustomer(string url, int clientId, int partnerId, int? oldClientId = null)
        {
            string fullUrl = "partner/" + $"{clientId}/{url}/{partnerId}";
            HttpResponseMessage result = null;
            switch (url)
            {
                case "insert":
                    result = client.PostAsync(fullUrl, null).GetAwaiter().GetResult();
                    break;
                case "update":
                    fullUrl += "/" + oldClientId;
                    result = client.PutAsync(fullUrl, null).GetAwaiter().GetResult();
                    break;
                case "remove":
                    result = client.DeleteAsync(fullUrl).GetAwaiter().GetResult();
                    break;
            }
            return result?.IsSuccessStatusCode ?? false;
        }


    }
}
