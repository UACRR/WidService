using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IpsCommonTypes.Types;
using IpsViewComponentLibrary.Shared.Interfaces;
using TimeSpan = System.TimeSpan;

namespace IpsViewComponentLibrary.RightholderRegisterControls.Presenters
{
    public class RightholderRegisterPresenter: ICatalogFileItemsHandler
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

        public CatalogFile GetFileWithRHCatalogItems(int custId, int fileId)
        {
            return _service.GetFile(custId, fileId);
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
            try
            {
                var data = _exelEngine.ReadData(fileName);
                
                List<RhcatalogItem> newItems = new List<RhcatalogItem>();

                foreach (var item in data)
                {
                    RhcatalogItem newItem = CreateItemFromXlsRow(item);
                    newItems.Add(newItem);
                }
                return newItems;
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Перетворення рядка Xls файлу в об'єкт RhcatalogItem
        /// </summary>
        /// <param name="item">рядок XLS файлу</param>
        /// <returns></returns>
        private RhcatalogItem CreateItemFromXlsRow(List<string> item)
        {
            if (item.Count < 7)
                throw new ArgumentException("Неправильна структура файлу! Кількість колонок з даними повинна дорівнювати 7!");

            var newItem = new RhcatalogItem
            {
                ItemCode = item[0],
                ObjName = item[1],
                GenreName = item[2],
                //Duration = GetTimeFromString(item[3]),
                RoleName = item[4],
                AuthorName = item[5],
                Rate = 0
            };

            if (decimal.TryParse(item[6], out decimal outBuffer))
                newItem.Rate = outBuffer;

            return newItem;
        }

        private static TimeSpan GetTimeFromString(string secondString)
        {
            var timeSpanConverter = new TimeSpanConverter();

            var regex = new Regex("^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]:[0-5][0-9]$");
            if (regex.IsMatch(secondString))
            {
                var timeObject = timeSpanConverter.ConvertFrom(secondString);
                return (TimeSpan?)timeObject ?? TimeSpan.Zero;
            }
            return TimeSpan.Zero;
        }


        /// <summary>
        /// Видалити файл
        /// </summary>
        /// <param name="custId"></param>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public bool DeleteCatalogFile(int custId, int fileId)
        {
            return _service.DeleteFile(custId, fileId);
        }

        public bool SaveRightholderRegister(CatalogFile catalogFile)
        {
            return _service.SaveFileComment(catalogFile);
        }

        public ExecSqlResponce<CatalogFile> ValidateCatalogFileItems(CatalogFile catalogFile)
        {
            return _service.Validate(catalogFile);
        }

        public ExecSqlResponce<CatalogFile> ProcessCatalogFileItems(CatalogFile catalogFile)
        {
            return _service.Process(catalogFile);
        }
    }
}
