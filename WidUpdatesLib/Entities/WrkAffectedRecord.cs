using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WidUpdatesLib.Entities
{
    [Table("WrkAffectedRecords")]
    public class WrkAffectedRecord
    {
        [Column(TypeName = "varchar(6)")] public string EntityName { get; set; }
        [Column(TypeName = "int")] public int Wic { get; set; }
    }
}
