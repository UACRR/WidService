using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using System;
using System.Collections.Generic;
using System.Text;
using ipsFormsDesign.Dictionary;
using WebAPIConnector;
using System.IO;
using System.Dynamic;

namespace ipsFormsDesign.Services
{
    public class ConsumerService : IConsumerService
    {
        private ApiConnector _webApi = new ApiConnector();
        public Customer GetData(int custId)
        {
            var anketaDic = _webApi.GetItemById<Customer>("consumer/detail", custId.ToString() );
            return anketaDic;
        }

        public AnketaDictionaties GetDictionary()
        {
            var anketaDic = _webApi.GetItemById<AnketaDictionaties>("dictionary","anketa");
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

        public IList<ConsumerBigRightView> getMainViewBR(TypeBRDocument typeDoc = TypeBRDocument.All,  ConsumerFilterEnum what = ConsumerFilterEnum.All)
        {
            string url = $"consumer/listBR";
            KeyValuePair<string, string>[] param = new[] {
                new KeyValuePair<string, string>("whatId", ((int)what).ToString()),
                new KeyValuePair<string, string>("typeDocId", ((int)typeDoc).ToString())
            };
            var anketaDic = _webApi.GetList<ConsumerBigRightView>(url, param );
            return anketaDic;
        }


        /// <summary>
        /// Получити дані для авто заповнення
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public IList<AutoCompleteData> GetAutoCompleteList( string filter)
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
            if( cust.CustId == 0 ) // Новий споживач
            {
                return _webApi.NewItem<Customer>("consumer/newconsumer", cust);
            }

            return _webApi.UpdateItem<Customer>("consumer/detail", cust.CustId.ToString(), cust);
        }

        public void uploadDocument(int custId, int typeDocument, string fileName, Stream Document)
        {
            string url = $"consumer/Document/{custId}/{typeDocument}";
            _webApi.uploadFile(url, fileName, Document).GetAwaiter().GetResult();
        }

        public Stream downloadDocument(int custId, int typeDocument, string fileName)
        {
            string url = $"consumer/Document/{custId}/{typeDocument}/{fileName}";
            return _webApi.downloadFile(url).GetAwaiter().GetResult();
        }
    }
}
