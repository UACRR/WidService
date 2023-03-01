using IpsCommonTypes.Types;
using ipsFormsDesign.Model;
using System.Threading.Tasks;
using WebAPIConnector;

namespace ipsFormsDesign.Services
{
    public class CalculationService
    {
        private readonly ApiConnector _apiConnector;
        private static CalculationService _service;

        private CalculationService()
        {
            _apiConnector = new ApiConnector();
        }

        public static CalculationService GetInstance()
        {
            if (_service == null)
                _service = new CalculationService();

            return _service;
        }


        public async Task<ResponseOfRequest> ChangePeriodOfAmount(PaidPeriod period)
        {
            string url = $"calculation/period/changeAmount";
            var result = await _apiConnector.SendPostRequestWithResultAsync<ResponseOfRequest, PaidPeriod>(url, period);
            return result;
        }
    }
}
