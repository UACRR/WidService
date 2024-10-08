using System.ComponentModel.DataAnnotations.Schema;


namespace WidExport.Entities
{
    [Table("RecSip")]
    public class RecSip
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "int")] public int SubmFileId { get; set; }
        [CustomPosInFile(1, 3, 'A')] [Column(TypeName = "varchar(3)")] public string RecType { get; set; }
        [CustomPosInFile(4, 8, 'N')] [Column(TypeName = "varchar(8)")] public string TransSeqNr { get; set; }
        [CustomPosInFile(12, 8, 'N')] [Column(TypeName = "varchar(8)")] public string RecSeqNr { get; set; }
        [CustomPosInFile(20, 9, ' ')] [Column(TypeName = "varchar(9)")] public string Filler5 { get; set; }
        [CustomPosInFile(29, 9, 'A')] [Column(TypeName = "varchar(9)")] public string IpNr { get; set; }
        [CustomPosInFile(38, 45, 'A')] [Column(TypeName = "varchar(45)")] public string IpName { get; set; }
        [CustomPosInFile(83, 30, 'O')] [Column(TypeName = "varchar(30)")] public string IpFstName { get; set; }
        [CustomPosInFile(113, 2, 'L')] [Column(TypeName = "varchar(2)")] public string IpRole { get; set; }
        [CustomForMatch][CustomPosInFile(115, 11, 'N')] [Column(TypeName = "varchar(11)")] public string IpNameNr { get; set; }
                                                        [Column(TypeName = "int")]        public int   GrpSeqNr            { get; set; }
    }
}

