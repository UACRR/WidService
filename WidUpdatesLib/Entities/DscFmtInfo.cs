using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WidUpdatesLib.Entities
{
    [Table("DscFmtInfo")]
    public class DscFmtInfo
    {
        [Column(TypeName = "char(1)")] public char Fmt { get; set; }
        [Column(TypeName = "varchar(32)")] public string CsTypeName { get; set; }
        [Column(TypeName = "varchar(32)")] public string SqlTypeName { get; set; }
    }
}
