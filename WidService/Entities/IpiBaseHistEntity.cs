using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WidServiceLib.Entities
{
    [Table("IpiBaseHist")]
    public class IpiBaseHistEntity
    {
        [Key] [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "datetime")] public DateTime ValidFrom { get; set; }
        [Column(TypeName = "datetime")] public DateTime ValidTo { get; set; }
        [CustomSeqNrInFile(0)] [Column(TypeName = "varchar(13)")][Required] public string IpBaseNr { get; set; }
        [CustomSeqNrInFile(1)] [Column(TypeName = "varchar(1)")][Required] public string IpType { get; set; }
        [CustomSeqNrInFile(2)] [Column(TypeName = "varchar(4)")] public string BirthYy { get; set; }
        [CustomSeqNrInFile(3)] [Column(TypeName = "varchar(2)")] public string BirthMm { get; set; }
        [CustomSeqNrInFile(4)] [Column(TypeName = "varchar(2)")] public string BirthDd { get; set; }
        [CustomSeqNrInFile(5)] [Column(TypeName = "varchar(4)")] public string DeathYy { get; set; }
        [CustomSeqNrInFile(6)] [Column(TypeName = "varchar(2)")] public string DeathMm { get; set; }
        [CustomSeqNrInFile(7)] [Column(TypeName = "varchar(2)")] public string DeathDd { get; set; }
        [CustomSeqNrInFile(8)] [Column(TypeName = "varchar(30)")] public string BirthPlace { get; set; }
        [CustomSeqNrInFile(9)] [Column(TypeName = "varchar(30)")] public string BirthState { get; set; }
        [CustomSeqNrInFile(10)][Column(TypeName = "varchar(4)")] public string TisNr { get; set; }
        [CustomSeqNrInFile(11)][Column(TypeName = "datetime")] public DateTime? TisNrFromTs { get; set; }
        [CustomSeqNrInFile(12)][Column(TypeName = "varchar(20)")] public string Tisan { get; set; }
        [CustomSeqNrInFile(13)][Column(TypeName = "datetime")] public DateTime? TisanFromTs { get; set; }
        [CustomSeqNrInFile(14)][Column(TypeName = "varchar(1)")] public string Gender { get; set; }
        [CustomSeqNrInFile(15)][Column(TypeName = "datetime")] public DateTime? AmdTs { get; set; }
        [CustomSeqNrInFile(16)] [Column(TypeName = "datetime")] public DateTime? UpdTs { get; set; }

    }
}
