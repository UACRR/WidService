using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WidServiceLib.Entities
{
    [Table("IpiStatusHist")]
    public class IpiStatusHistEntity
    {
        [Key] [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "datetime")] public DateTime ValidFrom { get; set; }
        [Column(TypeName = "datetime")] public DateTime ValidTo { get; set; }
        [CustomSeqNrInFile(0)] [Column(TypeName = "varchar(13)")][Required] public string IpBaseNr { get; set; }
        [CustomSeqNrInFile(1)] [Column(TypeName = "varchar(13)")][Required] public string RelIpBaseNr { get; set; }
        [CustomSeqNrInFile(2)] [Column(TypeName = "varchar(1)")][Required] public string StsCde { get; set; }
        [CustomSeqNrInFile(3)] [Column(TypeName = "datetime")] public DateTime FromTs { get; set; }
        [CustomSeqNrInFile(4)] [Column(TypeName = "datetime")] public DateTime ToTs { get; set; }
        [CustomSeqNrInFile(5)] [Column(TypeName = "datetime")] public DateTime? AmdTs { get; set; }
        [CustomSeqNrInFile(6)] [Column(TypeName = "datetime")] public DateTime? UpdTs { get; set; }
    }
}
