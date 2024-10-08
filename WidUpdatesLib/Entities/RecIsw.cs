using System.ComponentModel.DataAnnotations.Schema;


namespace WidUpdatesLib.Entities
{
    [Table("RecIsw")]
    [CustomTargetWidEntity("Iswc")]
    [CustomUpdateMethod("I")]
    public class RecIsw
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "int")] public int UpdFileId { get; set; }
        [CustomPosInFile(1, 3)] [Column(TypeName = "varchar(3)")] public string RecType { get; set; }
        [CustomPosInFile(4, 8)] [Column(TypeName = "varchar(8)")] public string TransSeqNr { get; set; }
        [CustomPosInFile(12, 8)] [Column(TypeName = "varchar(8)")] public string RecSeqNr { get; set; }
        [CustomPosInFile(20, 60)] [Column(TypeName = "varchar(60)")] public string CreTtl { get; set; }
        [CustomPosInFile(80, 11)] [Column(TypeName = "varchar(11)")] public string Iswc { get; set; }

        public UpdFile UpdFile { get; set; }
    }
}

