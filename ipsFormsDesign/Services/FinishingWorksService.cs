using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using IpsCommonTypes.Types;
using WebAPIConnector;

namespace ipsFormsDesign.Services
{
    public class FinishingWorksService
    {
        private const string prefix = "FinishingWorks";

        private static FinishingWorksService _service;
        private readonly ApiConnector _apiConnector;

        private readonly AuthenticationHeaderValue _authenticationHeaderValue = new AuthenticationHeaderValue("Bearer", "ff_zxcvbnm951");

        private FinishingWorksService()
        {
            _apiConnector = new ApiConnector();
        }

        public static FinishingWorksService GetInstance()
        {
            if (_service == null)
                _service = new FinishingWorksService();

            return _service;
        }

        public async Task<ResponseOfRequest<object>> RunPayment()
        {
            string url = $"{prefix}/RunPayment";
            var result = await _apiConnector.SendGetRequestAsync<ResponseOfRequest<object>>(url, _authenticationHeaderValue);
            return result;
        }

        public async Task<ResponseOfRequest<object>> StopPayment()
        {
            string url = $"{prefix}/StopPayment";
            var result = await _apiConnector.SendGetRequestAsync<ResponseOfRequest<object>>(url, _authenticationHeaderValue);
            return result;
        }

        public async Task<ResponseOfRequest<object>> RunFinalPayment()
        {
            string url = $"{prefix}/RunFinalPayment";
            var result = await _apiConnector.SendGetRequestAsync<ResponseOfRequest<object>>(url, _authenticationHeaderValue);
            return result;
        }
    }
}
