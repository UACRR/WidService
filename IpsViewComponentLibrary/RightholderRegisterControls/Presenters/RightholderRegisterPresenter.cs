using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Principal;
using System.Text.RegularExpressions;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Model;
using ipsFormsDesign.Services;
using IpsCommonTypes.Wrappers;
using IpsViewComponentLibrary.Extensions;
using IpsViewComponentLibrary.Shared.Interfaces;
using TimeSpan = System.TimeSpan;

namespace IpsViewComponentLibrary.RightholderRegisterControls.Presenters
{
    public sealed class RightholderRegisterPresenter: ICatalogFileItemsHandler<RhcatalogItem>
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

        /// <summary>
        /// Завантажити реєстр правовласника
        /// </summary>
        /// <param name="catalogFile"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public CatalogFile UploadCatalogFile(CatalogFile catalogFile, string path)
        {
            if (catalogFile.CustId == null || catalogFile.CustId == 0)
                throw new ArgumentOutOfRangeException($"CustId must be not null/0!");

            //string name = Environment.UserName;
            string identityName = new WindowsPrincipal(WindowsIdentity.GetCurrent()).Identity?.Name;
            catalogFile.UserId = identityName;

            var rhcatalogItemList = GetRightholderRegister(path);

            if (rhcatalogItemList == null)
                return null;

            if (!CheckValidDataLength(rhcatalogItemList))
                return null;

            catalogFile.RhcatalogItem = new ObservableListSource<RhcatalogItem>(rhcatalogItemList);

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

                if (!data.Any())
                {
                    MessageShow.ShowError("Неправильна структура файлу! Дані не завантажились!");
                    return null;
                }

                if (data[0].Count < 9)
                {
                    MessageShow.ShowError("Неправильна структура файлу! Кількість колонок з даними повинно бути не меншне 9!");
                    return null;
                }

                List<RhcatalogItem> newItems = new List<RhcatalogItem>();

                foreach (var item in data)
                {
                    var newItem = CreateItemFromXlsRow(item);
                    newItems.Add(newItem);
                }
                return newItems;
            }
            catch (Exception e)
            {
                MessageShow.ShowError(e.Message);
                return null;
            }
        }

        private bool CheckValidDataLength(ICollection<RhcatalogItem> rhcatalogItemList)
        {
            var dbTableLangth = new Dictionary<string, int>
            {
                ["itemCode".ToUpper()] = 50,
                ["objName".ToUpper()] = 254,
                ["genreName".ToUpper()] = 100,
                ["roleName".ToUpper()] = 100,
                ["authorName".ToUpper()] = 254,
            };


            bool ShowWarningNotValidDataLength(RhcatalogItem item, string propertyName)
            {
                string length = $"Довжина поля \"{propertyName}\" перевищує допустиму довжину '{dbTableLangth[propertyName.ToUpper()]}' символи!";
                string msg = $"Помилка завантаження! Запис з кодом (шифр твору) '{item.ItemCode}' не може бути записаний! {length}";

                MessageShow.ShowWarning(msg);

                return false;
            }

            foreach (var rhcatalogItem in rhcatalogItemList)
            {
                if (rhcatalogItem.ItemCode.Length > dbTableLangth[nameof(rhcatalogItem.ItemCode).ToUpper()])
                    return ShowWarningNotValidDataLength(rhcatalogItem, nameof(rhcatalogItem.ItemCode));

                if (rhcatalogItem.ObjName.Length > dbTableLangth[nameof(rhcatalogItem.ObjName).ToUpper()])
                    return ShowWarningNotValidDataLength(rhcatalogItem, nameof(rhcatalogItem.ObjName));

                if (rhcatalogItem.GenreName.Length > dbTableLangth[nameof(rhcatalogItem.GenreName).ToUpper()])
                    return ShowWarningNotValidDataLength(rhcatalogItem, nameof(rhcatalogItem.GenreName));

                if (rhcatalogItem.RoleName.Length > dbTableLangth[nameof(rhcatalogItem.RoleName).ToUpper()])
                    return ShowWarningNotValidDataLength(rhcatalogItem, nameof(rhcatalogItem.RoleName));

                if (rhcatalogItem.AuthorName.Length > dbTableLangth[nameof(rhcatalogItem.AuthorName).ToUpper()])
                    return ShowWarningNotValidDataLength(rhcatalogItem, nameof(rhcatalogItem.AuthorName));
            }

            return true;
        }

        /// <summary>
        /// Перетворення рядка Xls файлу в об'єкт RhcatalogItem
        /// </summary>
        /// <param name="item">рядок XLS файлу</param>
        /// <returns></returns>
        private RhcatalogItem CreateItemFromXlsRow(List<string> item)
        {
            var newItem = new RhcatalogItem
            {
                ItemCode = item[0],
                ObjName = item[1],
                GenreName = item[2],
                Duration = GetTimeFromString(item[3]),
                RoleName = item[4],
                AuthorName = item[5],
                Rate = 0,
                DateBegin = null,
                DateEnd = null,
            };

            if (decimal.TryParse(item[6], out decimal outBuffer))
                newItem.Rate = outBuffer;

            if (DateTime.TryParse(item[7], out DateTime dtBegin))
                newItem.DateBegin = dtBegin;

            if (DateTime.TryParse(item[8], out DateTime dtEnd))
                newItem.DateEnd = dtEnd;

            return newItem;
        }

        /// <summary>
        /// Конвертувати рядкове значення часу в тип TimeSpan
        /// </summary>
        /// <param name="secondsString"></param>
        /// <returns></returns>
        private static TimeSpan GetTimeFromString(string secondsString)
        {
            var timeSpanConverter = new TimeSpanConverter();

            if (double.TryParse(secondsString, out double result))
                return GetTimeFromExcelDoubleValue(result);

            var regex = new Regex("^([0-9]|0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]:[0-5][0-9]$");
            if (regex.IsMatch(secondsString))
            {
                var timeObject = timeSpanConverter.ConvertFrom(secondsString);
                return (TimeSpan?)timeObject ?? TimeSpan.Zero;
            }
            return TimeSpan.Zero;
        }

        /// <summary>
        /// Конвертувати Excel представлення Date/Time у вигляді double числа в TimeSpan
        /// </summary>
        /// <param name="doubleValue"></param>
        /// <returns></returns>
        private static TimeSpan GetTimeFromExcelDoubleValue(double doubleValue)
        {
            var dateTime = DateTime.FromOADate(doubleValue);
            var ts = dateTime.TimeOfDay;
            return ts;
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

        public List<RhcatalogItem> GetCatalogFileItems(int fileId, int skip, int take)
        {
            throw new NotImplementedException();
        }

        public List<object[]> GetItemsForExport(int fileId)
        {
            throw new NotImplementedException();
        }
    }
}
