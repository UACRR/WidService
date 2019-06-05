using IpsCommonTypes.Types;
using ipsFormsDesign.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIConnector;

namespace ipsFormsDesign.Services
{
    public class RightholderRegisterService
    {
        private const string Prefix = "RightholderRegister";
        private readonly ApiConnector _apiConnector;
        private static RightholderRegisterService _service;

        private RightholderRegisterService()
        {
            _apiConnector = new ApiConnector();
        }

        public static RightholderRegisterService GetInstance()
        {
            if (_service == null)
                _service = new RightholderRegisterService();

            return _service;
        }

        /// <summary>
        /// Список файлів за ID правовласника
        /// </summary>
        /// <param name="custId"></param>
        /// <returns></returns>
        public List<CatalogFile> GetFileList(int custId)
        {
            string url = $"{Prefix}/{custId}";
            return _apiConnector.GetList<CatalogFile>(url);
        }

        /// <summary>
        /// Файл повністю за ID користувача та ID файла
        /// </summary>
        /// <param name="custId"></param>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public CatalogFile GetFile(int custId, int fileId)
        {
            string url = $"{Prefix}/{custId}/file";
            return _apiConnector.GetItemById<CatalogFile>(url, fileId.ToString());
        }

        /// <summary>
        /// Видалити файл правовласника
        /// </summary>
        /// <param name="custId"></param>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public bool DeleteFile(int custId, int fileId)
        {
            string url = $"{Prefix}/{custId}/file";
            return _apiConnector.DeleteItem(url, fileId.ToString());
        }

        // upload
        public CatalogFile UploadFile(int custId, CatalogFile sors)
        {
            string url = $"{Prefix}/{custId}/upload";
            return _apiConnector.NewItemWithResult(url, sors);
        }

        /// <summary>
        /// Зберегти коментар до файлу
        /// </summary>
        /// <param name="catalogFile"></param>
        /// <returns></returns>
        public bool SaveFileComment(CatalogFile catalogFile)
        {
            string url = $"{Prefix}/updatecomment";
            var result = _apiConnector.UpdateItem(url, string.Empty, catalogFile);
            return result;
        }

        public ExecSqlResponce<CatalogFile> Validate( CatalogFile file )
        {
            int custId = file.CustId ?? 0, fileId = file.FileId;
            string url = $"{Prefix}/{custId}/validate";
            _apiConnector.UpdateItemWithResult(url, null, null, out ExecSqlResponce<CatalogFile> outResult);
            return outResult;

        }

        public ExecSqlResponce<CatalogFile> Process(CatalogFile file)
        {
            int custId = file.CustId ?? 0, fileId = file.FileId;
            string url = $"{Prefix}/{custId}/process";
            _apiConnector.UpdateItemWithResult(url, null, null, out ExecSqlResponce<CatalogFile> outResult);
            return outResult;

        }
    }
}
