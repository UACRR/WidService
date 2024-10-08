using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WidServiceLib.Entities
{
    [Table("widOrgTtlVrExrp")]
    public class OrgTtlVrExrpEntity
    {
        [Key] [Column(TypeName = "int")] public int Id { get; set; }
        [CustomSeqNrInFile(0)] [Column(TypeName = "int")] public int Wic { get; set; }
        [CustomSeqNrInFile(1)] [Column(TypeName = "varchar(60)")][Required] public string VrExrpInd { get; set; }
        [CustomSeqNrInFile(2)] [Column(TypeName = "varchar(60)")] public string EntireWrkTtl { get; set; }
        [CustomSeqNrInFile(3)] [Column(TypeName = "varchar(2)")] public string LngCode { get; set; }
        [CustomSeqNrInFile(4)] [Column(TypeName = "varchar(45)")] public string WrtLstName1 { get; set; }
        [CustomSeqNrInFile(5)] [Column(TypeName = "varchar(30)")] public string WrtFstName1 { get; set; }
        [CustomSeqNrInFile(6)] [Column(TypeName = "varchar(45)")] public string WrtLstName2 { get; set; }
        [CustomSeqNrInFile(7)] [Column(TypeName = "varchar(30)")] public string WrtFstName2 { get; set; }
        [CustomSeqNrInFile(8)] [Column(TypeName = "varchar(60)")] public string Source { get; set; }
        [CustomSeqNrInFile(13)][Column(TypeName = "varchar(11)")] public string IswcWrk { get; set; }
        [CustomSeqNrInFile(9)] [Column(TypeName = "datetime")] public DateTime? CreTs { get; set; }
        [CustomSeqNrInFile(10)][Column(TypeName = "varchar(15)")] public string CreUid { get; set; }
        [CustomSeqNrInFile(11)][Column(TypeName = "datetime")] public DateTime? UpdTs { get; set; }
        [CustomSeqNrInFile(12)][Column(TypeName = "varchar(15)")] public string UpdUid { get; set; }
    }
}
