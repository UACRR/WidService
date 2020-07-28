using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using IpsCommonTypes.Types;
using ipsFormsDesign.Model;
using WebAPIConnector;

namespace ipsFormsDesign.Services
{
    public class FinishingWorksService
    {
        private const string prefix = "FinishingWorks";
        private readonly KeyValuePair<string, string> header = new KeyValuePair<string, string>("FinishingWorksToken", "ff_zxcvbnm951");

        private static FinishingWorksService _service;
        private readonly ApiConnector _apiConnector;


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

        public async Task<ResponseOfRequest<ProcessManagement>> GetSystemState()
        {
            string url = $"{prefix}/SystemState";
            var result = await _apiConnector.GetRequestAsync<ResponseOfRequest<ProcessManagement>>(url);
            return result;
        }

        public async Task<ResponseOfRequest<ProcessManagement>> RunPayment()
        {
            string url = $"{prefix}/RunPayment";
            var result = await _apiConnector.SendPutRequestWithResultAsync<ResponseOfRequest<ProcessManagement>>(url, header);
            return result;
        }

        public async Task<ResponseOfRequest<ProcessManagement>> StopPayment(DateTime dateTime)
        {
            string url = $"{prefix}/StopPayment";
            var result = await _apiConnector.SendPutRequestWithResultAsync<ResponseOfRequest<ProcessManagement>, DateTime>(url, dateTime, header);
            return result;
        }

        public async Task<ResponseOfRequest<ProcessManagement>> ChangeDateStop(DateTime dateTime)
        {
            string url = $"{prefix}/ChangeDateStop";
            var result = await _apiConnector.SendPutRequestWithResultAsync<ResponseOfRequest<ProcessManagement>, DateTime>(url, dateTime, header);
            return result;
        }

        public async Task<ResponseOfRequest<ProcessManagement>> RunFinalEnrollment()
        {
            string url = $"{prefix}/RunFinalEnrollment";
            var result = await _apiConnector.GetRequestAsync<ResponseOfRequest<ProcessManagement>>(url, header);
            return result;
        }

        public async Task<ResponseOfRequest<ProcessManagement>> RollbackLastFinalEnrollment()
        {
            string url = $"{prefix}/RollbackLastFinalEnrollment";
            var result = await _apiConnector.GetRequestAsync<ResponseOfRequest<ProcessManagement>>(url, header);
            return result;
        }
    }
}
