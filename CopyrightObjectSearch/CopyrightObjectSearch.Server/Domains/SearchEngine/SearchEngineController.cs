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

        [HttpGet("api/SearchEngine/GetExternalObjects")]
        public IEnumerable<ExternalObjectDto> GetExternalObjects()
        {
            return _searchEngineRqHandler.GetExternalObjects();
        }

        [HttpPost("api/SearchEngine/GetFoundObjects")]
        public GetFoundObjectsRsp GetFoundObjects(SearchParamsDto searchParamsDto)
        {
            return _searchEngineRqHandler.GetFoundObjects(searchParamsDto);
        }

        [HttpPost("api/SearchEngine/SetWorkCode")]
        public SetWorkCodeRsp SetWorkCode(SetWorkCodeRq setWorkCodeRq)
        {
            return _searchEngineRqHandler.SetWorkCode(setWorkCodeRq);
        }
    }
}
