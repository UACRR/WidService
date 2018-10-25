using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services.ObjectUploading;
using ipsFormsDesign.Utilities;
using ipsFormsDesign.ViewModels.ObjectsRight;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        // use this method to fetch objects list
        public ObjectRightListResponse GetObjectRights(ObjectRightQuery query)
        {
            var result = _webApi.GetItemByIdWithParam<ObjectRightListResponse>("objectright", null, query.ToKeyValuePair());
            return result;
        }

        public async Task<ObjectRightListResponse> GetObjectRightsAsync(ObjectRightQuery query)
        {
            return await Task.Factory.StartNew(() => GetObjectRights(query));
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

        public ContainerForObjectRihgt GetObjectById(int objId)
        {
            var item = _webApi.GetItemById<ContainerForObjectRihgt>("objectright/detail", objId.ToString());
            return item;
        }

        public List<ObjectRightholderViewModel> GetObjectRightholders(int objId)
        {
            return _webApi.GetList<ObjectRightholderViewModel>($"objectright/{objId}/rightholders");
        }

        public bool Save(ObjectRight item)
        {
            ObjectRight result;

            if (item.ObjId == 0) // Новий об'єкт права
            {
                result = _webApi.NewItemWithResult("objectright/newobject", item);
            }
            else
            {
                result = _webApi.UpdateItemWithResult("objectright/detail", item.ObjId.ToString(), item);
            }

            if (result != null)
            {
                item.SetFields(result);
                return true;
            }
            else
                return false;
        }

        public ObjectRight NewObjectRight(int category)
        {
            var item = _webApi.GetItemById<ObjectRight>("objectright/new", category.ToString());
            return item;
        }

        public List<ObjectRightData> ValidateObjectsRight(List<ObjectRightData> objectRightList)
        {
            return _webApi.NewListItemWithResult("objectright/validate", objectRightList);
        }

        public bool AddAuthorRightholderForObject(int objId, ObjectAuthorRightholder objectAuthorRightholder, out string error)
        {
            var objectRightContainer = GetObjectById(objId);
            var objectRight = objectRightContainer.objectRight;

            if (objectRight.CopyRight.GetTotalRate() >= 100)
            {
                error = "Спільний відсоток володіння для вибраного об'єкта вже становить 100%.";
                return false;
            }

            objectRight.AddObjectAuthorRightholder(objectAuthorRightholder);

            if (objectRight.CopyRight.GetTotalRate() > 100)
            {
                error = "Спільний відсоток володіння з врахуванням доданого перевищує 100%. Об'єкт не доданий.";
                return false;
            }

            var result = Save(objectRight);

            if (!result)
                error = "Не вдалося зберегти зміни. Об'єкт не доданий.";
            else
                error = "";

            return result;
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
