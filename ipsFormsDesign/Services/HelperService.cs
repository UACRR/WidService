using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IpsCommonTypes.IntermediaryTypes;
using IpsCommonTypes.SQLViews;
using IpsCommonTypes.Types;
using WebAPIConnector;

namespace ipsFormsDesign.Services
{
    public class HelperService
    {
        private const string prefix = "Helper";
        private static HelperService _service;
        private readonly ApiConnector _apiConnector;

        private HelperService()
        {
            _apiConnector = new ApiConnector();
        }

        public static HelperService GetInstance()
        {
            if (_service == null)
                _service = new HelperService();

            return _service;
        }

        public async Task<ResponseOfRequest<FT_TSK_2_BRRegisterAuthor>> GetPrepayAmountAsync(int licId, decimal authAmount)
        {
            var data = new PrepayAmountResource
            {
                LicId = licId,
                AuthAmount = authAmount,
            };
            string url = $"{prefix}/PrepayAmount";
            var result = await _apiConnector.SendPostRequestWithResultAsync<ResponseOfRequest<FT_TSK_2_BRRegisterAuthor>, object>(url, data);
            return result;
        }
    }
}
