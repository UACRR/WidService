using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIConnector;

namespace ipsFormsDesign.Services
{
    public class LanguagesService
    {
        private readonly ApiConnector _apiConnector;
        private static LanguagesService _service;
        private const string Prefix = "Languages";
        
        private LanguagesService()
        {
            _apiConnector = new ApiConnector();
        }

        public static LanguagesService GetInstance()
        {
            if (_service == null)
                _service = new LanguagesService();

            return _service;
        }

        public async void Test()
        {
            string url = $"{Prefix}/execprocedure";
            var result = await _apiConnector.SendGetRequestAsync<object>(url);
        }
    }
}
