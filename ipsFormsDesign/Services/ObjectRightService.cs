using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPIConnector;

namespace ipsFormsDesign.Services
{
    public class ObjectRightService
    {
        private ApiConnector _webApi = new ApiConnector();

        public ObjectRightDictionaries GetDictionary()
        {
            var item = _webApi.GetItemById<ObjectRightDictionaries>("dictionary", "objectright");
            return item;
        }

        public IList<ObjectRightMainView> GetMainView()
        {
            var list = _webApi.GetList<ObjectRightMainView>("objectright/listobjectright");
            return list;
        }
    }
}
