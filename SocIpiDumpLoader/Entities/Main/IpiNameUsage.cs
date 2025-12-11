using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SocIpiDumpLoader.Entities.Main
{
    public class IpiNameUsage
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [CustomPosInFile(20, 11)] [Column(TypeName = "int")] public int IpNameNr { get; set; }
        [Column(TypeName = "varchar(13)")] public string IpBaseNr { get; set; }
        [CustomPosInFile(31, 2)] [Column(TypeName = "varchar(2)")] public string CreClsCde { get; set; }
        [CustomPosInFile(33, 2)] [Column(TypeName = "varchar(2)")] public string RolCde { get; set; }
        [Column(TypeName = "int")] public int IsDeleted { get; set; }
    }
}
