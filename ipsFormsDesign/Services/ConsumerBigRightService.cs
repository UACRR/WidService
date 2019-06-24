using ipsFormsDesign.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using IpsCommonTypes.Enums;

namespace ipsFormsDesign.Services
{
    public class ConsumerBigRightService : ConsumerService
    {
        private static ConsumerBigRightService _service;

        private ConsumerBigRightService() { }

        public static ConsumerBigRightService GetInstance()
        {
            if (_service == null)
                _service = new ConsumerBigRightService();

            if (IpsGlobal.AnketaDictionaties == null)
                IpsGlobal.SetAnketaDictionaties(_service.GetDictionary());

            if(IpsGlobal.ObjectRightDictionaries == null)
                IpsGlobal.SetObjectRightDictionaries(_service.GetObjectRightDictionaries());

            return _service;
        }

        /// <summary>
        /// Отримати основну VIEW для головного гріда
        /// </summary>
        /// <param name="typeDoc"></param>
        /// <param name="what"></param>
        /// <returns></returns>
        public IList<ConsumerBigRightView> GetMainBigRightView(ConsumersBigRightCategoryFilter typeDoc = ConsumersBigRightCategoryFilter.All, ConsumersBigRightFilter what = ConsumersBigRightFilter.All)
        {
            string url = $"consumer/listBR";
            KeyValuePair<string, string>[] param = new[] {
                new KeyValuePair<string, string>("whatId", ((int)what).ToString()),
                new KeyValuePair<string, string>("typeDocId", ((int)typeDoc).ToString())
            };
            var anketaDic = _webApi.GetList<ConsumerBigRightView>(url, param);
            return anketaDic;
        }

        /// <summary>
        /// Отримати дані VIEW за її ім'ям
        /// </summary>
        /// <param name="typeResult"></param>
        /// <param name="viewName"></param>
        /// <param name="custId"></param>
        /// <returns></returns>
        public IList<object> GetBigRightViewByName(Type typeResult, string viewName, int? custId)
        {
            string url = "consumer/BR/view/list";
            List<KeyValuePair<string, string>> param = new List<KeyValuePair<string, string>> { new KeyValuePair<string, string>("viewName", viewName) };
            if (custId != null)
                param.Add(new KeyValuePair<string, string>("custId", custId.ToString()));
            var list = _webApi.GetTypedList(typeResult, url, param.ToArray());
            return list;
        }

        public Customer SaveNewConsumer(Customer customer)
        {
            var result = _webApi.NewItemWithReturn<Customer>("consumer/newconsumer", customer);
            return result;
        }
        
    }
}
