using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IpsCommonTypes.DataModels;
using IpsCommonTypes.SQLViews;
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

        public async Task<LicenseAgreement> GetLicenseAgreementAsync(int custId)
        {
            string url = $"{prefix}/LicenseAgreement/{custId}";
            var result = await _apiConnector.GetRequestAsync<LicenseAgreement>(url);
            return result;
        }

        public async Task<ObservableListSource<MoneyReceived>> GetMoneyReceivedListAsync(int custId)
        {
            string url = $"{prefix}/MoneyReceived/{custId}";
            var result = await _apiConnector.GetRequestAsync<ResponseOfRequest<List<MoneyReceived>>>(url);
            return new ObservableListSource<MoneyReceived>(result.Data);
        }

        public async Task<ObservableListSource<FT_TSK_1_BRMoneyPrepay>> GetMoneyPrepayListAsync(int custId)
        {
            string url = $"{prefix}/MoneyPrepay/{custId}";
            var result = await _apiConnector.GetRequestAsync<ResponseOfRequest<List<FT_TSK_1_BRMoneyPrepay>>>(url);
            return new ObservableListSource<FT_TSK_1_BRMoneyPrepay>(result.Data);
        }

        public async Task<ResponseOfRequest<List<QUERY_RegisterPrepayAmountSum>>> GetPrepayAmountAsync(int licId)
        {
            string url = $"{prefix}/RegisterPrepayAmountList/{licId}";
            var result = await _apiConnector.GetRequestAsync<ResponseOfRequest<List<QUERY_RegisterPrepayAmountSum>>>(url);
            return result;
        }

        /// <summary>
        /// Створити новий період
        /// </summary>
        /// <param name="paidPeriod"></param>
        /// <returns></returns>
        public async Task<ResponseOfRequest> CreatePeriodAsync(PaidPeriod paidPeriod)
        {
            string url = $"{prefix}/CreatePeriod";
            var result = await _apiConnector.SendPostRequestWithResultAsync<ResponseOfRequest, PaidPeriod>(url, paidPeriod);
            return result;
        }

        /// <summary>
        /// Зберігання прив'язаних сум до періоду
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

        public async Task<ResponseOfRequest> SavePrepayLinkAsync(MoneyPrepayLink moneyPrepayLink)
        {
            string url = $"{prefix}/SavePrepayLink";
            var result = await _apiConnector.SendPostRequestWithResultAsync<ResponseOfRequest, MoneyPrepayLink>(url, moneyPrepayLink);
            return result;
        }

        /// <summary>
        /// Змінити суму в гривневому еквіваленті
        /// </summary>
        /// <param name="changePrepaySumParams"></param>
        /// <returns></returns>
        public async Task<ResponseOfRequest> ChangePrepaySumAsync(ChangePrepaySumParams changePrepaySumParams)
        {
            string url = $"{prefix}/ChangePrepaySum";
            var result = await _apiConnector.SendPutRequestWithResultAsync<ResponseOfRequest, ChangePrepaySumParams>(url, changePrepaySumParams);
            return result;
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

        /// <summary>
        /// Зарахувати виплату по авансу
        /// </summary>
        /// <param name="licId"></param>
        /// <param name="custId"></param>
        /// <returns></returns>
        public async Task<ResponseOfRequest> PayPrepaymentAsync(int licId, int custId)
        {
            string url = $"{prefix}/PayPrepayment/{licId}/{custId}";
            var result = await _apiConnector.SendPostRequestWithResultAsync<ResponseOfRequest, object>(url, new object());
            return result;
        }
    }
}
