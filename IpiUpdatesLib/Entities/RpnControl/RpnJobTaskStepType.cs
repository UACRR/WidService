using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IpiUpdatesLib
{
    [Table("RpnJobTaskStepTypes")]
    public class RpnJobTaskStepType
    {
        [Column(TypeName = "int")] [Key]    public int Id                   { get; set; }
        [Column(TypeName = "varchar(32)")]  public string Code              { get; set; }
        [Column(TypeName = "varchar(100)")] public string Description       { get; set; }
    }
}
