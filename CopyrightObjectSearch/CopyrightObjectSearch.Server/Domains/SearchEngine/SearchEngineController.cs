using Microsoft.AspNetCore.Mvc;

namespace CopyrightObjectSearch.Server
{
    [ApiController]
    [Route("")]
    public class SearchEngineController : ControllerBase
    {
        private readonly ILogger<SearchEngineController> _logger;
        private readonly SearchEngineRqHandler _searchEngineRqHandler;

        public SearchEngineController(ILogger<SearchEngineController> logger,
            SearchEngineRqHandler searchEngineRqHandler)
        {
            _logger = logger;
            _searchEngineRqHandler = searchEngineRqHandler;
        }

        [HttpGet("api/SearchEngine/GetPartnerWorks")]
        public IEnumerable<PartnerWorkDto> GetPartnerWorks()
        {
            return _searchEngineRqHandler.GetPartnerWorks();
        }

        [HttpPost("api/SearchEngine/GetFoundWorks")]
        public GetFoundWorksRsp GetFoundWorks(SearchParamsDto searchParamsDto)
        {
            return _searchEngineRqHandler.GetFoundWorks(searchParamsDto);
        }

        [HttpPost("api/SearchEngine/SetWorkCode")]
        public SetWorkCodeRsp SetWorkCode(SetWorkCodeRq setWorkCodeRq)
        {
            return _searchEngineRqHandler.SetWorkCode(setWorkCodeRq);
        }
    }
}
