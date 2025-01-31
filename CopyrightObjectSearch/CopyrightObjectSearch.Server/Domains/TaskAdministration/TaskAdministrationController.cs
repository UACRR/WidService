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

        [HttpPost("api/TaskAdministration/GetPartnerWorkSources")]
        public IEnumerable<GetPartnerWorkSourcesRsp> GetPartnerWorkSources(GetPartnerWorkSourcesRq rq)
        {
            return _taskAdministrationRqHandler.GetPartnerWorkSources(rq);
        }

        [HttpGet("api/TaskAdministration/GetPartnerWorkFilterInfo")]
        public GetPartnerWorkFilterInfoRsp GetPartnerWorkFilterInfo()
        {
            return _taskAdministrationRqHandler.GetPartnerWorkFilterInfo();
        }

        [HttpPost("api/TaskAdministration/GetPlannedTaskName")]
        public GetPlannedTaskNameRsp GetPlannedTaskName(GetPlannedTaskNameRq rq)
        {
            return _taskAdministrationRqHandler.GetPlannedTaskName(rq);
        }
    }
}
