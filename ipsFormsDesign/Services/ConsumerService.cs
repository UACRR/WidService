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
using ipsmedserviceapp.Model.SQLViewsData;
// ReSharper disable All

namespace ipsFormsDesign.Services
{
    public class ConsumerService : IConsumerService
    {
        private ApiConnector _webApi = new ApiConnector();
        private readonly string _prefix = "consumer/";


        public Customer GetData(int custId)
        {
            var consumer = _webApi.GetItemById<Customer>("consumer/detail", custId.ToString());
            return consumer;
        }

        public ConsumerMainView GetShortInfoById(int custId)
        {
            var consumerInfo = _webApi.GetItemById<ConsumerMainView>("consumer/info", custId.ToString());
            return consumerInfo;
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

        public IList<ConsumerMainView> GetListAll()
        {
            var list = _webApi.GetList<ConsumerMainView>("consumer/listall");
            return list;
        }

        public Customer GetExternalById(int custId)
        {
            var item = _webApi.GetItemById<Customer>("consumers/external", custId.ToString());
            return item;
        }

        public bool SaveExternal(Customer customer)
        {
            if (customer.CustId == 0) // Новий споживач
            {
                return _webApi.NewItem("consumers/external", customer);
            }

            return _webApi.UpdateItem("consumers/external", customer.CustId.ToString(), customer);
        }

        #region BigRight
        public IList<MainGridConsumerBigRightView> getMainViewBR(TypeBRDocument typeDoc = TypeBRDocument.All, ConsumerFilterEnum what = ConsumerFilterEnum.All)
        {
            string url = $"consumer/listBR";
            KeyValuePair<string, string>[] param = new[] {
                new KeyValuePair<string, string>("whatId", ((int)what).ToString()),
                new KeyValuePair<string, string>("typeDocId", ((int)typeDoc).ToString())
            };
            var anketaDic = _webApi.GetList<MainGridConsumerBigRightView>(url, param);
            return anketaDic;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="custId"></param>
        /// <returns></returns>
        public IList<LicenseAgreementBigRightView> GetAgreementsBigRight(string custId)
        {
            string url = $"consumer/viewBR/" + custId;

            var agr = _webApi.GetListAgreement<LicenseAgreementBigRightView>(url);
            return agr;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="typeResult"></param>
        /// <param name="viewName"></param>
        /// <param name="custId"></param>
        /// <returns></returns>
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
        #region Register Методи обробки 

        /// <summary>
        /// Отримати дані звіту
        /// </summary>
        /// <param name="regId">Ід звіту</param>
        /// <returns></returns>
        public List<RegisterItem> GetRegisterItems(int regId)
        {
            string url = $"consumer/period/register/RegisterItem/{regId}";
            return _webApi.GetList<RegisterItem>(url);
        }

        /// <summary>
        /// Отримати список Р/Л для споживача з параметром
        /// </summary>
        /// <param name="custId"></param>
        /// <returns></returns>
        public Customer GetRatedListForCust( int custId )
        {
            string url = _prefix + "period/register/RatedList";
            KeyValuePair<string, string> customer = new KeyValuePair<string, string>("custId", custId.ToString());
            return _webApi.GetItemByIdWithParam<Customer>(url, string.Empty, customer);
        }

        /// <summary>
        /// Отримати Р/Л по Ідентифікатору
        /// </summary>
        /// <param name="rmId"></param>
        /// <returns></returns>
        public RegisterRatedList GetRatedList( int rmId )
        {
            string url = _prefix + "period/register/RatedList";
            return _webApi.GetItemById<RegisterRatedList>(url, rmId.ToString());
        }

        public bool DeleteRatedList(int rmId)
        {
            string url = _prefix + "period/register/RatedList";
            return _webApi.DeleteItem(url, rmId.ToString());

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="regRatedList"></param>
        /// <param name="retObject"></param>
        /// <returns></returns>
        public bool SaveRegisterRatedList(RegisterRatedList regRatedList, out RegisterRatedList retObject)
        {
            string rmId = regRatedList.RmId == 0 ? string.Empty : regRatedList.RmId.ToString();
            return _webApi.UpdateItemWithReturn("consumer/period/register/RatedList", rmId, regRatedList, out retObject);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public bool SaveRegister(Register body)
        {
            string id = body.RegId == 0 ? string.Empty : body.RegId.ToString();
            return _webApi.UpdateItem<Register>("consumer/period/register", id, body);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="body"></param>
        /// <returns></returns>
        public bool DeleteRegister(Register body)
        {
            return _webApi.DeleteItem("consumer/period/register", body.RegId.ToString());
        }

        public Register GetRegister( int regId )
        {
            string url = _prefix + "period/register";
            return _webApi.GetItemById<Register>(url, regId.ToString());
        }

        public enum RegisterState : int
        {
            // Новий
            newItem = 0,
            // На погоджені
            OnAccept = 1,
            // Погоджений
            Accepted = 2,
            // До розподілу
            OnRate = 3,
            // Виконано
            Worked = 4,
            // Відхилено
            Rejected = 5
        }
        /// <summary>
        /// Зміна стану звітів
        /// </summary>
        /// <param name="state"></param>
        /// <param name="list"></param>
        /// <returns></returns>
        public List<Register> SetRegisterState(RegisterState state, List<Register> list )
        {
            string url = _prefix + "period/register/state";
            List<Register> retList = null;

            var ret = _webApi.UpdateListItemWithReturn(url, ((int)state).ToString(), list, out retList);
            if (ret == true)
                return retList;

            return null;
        }

        /*
         
             codeI	name
1	Прийом звітів
2	Прийом коштів
3	Борг
4	Судова робота
6	Кошти отримані
7	Закритий
             */
        public enum PeriodState : int
        {
            /// <summary>
            /// Прийом звітів
            /// </summary>
            getReport = 1,
            /// <summary>
            /// Прийом коштів
            /// </summary>
            getPay = 2,
            /// <summary>
            /// Борг
            /// </summary>
            Debt = 3,
            /// <summary>
            /// Судова робота
            /// </summary>
            Court = 4,
            /// <summary>
            /// Кошти отримані
            /// </summary>
            Paid = 6,
            /// <summary>
            /// Закритий
            /// </summary>
            Close = 7
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="v"></param>
        /// <param name="period"></param>
        public bool SetPeriodState(PeriodState state, PaidPeriod period)
        {
            string url = _prefix + $"period/state/{period.PeriodId}/{(int)state}";
            return _webApi.UpdateItem(url, string.Empty, period);
        }

        #endregion



        /// <summary>
        /// Получити дані для авто заповнення
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        public IList<AutoCompleteData> GetAutoCompleteList(string filter)
        {
            string url = $"consumer/listAutoCompleted";
            KeyValuePair<string, string> param = new KeyValuePair<string, string>("filter", filter);
            var list = _webApi.GetList<AutoCompleteData>(url, param);
            return list;
        }

        /// <summary>
        /// отримати шаблон customer
        /// </summary>
        /// <param name="custType"></param>
        /// <returns></returns>
        public Customer NewCustomer(int custType)
        {
            var anketaDic = _webApi.GetItemById<Customer>("consumer/newconsumer", custType.ToString());
            return anketaDic;
        }

        /// <summary>
        /// Зберегти customer
        /// </summary>
        /// <param name="cust"></param>
        /// <returns></returns>
        public bool Save(Customer cust)
        {
            if (cust.CustId == 0) // Новий споживач
            {
                return _webApi.NewItem<Customer>("consumer/newconsumer", cust);
            }

            return _webApi.UpdateItem<Customer>("consumer/detail", cust.CustId.ToString(), cust);
        }

        /// <summary>
        /// Використовується для збереження змін генерального договору великих прав
        /// </summary>
        /// <param name="agrId">ID agreementAddBr</param>
        /// <param name="agreement">Генеральна угода</param>
        /// <returns></returns>
        public bool SaveAgreementAddBrById(int agrId, LicenseAgreement agreement)
        {
            return _webApi.UpdateItem<LicenseAgreement>("consumer/genagrprol", agrId.ToString(), agreement);
        }

        #region * * * FILES * * * 

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

        /// <summary>
        /// Завантажити файл (документ) з сервера
        /// </summary>
        /// <param name="custId">ID користувача</param>
        /// <param name="typeDocument">Тип файлу</param>
        /// <param name="fileName">Найменування файлу</param>
        /// <returns>File-stream</returns>
        public Stream downloadDocument(int custId, int typeDocument, string fileName)
        {
            string url = $"consumer/Document/{custId}/{typeDocument}/{fileName}";
            return Task.Run(() => _webApi.downloadFile(url)).GetAwaiter().GetResult();
        }

        /// <summary>
        /// Видалити файл з сервера по ID 
        /// </summary>
        /// <param name="fileId">ID файла</param>
        /// <returns></returns>
        public bool DeleteFileById(int fileId)
        {
            string url = "consumer/document/delete";
            return _webApi.DeleteItem(url, fileId.ToString());
        }

        #endregion


        #region Payments
        /// <summary>
        /// Отримати всі зовнішні платежі користувача 
        /// </summary>
        /// <param name="custId"></param>
        /// <returns></returns>
        public List<ExternalPay> GetCustomerPays( int custId )
        {
            string url = "consumer/Period/Payments/" + custId.ToString();
            return _webApi.GetList<ExternalPay>(url); 
        }

        /// <summary>
        /// Збереження підтвердження Споживача по великим правам
        /// </summary>
        /// <param name="licId"></param>
        /// <param name="worrh"></param>
        /// <returns></returns>
        public bool SaveBRWorkRH(int licId, List<WorkRh> worrh)
        {
            string url = string.Concat(_prefix, "BR/WorkRH");
            return _webApi.UpdateItem<List<WorkRh>>(url, licId.ToString(), worrh);
        }

        /// <summary>
        /// Збереження нових зовнішніх платежів (відлагодження)
        /// </summary>
        /// <param name="custId"></param>
        /// <param name="pays"></param>
        /// <returns></returns>
        public bool SaveNewPayments( int custId, List<ExternalPay> pays )
        {
            string url = "consumer/Period/Payments";
            var ret = _webApi.UpdateItem(url, custId.ToString(), pays);
            return ret;
        }

        public enum LicType : int
        {
            License = 1,
            Request = 2,
            Reference = 3
        }

        /// <summary>
        /// Перевод типу ліц. договору з Заявки в Довідку та ліц договір.
        /// </summary>
        /// <param name="lic"></param>
        /// <param name="typeId">Тип ліцензії</param>
        /// <returns></returns>
        public bool SetLicenseType(LicenseAgreement lic, LicType typeId)
        {
            string url = _prefix + $"license/type/{lic.LicId}/{(int)typeId}";
            return _webApi.UpdateItem<LicenseAgreement>(url, null, null);

        }

 
        /// <summary>
        /// Отримати всю інормацію по поточним періодам оплати для інтерфейсу Розрахунки
        /// </summary>
        /// <param name="custId"></param>
        /// <returns></returns>
        public Customer getPaidInfo( int custId )
        {
            return _webApi.GetItemById<Customer>("consumer/Period/GetCustomerInfo", custId.ToString());
        }

        /// <summary>
        /// Зберігання нових періодів
        /// </summary>
        /// <param name="custId"></param>
        /// <param name="periods">Нові періоди</param>
        /// <returns></returns>
        public List<PaidPeriod> SavePeriods(int custId, List<PaidPeriod> periods)
        {
            List<PaidPeriod> retList = null;
            var retCode = _webApi.UpdateListItemWithReturn("consumer/Period/Payments/paidperiods", custId.ToString(), periods, out retList );
            return retList;
        }

        public bool SetLicAgreementStatus(LicenseAgreement agr, int version, int status, bool toChangeVersion = false)
        {
            string url = $"consumer/license/State/{version}/{status}/{(toChangeVersion ? 1 : 0)}";
            var ret = _webApi.UpdateItem<LicenseAgreement>(url, null, agr );

            return ret;
        }

        /// <summary>
        /// Зберігання прив'язаних сум
        /// </summary>
        /// <param name="custId"></param>
        /// <param name="listLinks">Прив'язані суми</param>
        /// <returns></returns>
        public List<MoneyPeriodLink> SaveLink(int custId, List<MoneyPeriodLink> listLinks)
        {
            List<MoneyPeriodLink> list;
            var retCode = _webApi.UpdateListItemWithReturn("consumer/Period/Payments/linkperiods", custId.ToString(), listLinks, out list );
            if (retCode)
                return list;
            return null;
        }
        #endregion

    }
    public enum CPartnerObjectStatus : int
    {
        /// <summary>
        /// Empty
        /// </summary>
        None = -1,

        /// <summary>
        /// Активація
        /// </summary>
        Activate = 2,

        /// <summary>
        /// Закрити
        /// </summary>
        Close = 4,
    }
}
