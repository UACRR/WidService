using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WidAdminLib.Entities
{
    [Table("WidTasks")]
    public class WidTaskEntity
    {
        [Column(TypeName = "int")] [Key] public int Id { get; set; }
        [Column(TypeName = "int")] public int WidTaskObjectId { get; set; }
        [Column(TypeName = "int")] public int WidTaskTypeId { get; set; }
        [Column(TypeName = "int")] public int WidTaskStatusId { get; set; }
        [Column(TypeName = "int")] public int? PrevWidTaskId { get; set; }
        [Column(TypeName = "int")] public int? NextWidTaskId { get; set; }
        [Column(TypeName = "decimal(5, 2")] public decimal PercentDone { get; set; }
        [Column(TypeName = "int")] public int? LastTransLineIdx { get; set; }
        [Column(TypeName = "varchar(1024)")] public string ErrMsg { get; set; }
        [Column(TypeName = "datetime")] public DateTime? ScheduledAt { get; set; }
        [Column(TypeName = "datetime")] public DateTime? StartedAt { get; set; }
        [Column(TypeName = "datetime")] public DateTime? EndedAt { get; set; }
        [Column(TypeName = "datetime")] public DateTime? CreatedAt { get; set; }
        [Column(TypeName = "datetime")] public DateTime? UpdatedAt { get; set; }

        public WidTaskObjectEntity WidTaskObject { get; set; }
        public WidTaskTypeEnum WidTaskType { get; set; }
        public WidTaskStatusEnum WidTaskStatus { get; set; }
        public WidTaskEntity PrevWidTask { get; set; }

        public ICollection<WidTaskEntity> NextWidTasks { get; set; }

    }
}


