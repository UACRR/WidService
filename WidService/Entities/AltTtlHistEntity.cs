using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WidServiceLib.Entities
{
    [Table("widAltTtlHist")]
    public class AltTtlHistEntity
    {
       [Key] [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "datetime")] public DateTime ValidFrom { get; set; }
        [Column(TypeName = "datetime")] public DateTime ValidTo { get; set; }
       [CustomSeqNrInFile(0)] [Column(TypeName = "int")] public int Wic { get; set; }
       [CustomSeqNrInFile(1)] [Column(TypeName = "int")] public int SeqNr { get; set; }
       [CustomSeqNrInFile(2)] [Column(TypeName = "varchar(120)")] public string AltTtl { get; set; }
       [CustomSeqNrInFile(3)] [Column(TypeName = "varchar(2)")] public string LngCode { get; set; }
       [CustomSeqNrInFile(4)] [Column(TypeName = "varchar(3)")] public string TtlType { get; set; }
       [CustomSeqNrInFile(5)] [Column(TypeName = "datetime")] public DateTime? CreTs { get; set; }
       [CustomSeqNrInFile(6)] [Column(TypeName = "varchar(15)")] public string CreUid { get; set; }
       [CustomSeqNrInFile(7)] [Column(TypeName = "datetime")] public DateTime? UpdTs { get; set; }
       [CustomSeqNrInFile(8)] [Column(TypeName = "varchar(15)")] public string UpdUid { get; set; }
       
    }  
}      
       
       
       
