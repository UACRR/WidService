using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ipsmedserviceapp.Extensions
{
    public class ExceptionHelper
    {
        private string _controller;

        public ExceptionHelper(string controller)
        {
            _controller = controller;
        }

        public string GetMessage(Exception e, HttpRequest request)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Timestamp: { DateTime.Now:O};");
            sb.AppendLine($"Exception message: {e.Message};");
            sb.AppendLine($"Class: {_controller};");
            sb.AppendLine($"Request Method: {request.Method};");
            sb.AppendLine($"Request Path: {request.Path};");
            sb.AppendLine($"Request QueryString: {request.QueryString};");
            string body = request.Body.CanRead ? request.Body.ToString() : string.Empty;
            sb.AppendLine($"Request Body: {body};");

            return sb.ToString();
        }

        public string GetFullMessage(Exception e, HttpRequest request)
        {
            string message = GetMessage(e, request);
            var sb = new StringBuilder(message);
            sb.AppendLine($"Full Exception: {e};");

            return sb.ToString();
        }
    }
}
