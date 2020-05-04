using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IpsCommonTypes.ClassesForSearchQuery;
using IpsCommonTypes.Types;
using ipsFormsDesign.Data;
using ipsFormsDesign.Model;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Enums;
using WebAPIConnector;

namespace ipsFormsDesign.Services
{
    // * * * ПРЕДСТАВНИКИ
    public class PartnerService
    {
        private readonly ApiConnector _webApi;
        private const string Prefix = "partner";

        private static PartnerService _service;

        private PartnerService()
        {
            _webApi = new ApiConnector();
        }

        /// <summary>
        /// Екземпляр PartnerService
        /// </summary>
        /// <returns></returns>
        public static PartnerService GetInstance()
        {
            if (_service == null)
                _service = new PartnerService();

            if(IpsGlobal.AnketaDictionaties == null)
                IpsGlobal.SetAnketaDictionaties(_service.GetDictionary());

            return _service;
        }

        private AnketaDictionaties GetDictionary()
        {
            var anketaDic = _webApi.GetItemById<AnketaDictionaties>("dictionary", "anketa");
            return anketaDic;
        }

        /// <summary>
        /// Отримати список представників
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        public async Task<ResponseOfRequest<DataTable>> GetPartnersList(SearchModuleResource resource)
        {
            string url = $"{Prefix}/list";
            var result = await _webApi.SendPostRequestWithResultAsync<ResponseOfRequest<DataTable>, SearchModuleResource>(url, resource);
            return result;
        }

        /// <summary>
        /// Отримати VIEW
        /// </summary>
        /// <param name="typeResult"></param>
        /// <param name="viewName"></param>
        /// <param name="custId"></param>
        /// <returns></returns>
        public IList<object> GetView(Type typeResult, string viewName, int? custId)
        {
            string url = $"{Prefix}/viewlist";
            List<KeyValuePair<string, string>> param = new List<KeyValuePair<string, string>> { new KeyValuePair<string, string>("viewName", viewName) };
            if (custId != null)
                param.Add(new KeyValuePair<string, string>("custId", custId.ToString()));
            var list = _webApi.GetTypedList(typeResult, url, param.ToArray());
            return list;
        }

        /// <summary>
        /// Отримати шаблон представника customer
        /// </summary>
        /// <param name="custType"></param>
        /// <returns></returns>
        public Customer GetPartnerTemplate(int custType)
        {
            var customer = _webApi.GetItemById<Customer>($"{Prefix}/newpartner", custType.ToString());
            return customer;
        }

        /// <summary>
        /// Отримати список представників
        /// </summary>
        /// <returns></returns>
        public List<Customer> GetPartnerList()
        {
            string url = $"{Prefix}/list";
            return _webApi.GetList<Customer>(url);
        }

        /// <summary>
        /// Отримати дані по одному представнику
        /// </summary>
        public Customer GetPartnerAnketa(int clientId)
        {
            var anketaPerson = _webApi.GetItemById<Customer>($"{Prefix}/listcl", clientId.ToString());
            return anketaPerson;
        }

        public Customer GetPartner(int custId)
        {
            var customerPartner = _webApi.GetItemById<Customer>("partner", custId.ToString());
            return customerPartner;
        }

        /// <summary>
        /// Збереження представника (customer)
        /// </summary>
        /// <param name="cust"></param>
        /// <returns></returns>
        public bool SavePartner(Customer cust)
        {
            // new
            if (cust.CustId == 0)
                return _webApi.NewItem($"{Prefix}/addnewpartner", cust);
            // update
            switch (cust.CustType)
            {
                case 1: return _webApi.UpdateItem($"{Prefix}/partnerphis", cust.CustId.ToString(), cust); // фіз. особа
                case 3: return _webApi.UpdateItem($"{Prefix}/partnerjur", cust.CustId.ToString(), cust);  // юр. особа
            }
            return false;
        }

        public bool UpdateAgreement(AgreementAddPartner agreement, Partner partner)
        {
            var url = $"{Prefix}/agreement";
            return _webApi.UpdateItem(url, null, new List<object> {agreement, partner});
        }

        #region  * * * ПРЕДСТАВНИК + КЛІЄНТ * * *

        /// <summary>
        /// додати представника клієнту
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="partnerId"></param>
        /// <returns></returns>
        public bool SetPartnerForCustomer(int clientId, int partnerId)
        {
            return _webApi.ChangePartnerForCustomer("insert", clientId, partnerId);
        }

        /// <summary>
        /// змінити представника в клієнта
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="partnerId"></param>
        /// <param name="oldClientId"></param>
        /// <returns></returns>
        public bool ChangePartnerForCustomer(int clientId, int partnerId, int oldClientId)
        {
            return _webApi.ChangePartnerForCustomer("update", clientId, partnerId, oldClientId);
        }

        /// <summary>
        /// вилучити представника в клієнта
        /// </summary>
        /// <param name="clientId"></param>
        /// <param name="partnerId"></param>
        /// <returns></returns>
        public bool RemovePartnerForCustomer(int clientId, int partnerId)
        {
            return _webApi.ChangePartnerForCustomer("remove", clientId, partnerId);
        }

        #endregion

        /// <summary>
        /// змінити поточний статус представника
        /// </summary>
        /// <param name="partnerId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public bool AgreementPartnerStatusChange(int partnerId, CPartnerObjectStatus status)
        {
            string url = $"{Prefix}/{partnerId}/statuschange";
            return _webApi.UpdateItem<object>(url, status.ToString("D"), null);
        }
    }
}
