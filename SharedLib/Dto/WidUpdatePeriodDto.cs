using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLib.Dto
{
    public class WidUpdatePeriodDto
    {
        public int Id { get; set; }
        public int WidTaskStatusId { get; set; }
        public DateTime? WidDumpTs { get; set; }
        public DateTime? NewWidDumpTs { get; set; }
        public long WidDumpFilesTotalSize { get; set; }
        public long NewWidDumpFilesTotalSize { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? EndedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public List<WidTaskSubjectDto> WidTaskSubjects { get; set; }
    }
}
