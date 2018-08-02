using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace WebAPIConnector
{
    public static class HttpContentExtensions
    {
        public static T ReadAs<T>(this HttpContent content)
        {
            var jObject = JObject.Parse(content.ReadAsStringAsync().GetAwaiter().GetResult());
            return jObject.ToObject<T>();
        }
    }
}
