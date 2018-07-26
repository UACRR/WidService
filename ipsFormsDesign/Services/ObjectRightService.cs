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
            var list = _webApi.GetList<ObjectRightMainView>("objectright/view/list_01");
            return list;
        }

        public List<ObjectRightMainView> GetObjectsByFilter( string filter )
        {
            string url = string.Concat("objectright/filteredObjectRights/", filter);
            var list = _webApi.GetList<ObjectRightMainView>(url);
            return list;
        }

        public IList<ObjectRightForRightholder> GetRightholdersObjectsRights(int custId)
        {
            var list = _webApi.GetList<ObjectRightForRightholder>($"objectright/view/list_0302/{custId}");
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
                return _webApi.NewItem("objectright/newobject", item);
            }

            return _webApi.UpdateItem("objectright/detail", item.ObjId.ToString(), item);
        }

        public ObjectRight NewObjectRight(int category)
        {
            var item = _webApi.GetItemById<ObjectRight>("objectright/new", category.ToString());
            return item;
        }

        public ContainerForObjectRihgt GetDataBr(int objId)
        {
            var item = _webApi.GetItemById<ContainerForObjectRihgt>("objectright/br/detail", objId.ToString());
            return item;
        }
        public bool SaveObjectBr(ObjectRight objectRight)
        {
            if (objectRight.ObjId == 0)
            {
                throw new NotImplementedException();
                //return _webApi.NewItem("objectright/br/newobject", objectRight);
            }

            return _webApi.UpdateItem("objectright/br/detail", objectRight.ObjId.ToString(), objectRight);
        }
    }
}
