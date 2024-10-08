using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLib.Dto
{
    public class WidTaskSubjectDto
    {
        public int Id { get; set; }
        public int WidUpdatePeriodId { get; set; }
        public int WidTaskSubjectTypeId { get; set; }
        public int WidTaskStatusId { get; set; }
        public string Db { get; set; }
        public DateTime? TasksDate { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? EndedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public List<WidTaskObjectDto> WidTaskObjects { get; set; }
    }
}
