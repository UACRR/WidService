using Microsoft.AspNetCore.Mvc;

namespace CopyrightObjectSearch.Server
{
    [ApiController]
    [Route("")]
    public class AccessController : ControllerBase
    {
        private readonly ILogger<SearchEngineController> _logger;
        private readonly AccessRqHandler _accessRqHandler;

        public AccessController(ILogger<SearchEngineController> logger,
            AccessRqHandler accessRqHandler)
        {
            _logger = logger;
            _accessRqHandler = accessRqHandler;
        }

        [HttpPost("api/AccessControl/Login")]
        public LoginRsp Login(LoginRq rq)
        {
            return _accessRqHandler.Login(rq);
        }
     }
}
