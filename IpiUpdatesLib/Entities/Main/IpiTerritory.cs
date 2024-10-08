using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace IpiUpdatesLib.Entities.Main
{
    public class IpiTerritory
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "varchar(26)")] public string IpAgreeNr { get; set; }
        [Column(TypeName = "varchar(4)")] public string TisNr { get; set; }
        [Column(TypeName = "date")] public DateTime TisNrFromD { get; set; }
        [Column(TypeName = "varchar(20)")] public string Tisan { get; set; }
        [Column(TypeName = "date")] public DateTime TisanFromD { get; set; }
        [Column(TypeName = "varchar(1)")] public string IncExcInd { get; set; }
    }
}
