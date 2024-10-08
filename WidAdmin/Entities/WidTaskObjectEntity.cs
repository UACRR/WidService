using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WidAdminLib.Entities
{
    [Table("WidTaskObjects")]
    public class WidTaskObjectEntity
    {
        [Column(TypeName = "int")] [Key] public int Id { get; set; }
        [Column(TypeName = "int")] public int WidTaskSubjectId { get; set; }
        [Column(TypeName = "int")] public int WidTaskStatusId { get; set; }
        [Column(TypeName = "varchar(64)")] public string ObjectInfo { get; set; }
        [Column(TypeName = "datetime")] public DateTime? ObjectFileTs { get; set; }
        [Column(TypeName = "datetime")] public DateTime? StartedAt { get; set; }
        [Column(TypeName = "datetime")] public DateTime? EndedAt { get; set; }
        [Column(TypeName = "datetime")] public DateTime? CreatedAt { get; set; }
        [Column(TypeName = "datetime")] public DateTime? UpdatedAt { get; set; }

        public WidTaskSubjectEntity WidTaskSubject { get; set; }
        public WidTaskStatusEnum WidTaskStatus { get; set; }
        public ICollection<WidTaskEntity> WidTasks { get; set; }

    }
}


