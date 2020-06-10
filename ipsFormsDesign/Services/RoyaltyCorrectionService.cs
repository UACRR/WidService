using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IpsCommonTypes.DataModels;
using IpsCommonTypes.Types;
using ipsFormsDesign.Model;
using WebAPIConnector;

namespace ipsFormsDesign.Services
{
    public class RoyaltyCorrectionService
    {
        private const string prefix = "RoyaltyCorrection";
        private static RoyaltyCorrectionService _service;
        private readonly ApiConnector _apiConnector;

        private RoyaltyCorrectionService()
        {
            _apiConnector = new ApiConnector();
        }

        public static RoyaltyCorrectionService GetInstance()
        {
            if (_service == null)
                _service = new RoyaltyCorrectionService();

            return _service;
        }

        public async Task<ResponseOfRequest<object>> SearchObjectRightAsync(int custId, int objId)
        {
            string url = $"{prefix}/search/object/{custId}/{objId}";
            var result = await _apiConnector.GetRequestAsync<ResponseOfRequest<object>>(url);
            return result;
        }

        public async Task<ResponseOfRequest<Account>> SearchRightholderAsync(int custId)
        {
            string url = $"{prefix}/search/rh/{custId}";
            var result = await _apiConnector.GetRequestAsync<ResponseOfRequest<Account>>(url);
            return result;
        }

        public async Task<ResponseOfRequest> RunCorrectionProcessAsync(RoyaltyCorrectionParams o)
        {
            string url = $"{prefix}/CorrectionProcess";
            var result = await _apiConnector.SendPostRequestWithResultAsync<ResponseOfRequest, RoyaltyCorrectionParams>(url, o);
            return result;
        }
    }
}
