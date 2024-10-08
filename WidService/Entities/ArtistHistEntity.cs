using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WidServiceLib.Entities
{
    [Table("widArtistHist")]
    public class ArtistHistEntity
    {
        [Key] [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "datetime")] public DateTime ValidFrom { get; set; }
        [Column(TypeName = "datetime")] public DateTime ValidTo { get; set; }
        [CustomSeqNrInFile(0)] [Column(TypeName = "int")] public int Wic { get; set; }
        [CustomSeqNrInFile(1)] [Column(TypeName = "int")] public int SeqNr { get; set; }
        [CustomSeqNrInFile(2)] [Column(TypeName = "varchar(45)")] public string PerfArtistLstName { get; set; }
        [CustomSeqNrInFile(3)] [Column(TypeName = "varchar(30)")] public string PerfArtistFstName { get; set; }
        [CustomSeqNrInFile(10)] [Column(TypeName = "int")] public int? PerfArtistIpNameNr { get; set; }
        [CustomSeqNrInFile(4)] [Column(TypeName = "varchar(20)")] public string Isrc { get; set; }
        [CustomSeqNrInFile(5)] [Column(TypeName = "int")] public int? CaeNr { get; set; }
        [CustomSeqNrInFile(6)] [Column(TypeName = "datetime")] public DateTime? CreTs { get; set; }
        [CustomSeqNrInFile(7)] [Column(TypeName = "varchar(15)")] public string CreUid { get; set; }
        [CustomSeqNrInFile(8)] [Column(TypeName = "datetime")] public DateTime? UpdTs { get; set; }
        [CustomSeqNrInFile(9)] [Column(TypeName = "varchar(15)")] public string UpdUid { get; set; }


    }
}
