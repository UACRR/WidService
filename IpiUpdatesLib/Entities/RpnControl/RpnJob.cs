using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IpiUpdatesLib
{
    [Table("RpnJobs")]
    public class RpnJob
    {
        [Column(TypeName = "int")] [Key]    public int Id               { get; set; }
        [Column(TypeName = "int")]          public int SeqNr            { get; set; }
        [Column(TypeName = "int")]          public int RpnPeriodId      { get; set; }
        [Column(TypeName = "int")]          public int RpnJobTypeId     { get; set; }
        [Column(TypeName = "datetime")]     public DateTime CreatedAt   { get; set; }
        [Column(TypeName = "datetime")]     public DateTime? StartedAt  { get; set; }
        [Column(TypeName = "datetime")]     public DateTime? EndedAt    { get; set; }

        public RpnPeriod RpnPeriod                      { get; set; }
        public RpnJobType RpnJobType                    { get; set; }
        public ICollection<RpnJobTask> RpnJobTasks      { get; set; }

    }
}


