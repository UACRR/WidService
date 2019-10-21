using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebAPIConnector
{
    public static class HttpClientExtensions
    {
        public static HttpResponseMessage PostData<T>(this HttpClient client, string url, T data)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            StringContent content = new StringContent(JsonConvert.SerializeObject(data, settings), Encoding.UTF8, "application/json");
            return client.PostAsync(url, content).GetAwaiter().GetResult();
        }

        public static HttpResponseMessage PutData<T>(this HttpClient client, string url, T data)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            StringContent content = new StringContent(JsonConvert.SerializeObject(data, settings), Encoding.UTF8, "application/json");
            return client.PutAsync(url, content).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Send a PUT request with data to the server by URL async
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="client"></param>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> PutDataAsync<T>(this HttpClient client, string url, T data)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            StringContent content = new StringContent(JsonConvert.SerializeObject(data, settings), Encoding.UTF8, "application/json");
            return await client.PutAsync(url, content);
        }

        /// <summary>
        /// Send a PUT request with data to the server by URL async
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="client"></param>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> PutDataAsync<T>(this HttpClient client, string url, T data, CancellationToken cancellationToken)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            StringContent content = new StringContent(JsonConvert.SerializeObject(data, settings), Encoding.UTF8, "application/json");
            return await client.PutAsync(url, content, cancellationToken);
        }

        /// <summary>
        /// Send a POST request with data to the server by URL async
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="client"></param>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> PostDataAsync<T>(this HttpClient client, string url, T data)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            StringContent content = new StringContent(JsonConvert.SerializeObject(data, settings), Encoding.UTF8, "application/json");
            return await client.PostAsync(url, content);
        }

        /// <summary>
        /// Send a POST request with data to the server by URL async
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="client"></param>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> PostDataAsync<T>(this HttpClient client, string url, T data, CancellationToken cancellationToken)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            StringContent content = new StringContent(JsonConvert.SerializeObject(data, settings), Encoding.UTF8, "application/json");
            return await client.PostAsync(url, content, cancellationToken);
        }

        /// <summary>
        /// Send a PATCH request with data to the server by URL async
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="client"></param>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> PatchDataAsync<T>(this HttpClient client, string url, T data)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            StringContent content = new StringContent(JsonConvert.SerializeObject(data, settings), Encoding.UTF8, "application/json");

            var uri = CreateUri(url);
            var requestMessage = new HttpRequestMessage(new HttpMethod("PATCH"), uri)
            {
                Content = content
            };

            return await client.SendAsync(requestMessage);
        }

        /// <summary>
        /// Send a PATCH request with data to the server by URL async
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="client"></param>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> PatchDataAsync<T>(this HttpClient client, string url, T data, CancellationToken cancellationToken)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            StringContent content = new StringContent(JsonConvert.SerializeObject(data, settings), Encoding.UTF8, "application/json");

            var uri = CreateUri(url);
            var requestMessage = new HttpRequestMessage(new HttpMethod("PATCH"), uri)
            {
                Content = content
            };

            return await client.SendAsync(requestMessage, cancellationToken);
        }

        /// <summary>
        /// Send a DELETE request with data to the server by URL async
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="client"></param>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> DeleteDataAsync<T>(this HttpClient client, string url, T data)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            StringContent content = new StringContent(JsonConvert.SerializeObject(data, settings), Encoding.UTF8, "application/json");

            var uri = CreateUri(url);
            var requestMessage = new HttpRequestMessage(new HttpMethod("DELETE"), uri)
            {
                Content = content
            };

            return await client.SendAsync(requestMessage);
        }

        /// <summary>
        /// Send a DELETE request with data to the server by URL async
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="client"></param>
        /// <param name="url"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public static async Task<HttpResponseMessage> DeleteDataAsync<T>(this HttpClient client, string url, T data, CancellationToken cancellationToken)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            StringContent content = new StringContent(JsonConvert.SerializeObject(data, settings), Encoding.UTF8, "application/json");

            var uri = CreateUri(url);
            var requestMessage = new HttpRequestMessage(new HttpMethod("DELETE"), uri)
            {
                Content = content
            };

            return await client.SendAsync(requestMessage, cancellationToken);
        }

        private static Uri CreateUri(string uri)
        {
            return string.IsNullOrEmpty(uri) ? null : new Uri(uri, UriKind.RelativeOrAbsolute);
        }
    }
}
