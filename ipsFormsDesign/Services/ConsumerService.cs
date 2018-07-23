using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using System;
using System.Collections.Generic;
using System.Text;
using ipsFormsDesign.Dictionary;
using WebAPIConnector;
using System.IO;
using System.Dynamic;
using System.Threading.Tasks;

namespace ipsFormsDesign.Services
{
    public class ConsumerService : IConsumerService
    {
        private ApiConnector _webApi = new ApiConnector();
        public Customer GetData(int custId)
        {
            var anketaDic = _webApi.GetItemById<Customer>("consumer/detail", custId.ToString());
            return anketaDic;
        }
        public AnketaDictionaties GetDictionary()
        {
            var anketaDic = _webApi.GetItemById<AnketaDictionaties>("dictionary", "anketa");
            return anketaDic;
        }
        public IList<ConsumerMainView> GetMainView()
        {
            return getMainView(ConsumerFilterEnum.All);
        }
        public IList<ConsumerMainView> getMainView(ConsumerFilterEnum what = ConsumerFilterEnum.All)
        {
            string url = $"consumer/listSR/{(int)what}";
            var anketaDic = _webApi.GetList<ConsumerMainView>(url);
            return anketaDic;
        }
        #region BRViews
        public IList<ConsumerBigRightView> getMainViewBR(TypeBRDocument typeDoc = TypeBRDocument.All, ConsumerFilterEnum what = ConsumerFilterEnum.All)
        {
            string url = $"consumer/listBR";
            KeyValuePair<string, string>[] param = new[] {
                new KeyValuePair<string, string>("whatId", ((int)what).ToString()),
                new KeyValuePair<string, string>("typeDocId", ((int)typeDoc).ToString())
            };
            var anketaDic = _webApi.GetList<ConsumerBigRightView>(url, param);
            return anketaDic;
        }
        public IList<VbrLicense> GetAgreementsBigRight(string custId)
        {
            string url = $"consumer/viewBR/" + custId;

            var agr = _webApi.GetListAgreement<VbrLicense>(url);
            return agr;
        }

        public IList<object> getBRView(Type typeResult, string viewName, int? custId)
        {
            string url = "consumer/BR/view/list";
            List<KeyValuePair<string, string>> param = new List<KeyValuePair<string, string>> { new KeyValuePair<string, string>("viewName", viewName) };
            if (custId != null)
                param.Add(new KeyValuePair<string, string>("custId", custId.ToString()));
            var list = _webApi.GetTypedList(typeResult, url, param.ToArray());
            return list;
        }
        #endregion

        /// <summary>
        /// Получити дані для авто заповнення
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public IList<AutoCompleteData> GetAutoCompleteList(string filter)
        {
            string url = $"consumer/listAll/{filter}";
            var list = _webApi.GetList<AutoCompleteData>(url);
            return list;
        }
        public Customer NewCustomer(int custType)
        {
            var anketaDic = _webApi.GetItemById<Customer>("consumer/newconsumer", custType.ToString());
            return anketaDic;
        }
        public bool Save(Customer cust)
        {
            if (cust.CustId == 0) // Новий споживач
            {
                return _webApi.NewItem<Customer>("consumer/newconsumer", cust);
            }

            return _webApi.UpdateItem<Customer>("consumer/detail", cust.CustId.ToString(), cust);
        }
        /// <summary>
        /// Запис файла на сервер
        /// </summary>
        /// <param name="custId">Ід користувача</param>
        /// <param name="typeDocument">Тип зі довідника</param>
        /// <param name="comment">Коментар</param>
        /// <param name="Document">назва файлу з повнм шляхом</param>
        public void uploadDocument(int custId, int typeDocument, string comment, string Document)
        {
            string url = $"consumer/Document/{custId}/{typeDocument}";
            var fileName = Path.GetFileName(Document);
            FileStream document = new FileStream(Document, FileMode.Open);
            Task.Run(() => _webApi.uploadFile(url, fileName, comment, document)).GetAwaiter().GetResult();
        }
        public Stream downloadDocument(int custId, int typeDocument, string fileName)
        {
            string url = $"consumer/Document/{custId}/{typeDocument}/{fileName}";
            return Task.Run(() => _webApi.downloadFile(url)).GetAwaiter().GetResult();
        }

        #region Payments
        public List<ExternalPay> GetCustomerPays( int custId )
        {
            string url = "consumer/PaydPeriod/GetPayments/" + custId.ToString();
            return _webApi.GetList<ExternalPay>(url); 
        }

        public bool SaveNewPayments( int custId, List<ExternalPay> pays )
        {
            string url = "consumer/PaydPeriod/GetPayments";
            var ret = _webApi.UpdateItem(url, custId.ToString(), pays);
            return ret;
        }

        public Customer getPaidInfo( int custId )
        {
            return _webApi.GetItemById<Customer>("consumer/PaydPeriod/GetCustomerInfo", custId.ToString());
        }

        public bool SavePeriods( int custId, List<PaidPeriod> periods)
        {
            return _webApi.UpdateItem("consumer/PaydPeriod/GetPayments/paidperiods", custId.ToString(), periods);
        }
        #endregion
    }
}
