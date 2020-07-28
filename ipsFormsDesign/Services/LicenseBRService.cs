using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using IpsCommonTypes.ClassesForSearchQuery;
using IpsCommonTypes.Types;
using WebAPIConnector;

namespace ipsFormsDesign.Services
{
    /// <summary>
    /// Сервіс обміну даними з сервером по ліцензіям театрів (великі права)
    /// </summary>
    public class LicenseBRService
    {
        private static LicenseBRService _service;
        private readonly ApiConnector _apiConnector;
        private const string Prefix = "LicenseBR";

        private LicenseBRService()
        {
            _apiConnector = new ApiConnector();
        }

        public static LicenseBRService GetInstance()
        {
            if (_service == null)
                _service = new LicenseBRService();

            return _service;
        }

        /// <summary>
        /// Отримати список ліцензій театрів
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        public async Task<ResponseOfRequest<DataTable>> GetLicenseBRList(SearchModuleResource resource)
        {
            string url = $"{Prefix}/list";
            var result = await _apiConnector.SendPostRequestWithResultAsync<ResponseOfRequest<DataTable>, SearchModuleResource>(url, resource);
            return result;
        }

        public IList<RequestsOrReferenceBigRightView> GetLicenseAgreements(LicenseAgreementQuery query)
        {
            var list = _apiConnector.GetList<RequestsOrReferenceBigRightView>("LicenseBR", query.ToKeyValuePair());

            return list;
        }

        /// <summary>
        /// Створити заявку на ліцензію
        /// </summary>
        /// <param name="licenseAgreement"></param>
        /// <returns></returns>
        public async Task<ResponseOfRequest> CreateLicenseBR(LicenseAgreement licenseAgreement)
        {
            string url = $"{Prefix}/CreateLicenseBR";
            var result = await _apiConnector.SendPostRequestWithResultAsync<ResponseOfRequest, LicenseAgreement>(url, licenseAgreement);
            return result;
        }

        /// <summary>
        /// Оновити заявку/довідку/ліцензію ВП
        /// </summary>
        /// <param name="licenseAgreement"></param>
        /// <returns></returns>
        public async Task<ResponseOfRequest> UpdateLicenseBR(LicenseAgreement licenseAgreement)
        {
            string url = $"{Prefix}/UpdateLicenseBR";
            var result = await _apiConnector.SendPutRequestWithResultAsync<ResponseOfRequest, LicenseAgreement>(url, licenseAgreement);
            return result;
        }
    }
}
