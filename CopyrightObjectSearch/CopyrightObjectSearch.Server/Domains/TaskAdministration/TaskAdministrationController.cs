using Microsoft.AspNetCore.Mvc;

namespace CopyrightObjectSearch.Server
{
    [ApiController]
    [Route("")]
    public class TaskAdministrationController : ControllerBase
    {
        private readonly ILogger<TaskAdministrationController> _logger;
        private readonly TaskAdministrationRqHandler _taskAdministrationRqHandler;

        public TaskAdministrationController(ILogger<TaskAdministrationController> logger,
            TaskAdministrationRqHandler taskAdministrationRqHandler)
        {
            _logger = logger;
            _taskAdministrationRqHandler = taskAdministrationRqHandler;
        }

        [HttpGet("api/TaskAdministration/GetTasks")]
        public void GetTasks()
        {
        }
    }
}
