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

        public void UploadCatalogFile(CatalogFile catalogFile, string path, string fileName)
        {
            if (catalogFile.CustId == null || catalogFile.CustId == 0)
                throw new ArgumentOutOfRangeException($"CustId must be not null/0!");

            catalogFile.PubСatalogItem = new ObservableListSource<PubСatalogItem>(GetPubСatalog(string.Concat(path, fileName)));
            // result can be used
            var result = _service.UploadCatalogFile((int)catalogFile.CustId, catalogFile);
        }

        public List<T> GetFileList<T>() where T : class
        {
            return new List<T>();
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
                throw new ArgumentException("Не правильна структура файлу.Кількість колонок з даними дорівнює 10");

            PubСatalogItem newItem = new PubСatalogItem();
            newItem.ItemCode = item[0];
            newItem.Iswc = item[1];
            newItem.ObjName = item[2];
            newItem.GenreName = item[3];
            newItem.Performer = item[4];
            newItem.AuthorMusic = item[5];
            newItem.AuthorText = item[6];
            newItem.RoleName = item[7];
            newItem.Rate = 0;
            decimal outBuffer;
            if (decimal.TryParse(item[9], out outBuffer))
                newItem.Rate = outBuffer*100;

            return newItem;
        }
    }
}
