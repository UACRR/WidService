using System.ComponentModel.DataAnnotations.Schema;


namespace WidUpdatesLib.Entities
{
    [Table("RecAlt")]
    [CustomTargetWidEntity("AltTtl")]
    [CustomUpdateMethod("I")]
    public class RecAlt
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "int")] public int UpdFileId { get; set; }
        [CustomPosInFile(1, 3)] [Column(TypeName = "varchar(3)")] public string RecType { get; set; }
        [CustomPosInFile(4, 8)] [Column(TypeName = "varchar(8)")] public string TransSeqNr { get; set; }
        [CustomPosInFile(12, 8)] [Column(TypeName = "varchar(8)")] public string RecSeqNr { get; set; }
        [CustomForMatch][CustomPosInFile(20, 60)] [Column(TypeName = "varchar(60)")] public string AltTtl { get; set; }
        [CustomForMatch] [CustomPosInFile(80, 3)] [Column(TypeName = "varchar(3)")] public string TtlType { get; set; }
        [CustomForMatch] [CustomPosInFile(83, 2)] [Column(TypeName = "varchar(2)")] public string LngCode { get; set; }

        public UpdFile UpdFile { get; set; }
    }
}

