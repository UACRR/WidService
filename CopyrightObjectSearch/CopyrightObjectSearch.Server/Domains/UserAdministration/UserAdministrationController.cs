using Microsoft.AspNetCore.Mvc;

namespace CopyrightObjectSearch.Server
{
    [ApiController]
    [Route("")]
    public class UserAdministrationController : ControllerBase
    {
        private readonly ILogger<SearchEngineController> _logger;
        private readonly UserAdministrationRqHandler _userAdministrationRqHandler;

        public UserAdministrationController(ILogger<SearchEngineController> logger,
            UserAdministrationRqHandler userAdministrationRqHandler)
        {
            _logger = logger;
            _userAdministrationRqHandler = userAdministrationRqHandler;
        }

        [HttpGet("api/UserAdministration/GetUsers")]
        public GetUsersRsp GetUsers()
        {
            return _userAdministrationRqHandler.GetUsers();
        }

        [HttpGet("api/UserAdministration/AddUser")]
        public AddUserRsp AddUser()
        {
            return _userAdministrationRqHandler.AddUser();
        }

    }
}
