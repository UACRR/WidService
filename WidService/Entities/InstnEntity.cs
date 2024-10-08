using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WidServiceLib.Entities
{
    [Table("widInstn")]
    public class InstnEntity
    {
        [Key] [Column(TypeName = "int")] public int Id { get; set; }
        [CustomSeqNrInFile(0)][Column(TypeName = "int")] public int Wic { get; set; }
        [CustomSeqNrInFile(8)] [Column(TypeName = "int")] public int? SeqNr { get; set; }
        [CustomSeqNrInFile(1)] [Column(TypeName = "varchar(3)")][Required] public string StdInstrType { get; set; }
        [CustomSeqNrInFile(2)] [Column(TypeName = "int")] public int? NumOfVoices { get; set; }
        [CustomSeqNrInFile(3)] [Column(TypeName = "varchar(50)")] public string InstrDsc { get; set; }
        [CustomSeqNrInFile(4)] [Column(TypeName = "datetime")] public DateTime? CreTs { get; set; }
        [CustomSeqNrInFile(5)] [Column(TypeName = "varchar(15)")] public string CreUid { get; set; }
        [CustomSeqNrInFile(6)] [Column(TypeName = "datetime")] public DateTime? UpdTs { get; set; }
        [CustomSeqNrInFile(7)] [Column(TypeName = "varchar(15)")] public string UpdUid { get; set; }
    }
}
