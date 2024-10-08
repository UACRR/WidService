using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WidServiceLib.Entities
{
    [Table("widComponentHist")]
    public class ComponentHistEntity
    {
        [Key] [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "datetime")] public DateTime ValidFrom { get; set; }
        [Column(TypeName = "datetime")] public DateTime ValidTo { get; set; }
        [CustomSeqNrInFile(0)] [Column(TypeName = "int")] public int Wic { get; set; }
        [CustomSeqNrInFile(1)] [Column(TypeName = "int")] public int SeqNr { get; set; }
        [CustomSeqNrInFile(2)] [Column(TypeName = "varchar(100)")] public string SubmWrkNr { get; set; }
        [CustomSeqNrInFile(3)] [Column(TypeName = "varchar(11)")] public string IswcComp { get; set; }
        [CustomSeqNrInFile(4)] [Column(TypeName = "varchar(60)")] public string Ttl { get; set; }
        [CustomSeqNrInFile(5)] [Column(TypeName = "int")] public int? DurHr { get; set; }
        [CustomSeqNrInFile(6)] [Column(TypeName = "int")] public int? DurMm { get; set; }
        [CustomSeqNrInFile(7)] [Column(TypeName = "int")] public int? DurSs { get; set; }
        [CustomSeqNrInFile(8)] [Column(TypeName = "varchar(45)")] public string WrtLstName1 { get; set; }
        [CustomSeqNrInFile(9)] [Column(TypeName = "varchar(30)")] public string WrtFstName1 { get; set; }
        [CustomSeqNrInFile(18)] [Column(TypeName = "int")] public int? WrtIpNameNr1 { get; set; }
        [CustomSeqNrInFile(10)][Column(TypeName = "int")] public int? CarNr1 { get; set; }
        [CustomSeqNrInFile(11)] [Column(TypeName = "varchar(45)")] public string WriterLstName2 { get; set; }
        [CustomSeqNrInFile(12)] [Column(TypeName = "varchar(30)")] public string WrtFstName2 { get; set; }
        [CustomSeqNrInFile(19)] [Column(TypeName = "int")] public int? WrtIpNameNr2 { get; set; }
        [CustomSeqNrInFile(13)] [Column(TypeName = "int")] public int? CarNr2 { get; set; }
        [CustomSeqNrInFile(14)] [Column(TypeName = "datetime")] public DateTime? CreTs { get; set; }
        [CustomSeqNrInFile(15)] [Column(TypeName = "varchar(15)")] public string CreUid { get; set; }
        [CustomSeqNrInFile(16)] [Column(TypeName = "datetime")] public DateTime? UpdTs { get; set; }
        [CustomSeqNrInFile(17)] [Column(TypeName = "varchar(15)")] public string UpdUid { get; set; }
    }
}
