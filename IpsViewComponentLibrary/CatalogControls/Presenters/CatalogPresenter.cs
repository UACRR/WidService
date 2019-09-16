using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IpsCommonTypes.Wrappers;
using IpsViewComponentLibrary.Extensions;
using IpsViewComponentLibrary.Shared.Interfaces;

namespace IpsViewComponentLibrary.CatalogControls.Presenters
{
    public class CatalogPresenter: ICatalogFileItemsHandler
    {
        private readonly RightholderCatalogService _service;
        private readonly ExcelEngine _exelEngine;

        public CatalogPresenter()
        {
            _service = RightholderCatalogService.GetInstance();
            _exelEngine = ExcelEngine.GetInstance();
        }

        public List<CatalogFile> GetFileList(int custId)
        {
            return _service.GetCatalogFileList(custId);
        }

        public CatalogFile GetCatalogFile( int custId, int fileId )
        {
            return _service.GetCatalogFile(custId, fileId);
        }

        public CatalogFile UploadCatalogFile(CatalogFile catalogFile, string path)
        {
            if (catalogFile.CustId == null || catalogFile.CustId == 0)
                throw new ArgumentOutOfRangeException($"CustId must be not null/0!");

            //string name = Environment.UserName;
            string identityName = new WindowsPrincipal(WindowsIdentity.GetCurrent()).Identity?.Name;
            catalogFile.UserId = identityName;

            var PubCatalogItemList = GetPubСatalog(path);

            if (!CheckValidDataLength(PubCatalogItemList))
                return null;

            catalogFile.PubCatalogItem = new ObservableListSource<PubCatalogItem>(PubCatalogItemList);

            // result can be used
            var result = _service.UploadCatalogFile((int)catalogFile.CustId, catalogFile);
            return result;
        }

        private bool CheckValidDataLength(ICollection<PubCatalogItem> pubCatalogItems)
        {
            var dbTableLangth = new Dictionary<string, int>
            {
                ["itemCode".ToUpper()] = 50,
                ["iswc".ToUpper()] = 100,
                ["objName".ToUpper()] = 254,
                ["genreName".ToUpper()] = 100,
                ["roleName".ToUpper()] = 100,
                ["authorMusic".ToUpper()] = 254,
                ["authorText".ToUpper()] = 254,
                ["performer".ToUpper()] = 254,
                ["rhName".ToUpper()] = 254,
            };


            bool ShowWarningNotValidDataLength(PubCatalogItem item, string propertyName)
            {
                string length = $"Довжина поля \"{propertyName}\" перевищує допустиму довжину '{dbTableLangth[propertyName.ToUpper()]}' символи!";
                string msg = $"Помилка завантаження! Запис з кодом (шифр твору) '{item.ItemCode}' не може бути записаний! {length}";

                MessageShow.ShowWarning(msg);

                return false;
            }

            foreach (var pubCatalogItem in pubCatalogItems)
            {
                if (pubCatalogItem.ItemCode.Length > dbTableLangth[nameof(pubCatalogItem.ItemCode).ToUpper()])
                    return ShowWarningNotValidDataLength(pubCatalogItem, nameof(pubCatalogItem.ItemCode));

                if (pubCatalogItem.Iswc.Length > dbTableLangth[nameof(pubCatalogItem.Iswc).ToUpper()])
                    return ShowWarningNotValidDataLength(pubCatalogItem, nameof(pubCatalogItem.Iswc));

                if (pubCatalogItem.ObjName.Length > dbTableLangth[nameof(pubCatalogItem.ObjName).ToUpper()])
                    return ShowWarningNotValidDataLength(pubCatalogItem, nameof(pubCatalogItem.ObjName));

                if (pubCatalogItem.GenreName.Length > dbTableLangth[nameof(pubCatalogItem.GenreName).ToUpper()])
                    return ShowWarningNotValidDataLength(pubCatalogItem, nameof(pubCatalogItem.GenreName));

                if (pubCatalogItem.RoleName.Length > dbTableLangth[nameof(pubCatalogItem.RoleName).ToUpper()])
                    return ShowWarningNotValidDataLength(pubCatalogItem, nameof(pubCatalogItem.RoleName));

                if (pubCatalogItem.AuthorMusic.Length > dbTableLangth[nameof(pubCatalogItem.AuthorMusic).ToUpper()])
                    return ShowWarningNotValidDataLength(pubCatalogItem, nameof(pubCatalogItem.AuthorMusic));

                if (pubCatalogItem.AuthorText.Length > dbTableLangth[nameof(pubCatalogItem.AuthorText).ToUpper()])
                    return ShowWarningNotValidDataLength(pubCatalogItem, nameof(pubCatalogItem.AuthorText));

                if (pubCatalogItem.Performer.Length > dbTableLangth[nameof(pubCatalogItem.Performer).ToUpper()])
                    return ShowWarningNotValidDataLength(pubCatalogItem, nameof(pubCatalogItem.Performer));

                if (pubCatalogItem.RhName.Length > dbTableLangth[nameof(pubCatalogItem.RhName).ToUpper()])
                    return ShowWarningNotValidDataLength(pubCatalogItem, nameof(pubCatalogItem.RhName));
            }

            return true;
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
                RhName = item[8],
                Rate = 0
            };

            if (decimal.TryParse(item[9], out decimal outBuffer))
            {
                newItem.Rate = outBuffer;
            }

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

        public bool SaveCatalogFileComment(CatalogFile catalogFile)
        {
            return _service.SaveCatalogFileComment(catalogFile);
        }

        public ExecSqlResponce<CatalogFile> ValidateCatalogFileItems(CatalogFile catalogFile)
        {
            return _service.ValidateCatalogFileItems(catalogFile);
        }

        public ExecSqlResponce<CatalogFile> ProcessCatalogFileItems(CatalogFile catalogFile)
        {
            return _service.ProcessCatalogFileItems(catalogFile);
        }
    }
}
