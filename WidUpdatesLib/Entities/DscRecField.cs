using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WidUpdatesLib.Entities
{
    [Table("DscRecFields")]
    public class DscRecField
    {
        [Column(TypeName = "char(3)")] public string RecTypeCode { get; set; }
        [Column(TypeName = "int")] public int SeqNr { get; set; }
        [Column(TypeName = "varchar(64)")] public string Field { get; set; }
        [Column(TypeName = "int")] public int Start { get; set; }
        [Column(TypeName = "int")] public int Size { get; set; }
        [Column(TypeName = "char(1)")] public char Fmt { get; set; }
        [Column(TypeName = "char(1)")] public char Req { get; set; }
        [Column(TypeName = "varchar(1024)")] public string Dsc { get; set; }
        [Column(TypeName = "varchar(255)")] public string Rules { get; set; }

        public DscRecType RecType { get; set; }
    }
}
