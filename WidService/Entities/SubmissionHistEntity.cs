using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WidServiceLib.Entities
{
    [Table("widSubmissionHist")]
    public class SubmissionHistEntity
    {
        [Key] [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "datetime")] public DateTime ValidFrom { get; set; }
        [Column(TypeName = "datetime")] public DateTime ValidTo { get; set; }
        [CustomSeqNrInFile(0)] [Column(TypeName = "int")] public int Wic { get; set; }
        [CustomSeqNrInFile(1)] [Column(TypeName = "varchar(3)")] public string SocCde { get; set; }
        [CustomSeqNrInFile(2)] [Column(TypeName = "datetime")] public DateTime? SubmDt { get; set; }
        [CustomSeqNrInFile(3)] [Column(TypeName = "varchar(20)")] public string SocWorkCde { get; set; }
        [CustomSeqNrInFile(4)] [Column(TypeName = "varchar(3)")] public string TrTyp { get; set; }
        [CustomSeqNrInFile(5)] [Column(TypeName = "datetime")] public DateTime? CreTs { get; set; }
        [CustomSeqNrInFile(6)] [Column(TypeName = "varchar(15)")] public string CreUid { get; set; }
        [CustomSeqNrInFile(7)] [Column(TypeName = "datetime")] public DateTime? UpdTs { get; set; }
        [CustomSeqNrInFile(8)] [Column(TypeName = "varchar(15)")] public string UpdUid { get; set; }

    }
}
