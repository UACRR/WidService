using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WidUpdatesLib.Entities
{
    [Table("DscRecTypes")]
    public class DscRecType
    {
        [Column(TypeName = "char(3)")] public string Code { get; set; }
        [Column(TypeName = "char(4)")] public string Nr { get; set; }
        [Column(TypeName = "varchar(255)")] public string Dsc { get; set; }

        public ICollection<DscRecField> RecFields { get; set; }
    }
}
