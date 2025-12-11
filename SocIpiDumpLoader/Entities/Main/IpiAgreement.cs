using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SocIpiDumpLoader.Entities.Main
{
    public class IpiAgreement
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "varchar(41)")] public string IpAgreeNr { get; set; }
        [Column(TypeName = "varchar(13)")] public string IpBaseNr { get; set; }
        [Column(TypeName = "varchar(3)")] public string SocCde { get; set; }
        [Column(TypeName = "varchar(2)")] public string CreClsCde { get; set; }
        [Column(TypeName = "varchar(2)")] public string RolCde { get; set; }
        [Column(TypeName = "varchar(2)")] public string RgtCde { get; set; }
        [Column(TypeName = "datetime")] public DateTime FromDt { get; set; }
        [Column(TypeName = "datetime")] public DateTime ToDt { get; set; }
        [Column(TypeName = "date")] public DateTime SignD { get; set; }
        [Column(TypeName = "decimal(5, 2)")] public decimal Shr { get; set; }
        [Column(TypeName = "datetime")] public DateTime AmdDt { get; set; }
        [Column(TypeName = "int")] public int IsDeleted { get; set; }
    }
}
