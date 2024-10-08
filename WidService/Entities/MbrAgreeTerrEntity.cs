using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WidServiceLib.Entities
{
    [Table("IpiMbrAgreeTerr")]
    public class MbrAgreeTerrEntity
    {
        [Key] [Column(TypeName = "int")] public int Id { get; set; }
        [CustomSeqNrInFile(0)] [Column(TypeName = "varchar(13)")][Required] public string IpBaseNr { get; set; }
        [CustomSeqNrInFile(1)] [Column(TypeName = "varchar(3)")][Required] public string SocId { get; set; }
        [CustomSeqNrInFile(2)] [Column(TypeName = "varchar(2)")][Required] public string CreClass { get; set; }
        [CustomSeqNrInFile(3)] [Column(TypeName = "varchar(2)")][Required] public string Rol { get; set; }
        [CustomSeqNrInFile(4)] [Column(TypeName = "varchar(2)")][Required] public string Rgt { get; set; }
        [CustomSeqNrInFile(5)] [Column(TypeName = "datetime")] public DateTime FromTs { get; set; }
        [CustomSeqNrInFile(6)] [Column(TypeName = "datetime")] public DateTime ToTs { get; set; }
        [CustomSeqNrInFile(7)] [Column(TypeName = "decimal(5, 2)")] public decimal? Shr { get; set; }
        [CustomSeqNrInFile(8)] [Column(TypeName = "datetime")] public DateTime? AmdTs { get; set; }
        [CustomSeqNrInFile(9)] [Column(TypeName = "varchar(4)")][Required] public string TisNr { get; set; }
        [CustomSeqNrInFile(10)] [Column(TypeName = "datetime")] public DateTime? TisNrFromTs { get; set; }
        [CustomSeqNrInFile(11)] [Column(TypeName = "varchar(20)")] public string Tisan { get; set; }
        [CustomSeqNrInFile(12)] [Column(TypeName = "datetime")] public DateTime? TisanFromTs { get; set; }
        [CustomSeqNrInFile(13)] [Column(TypeName = "varchar(1)")][Required] public string IncExc { get; set; }
        [CustomSeqNrInFile(14)] [Column(TypeName = "datetime")] public DateTime? UpdTs { get; set; }

    }
}
