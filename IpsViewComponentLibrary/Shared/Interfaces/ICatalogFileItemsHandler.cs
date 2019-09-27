using System.Collections.Generic;
using ipsFormsDesign.Model;
using IpsCommonTypes.Types;
using IpsCommonTypes.Wrappers;

namespace IpsViewComponentLibrary.Shared.Interfaces
{
    public interface ICatalogFileItemsHandler<T>
    {
        /// <summary>
        /// Виконати перевірку
        /// </summary>
        /// <param name="catalogFile"></param>
        /// <returns></returns>
        ExecSqlResponce<CatalogFile> ValidateCatalogFileItems(CatalogFile catalogFile);

        /// <summary>
        /// Виконати прив'язку
        /// </summary>
        /// <param name="catalogFile"></param>
        /// <returns></returns>
        ExecSqlResponce<CatalogFile> ProcessCatalogFileItems(CatalogFile catalogFile);

        /// <summary>
        /// Отримати частину каталогу
        /// </summary>
        /// <param name="fileId"></param>
        /// <param name="skip"></param>
        /// <param name="take"></param>
        /// <returns></returns>
        List<T> GetCatalogFileItems(int fileId, int skip, int take);

        /// <summary>
        /// Отримати дані для експорту
        /// </summary>
        /// <param name="fileId"></param>
        /// <returns></returns>
        List<object[]> GetItemsForExport(int fileId);
    }
}