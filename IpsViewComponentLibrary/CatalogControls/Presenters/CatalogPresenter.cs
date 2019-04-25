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

        public List<T> GetFileList<T>() where T : class
        {
            return new List<T>();
        }

        public void UploadCatalogFile(CatalogFile catalogFile, string path, string fileName)
        {
            if (catalogFile.CustId == null || catalogFile.CustId == 0)
                throw new ArgumentOutOfRangeException($"CustId must be not null/0!");

            var pubСatalogItemList = GetPubСatalog(string.Concat(path, fileName));
            catalogFile.PubСatalogItem = new ObservableListSource<PubСatalogItem>(pubСatalogItemList);

            // result can be used
            var result = _service.UploadCatalogFile((int)catalogFile.CustId, catalogFile);
        }
        

        /// <summary>
        /// Конвертація Xls файлу в список PubСatalogItem
        /// </summary>
        /// <param name="fileName">Назва Xls файлу</param>
        /// <returns></returns>
        public List<PubСatalogItem> GetPubСatalog(string fileName)
        {
            try
            {
                var data = _exelEngine.ReadData(fileName);
                List<PubСatalogItem> newItems = new List<PubСatalogItem>();

                foreach (var item in data)
                {
                    PubСatalogItem newItem = PubСatalogItemFromXlsRow(item);
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
        /// Перетворення рядка Xls файлу в об'єкт PubСatalogItem
        /// </summary>
        /// <param name="item">рядок XLS файлу</param>
        /// <returns></returns>
        private PubСatalogItem PubСatalogItemFromXlsRow(List<string> item)
        {
            if (item.Count < 10)
                throw new ArgumentException("Неправильна структура файлу! Кількість колонок з даними повинна дорівнювати 10!");

            var newItem = new PubСatalogItem
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
    }
}
