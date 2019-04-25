using System;
using System.Collections.Generic;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;

namespace IpsViewComponentLibrary.CatalogControls.Presenters
{
    public class CatalogPresenter
    {
        private CatalogService _service;
        private ExcelEngine _exelEngine;

        public CatalogPresenter()
        {
            _service = CatalogService.GetInstance();
            _exelEngine = ExcelEngine.GetInstance();
        }

        public List<T> GetFileList<T>() where T : class
        {
            return new List<T>();
        }

        /// <summary>
        /// Конвертація Xls файлу в список PubCatalogItem
        /// </summary>
        /// <param name="fileName">Назва Xls файлу</param>
        /// <returns></returns>
        public List<PubCatalogItem> GetPubСatalog(string fileName)
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
                throw new ArgumentException("Не правильна структура файлу.Кількість колонок з даними дорівнює 10");

            PubCatalogItem newItem = new PubCatalogItem();
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
