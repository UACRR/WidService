using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SharedLib.Requests;
using SharedLib.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WidAdminLib;

namespace WidAdminApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WidAdminController : ControllerBase
    {
        private readonly ILogger<WidAdminController> _logger;
        private readonly WidAdminService _widAdminService;

        public WidAdminController(ILogger<WidAdminController> logger,
            WidAdminService widAdminService)
        {
            _logger = logger;
            _widAdminService = widAdminService;
        }

        [HttpGet("widconfiguration")]
        public WidConfigurationRsp GetConfiguration()
        {
            Console.WriteLine("=> GetConfiguration");
            var config = _widAdminService.GetConfiguration();
            Console.WriteLine($"<= {config.WidConfiguration.Name}");
            return config;
        }

        [HttpPost("widconfiguration")]
        public bool PostConfiguration(WidConfigurationRq rq)
        {
            return _widAdminService.UpdateConfiguration(rq);
        }

        [HttpGet("widalltasks")]
        public WidAllTasksRsp GetWidAllTasks()
        {
            Services.WidTasksPlannerService.taskStatusChangedHandle.Set();
            return _widAdminService.GetWidAllTasks();
        }
    }
}
