using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IpsCommonTypes.Types;
using WebAPIConnector;
using Task = Microsoft.Office.Interop.Word.Task;

namespace ipsFormsDesign.Services
{
    public class TransferOfRightService
    {
        private static TransferOfRightService _service;
        private const string Prefix = "transferofright";
        private readonly ApiConnector _apiConnector;

        private TransferOfRightService()
        {
            _apiConnector = new ApiConnector();
        }

        public static TransferOfRightService GetInstance()
        {
            if (_service == null)
                _service = new TransferOfRightService();

            return _service;
        }

        /// <summary>
        /// Отримати правовасників для передачі 
        /// </summary>
        /// <returns></returns>
        public async Task<List<object[]>> GetRightholdersDefault()
        {
            string url = $"{Prefix}/list/rightholders/default";
            var data = await _apiConnector.GetListAsync<object[]>(url);
            return data;
        }

        /// <summary>
        /// Отримати правовласників для спадщини
        /// </summary>
        /// <returns></returns>
        public async Task<List<object[]>> GetRightholdersHeritage()
        {
            string url = $"{Prefix}/list/rightholders/heritage";
            var data = await _apiConnector.GetListAsync<object[]>(url);
            return data;
        }

        /// <summary>
        /// Отримати видавництва для передачі прав
        /// </summary>
        /// <returns></returns>
        public async Task<List<object[]>> GetPublishers()
        {
            string url = $"{Prefix}/list/rightholders/pubsub";
            var data = await _apiConnector.GetListAsync<object[]>(url);
            return data;
        }

        /// <summary>
        /// Отримати список об'єктів для передачі прав
        /// </summary>
        /// <param name="custId"></param>
        /// <returns></returns>
        public async Task<ObjectsForTransferInfo> GetObjectsForTransfer(int custId)
        {
            string url = $"{Prefix}/list/objects/{custId}";
            var data = await _apiConnector.SendGetRequestAsync<ObjectsForTransferInfo>(url);
            return data;
        }


        public async Task<object> TransferRightsOfObjectsDetault(ObjectTransferDataParameters dataParameters)
        {
            string url = $"{Prefix}/transfer/default";
            var data = await _apiConnector.SendPutRequestWithResultAsync<object, ObjectTransferDataParameters>(url, dataParameters);
            return data;
        }

        public async Task<object> TransferRightsOfObjectsHeritage(ObjectTransferDataParameters dataParameters)
        {
            string url = $"{Prefix}/transfer/heritage";
            var data = await _apiConnector.SendPutRequestWithResultAsync<object, ObjectTransferDataParameters>(url, dataParameters);
            return data;
        }
    }
}
