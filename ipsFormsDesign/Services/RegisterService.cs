using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIConnector;

namespace ipsFormsDesign.Services
{
    public class RegisterService
    {
        private readonly ApiConnector _webApi;

        public RegisterService()
        {
            _webApi = new ApiConnector();
        }

        public List<RegisterListViewModel> GetListByFilter(RegisterFilter registerFilter)
        {
            var result = _webApi.GetList<RegisterListViewModel>("register/filter", registerFilter.GetKeyValuePairParameters());
            return result;
        }

        public Register GetById(int regId)
        {
            var item = _webApi.GetItemById<Register>("register", regId.ToString());
            return item;
        }

        public List<RegisterSearchObject> SearchObjects( string name, string authtors, string performers )
        {
            KeyValuePair<string, string>[] param = {
                new KeyValuePair<string, string>("name",name),
                new KeyValuePair<string, string>("authtors",authtors),
                new KeyValuePair<string, string>("performers",performers)
            };

            var list = _webApi.GetList<RegisterSearchObject>("register/search", param );

            return list;
        }
    }
}
