using SharedLib.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLib.Responses
{
    public class WidTasksRsp
    {
        public bool IsRunning { get; set; }
        public WidTaskDto[] WidTasks { get; set; }
    }
}
