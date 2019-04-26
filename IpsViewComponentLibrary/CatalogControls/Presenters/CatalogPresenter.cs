using System;
using System.Collections.Generic;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;

namespace IpsViewComponentLibrary.CatalogControls.Presenters
{
    public class CatalogPresenter
    {
        private readonly CatalogService _service;
        private readonly ExcelEngine _exelEngine;

        public CatalogPresenter()
        {
            _service = CatalogService.GetInstance();
            _exelEngine = ExcelEngine.GetInstance();
        }

        public List<CatalogFile> GetFileList(int custId)
        {
            return _service.GetCatalogFileList(custId);
        }

        public CatalogFile GetCatalogFile(int custId, int fileId)
        {
            return _service.GetCatalogFile(custId, fileId);
        }

        public void UploadCatalogFile(CatalogFile catalogFile, string path)
        {
            if (catalogFile.CustId == null || catalogFile.CustId == 0)
                throw new ArgumentOutOfRangeException($"CustId must be not null/0!");

            var PubCatalogItemList = GetPubСatalog(path);
            catalogFile.PubCatalogItem = new ObservableListSource<PubCatalogItem>(PubCatalogItemList);

            // result can be used
            var result = _service.UploadCatalogFile((int)catalogFile.CustId, catalogFile);
        }
        
        /// <summary>
        /// Конвертація Xls файлу в список PubCatalogItem
        /// </summary>
        /// <param name="fileName">Назва Xls файлу</param>
        /// <returns></returns>
        private List<PubCatalogItem> GetPubСatalog(string fileName)
        {
            try
            {
                var data = _exelEngine.ReadData(fileName);
                List<PubCatalogItem> newItems = new List<PubCatalogItem>();

                foreach (var item in data)
                {
                    PubCatalogItem newItem = PubCatalogItemFromXlsRow(item);
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
        /// Перетворення рядка Xls файлу в об'єкт PubCatalogItem
        /// </summary>
        /// <param name="item">рядок XLS файлу</param>
        /// <returns></returns>
        private PubCatalogItem PubCatalogItemFromXlsRow(List<string> item)
        {
            if (item.Count < 10)
                throw new ArgumentException("Неправильна структура файлу! Кількість колонок з даними повинна дорівнювати 10!");

            var newItem = new PubCatalogItem
            {
                ItemCode = item[0],
                Iswc = item[1],
                ObjName = item[2],
                GenreName = item[3],
                Performer = item[4],
                AuthorMusic = item[5],
                AuthorText = item[6],
                RoleName = item[7],
                Rate = 0
            };

            if (decimal.TryParse(item[9], out decimal outBuffer))
                newItem.Rate = outBuffer*100;

            return newItem;
        }

        /// <summary>
        /// Видалити
        /// </summary>
        /// <param name="custId"></param>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public bool DeleteCatalogFile(int custId, int fileId)
        {
            return _service.DeleteCatalogFile(custId, fileId);
        }


    }
}
