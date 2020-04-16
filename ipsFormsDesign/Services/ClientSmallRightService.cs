using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using IpsCommonTypes.ClassesForSearchQuery;
using ipsFormsDesign.Data;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.ViewModels.Consumer;
using IpsCommonTypes.Enums;
using IpsCommonTypes.Types;
using IpsCommonTypes.Wrappers;

namespace ipsFormsDesign.Services
{
    public class ClientSmallRightService: ConsumerService
    {
        private static ClientSmallRightService _service;
        private const string prefix = "clientSmallRight";
        private ClientSmallRightService() { }

        public static ClientSmallRightService GetInstance()
        {
            if (_service == null)
                _service = new ClientSmallRightService();

            if (IpsGlobal.AnketaDictionaties == null)
                IpsGlobal.SetAnketaDictionaties(_service.GetDictionary());

            return _service;
        }

        public async Task<ResponseOfRequest<DataTable>> GetClientsSRListAsync(SearchModuleResource moduleResource)
        {
            string url = $"{prefix}/list";
            var result = await _webApi.SendPostRequestWithResultAsync<ResponseOfRequest<DataTable>, SearchModuleResource>(url, moduleResource);
            return result;
        }

        public IList<ConsumerSmallRightView> GetListAll()
        {
            var list = _webApi.GetList<ConsumerSmallRightView>("consumer/listall");
            return list;
        }

        public ItemListResponse<ConsumerSmallRightView> getMainView(ConsumersSmallRightFilter what = ConsumersSmallRightFilter.All, PaginateAndSearchQuery query = null)
        {
            string url = $"consumer/listSR/{(int)what}";
            var anketaDic = _webApi.GetItemByIdWithParam<ItemListResponse<ConsumerSmallRightView>>(url, null, query?.ToKeyValuePair());
            return anketaDic;
        }
    }
}
