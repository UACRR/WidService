using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            string url = $"{Prefix}/rrl/create";
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
            var result = await _apiConnector.SendPostRequestWithResultAsync<ResponseOfRequest, Register>(url, register);
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
        public async Task<ObjectAndItemsWrap<Register, object[]>> GetRegisterItems(Register register)
        {
            string url = $"{Prefix}/register/getitems/{register.RegId}";
            var result = await _apiConnector.SendGetRequestAsync<ObjectAndItemsWrap<Register, object[]>>(url);
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
    }
}
