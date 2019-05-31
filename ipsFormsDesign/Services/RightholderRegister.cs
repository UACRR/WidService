using ipsFormsDesign.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIConnector;

namespace ipsFormsDesign.Services
{
    class RightholderRegisterService
    {
        private const string _prefix = "rightholderregister";
        private readonly ApiConnector _apiConnector;
        private static RightholderRegisterService _service;

        private RightholderRegisterService() {
            _apiConnector = new ApiConnector();
        }
        public RightholderRegisterService GetInstance()
        {
            if (_service == null)
                _service = new RightholderRegisterService();

            return _service;
        }

        // *** GET --- List CatalogFile
        public List<CatalogFile> GetFileList( int custId )
        {
            string url = $"{_prefix}/{custId}";
            return _apiConnector.GetList<CatalogFile>(url);
        }
        // file
        // *** Get
        public CatalogFile GetFile( int custId, int fileId )
        {
            string url = $"{_prefix}/{custId}/file";
            return _apiConnector.GetItemById<CatalogFile>(url, fileId.ToString());
        }
        // *** Delete
        public bool DeleteFile(int custId, int fileId)
        {
            string url = $"{_prefix}/{custId}/file";
            return _apiConnector.DeleteItem(url, fileId.ToString());
        }
        // *** Update
        public CatalogFile UpdateFile(int custId, int fileId, CatalogFile sors )
        {
            string url = $"{_prefix}/{custId}/file";
            return _apiConnector.UpdateItemWithResult(url, fileId.ToString(), sors);
        }

        // upload
        public CatalogFile UploadFile(int custId, CatalogFile sors)
        {
            string url = $"{_prefix}/{custId}/upload";
            return _apiConnector.NewItemWithReturn(url, sors);
        }
    }
}
