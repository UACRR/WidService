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
using System.Net;
//using IpsCommonTypes.Types;
//using IpsCommonTypes.Enums;
//using IpsCommonTypes.Wrappers;
using System.Windows;
using System.Threading;
using System.Windows.Documents;

namespace WebAPIConnector
{
    /// <summary>
    /// Клас підключення до WebAPI серверу додатків
    /// </summary>
    public class ApiConnector
    {
        private readonly HttpClient client;

        public ApiConnector()
        {
            string Uri = configUrl();
            HttpClientHandler handler = new HttpClientHandler();
            handler.UseDefaultCredentials = true;
            handler.MaxRequestContentBufferSize = 352428800;

            client = new HttpClient(handler);
            client.BaseAddress = new Uri(Uri);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.Timeout = TimeSpan.FromMinutes(20);
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
            var keyValuePairs = parameters.ToList();
            if (!keyValuePairs.Any())
                return string.Empty;

            var builder = new StringBuilder("?");

            var separator = "";
            foreach (var kvp in keyValuePairs.Where(kvp => kvp.Value != null))
            {
                builder.AppendFormat("{0}{1}={2}", separator, WebUtility.UrlEncode(kvp.Key), WebUtility.UrlEncode(kvp.Value.ToString()));
                separator = "&";
            }

            return builder.ToString();
        }

        #region * * * REQUEST METHODS * * *

        /// <summary>
        /// GET запит
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<T> GetRequestAsync<T>(string url)
        {
            var result = await client.GetAsync(url);

            if (result != null && !result.IsSuccessStatusCode)
                LogError(result);

            return result?.Content != null ? result.Content.ReadAs<T>() : default(T);
        }

        /// <summary>
        /// GET запит з хедером
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="header"></param>
        /// <returns></returns>
        public async Task<T> GetRequestAsync<T>(string url, KeyValuePair<string, string> header)
        {
            if (!client.DefaultRequestHeaders.Contains(header.Key))
                client.DefaultRequestHeaders.Add(header.Key, header.Value);

            var result = await client.GetAsync(url);

            if (result != null && !result.IsSuccessStatusCode)
                LogError(result);

            return result?.Content != null ? result.Content.ReadAs<T>() : default(T);
        }

        public async Task<List<T>> SendGetRequestWithListResultAsync<T>(string url)
        {
            var result = await client.GetAsync(url);

            if (result != null && !result.IsSuccessStatusCode)
                LogError(result);

            return result?.Content?.ReadAsList<T>();
        }

        /// <summary>
        /// Надіслати POST запит на сервер з отриманням результату
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<T> SendPostRequestWithResultAsync<T>(string url, T data)
        {
            var result = await client.PostDataAsync(url, data).ConfigureAwait(false);

            if (result != null && !result.IsSuccessStatusCode)
                LogError(result);

            return result != null && result.IsSuccessStatusCode ? result.Content.ReadAs<T>() : default(T);
        }

        /// <summary>
        /// Надіслати POST запит на сервер з отриманням результату
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="TData"></typeparam>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<TResult> SendPostRequestWithResultAsync<TResult, TData>(string url, TData data)
        {
            var result = await client.PostDataAsync(url, data).ConfigureAwait(false);

            if (result != null && !result.IsSuccessStatusCode)
                LogError(result);

            return result?.Content != null ? result.Content.ReadAs<TResult>() : default(TResult);
        }

        /// <summary>
        /// PUT запит на сервер з поверненням результату
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<TResult> SendPutRequestWithResultAsync<TResult>(string url) where TResult : class
        {
            var result = await client.PutDataAsync<TResult>(url, null).ConfigureAwait(false);

            if (result != null && !result.IsSuccessStatusCode)
                LogError(result);

            return result?.Content != null ? result.Content.ReadAs<TResult>() : default(TResult);
        }

        /// <summary>
        /// PUT запит на сервер з поверненням результату
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<T> SendPutRequestWithResultAsync<T>(string url, T data)
        {
            var result = await client.PutDataAsync(url, data).ConfigureAwait(false);

            if (result != null && !result.IsSuccessStatusCode)
                LogError(result);

            return result?.Content != null ? result.Content.ReadAs<T>() : default(T);
        }

        /// <summary>
        /// PUT запит на сервер з отриманням результату
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="TData"></typeparam>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<TResult> SendPutRequestWithResultAsync<TResult, TData>(string url, TData data)
        {
            var result = await client.PutDataAsync(url, data).ConfigureAwait(false);

            if (result != null && !result.IsSuccessStatusCode)
                LogError(result);

            return result?.Content != null ? result.Content.ReadAs<TResult>() : default(TResult);
        }

