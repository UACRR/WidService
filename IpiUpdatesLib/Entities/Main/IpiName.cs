using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IpiUpdatesLib.Entities.Main
{
    public class IpiName
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "int")] public int IpNameNr { get; set; }
        [Column(TypeName = "varchar(13)")] public string IpBaseNr { get; set; }
        [Column(TypeName = "int")] public int? IpNameNrRef { get; set; }
        [Column(TypeName = "varchar(13)")] public string IpBaseNrRef { get; set; }
        [Column(TypeName = "varchar(90)")] public string Name { get; set; }
        [Column(TypeName = "varchar(45)")] public string FstName { get; set; }
        [Column(TypeName = "varchar(2)")] public string NameType { get; set; }
        [Column(TypeName = "datetime")] public DateTime CreDt { get; set; }
        [Column(TypeName = "datetime")] public DateTime AmdDt { get; set; }
        [Column(TypeName = "int")] public int IsDeleted { get; set; }
    }
}
