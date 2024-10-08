using System.ComponentModel.DataAnnotations.Schema;


namespace WidExport.Entities
{
    [Table("RecAlt")]
    public class RecAlt
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "int")] public int SubmFileId { get; set; }
        [CustomPosInFile(1, 3, 'A')] [Column(TypeName = "varchar(3)")] public string RecType { get; set; }
        [CustomPosInFile(4, 8, 'N')] [Column(TypeName = "varchar(8)")] public string TransSeqNr { get; set; }
        [CustomPosInFile(12, 8, 'N')] [Column(TypeName = "varchar(8)")] public string RecSeqNr { get; set; }
        [CustomForMatch][CustomPosInFile(20, 60, 'A')] [Column(TypeName = "varchar(60)")] public string AltTtl { get; set; }
        [CustomForMatch] [CustomPosInFile(80, 3, 'L')] [Column(TypeName = "varchar(3)")] public string TtlType { get; set; }
        [CustomForMatch] [CustomPosInFile(83, 2, 'L')] [Column(TypeName = "varchar(2)")] public string LngCode { get; set; }
                                                       [Column(TypeName = "int")]        public int   GrpSeqNr            { get; set; }
    }
}

