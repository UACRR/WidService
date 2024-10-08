using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WidServiceLib.Entities
{
    [Table("widWtrPubRel")]
    public class WtrPubRelEntity
    {
        [Key] [Column(TypeName = "int")] public int Id { get; set; }
        [CustomSeqNrInFile(0)][Column(TypeName = "int")] public int Wic { get; set; }
        [CustomSeqNrInFile(1)][Column(TypeName = "int")] public int WtrIntrPtySeq { get; set; }
        [CustomSeqNrInFile(2)][Column(TypeName = "int")] public int PubIntrPtySeq { get; set; }
        [CustomSeqNrInFile(3)][Column(TypeName = "datetime")] public DateTime? CreTs { get; set; }
        [CustomSeqNrInFile(4)][Column(TypeName = "varchar(15)")] public string CreUid { get; set; }
        [CustomSeqNrInFile(5)][Column(TypeName = "datetime")] public DateTime? UpdTs { get; set; }
        [CustomSeqNrInFile(6)][Column(TypeName = "varchar(15)")] public string UpdUid { get; set; }

    }
}
