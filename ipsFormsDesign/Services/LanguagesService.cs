using System.Collections.Generic;
using System.Threading.Tasks;
using IpsCommonTypes.Types;
using WebAPIConnector;

namespace ipsFormsDesign.Services
{
    public class LanguagesService
    {
        private readonly ApiConnector _apiConnector;
        private static LanguagesService _service;
        private const string Prefix = "Languages";
        
        private LanguagesService()
        {
            _apiConnector = new ApiConnector();
        }

        public static LanguagesService GetInstance()
        {
            if (_service == null)
                _service = new LanguagesService();

            return _service;
        }

        /// <summary>
        /// Синхронізувати на сервері
        /// </summary>
        public async Task<ResponseOfRequest> SyncOnServer(Dictionary<string, byte[]> dictionary)
        {
            string url = $"{Prefix}/sync/server";
            var result = await _apiConnector.SendPutRequestWithResultAsync<ResponseOfRequest, Dictionary<string, byte[]>>(url, dictionary);
            return result;
        }

        /// <summary>
        /// Синхронізувати на клієнті
        /// </summary>
        public async Task<Dictionary<string, byte[]>> SyncOnClient()
        {
            string url = $"{Prefix}/sync/client";
            var result = await _apiConnector.SendGetRequestAsync<Dictionary<string, byte[]>>(url);
            return result;
        }
    }
}
