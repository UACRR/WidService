using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IpiUpdatesLib.Entities.Main
{
    public class IpiStatus
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "varchar(13)")] public string IpBaseNr { get; set; }
        [Column(TypeName = "varchar(13)")] public string IpBaseNrRef { get; set; }
        [Column(TypeName = "varchar(1)")] public string SttCde { get; set; }
        [Column(TypeName = "datetime")] public DateTime FromDt { get; set; }
        [Column(TypeName = "datetime")] public DateTime ToDt { get; set; }
        [Column(TypeName = "datetime")] public DateTime AmdDt { get; set; }
    }
}
