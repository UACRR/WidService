using System.Threading.Tasks;
using IpsCommonTypes.Wrappers;
using ipsFormsDesign.Model;

namespace ipsFormsDesign.Services.Interfaces
{
    public interface ICatalogFileItemsService
    {
        Task<ExecSqlResponce<CatalogFile>> ValidateCatalogFileItemsAsync(CatalogFile catalogFile);
        Task<ExecSqlResponce<CatalogFile>> ProcessCatalogFileItemsAsync(CatalogFile catalogFile);
    }
}