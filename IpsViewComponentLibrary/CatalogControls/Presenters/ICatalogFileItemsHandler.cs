using IpsCommonTypes.Types;
using ipsFormsDesign.Model;

namespace IpsViewComponentLibrary.CatalogControls.Presenters
{
    public interface ICatalogFileItemsHandler
    {
        /// <summary>
        /// Виконати перевірку
        /// </summary>
        /// <param name="catalogFile"></param>
        /// <returns></returns>
        CatalogFile ValidateCatalogFileItems(CatalogFile catalogFile);

        /// <summary>
        /// Виконати прив'язку
        /// </summary>
        /// <param name="catalogFile"></param>
        /// <returns></returns>
        ExecSqlResponce<CatalogFile> ProcessCatalogFileItems(CatalogFile catalogFile);
    }
}