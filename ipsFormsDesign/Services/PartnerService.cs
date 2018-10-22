using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ipsFormsDesign.Model;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Dictionary;
using WebAPIConnector;

namespace ipsFormsDesign.Services
{
    // * * * ПРЕДСТАВНИКИ
    public class PartnerService
    {
        private readonly ApiConnector _webApi = new ApiConnector();
        private const string Prefix = "partner/";
        
        /// <summary>
        /// Отримати VIEW
        /// </summary>
        /// <param name="typeResult"></param>
        /// <param name="viewName"></param>
        /// <param name="custId"></param>
        /// <returns></returns>
        public IList<object> GetView(Type typeResult, string viewName, int? custId)
        {
            string url = "consumer/BR/view/list";
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
            var customer = _webApi.GetItemById<Customer>("partner/newpartner", custType.ToString());
            return customer;
        }

        /// <summary>
        /// Отримати список представників
        /// </summary>
        /// <returns></returns>
        public List<Customer> GetPartnerList()
        {
            string url = "partner/list";
            return _webApi.GetList<Customer>(url);
        }

        /// <summary>
        /// Отримати дані по одному представнику
        /// </summary>
        public Customer GetPartnerAnketa(int clientId)
        {
            var anketaPerson = _webApi.GetItemById<Customer>("partner/listcl", clientId.ToString());
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
                return _webApi.NewItem(Prefix + "addnewpartner", cust);
            // update
            switch (cust.CustType)
            {
                case 1: return _webApi.UpdateItem<Customer>("partner/partnerphis", cust.CustId.ToString(), cust); // фіз. особа
                case 3: return false; // юр. особа
            }
            return false;
        }

        // додати представника клієнту
        public bool SetPartnerForCustomer(int clientId, int partnerId)
        {
            return _webApi.ChangePartnerForCustomer("insert", clientId, partnerId);
        }

        // змінити представника в клієнта
        public bool ChangePartnerForCustomer(int clientId, int partnerId, int oldClientId)
        {
            return _webApi.ChangePartnerForCustomer("update", clientId, partnerId, oldClientId);
        }

        //вилучити представника в клієнта
        public bool RemovePartnerForCustomer(int clientId, int partnerId)
        {
            return _webApi.ChangePartnerForCustomer("remove", clientId, partnerId);
        }

        // змінити поточний статус представника
        public bool AgreementPartnerStatusChange(int partnerId, CPartnerObjectStatus status)
        {
            string url = "partner/" + $"{partnerId}/statuschange";
            return _webApi.UpdateItem<object>(url, status.ToString("D"), null);
        }
    }
}
