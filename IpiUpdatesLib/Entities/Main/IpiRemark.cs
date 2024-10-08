using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IpiUpdatesLib.Entities.Main
{
    public class IpiRemark
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "varchar(13)")] public string IpBaseNr { get; set; }
        [Column(TypeName = "varchar(3)")] public string SocCde { get; set; }
        [Column(TypeName = "int")] public int SeqNr { get; set; }
        [Column(TypeName = "varchar(20)")] public string Txt { get; set; }

    }
}
