using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
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
            var dictionaries = _webApi.GetItemById<ObjectRightDictionaries>("dictionary", "objectright");
            return dictionaries;
        }

        public IList<ObjectRightMainView> GetMainView()
        {
            var list = _webApi.GetList<ObjectRightMainView>("objectright/listobjectright");
            return list;
        }

        public ContainerForObjectRihgt GetData(int objId)
        {
            var item = _webApi.GetItemById<ContainerForObjectRihgt>("objectright/detail", objId.ToString());
            return item;
        }

        public bool Save(ObjectRight item)
        {
            if (item.ObjId == 0) // Новий об'єкт права
            {
                return _webApi.NewItem("objectright/newrightholder", item);
            }

            return _webApi.UpdateItem("objectright/detail", item.ObjId.ToString(), item);
        }
    }
}
