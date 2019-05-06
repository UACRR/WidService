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
        CatalogFile AuditCatalogFileItems(CatalogFile catalogFile);

        /// <summary>
        /// Виконати прив'язку
        /// </summary>
        /// <param name="catalogFile"></param>
        /// <returns></returns>
        CatalogFile AttachCatalogFileItems(CatalogFile catalogFile);
    }
}