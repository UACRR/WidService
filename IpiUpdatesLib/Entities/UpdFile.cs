using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IpiUpdatesLib.Entities
{
    [Table("UpdFiles")]
    public class UpdFile
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "varchar(32)")] public string Name { get; set; }
        [Column(TypeName = "int")] public int Year { get; set; }
        [Column(TypeName = "int")] public int Month { get; set; }
        [Column(TypeName = "int")] public int Day { get; set; }
    }
}
