using System;
using Microsoft.AspNetCore.Http;

namespace ipsmedserviceapp.Services
{
    public static class UrlHelper
    {
        public static string GetUrl(string path, string queryString = null)
        {
            var request = new HttpContextAccessor().HttpContext.Request;
            var builder = new UriBuilder();
            builder.Scheme = request.Scheme;
            builder.Host = request.Host.Host;
            builder.Port = request.Host.Port ?? -1;
            builder.Path = path;
            if (queryString != null)
                builder.Query = queryString;

            return builder.Uri.ToString();
        }
    }
}