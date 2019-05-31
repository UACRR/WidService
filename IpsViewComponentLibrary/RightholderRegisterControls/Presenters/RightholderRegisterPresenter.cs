using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using IpsCommonTypes.Types;

namespace IpsViewComponentLibrary.RightholderRegisterControls.Presenters
{
    public class RightholderRegisterPresenter
    {
        public RightholderRegisterPresenter()
        {

        }

        public List<CatalogFile> GetFileList(int custId)
        {
            return new List<CatalogFile>
            {
                new CatalogFile{FileName = "File_01", CustId = 1},
                new CatalogFile{FileName = "File_02.04", CustId = 1},
                new CatalogFile{FileName = "File_qwertrty", CustId = 1}
            };
        }

        public List<RhcatalogItem> GetRHCatalogItems(int custId, int fileId)
        {
            return new List<RhcatalogItem>();
        }

        public CatalogFile UploadCatalogFile(CatalogFile catalogFile, string path)
        {
            return new CatalogFile();
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
