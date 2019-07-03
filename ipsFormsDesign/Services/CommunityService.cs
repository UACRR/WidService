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
using ipsFormsDesign.Enums;
using WebAPIConnector;

namespace ipsFormsDesign.Services
{
    public class CommunityService
    {
        private readonly ApiConnector _webApi;
        private const string Prefix = "community/";

        private static CommunityService _service;

        private CommunityService()
        {
            _webApi = new ApiConnector();
        }

        public static CommunityService GetInstance()
        {
            if (_service == null)
                _service = new CommunityService();
            return _service;
        }

        /// <summary>
        /// Отримати VIEW у вигляді списку елементів 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="typeResult"></param>
        /// <param name="viewName"></param>
        /// <param name="paramId"></param>
        /// <param name="columnName"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public List<T> GetView<T>(Type typeResult, string viewName, int? paramId = null, string columnName = null) where T : class
        {
            string url = Prefix + "list/view";
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
        /// Отримати VIEW списку правовласників 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="viewName"></param>
        /// <param name="query"></param>
        /// <returns></returns>
        public T GetCommunityAuthorsView<T>(string viewName, PaginateAndSearchQuery query) where T : class
        {
            string url = string.Concat(Prefix, $"list/rhview/{viewName}");

            var result = _webApi.GetItemByIdWithParam<T>(url, null, query.ToKeyValuePair());
            return result;
        }

        /// <summary>
        /// тримати шаблон для створення нової спільноти 
        /// </summary>
        /// <returns></returns>
        public Customer GetTemplateComunity()
        {
            var templateComunity = _webApi.GetItemById<Customer>(Prefix + "template", null);
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
                _webApi.NewItem<Customer>(Prefix + "createcommunity", customer) : 
                _webApi.UpdateItem<Customer>(Prefix + "updatecommunity", customer.CustId.ToString(), customer);
        }

        /// <summary>
        /// Збереження змін договору спільноти
        /// </summary>
        /// <param name="agreement"></param>
        /// <returns></returns>
        public bool SaveAgreement(AgreementAddCommunity agreement)
        {
            return _webApi.UpdateItem($"{Prefix}updateagreement", agreement.AgrId.ToString(), agreement);
        }

        public bool SaveCustCmRightLimitedRights(int cmCustId, int custId, List<CustCmRight> listObj)
        {
            var url = $"lrightsupd/{cmCustId}/{custId}";

            var result = _webApi.UpdateItem(string.Concat(Prefix, url), null, listObj);
            return result;
        }

        public bool SaveTermsOfServiceLimitedRights(int cmCustId, int custId, List<TermsOfService> termsOfServices)
        {
            var url = $"{Prefix}lrightstosupd/{cmCustId}/{custId}";

            var result = _webApi.UpdateItem(url, null, termsOfServices);
            return result;
        }

        public Customer GetComunity(int custId)
        {
            var comunity = _webApi.GetItemById<Customer>(Prefix + "list", custId.ToString());
            return comunity;
        }

        public List<CustCmRight> GetCommunityRightList(int custId)
        {
            string url = Prefix + "cmautors/" + custId;
            var rightlist = _webApi.GetList<CustCmRight>(url);
            return rightlist;
        }

        public List<TermsOfService> GetTermsOfService(int custId)
        {
            string url = Prefix + "termsofservice/" + custId;
            var termsOfServices = _webApi.GetList<TermsOfService>(url);
            return termsOfServices;
        }

        public bool ChangeStatusAgr(int communityId, CPartnerObjectStatus status)
        {
            string url = Prefix + "agrstatuschange/" + $"{communityId}/{(int)status}";
            var result = _webApi.UpdateItem<object>(url, null, null);
            return result;
        }
    }
}
