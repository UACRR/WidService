using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using System;
using System.Collections.Generic;
using System.Text;
using WebAPIConnector;

namespace ipsFormsDesign.Services
{
    public class RightholderService : IRightHolderService
    {
        private ApiConnector _webApi = new ApiConnector();

        public Customer GetData(int custId)
        {
            var anketaDic = _webApi.GetItemById<Customer>("rh/detail", custId.ToString() );
            return anketaDic;
        }

        public AnketaDictionaties GetDictionary()
        {
            var anketaDic = _webApi.GetItemById<AnketaDictionaties>("dictionary","anketa");
            return anketaDic;
        }

        public IList<RightholderMainView> GetMainView()
        {
            return GetRightholdersList("rh/listrh");
        }

        public IList<RightholderMainView> GetMainViewByStatus(RightholderStatusType rightholderStatus)
        {
            var resourceUrl = "rh/listrh" + "/" + rightholderStatus.ToString().ToLower();

            return GetRightholdersList(resourceUrl);
        }

        public Customer NewCustomer(int custType)
        {
            var anketaDic = _webApi.GetItemById<Customer>("rh/newrightholder", custType.ToString());
            return anketaDic;
        }

        public bool Save(Customer cust)
        {
            if( cust.CustId == 0 ) // Новий споживач
            {
                return _webApi.NewItem<Customer>("rh/newrightholder", cust);
            }

            return _webApi.UpdateItem<Customer>("rh/detail", cust.CustId.ToString(), cust);
        }

        private IList<RightholderMainView> GetRightholdersList(string resourceUrl)
        {
            var list = _webApi.GetList<RightholderMainView>(resourceUrl);
            return list;
        }

        public bool SetStatus(int CustId, RightholderStatusType status)
        {
            return _webApi.UpdateItem("rh/setstatus", CustId.ToString(), status);
        }

        public bool Inherit(int rhId, List<RightHolder> inheritData)
        {
            return _webApi.ApiAction<RightHolder>("rh/inheritance", rhId, inheritData);
        }

        public IList<Authors> getAuthorsByFilter( string filterString )
        {
            var url = string.Concat("rh/filters/authors/", filterString);
            var listOfAuthors = _webApi.GetList<Authors>(url);
            return listOfAuthors;
        }

        #region Copyright requests

        public IList<RightolderWithNotAcceptedCopyrightViewModel> GetRightholdersWithNotAcceptedCopyrights()
        {
            var list = _webApi.GetList<RightolderWithNotAcceptedCopyrightViewModel>("rh/withNotAcceptedCopyrights");
            return list;
        }

        public IList<ObjectRightNotAccepted> GetNotAcceptedObjectsByRightholder(int custId)
        {
            var list = _webApi.GetList<ObjectRightNotAccepted>($"rh/notAcceptedObjects/{custId}");
            return list;
        }

        public bool UpdateCopyrights(List<CopyRight> copyrighList)
        {
            return _webApi.UpdateItem("rh/updateCopyrights", null, copyrighList);
        }

        #endregion

#if DEBUG
        public class DebugInheritData
        {
            public DebugInheritData()
            {
                listCopyRight = new List<CopyRight>();
                authtors = new List<Authors>();
                inheriers = new List<CopyRight>();
            }
            public List<CopyRight> listCopyRight { get; }
            public List<Authors> authtors { get; }
            public List<CopyRight> inheriers { get; }
        }
        public DebugInheritData InheritDebug(int checkCustId, List<RightHolder> inheritData)
        {
            return _webApi.ApiFunc<RightHolder, DebugInheritData>("rh/inheritancedebug", checkCustId, inheritData);
        }
#endif
    }
}
