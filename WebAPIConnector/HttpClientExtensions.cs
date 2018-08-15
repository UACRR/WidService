using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace WebAPIConnector
{
    public static class HttpClientExtensions
    {
        public static HttpResponseMessage PostAsJson<T>(this HttpClient client, string url, T data)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            StringContent content = new StringContent(JsonConvert.SerializeObject(data, settings), Encoding.UTF8, "application/json");
            return client.PostAsync(url, content).GetAwaiter().GetResult();
        }

        public static HttpResponseMessage PutAsJson<T>(this HttpClient client, string url, T data)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            };

            StringContent content = new StringContent(JsonConvert.SerializeObject(data, settings), Encoding.UTF8, "application/json");
            return client.PutAsync(url, content).GetAwaiter().GetResult();
        }
    }
}
