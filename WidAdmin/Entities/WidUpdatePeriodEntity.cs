using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WidAdminLib.Entities
{
    [Table("WidUpdatePeriods")]
    public class WidUpdatePeriodEntity
    {
        [Column(TypeName = "int")] [Key] public int Id { get; set; }
        [Column(TypeName = "int")] public int WidTaskStatusId { get; set; }
        [Column(TypeName = "datetime")] public DateTime? WidDumpTs { get; set; }
        [Column(TypeName = "datetime")] public DateTime? NewWidDumpTs { get; set; }
        [Column(TypeName = "bigint")] public long WidDumpFilesTotalSize{ get; set; }
        [Column(TypeName = "bigint")] public long NewWidDumpFilesTotalSize { get; set; }
        [Column(TypeName = "datetime")] public DateTime? IpiDumpTs { get; set; }
        [Column(TypeName = "datetime")] public DateTime? NewIpiDumpTs { get; set; }

        [Column(TypeName = "datetime")] public DateTime? StartedAt { get; set; }
        [Column(TypeName = "datetime")] public DateTime? EndedAt { get; set; }
        [Column(TypeName = "datetime")] public DateTime? CreatedAt { get; set; }
        [Column(TypeName = "datetime")] public DateTime? UpdatedAt { get; set; }

        public WidTaskStatusEnum WidTaskStatus { get; set; }
        public List<WidTaskSubjectEntity> WidTaskSubjects { get; set; }
    }
}


