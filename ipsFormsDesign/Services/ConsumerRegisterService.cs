using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IpsCommonTypes.IntermediaryTypes;
using IpsCommonTypes.Types;
using IpsCommonTypes.Wrappers;
using ipsFormsDesign.Model;
using WebAPIConnector;

namespace ipsFormsDesign.Services
{
    public class ConsumerRegisterService
    {
        private const string Prefix = "ConsumerRegister";
        private static ConsumerRegisterService _service;
        private readonly ApiConnector _apiConnector;

        private ConsumerRegisterService()
        {
            _apiConnector = new ApiConnector();
        }

        public static ConsumerRegisterService GetInstance()
        {
            if (_service == null)
                _service = new ConsumerRegisterService();

            return _service;
        }

        /// <summary>
        /// Отримати ліцензії з періодами та звітами
        /// </summary>
        /// <param name="custId"></param>
        /// <returns></returns>
        public async Task<List<LicenseAgreement>> GetLicenseAgreementList(int custId)
        {
            string url = $"{Prefix}/licenses/{custId}";
            var result = await _apiConnector.GetListAsync<LicenseAgreement>(url);
            return result;
        }

        /// <summary>
        /// Створити період платежів
        /// </summary>
        /// <param name="paidPeriod"></param>
        /// <returns></returns>
        public async Task<ResponseOfRequest> CreatePaidPeriod(PaidPeriod paidPeriod)
        {
            string url = $"{Prefix}/paidperiod/create";
            var result = await _apiConnector.SendPostRequestWithResultAsync<ResponseOfRequest, PaidPeriod>(url, paidPeriod);
            return result;
        }

        /// <summary>
        /// Видалити період платежів
        /// </summary>
        /// <param name="paidPeriod"></param>
        /// <returns></returns>
        public async Task<ResponseOfRequest> DeletePaidPeriod(PaidPeriod paidPeriod)
        {
            string url = $"{Prefix}/paidperiod/delete/{paidPeriod.PeriodId}";
            var result = await _apiConnector.SendDeleteRequestWithResultAsync<ResponseOfRequest>(url);
            return result;
        }

        /// <summary>
        /// Створити розрахунковий лист
        /// </summary>
        /// <param name="registerRatedList"></param>
        /// <returns></returns>
        public async Task<ResponseOfRequest> CreateRegisterRatedList(RegisterRatedList registerRatedList)
        {
            string url = $"{Prefix}/rrl/create";
            var result = await _apiConnector.SendPostRequestWithResultAsync<ResponseOfRequest, RegisterRatedList>(url, registerRatedList);
            return result;
        }

        /// <summary>
        /// Оновити дані розрахункового листа
        /// </summary>
        /// <param name="registerRatedList"></param>
        /// <returns></returns>
        public async Task<ResponseOfRequest> UpdateRegisterRatedList(RegisterRatedList registerRatedList)
        {
            string url = $"{Prefix}/rrl/update";
            var result = await _apiConnector.SendPutRequestWithResultAsync<ResponseOfRequest, RegisterRatedList>(url, registerRatedList);
            return result;
        }

        /// <summary>
        /// Створити звіт
        /// </summary>
        /// <param name="register"></param>
        /// <returns></returns>
        public async Task<ResponseOfRequest> CreateRegister(Register register)
        {
            string url = $"{Prefix}/register/create";
            var registerWrap = new NewRegisterWrap
            {
                Register = register,
                RegisterRatedList = register.Rm,
            };
            var result = await _apiConnector.SendPostRequestWithResultAsync<ResponseOfRequest, NewRegisterWrap>(url, registerWrap);
            return result;
        }

        /// <summary>
        /// Оновити дані звіту
        /// </summary>
        /// <param name="register"></param>
        /// <returns></returns>
        public async Task<ResponseOfRequest> UpdateRegister(Register register)
        {
            string url = $"{Prefix}/register/update";
            var result = await _apiConnector.SendPutRequestWithResultAsync<ResponseOfRequest, Register>(url, register);
            return result;
        }

        /// <summary>
        /// Видалити звіт
        /// </summary>
        /// <param name="register"></param>
        /// <returns></returns>
        public async Task<ResponseOfRequest> DeleteRegister(Register register)
        {
            string url = $"{Prefix}/register/delete/{register.RegId}";
            var result = await _apiConnector.SendDeleteRequestWithResultAsync<ResponseOfRequest>(url);
            return result;
        }

        /// <summary>
        /// Отримати дані звіту для перегляду / редагування
        /// </summary>
        /// <param name="register"></param>
        /// <returns></returns>
        public async Task<List<object[]>> GetCCIDRegisterItems(Register register)
        {
            string url = $"{Prefix}/register/ccid/getitems/{register.RegId}";
            var result = await _apiConnector.GetListAsync<object[]>(url);
            return result;
        }

        /// <summary>
        /// Отримати дані звіту для перегляду / редагування
        /// </summary>
        /// <param name="register"></param>
        /// <returns></returns>
        public async Task<List<RegisterItem>> GetDefaultRegisterItems(Register register)
        {
            string url = $"{Prefix}/register/getitems/{register.RegId}";
            var result = await _apiConnector.GetListAsync<RegisterItem>(url);
            return result;
        }

        /// <summary>
        /// Зафіксувати перелік звітів
        /// </summary>
        /// <param name=""></param>
        /// <param name="registerRatedList"></param>
        /// <returns></returns>
        public async Task<ResponseOfRequest> FixateRegistersList(RegisterRatedList registerRatedList)
        {
            string url = $"{Prefix}/registers/fixate";
            var result = await _apiConnector.SendPutRequestWithResultAsync<ResponseOfRequest, RegisterRatedList>(url, registerRatedList);
            return result;
        }

        /// <summary>
        /// Відправити на погодження
        /// </summary>
        /// <param name="register"></param>
        /// <returns></returns>
        public async Task<ResponseOfRequest> SendRegisterToAccept(Register register)
        {
            string url = $"{Prefix}/register/accept/{register.RegId}";
            var result = await _apiConnector.SendPutRequestWithResultAsync<ResponseOfRequest>(url);
            return result;
        }

        /// <summary>
        /// Отримати дані по курсу звіту CCID
        /// </summary>
        /// <param name="register"></param>
        /// <returns></returns>
        public async Task<RegisterCCIDCurrencyData> GetCCIDRegisterCurrencyData(Register register)
        {
            string url = $"{Prefix}/register/ccid/currency/data/{register.RegId}";
            var result = await _apiConnector.SendGetRequestAsync<RegisterCCIDCurrencyData>(url);
            return result;
        }

        /// <summary>
        /// Змінити курс звіту CCID
        /// </summary>
        /// <param name="currencyData"></param>
        /// <returns></returns>
        public async Task<ResponseOfRequest> ChangeCCIDRegisterCurrency(RegisterCCIDCurrencyData currencyData)
        {
            string url = $"{Prefix}/register/ccid/currency/change";
            var result = await _apiConnector.SendPutRequestWithResultAsync<ResponseOfRequest, RegisterCCIDCurrencyData>(url, currencyData);
            return result;
        }

        private class NewRegisterWrap
        {
            public Register Register { get; set; }
            public RegisterRatedList RegisterRatedList { get; set; }
        }
    }
}
