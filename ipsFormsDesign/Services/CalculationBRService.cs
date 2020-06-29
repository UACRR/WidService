using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IpsCommonTypes.Types;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using WebAPIConnector;

namespace ipsFormsDesign.Services
{
    public class CalculationBRService
    {
        private readonly ApiConnector _apiConnector;
        private static CalculationBRService _service;
        private const string prefix = "CalculationBR";

        private CalculationBRService()
        {
            _apiConnector = new ApiConnector();
        }

        public static CalculationBRService GetInstance()
        {
            if (_service == null)
                _service = new CalculationBRService();

            return _service;
        }

        public async Task<LicenseAgreement> GetLicenseAgreement(int custId)
        {
            string url = $"{prefix}/LicenseAgreement/{custId}";
            var result = await _apiConnector.GetRequestAsync<LicenseAgreement>(url);
            return result;
        }

        public async Task<ObservableListSource<MoneyReceived>> GetMoneyReceivedList(int custId)
        {
            string url = $"{prefix}/MoneyReceived/{custId}";
            var result = await _apiConnector.GetRequestAsync<ResponseOfRequest<List<MoneyReceived>>>(url);
            return new ObservableListSource<MoneyReceived>(result.Data);
        }

        /// <summary>
        /// Створити новий період
        /// </summary>
        /// <param name="paidPeriod"></param>
        /// <returns></returns>
        public async Task<ResponseOfRequest> CreatePeriod(PaidPeriod paidPeriod)
        {
            string url = $"{prefix}/CreatePeriod";
            var result = await _apiConnector.SendPostRequestWithResultAsync<ResponseOfRequest, PaidPeriod>(url, paidPeriod);
            return result;
        }

        /// <summary>
        /// Зберігання прив'язаних сум
        /// </summary>
        /// <param name="custId"></param>
        /// <param name="listLinks">Прив'язані суми</param>
        /// <returns></returns>
        public List<MoneyPeriodLink> SaveLink(int custId, List<MoneyPeriodLink> listLinks)
        {
            List<MoneyPeriodLink> list;

            var retCode = _apiConnector.UpdateListItemWithReturn("consumer/Period/Payments/linkperiods", custId.ToString(), listLinks, out list);
            
            if (retCode)
                return list;

            return null;
        }

        /// <summary>
        /// Змінити статус періоду
        /// </summary>
        /// <param name="period"></param>
        /// <returns></returns>
        public bool ChangePeriodStatus(PaidPeriod period)
        { 
            string url = $"consumer/period/state/{period.PeriodId}/{period.Status}";
            return _apiConnector.UpdateItem(url, string.Empty, period);
        }

    }
}
