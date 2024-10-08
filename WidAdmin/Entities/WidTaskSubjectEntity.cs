using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WidAdminLib.Entities
{
    [Table("WidTaskSubjects")]
    public class WidTaskSubjectEntity
    {
        [Column(TypeName = "int")] [Key] public int Id { get; set; }
        [Column(TypeName = "int")] public int WidUpdatePeriodId { get; set; }
        [Column(TypeName = "int")] public int WidTaskSubjectTypeId { get; set; }
        [Column(TypeName = "int")] public int WidTaskStatusId { get; set; }
        [Column(TypeName = "varchar(3)")] public string Db { get; set; }
        [Column(TypeName = "date")] public DateTime? TasksDate { get; set; }
        [Column(TypeName = "datetime")] public DateTime? StartedAt { get; set; }
        [Column(TypeName = "datetime")] public DateTime? EndedAt { get; set; }
        [Column(TypeName = "datetime")] public DateTime? CreatedAt { get; set; }
        [Column(TypeName = "datetime")] public DateTime? UpdatedAt { get; set; }

        public WidUpdatePeriodEntity WidUpdatePeriod { get; set; }
        public WidTaskTypeEnum WidTaskSubjectType { get; set; }
        public WidTaskStatusEnum WidTaskStatus { get; set; }
        public ICollection<WidTaskObjectEntity> WidTaskObjects { get; set; }

    }
}


