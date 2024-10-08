using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IpiUpdatesLib.Entities.Main
{
    public class IpiBase
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "varchar(13)")] public string IpBaseNr { get; set; }
        [Column(TypeName = "varchar(1)")] public string IpType { get; set; }
        [Column(TypeName = "date")] public DateTime BirthD { get; set; }
        [Column(TypeName = "date")] public DateTime DeathD { get; set; }
        [Column(TypeName = "varchar(30)")] public string BirthPlace { get; set; }
        [Column(TypeName = "varchar(30)")] public string BirthState { get; set; }
        [Column(TypeName = "varchar(4)")] public string BirthTisNr { get; set; }
        [Column(TypeName = "date")] public DateTime TisNrFromD { get; set; }
        [Column(TypeName = "varchar(20)")] public string BirthTisan { get; set; }
        [Column(TypeName = "date")] public DateTime TisanFromD { get; set; }
        [Column(TypeName = "varchar(1)")] public string Sex { get; set; }
        [Column(TypeName = "datetime")] public DateTime AmdDt { get; set; }
    }
}
