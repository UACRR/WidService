using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using ipsFormsDesign.Model;
using IpsCommonTypes.Types;
using IpsCommonTypes.Wrappers;
using Telerik.WinControls;
using WebAPIConnector;
using System.Threading.Tasks;

namespace ipsFormsDesign.Services
{
    public class RightholderCatalogService
    {
        private const string Prefix = "catalog";
        private readonly ApiConnector _apiConnector;
        private static RightholderCatalogService _service;

        private RightholderCatalogService()
        {
            _apiConnector = new ApiConnector();
        }

        public static RightholderCatalogService GetInstance()
        {
            if (_service == null)
                _service = new RightholderCatalogService();

            return _service;
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
        /// Отримати CatalogFile по ID правовласника/видавництва та по FileId
        /// </summary>
        /// <param name="custId">ID правовласника/видавництва</param>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public CatalogFile GetCatalogFile(int custId, int fileId )
        {
            string url = $"{Prefix}/catalogfile/{custId}/{fileId}";
            var result = _apiConnector.GetItemById<CatalogFile>(url, null);
            return result;
        }

        /// <summary>
        /// Отримати частину записів каталогу
        /// </summary>
        /// <param name="fileId"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        public List<PubCatalogItem> GetCatalogFileItems(int fileId, int skip, int take)
        {
            string url = $"{Prefix}/catalogfileitems/{fileId}/{skip}/{take}";
            var result = _apiConnector.GetList<PubCatalogItem>(url);
            return result;
        }

        /// <summary>
        /// Отримати дані для експорту
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public List<object[]> GetItemsForExport(int fileId)
        {
            string url = $"{Prefix}/exportdata/{fileId}";
            var result = _apiConnector.GetList<object[]>(url);
            return result;
        }

        /// <summary>
        /// Завантажити CatalogFile на сервер
        /// </summary>
        /// <param name="custId"></param>
        /// <param name="catalogFile"></param>
        /// <returns></returns>
        public async Task<CatalogFile> UploadCatalogFileAsync(CatalogFile catalogFile, List<List<string>> items)
        {
            string url = $"{Prefix}/upload/{catalogFile.CustId}";
            var wrapData = new ObjectAndItemsWrap<CatalogFile, List<string>>(catalogFile, items);
            //var result = _apiConnector.NewItemWithResult<CatalogFile, object>(url, wrapData);
            var result = await _apiConnector.SendPostRequestWithResultAsync<CatalogFile, ObjectAndItemsWrap<CatalogFile, List<string>>>(url, wrapData);
            return result;
        }

        /// <summary>
        /// Видалити CatalogFile
        /// </summary>
        /// <param name="custId">ID правовласника/видавництва </param>
        /// <param name="fileId">ID файлу</param>
        /// <returns></returns>
        public ExecSqlResponce DeleteCatalogFile(int custId, int fileId)
        {
            string url = $"{Prefix}/delete/{custId}/{fileId}";
            var result = _apiConnector.DeleteItemWithResponce(url);
            return result;
        }

        public bool SaveCatalogFileComment(CatalogFile catalogFile)
        {
            string url = $"{Prefix}/updatecomment";
            var result = _apiConnector.UpdateItem(url, string.Empty, catalogFile);
            return result;
        }

        public ExecSqlResponce<CatalogFile> ValidateCatalogFileItems(CatalogFile catalogFile)
        {
            string url = $"{Prefix}/validate";
            var result = _apiConnector.UpdateItemWithResult<ExecSqlResponce<CatalogFile>>(url, catalogFile.FileId.ToString(), null);
            return result;
        }

        /// <summary>
        /// Async call procedure
        /// </summary>
        /// <param name="catalogFile"></param>
        /// <returns></returns>
        public async Task<ExecSqlResponce<CatalogFile>> ValidateCatalogFileItemsAsync(CatalogFile catalogFile)
        {
            string url = $"{Prefix}/validate/{catalogFile.FileId}";
            return await _apiConnector.SendPutRequestWithResultAsync<ExecSqlResponce<CatalogFile>>(url, null);
        }

        public ExecSqlResponce<CatalogFile> ProcessCatalogFileItems(CatalogFile catalogFile)
        {
            string url = $"{Prefix}/process";
            var result = _apiConnector.UpdateItemWithResult(url, catalogFile.FileId.ToString(), null, out ExecSqlResponce<CatalogFile> outCatalogFile);
            return outCatalogFile;
        }

        public void ShowErrors()
        {
            foreach (var error in _apiConnector.ResponseErrors)
            {
                string str = $"MethodType:{error.MethodType}, StatusCode: {error.StatusCode}, Message: {error.ReasonPhrase}";
                MessageBox.Show(str, "request error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
