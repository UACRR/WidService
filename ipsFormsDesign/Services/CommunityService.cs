using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Dynamic;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Reflection;
using ipsFormsDesign.Model;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Dictionary;
using WebAPIConnector;

namespace ipsFormsDesign.Services
{
    public class CommunityService
    {
        private readonly ApiConnector _webApi = new ApiConnector();
        private readonly string _prefix = "community/";

        /// <summary>
        /// Отримати VIEW у вигляді списку елементів 
        /// </summary>
        /// <typeparam name="T">Бажаний тип</typeparam>
        /// <param name="nameView">назва View</param>
        /// <returns>необхідна View</returns>
        public List<T> GetView<T>(Type typeResult, string viewName, int? paramId = null, string columnName = null) where T:class
        {
            string url = _prefix + "list/view";
            List<KeyValuePair<string, string>> param = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("viewName", viewName),
                new KeyValuePair<string, string>("paramId", paramId.ToString()),
                new KeyValuePair<string, string>("columnName", columnName),
            };
            //if (paramId != null)
            var list = _webApi.GetTypedList(typeResult, url, param.ToArray());

            var typeList = new List<T>();
            foreach (var temp in list)
                typeList.Add(temp as T);
            return typeList;
        }

        /// <summary>
        /// тримати шаблон для створення нової спільноти 
        /// </summary>
        /// <returns></returns>
        public Customer GetTemplateComunity()
        {
            var templateComunity = _webApi.GetItemById<Customer>(_prefix + "template", null);
            return templateComunity;
        }

        /// <summary>
        /// Збереження нової або існуючої спільноти
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public bool SaveCommunity(Customer customer)
        {
            return customer.CustId == 0 ? 
                _webApi.NewItem<Customer>(_prefix + "createcommunity", customer) : 
                _webApi.UpdateItem<Customer>(_prefix + "updatecommunity", customer.CustId.ToString(), customer);
        }

        public Customer GetComunity(int custId)
        {
            var comunity = _webApi.GetItemById<Customer>(_prefix + "list", custId.ToString());
            return comunity;
        }



    }
}
