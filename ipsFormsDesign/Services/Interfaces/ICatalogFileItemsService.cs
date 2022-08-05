using System.Threading.Tasks;
using IpsCommonTypes.Wrappers;
using ipsFormsDesign.Model;

namespace ipsFormsDesign.Services.Interfaces
{
    public interface ICatalogFileItemsService
    {
        Task<ExecSqlResponse<CatalogFile>> ValidateCatalogFileItemsAsync(CatalogFile catalogFile);
        Task<ExecSqlResponse<CatalogFile>> ProcessCatalogFileItemsAsync(CatalogFile catalogFile);
    }
}