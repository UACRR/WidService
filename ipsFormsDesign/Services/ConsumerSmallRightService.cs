using System.Collections.Generic;
using ipsFormsDesign.Data;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.ViewModels.Consumer;
using IpsCommonTypes.Enums;

namespace ipsFormsDesign.Services
{
    public class ConsumerSmallRightService: ConsumerService
    {
        private static ConsumerSmallRightService _service;

        private ConsumerSmallRightService() { }

        public static ConsumerSmallRightService GetInstance()
        {
            if (_service == null)
                _service = new ConsumerSmallRightService();

            if (IpsGlobal.AnketaDictionaties == null)
                IpsGlobal.SetAnketaDictionaties(_service.GetDictionary());

            return _service;
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
