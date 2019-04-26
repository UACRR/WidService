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

        /// <summary>
        /// Отримати CatalogFile по ID правовласника/видавництва та ID файлу
        /// </summary>
        /// <param name="custId">ID правовласника/видавництва </param>
        /// <param name="fileId">ID файлу</param>
        /// <returns></returns>
        public CatalogFile GetCatalogFile(int custId, int fileId)
        {
            string url = $"{Prefix}/catalogfile/{custId}";
            var result = _apiConnector.GetItemById<CatalogFile>(url, fileId.ToString());
            return result;
        }

        /// <summary>
        /// Отримати список CatalogFile по ID правовласника/видавництва 
        /// </summary>
        /// <param name="custId">ID правовласника/видавництва</param>
        /// <returns></returns>
        public List<CatalogFile> GetCatalogFileList(int custId)
        {
            string url = $"{Prefix}/catalogfilelist/{custId}";
            var result = _apiConnector.GetList<CatalogFile>(url);
            return result;
        }

        /// <summary>
        /// Завантажити CatalogFile на сервер
        /// </summary>
        /// <param name="custId"></param>
        /// <param name="catalogFile"></param>
        /// <returns></returns>
        public CatalogFile UploadCatalogFile(int custId, CatalogFile catalogFile)
        {
            string url = $"{Prefix}/upload/{custId}";
            var result = _apiConnector.NewItemWithResult(url, catalogFile);
            return result;
        }

        /// <summary>
        /// Видалити CatalogFile
        /// </summary>
        /// <param name="custId">ID правовласника/видавництва </param>
        /// <param name="fileId">ID файлу</param>
        /// <returns></returns>
        public bool DeleteCatalogFile(int custId, int fileId)
        {
            string url = $"{Prefix}/delete/{custId}";
            var result = _apiConnector.DeleteItem(url, fileId.ToString());
            return result;
        }

        public bool SaveCatalogFileComment(CatalogFile catalogFile)
        {
            string url = $"{Prefix}/updatecomment";
            var result = _apiConnector.UpdateItem(url, string.Empty, catalogFile);
            return result;
        }

        public CatalogFile ValidateCatalogFileItems(CatalogFile catalogFile)
        {
            string url = $"{Prefix}/validate";
            CatalogFile outCatalogFile;
            var result = _apiConnector.UpdateItemWithResult(url, catalogFile.FileId.ToString(), null, out outCatalogFile);

            return outCatalogFile;
        }

        public CatalogFile ProcessCatalogFileItems(CatalogFile catalogFile)
        {
            string url = $"{Prefix}/process";
            CatalogFile outCatalogFile;
            var result = _apiConnector.UpdateItemWithResult(url, catalogFile.FileId.ToString(), null, out outCatalogFile);

            return outCatalogFile;
        }
    }
}
