using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WidServiceLib.Entities
{
    [Table("IpiNameHist")]
    public class IpiNameHistEntity
    {
        [Key] [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "datetime")] public DateTime ValidFrom { get; set; }
        [Column(TypeName = "datetime")] public DateTime ValidTo { get; set; }
        [CustomSeqNrInFile(0)] [Column(TypeName = "varchar(13)")][Required] public string IpBaseNr { get; set; }
        [CustomSeqNrInFile(1)] [Column(TypeName = "varchar(11)")][Required] public string IpNameNr { get; set; }
        [CustomSeqNrInFile(2)] [Column(TypeName = "varchar(90)")][Required] public string FstName { get; set; }
        [CustomSeqNrInFile(3)] [Column(TypeName = "varchar(90)")] public string LstName { get; set; }
        [CustomSeqNrInFile(4)] [Column(TypeName = "varchar(2)")][Required] public string NameType { get; set; }
        [CustomSeqNrInFile(5)] [Column(TypeName = "datetime")] public DateTime? AmdTs { get; set; }
        [CustomSeqNrInFile(6)] [Column(TypeName = "datetime")] public DateTime? UpdTs { get; set; }
        [CustomSeqNrInFile(7)] [Column(TypeName = "varchar(100)")] public string NameCrea { get; set; }
    }
}
