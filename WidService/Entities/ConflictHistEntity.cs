using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WidServiceLib.Entities
{
    [Table("widConflictHist")]
    public class ConflictHistEntity
    {

        [Key] [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "datetime")] public DateTime ValidFrom { get; set; }
        [Column(TypeName = "datetime")] public DateTime ValidTo { get; set; }
        [CustomSeqNrInFile(0)] [Column(TypeName = "int")] public int Wic { get; set; }
       [CustomSeqNrInFile(1)] [Column(TypeName = "varchar(3)")] public string SocCode { get; set; }
       [CustomSeqNrInFile(2)] [Column(TypeName = "varchar(3)")][Required] public string RightType { get; set; }
       [CustomSeqNrInFile(3)] [Column(TypeName = "varchar(3)")] public string CflReasonCode { get; set; }
       [CustomSeqNrInFile(4)] [Column(TypeName = "datetime")] public DateTime? CflDt { get; set; }
       [CustomSeqNrInFile(5)] [Column(TypeName = "datetime")] public DateTime? RsvDt { get; set; }
       [CustomSeqNrInFile(6)] [Column(TypeName = "varchar(60)")] public string CflNote { get; set; }
       [CustomSeqNrInFile(7)] [Column(TypeName = "varchar(30)")] public string CntrName { get; set; }
       [CustomSeqNrInFile(8)] [Column(TypeName = "varchar(10)")] public string CntrId { get; set; }
       [CustomSeqNrInFile(9)] [Column(TypeName = "datetime")] public DateTime? CreTs { get; set; }
       [CustomSeqNrInFile(10)][Column(TypeName = "varchar(15)")] public string CreUid { get; set; }
       [CustomSeqNrInFile(11)] [Column(TypeName = "datetime")] public DateTime? UpdTs { get; set; }
       [CustomSeqNrInFile(12)] [Column (TypeName = "varchar(15)")] public string UpdUid { get; set; }

    }
}
