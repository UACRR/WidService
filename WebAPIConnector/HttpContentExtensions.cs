using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
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

        public static List<T> ReadAsList<T>(this HttpContent content)
        {
            JArray array = JArray.Parse(content.ReadAsStringAsync().GetAwaiter().GetResult());
            List<T> list = array.Select(rec =>
            {
                var item = rec.ToObject<T>();
                return item;
            }).ToList();

            return list;
        }
    }
}
