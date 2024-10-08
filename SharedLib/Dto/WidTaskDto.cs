using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLib.Dto
{
    public class WidTaskDto
    {
        public int Id { get; set; }
        public int WidConfigurationId { get; set; }
        public int WidTaskTypeId { get; set; }
        public int WidTaskStatusId { get; set; }
        public int? PrevWidTaskId { get; set; }
        public int? NextWidTaskId { get; set; }
        public string EntityName { get; set; }
        public decimal PercentDone { get; set; }
        public string ErrMsg { get; set; }
        public DateTime? ScheduledAt { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? EndedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
