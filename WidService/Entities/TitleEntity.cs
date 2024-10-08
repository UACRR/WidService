using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WidServiceLib.Entities
{
    [Table("widTitle")]
    public class TitleEntity
    {
        [Key] [Column(TypeName = "int")] public int Id { get; set; }
        [CustomSeqNrInFile(0)] [Column(TypeName = "int")] public int Wic { get; set; }
        [CustomSeqNrInFile(1)] [Column(TypeName = "varchar(60)")] public string WrkTtl { get; set; }
        [CustomSeqNrInFile(2)] [Column(TypeName = "varchar(2)")] public string LngCode { get; set; }
        [CustomSeqNrInFile(3)] [Column(TypeName = "int")] public int? DurHr { get; set; }
        [CustomSeqNrInFile(4)] [Column(TypeName = "int")] public int? DurMm { get; set; }
        [CustomSeqNrInFile(5)] [Column(TypeName = "int")] public int? DurSs { get; set; }
        [CustomSeqNrInFile(6)] [Column(TypeName = "datetime")] public DateTime? CprDate { get; set; }
        [CustomSeqNrInFile(7)] [Column(TypeName = "varchar(12)")] public string CprNr { get; set; }
        [CustomSeqNrInFile(8)] [Column(TypeName = "varchar(1)")] public string RecInd { get; set; }
        [CustomSeqNrInFile(9)] [Column(TypeName = "varchar(3)")] public string MwDistrCat { get; set; }
        [CustomSeqNrInFile(10)][Column(TypeName = "varchar(3)")] public string VerType { get; set; }
        [CustomSeqNrInFile(11)][Column(TypeName = "int")] public int? VerWic { get; set; }
        [CustomSeqNrInFile(12)][Column(TypeName = "varchar(3)")] public string ExcType { get; set; }
        [CustomSeqNrInFile(13)][Column(TypeName = "int")] public int? ExcWic { get; set; }
        [CustomSeqNrInFile(14)][Column(TypeName = "varchar(3)")] public string CmpType { get; set; }
        [CustomSeqNrInFile(15)][Column(TypeName = "varchar(3)")] public string TxtMusicRel { get; set; }
        [CustomSeqNrInFile(16)][Column(TypeName = "varchar(3)")] public string MusicArr { get; set; }
        [CustomSeqNrInFile(17)][Column(TypeName = "varchar(3)")] public string LyrAdapt { get; set; }
        [CustomSeqNrInFile(22)] [Column(TypeName = "varchar(1)")] public string PdInd { get; set; }
        [CustomSeqNrInFile(23)] [Column(TypeName = "varchar(1)")] public string NonDisplay { get; set; }
        [CustomSeqNrInFile(18)][Column(TypeName = "datetime")] public DateTime? CreTs { get; set; }
        [CustomSeqNrInFile(19)][Column(TypeName = "varchar(15)")] public string CreUid { get; set; }
        [CustomSeqNrInFile(20)] [Column(TypeName = "datetime")] public DateTime? UpdTs { get; set; }
        [CustomSeqNrInFile(21)] [Column(TypeName = "varchar(15)")] public string UpdUid { get; set; }

    }
}
