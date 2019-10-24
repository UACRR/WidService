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
using System.Globalization;
using System.Threading.Tasks;

namespace IpsViewComponentLibrary.RightholderCatalogControls.Presenters
{
    public sealed class RightholderCatalogPresenter: ICatalogFileItemsHandler<PubCatalogItem>
    {
        private readonly RightholderCatalogService _service;
        private readonly ExcelEngine _exelEngine;

        public RightholderCatalogPresenter()
        {
            _service = RightholderCatalogService.GetInstance();
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

        /// <summary>
        /// Завантажити каталог
        /// </summary>
        /// <param name="catalogFile"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public async Task<CatalogFile> UploadCatalogFileAsync(CatalogFile catalogFile, string path)
        {
            if (catalogFile.CustId == null || catalogFile.CustId == 0)
                throw new ArgumentOutOfRangeException($"CustId must be not null/0!");

            //string name = Environment.UserName;
            string identityName = new WindowsPrincipal(WindowsIdentity.GetCurrent()).Identity?.Name;
            catalogFile.UserId = identityName;

            var data = _exelEngine.ReadData(path, 12);
            TrimNotValidData(data);

            var result = await _service.UploadCatalogFileAsync(catalogFile, data);


            //var pubCatalogItemList = GetPubСatalog(path);

            //if (pubCatalogItemList == null)
            //    return null;

            ////if (!CheckValidDataLength(pubCatalogItemList))
            ////    return null;
            //TrimNotValidData(pubCatalogItemList);

            //catalogFile.PubCatalogItem = new ObservableListSource<PubCatalogItem>(pubCatalogItemList);

            //// result can be used
            //var result = _service.UploadCatalogFile((int)catalogFile.CustId, catalogFile);

            if (result == null)
                _service.ShowErrors();
            
            return result;
        }

        /// <summary>
        /// Перевірити коректність даних
        /// </summary>
        /// <param name="pubCatalogItems"></param>
        /// <returns></returns>
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

        private void TrimNotValidData(ICollection<PubCatalogItem> pubCatalogItems)
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

            int length = 0;
            foreach (var pubCatalogItem in pubCatalogItems)
            {
                length = dbTableLangth[nameof(pubCatalogItem.ItemCode).ToUpper()];
                if (pubCatalogItem.ItemCode.Length > length)
                    pubCatalogItem.ItemCode = pubCatalogItem.ItemCode.Substring(0, length);

                length = dbTableLangth[nameof(pubCatalogItem.Iswc).ToUpper()];
                if (pubCatalogItem.Iswc.Length > length)
                    pubCatalogItem.Iswc = pubCatalogItem.Iswc.Substring(0, length);

                length = dbTableLangth[nameof(pubCatalogItem.ObjName).ToUpper()];
                if (pubCatalogItem.ObjName.Length > length)
                    pubCatalogItem.ObjName = pubCatalogItem.ObjName.Substring(0, length);

                length = dbTableLangth[nameof(pubCatalogItem.GenreName).ToUpper()];
                if (pubCatalogItem.GenreName.Length > length)
                    pubCatalogItem.GenreName = pubCatalogItem.GenreName.Substring(0, length);

                length = dbTableLangth[nameof(pubCatalogItem.RoleName).ToUpper()];
                if (pubCatalogItem.RoleName.Length > length)
                    pubCatalogItem.RoleName = pubCatalogItem.RoleName.Substring(0, length);

                length = dbTableLangth[nameof(pubCatalogItem.AuthorMusic).ToUpper()];
                if (pubCatalogItem.AuthorMusic.Length > length)
                    pubCatalogItem.AuthorMusic = pubCatalogItem.AuthorMusic.Substring(0, length);

                length = dbTableLangth[nameof(pubCatalogItem.AuthorText).ToUpper()];
                if (pubCatalogItem.AuthorText.Length > length)
                    pubCatalogItem.AuthorText = pubCatalogItem.AuthorText.Substring(0, length);

                length = dbTableLangth[nameof(pubCatalogItem.Performer).ToUpper()];
                if (pubCatalogItem.Performer.Length > length)
                    pubCatalogItem.Performer = pubCatalogItem.Performer.Substring(0, length);

                length = dbTableLangth[nameof(pubCatalogItem.RhName).ToUpper()];
                if (pubCatalogItem.RhName.Length > length)
                    pubCatalogItem.RhName = pubCatalogItem.RhName.Substring(0, length);
            }
        }

