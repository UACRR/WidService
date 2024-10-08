using System.ComponentModel.DataAnnotations.Schema;


namespace WidExport.Entities
{
    [Table("RecPer")]
    public class RecPer
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "int")] public int SubmFileId { get; set; }
        [CustomPosInFile(1, 3, 'A')] [Column(TypeName = "varchar(3)")] public string RecType { get; set; }
        [CustomPosInFile(4, 8, 'N')] [Column(TypeName = "varchar(8)")] public string TransSeqNr { get; set; }
        [CustomPosInFile(12, 8, 'N')] [Column(TypeName = "varchar(8)")] public string RecSeqNr { get; set; }
        [CustomPosInFile(20, 45, 'A')] [Column(TypeName = "varchar(45)")] public string PerfArtistLstName { get; set; }
        [CustomPosInFile(65, 30, 'A')] [Column(TypeName = "varchar(30)")] public string PerfArtistFstName { get; set; }
        [CustomPosInFile(95, 9, ' ')] [Column(TypeName = "varchar(9)")] public string Filler4 { get; set; }
        [CustomPosInFile(104, 11, 'L')] [Column(TypeName = "varchar(11)")] public string PerfArtistIpNameNr { get; set; }
                                        [Column(TypeName = "int")]        public int   GrpSeqNr            { get; set; }
    }
}

