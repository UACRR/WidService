using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.ViewModels.ObjectsRight;
using IpsCommonTypes.ClassesForSearchQuery;
using IpsCommonTypes.Types;
using IpsCommonTypes.Views;
using IpsCommonTypes.Wrappers;
using WebAPIConnector;

namespace ipsFormsDesign.Services
{
    public class RegisterWIDService
    {
        private const string Prefix = "registerwid";
        private readonly ApiConnector _apiConnector;
        private static RegisterWIDService _service;

        private RegisterWIDService()
        {
            _apiConnector = new ApiConnector();
        }

        public static RegisterWIDService GetInstance()
        {
            if (_service == null)
                _service = new RegisterWIDService();

            return _service;
        }

        /// <summary>
        /// Запустити процес автоматичної прив'язки об'єктів права
        /// </summary>
        /// <param name="regId"></param>
        /// <returns></returns>
        public List<RegisterItemViewModel> GetAutoLinkedObjects(int regId)
        {
            string url = $"{Prefix}/autolinkedobjects/{regId}";
            var list = _apiConnector.GetList<RegisterItemViewModel>(url);
            return list;
        }

        /// <summary>
        /// Отримати список об'єктів права за пошуком
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        public ItemListResponse<ObjectRightWithWID> GetObjectRightListBySearch(SearchObjectRightQuery query)
        {
            string url = $"{Prefix}/searchbyquery";
            var item = _apiConnector.GetItemByObjectQuery<ItemListResponse<ObjectRightWithWID>, SearchObjectRightQuery>(url, query);
            return item;
        }

        public List<ObjectRightWithWID> GetObjectRightListByWIC(int[] wicArray)
        {
            string url = $"{Prefix}/widobjectrights";
            var list = _apiConnector.GetItemByObjectQuery<List<ObjectRightWithWID>, int[]>(url, wicArray);
            return list;
        }
    }
}
