using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using IpsCommonTypes.ClassesForSearchQuery;
using IpsCommonTypes.Types;
using WebAPIConnector;

namespace ipsFormsDesign.Services
{
    public class RegisterService
    {
        private readonly ApiConnector _webApi;
        private const string Prefix = "register";

        public RegisterService()
        {
            _webApi = new ApiConnector();
        }

        /// <summary>
        /// Отримати дані звіту по ID для перегляду
        /// </summary>
        /// <param name="regId"></param>
        /// <returns></returns>
        public Register GetCCIDRegister(int regId)
        {
            string url = $"register/ccid/{regId}";
            var result = _webApi.GetItemById<LicenseAgreement>(url, null);

            foreach (var period in result.PaidPeriod)
            {
                period.Lic = result;

                foreach (var rateList in period.RegisterRatedList)
                {
                    rateList.Period = period;
                    foreach (var register in rateList.Register)
                    {
                        register.Rm = rateList;
                    }
                }
            }

            return result.PaidPeriod?.FirstOrDefault()?.RegisterRatedList?.FirstOrDefault()?.Register.FirstOrDefault();
        }

        /// <summary>
        /// Отримати вміст звіту для перегляду
        /// </summary>
        /// <param name="regId"></param>
        /// <returns></returns>
        public async Task<List<object[]>> GetCCIDRegisterItems(int regId)
        {
            string url = $"register/ccid/items/{regId}";
            var result = await _webApi.GetListAsync<object[]>(url);
            return result;
        }

        /// <summary>
        /// Отримати список звітів малих прав
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        public async Task<ResponseOfRequest<DataTable>> GetSRReportsList(SearchModuleResource resource)
        {
            string url = $"{Prefix}/list/sr";
            var result = await _webApi.SendPostRequestWithResultAsync<ResponseOfRequest<DataTable>, SearchModuleResource>(url, resource);
            return result;
        }

        /// <summary>
        /// Отримати список звітів онлайн-ресурси
        /// </summary>
        /// <param name="resource"></param>
        /// <returns></returns>
        public async Task<ResponseOfRequest<DataTable>> GetOnlineReportsList(SearchModuleResource resource)
        {
            string url = $"{Prefix}/list/online";
            var result = await _webApi.SendPostRequestWithResultAsync<ResponseOfRequest<DataTable>, SearchModuleResource>(url, resource);
            return result;
        }

        public List<RegisterListViewModel> GetListByFilter(RegisterFilter registerFilter)
        {
            var result = _webApi.GetList<RegisterListViewModel>("register/filter", registerFilter.GetKeyValuePairParameters());
            return result;
        }

        public List<RegisterListViewModel> GetExternalListByFilter(RegisterFilter registerFilter)
        {
            var result = _webApi.GetList<RegisterListViewModel>("register/ccid/filter", registerFilter.GetKeyValuePairParameters());
            return result;
        }

        public Register GetById(int regId)
        {
            var item = _webApi.GetItemById<LicenseAgreement>("register", regId.ToString());
            if (item == null)
                return null;

            foreach ( var period in item.PaidPeriod )
            {
                period.Lic = item;

                foreach( var rateList in period.RegisterRatedList )
                {
                    rateList.Period = period;
                    foreach (var register in rateList.Register )
                    {
                        register.Rm = rateList;
                        foreach (var items in register.RegisterItem)
                        {
                            items.Reg = register;
                            foreach (var extra in items.RegisterExtra)
                                extra.RegI = items;
                        }

                    }
                }

            }

            return item.PaidPeriod.FirstOrDefault().RegisterRatedList.FirstOrDefault().Register.FirstOrDefault();
        }

        public List<RegisterSearchObject> SearchObjects(string name, string authtors, string performers)
        {
            KeyValuePair<string, string>[] param =
            {
                new KeyValuePair<string, string>("name", name),
                new KeyValuePair<string, string>("authtors", authtors),
                new KeyValuePair<string, string>("performers", performers)
            };

            var list = _webApi.GetList<RegisterSearchObject>("register/search", param);

            return list;
        }

        public bool Save(Register register)
        {
            if (register.RegId == 0)
            {
                throw new NotImplementedException();
            }

            return _webApi.UpdateItem("register", register.RegId.ToString(), register);
        }

        public bool SetStatus(int regId, RegisterStatusType status)
        {
            return _webApi.UpdateItem("register/setstatus", regId.ToString(), status);
        }

        public List<RegisterItemViewModel> GetAutoLinkedObjects(int regId)
        {
            var list = _webApi.GetList<RegisterItemViewModel>($"register/{regId}/autolinkedobjects");
            return list;
        }

        /// <summary>
        /// Запустити процедуру синхронізації
        /// </summary>
        /// <param name="regId"></param>
        /// <returns></returns>
        public async Task<ResponseOfRequest> ExecuteSyncProcedure(int regId)
        {
            string url = $"register/ccid/sync/{regId}";
            var result = await _webApi.SendGetRequestAsync<ResponseOfRequest>(url);
            return result;
        }

        /// <summary>
        /// Запустити процедуру розподілу
        /// </summary>
        /// <param name="regId"></param>
        /// <returns></returns>
        public async Task<ResponseOfRequest> ExecuteDistributionProcedure(int regId)
        {
            string url = $"register/ccid/distribution/{regId}";
            var result = await _webApi.SendGetRequestAsync<ResponseOfRequest>(url);
            return result;
        }

        /// <summary>
        /// Запустити процедуру оплати
        /// </summary>
        /// <param name="regId"></param>
        /// <returns></returns>
        public async Task<ResponseOfRequest> ExecutePaymentProcedure(int regId)
        {
            string url = $"register/ccid/payment/{regId}";
            var result = await _webApi.SendGetRequestAsync<ResponseOfRequest>(url);
            return result;
        }
    }
}
