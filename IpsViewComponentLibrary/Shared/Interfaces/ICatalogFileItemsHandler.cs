using ipsFormsDesign.Model;
using IpsCommonTypes.Types;
using IpsCommonTypes.Wrappers;

namespace IpsViewComponentLibrary.Shared.Interfaces
{
    public interface ICatalogFileItemsHandler
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
    }
}