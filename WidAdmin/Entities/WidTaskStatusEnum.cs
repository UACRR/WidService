using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WidAdminLib.Entities
{
    [Table("WidTaskStatuses")]
    public class WidTaskStatusEnum
    {
        [Column(TypeName = "int")] [Key]    public int Id               { get; set; }
        [Column(TypeName = "varchar(20)")]  public string Code             { get; set; }
        [Column(TypeName = "varchar(100)")] public string Description   { get; set; }
    }
}
