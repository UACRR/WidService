using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IpsCommonTypes.DataModels;
using IpsCommonTypes.Types;
using ipsFormsDesign.Model;
using ipsFormsDesign.Model.SQLViewsData;
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

        public async Task<ResponseOfRequest<RoyaltyCorrectionTransfer>> SearchObjectRightAsync(int custId, int objId)
        {
            string url = $"{prefix}/search/object/{custId}/{objId}";
            var result = await _apiConnector.GetRequestAsync<ResponseOfRequest<RoyaltyCorrectionTransfer>>(url);
            return result;
        }

        public async Task<ResponseOfRequest<vCustomer>> SearchRightholderAsync(int custId)
        {
            string url = $"{prefix}/search/rh/{custId}";
            var result = await _apiConnector.GetRequestAsync<ResponseOfRequest<vCustomer>>(url);
            return result;
        }

        public async Task<ResponseOfRequest<List<RoyaltyCorrectionParams>>> RunCorrectionProcessAsync(List<RoyaltyCorrectionParams> royaltyCorrectionParamsList)
        {
            string url = $"{prefix}/CorrectionProcess";
            var result = await _apiConnector.SendPostRequestWithResultAsync<ResponseOfRequest<List<RoyaltyCorrectionParams>>, List<RoyaltyCorrectionParams>>(url, royaltyCorrectionParamsList);
            return result;
        }
    }
}