        private void TrimNotValidData(ICollection<List<string>> items)
        {
            CultureInfo culture = CultureInfo.CreateSpecificCulture("uk-UA");
            DateTimeStyles dateTimeStyles = DateTimeStyles.None;
            var tableLangth = new Dictionary<int, int>
            {
                [0] = 50,
                [1] = 100,
                [2] = 254,
                [3] = 100,
                [4] = 254,
                [5] = 254,
                [6] = 254,
                [7] = 100,
                [8] = 254,
            };

            foreach (var item in items)
            {
                foreach(var e in tableLangth)
                {
                    if (item[e.Key].Length > e.Value)
                        item[e.Key] = item[e.Key].Substring(0, e.Value);
                }

                if (!decimal.TryParse(item[9], out decimal outBuffer))
                    item[9] = null;
                else
                    item[9] = item[9].Replace(",", ".");

                if (string.IsNullOrWhiteSpace(item[10]))
                    item[10] = null;
                else if (DateTime.TryParse(item[10], culture, dateTimeStyles, out DateTime dtBegin))
                    item[10] = dtBegin.ToString("yyyy-MM-dd");

                if (string.IsNullOrWhiteSpace(item[11]))
                    item[11] = null;
                else if (DateTime.TryParse(item[11], culture, dateTimeStyles, out DateTime dtEnd))
                    item[11] = dtEnd.ToString("yyyy-MM-dd");

            }
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
                var data = _exelEngine.ReadData(fileName, 12);

                if (!data.Any())
                {
                    MessageShow.ShowError("Неправильна структура файлу! Дані не завантажились!");
                    return null;
                }
                
                if (data[0].Count < 12)
                {
                    MessageShow.ShowError("Неправильна структура файлу! Кількість колонок з даними повинно бути не меншне 12!");
                    return null;
                }

                List<PubCatalogItem> newItemList = new List<PubCatalogItem>();

                foreach (var item in data)
                {
                    var newItem = PubCatalogItemFromXlsRow(item);
                    newItemList.Add(newItem);
                }
                return newItemList;
            }
            catch (Exception e)
            {
                MessageShow.ShowError(e.Message);
                return null;
            }
        }

        /// <summary>
        /// Перетворення рядка Xls файлу в об'єкт PubCatalogItem
        /// </summary>
        /// <param name="item">рядок XLS файлу</param>
        /// <returns></returns>
        private PubCatalogItem PubCatalogItemFromXlsRow(List<string> item)
        {
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
                Rate = 0,
                DateBegin = null,
                DateEnd = null,
            };

            if (decimal.TryParse(item[9], out decimal outBuffer))
                newItem.Rate = outBuffer;

            if (DateTime.TryParse(item[10], out DateTime dtBegin))
                newItem.DateBegin = dtBegin;

            if (DateTime.TryParse(item[11], out DateTime dtEnd))
                newItem.DateEnd = dtEnd;

            return newItem;
        }

        /// <summary>
        /// Видалити каталог
        /// </summary>
        /// <param name="custId"></param>
        /// <param name="fileId"></param>
        /// <returns></returns>
        public ExecSqlResponce DeleteCatalogFile(int custId, int fileId)
        {
            return _service.DeleteCatalogFile(custId, fileId);
        }

        /// <summary>
        /// Зберегти коментад до каталогу
        /// </summary>
        /// <param name="catalogFile"></param>
        /// <returns></returns>
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
            return _service.ProcessCatalogFileItemsAsync(catalogFile).GetAwaiter().GetResult();
        }

        public List<PubCatalogItem> GetCatalogFileItems(int fileId, int skip, int take)
        {
            return _service.GetCatalogFileItems(fileId, skip, take);
        }

        public List<object[]> GetCatalogItemList(int fileId)
        {
            GC.Collect();
            return _service.GetItemsForExport(fileId);
        }
    }
}