        /// <summary>
        /// Надіслати PUT запит на сервер з токеном авторизації та поверненням результату
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="url"></param>
        /// <param name="header"></param>
        /// <returns></returns>
        public async Task<TResult> SendPutRequestWithResultAsync<TResult>(string url, KeyValuePair<string, string> header) where TResult : class
        {
            if (!client.DefaultRequestHeaders.Contains(header.Key)) 
                client.DefaultRequestHeaders.Add(header.Key, header.Value);

            var result = await client.PutDataAsync<TResult>(url, null).ConfigureAwait(false);

            if (result != null && !result.IsSuccessStatusCode)
                LogError(result);

            return result?.Content?.ReadAs<TResult>();
        }

        /// <summary>
        /// Надіслати PUT запит на сервер з токеном авторизації та отриманням результату
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="TData"></typeparam>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <param name="header"></param>
        /// <returns></returns>
        public async Task<TResult> SendPutRequestWithResultAsync<TResult, TData>(string url, TData data, KeyValuePair<string, string> header)
        {
            if (!client.DefaultRequestHeaders.Contains(header.Key))
                client.DefaultRequestHeaders.Add(header.Key, header.Value);

            var result = await client.PutDataAsync(url, data).ConfigureAwait(false);

            if (result != null && !result.IsSuccessStatusCode)
                LogError(result);

            return result?.Content != null ? result.Content.ReadAs<TResult>() : default(TResult);
        }

        /// <summary>
        /// Надіслати PATCH запит на сервер з отриманням результату
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<T> SendPatchRequestWithResultAsync<T>(string url, T data = null) where T : class
        {
            var result = await client.PatchDataAsync(url, data);

            if (result != null && !result.IsSuccessStatusCode)
                LogError(result);

            return result != null && result.IsSuccessStatusCode ? result.Content.ReadAs<T>() : default(T);
        }

        /// <summary>
        /// Надіслати PATCH запит на сервер з отриманням результату
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="TData"></typeparam>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<TResult> SendPatchRequestWithResultAsync<TResult, TData>(string url, TData data = null) where TData : class
        {
            var result = await client.PatchDataAsync(url, data);

            if (result != null && !result.IsSuccessStatusCode)
                LogError(result);

            return result != null && result.IsSuccessStatusCode ? result.Content.ReadAs<TResult>() : default(TResult);
        }

        /// <summary>
        /// Надіслати DELETE запит на сервер з отриманням результату
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<TResult> SendDeleteRequestWithResultAsync<TResult>(string url)
        {
            var result = await client.DeleteAsync(url);

            if (result != null && !result.IsSuccessStatusCode)
                LogError(result);

            return result?.Content != null ? result.Content.ReadAs<TResult>() : default(TResult);
        }

        /// <summary>
        /// Надіслати DELETE запит на сервер з отриманням результату
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        public async Task<TResult> SendDeleteRequestWithResultAsync<TResult>(string url, CancellationToken cancellationToken)
        {
            var result = await client.DeleteAsync(url, cancellationToken);

            if (result != null && !result.IsSuccessStatusCode)
                LogError(result);

            return result != null && result.IsSuccessStatusCode ? result.Content.ReadAs<TResult>() : default(TResult);
        }

        /// <summary>
        /// Надіслати DELETE запит на сервер з отриманням результату
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="TData"></typeparam>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<TResult> SendDeleteRequestWithResultAsync<TResult, TData>(string url, TData data)
        {
            var result = await client.DeleteDataAsync(url, data);

            if (result != null && !result.IsSuccessStatusCode)
                LogError(result);

            return result != null && result.IsSuccessStatusCode ? result.Content.ReadAs<TResult>() : default(TResult);
        }

        /// <summary>
        /// Надіслати DELETE запит на сервер з отриманням результату
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="TData"></typeparam>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public async Task<TResult> SendDeleteRequestWithResultAsync<TResult, TData>(string url, TData data, CancellationToken cancellationToken)
        {
            var result = await client.DeleteDataAsync(url, data, cancellationToken);

            if (result != null && !result.IsSuccessStatusCode)
                LogError(result);

            return result != null && result.IsSuccessStatusCode ? result.Content.ReadAs<TResult>() : default(TResult);
        }

        public async Task<TResult> SendCancelRequestWithResultAsync<TResult>(CancellationToken cancellationToken)
        {
            return default(TResult);
        }

