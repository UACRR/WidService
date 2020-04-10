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
        private readonly ApiConnector _webApi;
        private const string Prefix = "LicenseBR";

        private LicenseBRService()
        {
            _webApi = new ApiConnector();
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
            var result = await _webApi.SendPostRequestWithResultAsync<ResponseOfRequest<DataTable>, SearchModuleResource>(url, resource);
            return result;
        }

        public IList<RequestsOrReferenceBigRightView> GetLicenseAgreements(LicenseAgreementQuery query)
        {
            var list = _webApi.GetList<RequestsOrReferenceBigRightView>("LicenseBR", query.ToKeyValuePair());

            return list;
        }
    }
}
