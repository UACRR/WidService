using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IpsCommonTypes.Types;

namespace IpsViewComponentLibrary.RightholderRegisterControls.Presenters
{
    public class RightholderRegisterPresenter
    {
        private readonly RightholderRegisterService _service;
        private readonly ExcelEngine _exelEngine;

        public RightholderRegisterPresenter()
        {
            _service = RightholderRegisterService.GetInstance();
            _exelEngine = ExcelEngine.GetInstance();
        }

        public List<CatalogFile> GetFileList(int custId)
        {
            return _service.GetFileList(custId);
        }

        public List<RhcatalogItem> GetRHCatalogItems(int custId, int fileId)
        {
            return new List<RhcatalogItem>();
        }

        public CatalogFile UploadCatalogFile(CatalogFile catalogFile, string path)
        {
            if (catalogFile.CustId == null || catalogFile.CustId == 0)
                throw new ArgumentOutOfRangeException($"CustId must be not null/0!");

            var PubCatalogItemList = GetRightholderRegister(path);
            catalogFile.RhcatalogItem = new ObservableListSource<RhcatalogItem>(PubCatalogItemList);

            // result can be used
            var result = _service.UploadFile((int)catalogFile.CustId, catalogFile);
            return result;
        }

        /// <summary>
        /// Конвертація Xls файлу в список PubCatalogItem
        /// </summary>
        /// <param name="fileName">Назва Xls файлу</param>
        /// <returns></returns>
        private List<RhcatalogItem> GetRightholderRegister(string fileName)
        {
            return new List<RhcatalogItem>();
        }

        /// <summary>
        /// Видалити файл
        /// </summary>
        /// <param name="custId"></param>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public bool DeleteCatalogFile(int custId, int fileId)
        {
            return false;
        }

        public bool SaveRightholderRegister(CatalogFile catalogFile)
        {
            return false;
        }

        public ExecSqlResponce<CatalogFile> ValidateRightholderRegister(CatalogFile catalogFile)
        {
            return new ExecSqlResponce<CatalogFile>();
        }

        public ExecSqlResponce<CatalogFile> ProcessRightholderRegister(CatalogFile catalogFile)
        {
            return new ExecSqlResponce<CatalogFile>();
        }
    }
}