        /// <summary>
        /// Отримати список об'єктів з серверу додатків
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="listParam"></param>
        /// <returns></returns>
        public async Task<List<T>> GetListAsync<T>(string url, params KeyValuePair<string, string>[] listParam)
        {
            string requestUri = url;
            try
            {
                if (listParam.Any())
                    requestUri = string.Concat(requestUri, AsQueryString(listParam));

                var result = await client.GetAsync(requestUri);

                if (result != null && !result.IsSuccessStatusCode)
                    LogError(result);

                return result != null && result.IsSuccessStatusCode ? result.Content.ReadAsList<T>() : default(List<T>);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion


        /// <summary>
        /// Отримати список об'єктів з серверу додатків
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

                string retApiString = client.GetStringAsync(runUrl).GetAwaiter().GetResult();

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
        /// Отримати список об'єктів з серверу додатків
        /// </summary>
        /// <param name="typeResult"></param>
        /// <param name="url"></param>
        /// <param name="listParam"></param>
        /// <returns></returns>
        public List<object> GetTypedList(Type typeResult, string url, params KeyValuePair<string, string>[] listParam)
        {
            string runUrl = url;
            if (listParam.Any())
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
        /// Отримати об'єкт з серверу додатків по ID
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="url"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public TResult GetItemById<TResult>(string url, string id)
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
                        return default(TResult);

                    JObject retObj = JObject.Parse(retApiString);

                    return retObj.ToObject<TResult>();
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                    return default(TResult);
                else
                    return default(TResult);
            }
            catch
            {
                // some code
                throw;
            }
        }

        /// <summary>
        /// Отримати список об'єктів з серверу додатків по об'єтку фільтра через POST request
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="TData"></typeparam>
        /// <param name="url"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public List<TResult> GetItemListByObjectQuery<TResult, TData>(string url, TData obj)
        {
            var content = new StringContent(JsonConvert.SerializeObject(obj), Encoding.UTF8, "application/json");
            var result = client.PostAsync(url, content).GetAwaiter().GetResult();
            if (result.IsSuccessStatusCode)
            {
                var contentCollectionReturn = result.Content.ReadAsList<TResult>();
                return contentCollectionReturn;
            }

            return default(List<TResult>);
        }

        /// <summary>
        /// Отримати об'єкт з серверу додатків по ID
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="id"></param>
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
        /// <param name="data"></param>
        /// <returns></returns>
        public bool NewItem<T>(string url, T data)
        {
            StringContent content = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
            var result = client.PostAsync(url, content).GetAwaiter().GetResult();

            return result.IsSuccessStatusCode;
        }

        /// <summary>
        /// Сторити об'єкт на сервері додоатків та повернути
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public T NewItemWithResult<T>(string url, T data) where T : class
        {
            var result = client.PostData(url, data);

            if (result.IsSuccessStatusCode)
            {
                return result.Content.ReadAs<T>();
            }

            LogError(result);
            return null;
        }

        public List<T> NewListItemWithResult<T>(string url, List<T> data) where T : class
        {
            var result = client.PostData(url, data);

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

            var result = client.PutData(idUrl, data);

            return result != null && result.IsSuccessStatusCode ? result.Content.ReadAs<T>() : null;
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
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
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
            try
            {
                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
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
                {
                    retObject = default(T);
                }

                return retCode;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
                retObject = default(T);
                return false;
            }
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
            if (result.IsSuccessStatusCode)
            {
                var retString = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
                var jarray = JArray.Parse(retString);
                retData = jarray.ToObject<List<T>>();

                return true;
            }

            retData = null;
            return false;
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
        /// Видалити об'єкт на сервері додатків
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="urlData"></param>
        /// <returns></returns>
        public bool DeleteItem(string urlData, string id)
        {
            string idUrl = $"{urlData}/{id}";
            var result = client.DeleteAsync(idUrl).GetAwaiter().GetResult();

            return result.IsSuccessStatusCode;
        }

        /// <summary>
        /// Видалити об'єкт на сервері додатків
        /// </summary>
        /// <param name="urlData">Дані по об'єкту</param>
        /// <returns></returns>
        public bool DeleteItem(string urlData)
        {
            var result = client.DeleteAsync(urlData).GetAwaiter().GetResult();
            var retCode = result.IsSuccessStatusCode;
            return retCode;
        }

        /// <summary>
        /// Видалити об'єкт на сервері додатків з поверненням результату
        /// </summary>
        /// <param name="urlData"></param>
        /// <returns></returns>
        //public ExecSqlResponce DeleteItemWithResponce(string urlData)
        //{
        //    var result = client.DeleteAsync(urlData).GetAwaiter().GetResult();

        //    try
        //    {
        //        var jobject = JObject.Parse(result.Content.ReadAsStringAsync().GetAwaiter().GetResult());
        //        var obj = jobject.ToObject<ExecSqlResponce>();
        //        return obj;
        //    }
        //    catch (Exception e)
        //    {
        //        return new ExecSqlResponce
        //        {
        //            Message = e.Message,
        //            StatusCode = ExecSqlResponceStatus.Failed,
        //        };
        //    }
        //}

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
            string fullUrl = $"partner/{clientId}/{url}/{partnerId}";
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

            var boolResult = result?.IsSuccessStatusCode ?? false;

            if (!boolResult)
                LogError(result);

            return boolResult;
        }

        private void LogError(HttpResponseMessage result)
        {
            //string url = $"errorhandler/error/apiconnector";
            //var item = new ResponseError
            //{
            //    StatusCode = (int) result.StatusCode,
            //    ReasonPhrase = result.ReasonPhrase,
            //    MethodType = result.RequestMessage.Method.Method,
                
            //};
            //_responseErrors.Clear();
            //_responseErrors.Add(item);
            ////client.PostAsJson(url, item);
        }

        //private readonly List<ResponseError> _responseErrors = new List<ResponseError>();
        //public List<ResponseError> ResponseErrors => _responseErrors;
    
    }
}
