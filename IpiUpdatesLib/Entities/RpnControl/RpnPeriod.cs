using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IpiUpdatesLib
{
    [Table("RpnPeriods")]
    public class RpnPeriod
    {
        [Column(TypeName = "int")] [Key] public int Id                   { get; set; }
        [Column(TypeName = "date")]      public DateTime IpiCompleteDate { get; set; }
        [Column(TypeName = "datetime")]  public DateTime CreatedAt       { get; set; }
        [Column(TypeName = "datetime")]  public DateTime? StartedAt      { get; set; }
        [Column(TypeName = "datetime")]  public DateTime? EndedAt        { get; set; }

        public List<RpnJob> RpnJobs { get; set; }
    }
}


