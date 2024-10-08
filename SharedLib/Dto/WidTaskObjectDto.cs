using System;
using System.Collections.Generic;
using System.Text;

namespace SharedLib.Dto
{
    public class WidTaskObjectDto
    {
        public int Id { get; set; }
        public int WidTaskSubjectId { get; set; }
        public int WidTaskStatusId { get; set; }
        public string ObjectInfo { get; set; }
        public DateTime? ObjectFileTs { get; set; }
        public DateTime? StartedAt { get; set; }
        public DateTime? EndedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public List<WidTaskDto> WidTasks { get; set; }
    }
}
