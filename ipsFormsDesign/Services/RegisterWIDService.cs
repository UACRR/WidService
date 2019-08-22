using System.Collections.Generic;
using ipsFormsDesign.Dictionary;
using IpsCommonTypes.ClassesForSearchQuery;
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

        /// <summary>
        /// Отримати об'єкти права з WID БД за масивом ID
        /// </summary>
        /// <param name="wicArray"></param>
        /// <returns></returns>
        public List<ObjectRightWithWID> GetObjectRightListByWIC(int[] wicArray)
        {
            string url = $"{Prefix}/widobjectrights";
            var list = _apiConnector.GetItemListByObjectQuery<ObjectRightWithWID, int[]>(url, wicArray);
            return list;
        }

        /// <summary>
        /// Отримати об'єкти права з локальної БД для режиму прив'язки по лупі
        /// </summary>
        /// <param name="name"></param>
        /// <param name="authtors"></param>
        /// <param name="performers"></param>
        /// <returns></returns>
        public List<RegisterSearchObject> SearchObjectsLocal(string name, string authtors, string performers)
        {
            KeyValuePair<string, string>[] param =
            {
                new KeyValuePair<string, string>("name", name),
                new KeyValuePair<string, string>("authtors", authtors),
                new KeyValuePair<string, string>("performers", performers)
            };

            string url = $"{Prefix}/searchlocal";
            var list = _apiConnector.GetList<RegisterSearchObject>(url, param);

            return list;
        }

        /// <summary>
        /// Отримати об'єкти права з WID БД для режиму прив'язки по лупі
        /// </summary>
        /// <param name="name"></param>
        /// <param name="authtors"></param>
        /// <param name="performers"></param>
        /// <returns></returns>
        public List<RegisterSearchObject> SearchObjectsWid(string name, string authtors, string performers)
        {
            KeyValuePair<string, string>[] param =
            {
                new KeyValuePair<string, string>("name", name),
                new KeyValuePair<string, string>("authtors", authtors),
                new KeyValuePair<string, string>("performers", performers)
            };

            string url = $"{Prefix}/searchwid";
            var list = _apiConnector.GetList<RegisterSearchObject>(url, param);

            return list;
        }
    }
}
