using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WidUpdatesLib.Entities
{
    [Table("DscFieldColNames")]
    public class DscFieldColName
    {
        [Column(TypeName = "varchar(64)")] public string FieldName { get; set; }
        [Column(TypeName = "varchar(64)")] public string ColName { get; set; }
    }
}
