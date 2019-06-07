using System.Threading.Tasks;
using ipsFormsDesign.Dictionary;
using ipsFormsDesign.Services;

namespace IpsViewComponentLibrary.CommunityControls.Presenters
{
    public class CommunityViewsPresenter
    {
        private readonly CommunityService _service;

        public CommunityViewsPresenter()
        {
            _service = CommunityService.GetInstance();
        }

        public async Task<RightholdersResponse> GetAllAutorsView(PaginateAndSearchQuery query)
        {
            return await Task.Factory.StartNew(() => _service.GetCommunityAuthorsView<RightholdersResponse>("vTsk_1_ListRHCommunity", query));
        }
    }
}
