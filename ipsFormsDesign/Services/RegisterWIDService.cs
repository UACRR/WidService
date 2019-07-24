using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using WebAPIConnector;

namespace ipsFormsDesign.Services
{
    public class RegisterWIDService
    {
        private const string Prefix = "registerwid";
        private readonly ApiConnector _apiConnector;
        private static RegisterWIDService _service;

        private RegisterWIDService()
        {
            _apiConnector = new ApiConnector();
        }

        public static RegisterWIDService GetInstance()
        {
            if (_service == null)
                _service = new RegisterWIDService();

            return _service;
        }

        public string GetDefault()
        {
            string url = $"{Prefix}/default";
            var result = _apiConnector.GetItemById<string>(url, null);
            return result;
        }
    }
}
