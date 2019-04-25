using System.Collections.Generic;
using ipsFormsDesign.Model;
using WebAPIConnector;

namespace ipsFormsDesign.Services
{
    public class CatalogService
    {
        private const string Prefix = "catalog";
        private readonly ApiConnector _apiConnector;
        private static CatalogService _service;

        private CatalogService()
        {
            _apiConnector = new ApiConnector();
        }

        public static CatalogService GetInstance()
        {
            if (_service == null)
                _service = new CatalogService();

            return _service;
        }

        public List<CatalogFile> GetCatalogFileList(int custId)
        {
            string url = $"{Prefix}/filelist/{custId}";
            var result = _apiConnector.GetList<CatalogFile>(url);
            return result;
        }

        public CatalogFile UploadCatalogFile(int custId, CatalogFile catalogFile)
        {
            string url = $"{Prefix}/upload/{custId}";
            var result = _apiConnector.NewItemWithResult(url, catalogFile);
            return result;
        }

        public bool DeleteCatalogFile(int custId, int fileId)
        {
            string url = $"{Prefix}/delete/{custId}";
            var result = _apiConnector.DeleteItem(url, fileId.ToString());
            return result;
        }
    }
}
