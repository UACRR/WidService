using System.ComponentModel.DataAnnotations.Schema;


namespace WidUpdatesLib.Entities
{
    [Table("RecTtu")]
    [CustomIsTran]
    [CustomTargetWidEntity("Title")]
    [CustomUpdateMethod("C")]
    public class RecTtu
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "int")] public int UpdFileId { get; set; }
        [CustomPosInFile(1, 3)] [Column(TypeName = "varchar(3)")] public string RecType { get; set; }
        [CustomPosInFile(4, 8)] [Column(TypeName = "varchar(8)")] public string TransSeqNr { get; set; }
        [CustomPosInFile(12, 8)] [Column(TypeName = "varchar(8)")] public string RecSeqNr { get; set; }
        [CustomForMatch][CustomPosInFile(20, 11)] [Column(TypeName = "varchar(11)")] public string Iswc { get; set; }
        [CustomForMatch] [CustomPosInFile(31, 10)] [Column(TypeName = "varchar(10)")] public string WicCode { get; set; }
        [CustomPosInFile(41, 60)] [Column(TypeName = "varchar(60)")] public string OrigWrkTtl { get; set; }
        [CustomForUpdate] [CustomPosInFile(101, 60)] [Column(TypeName = "varchar(60)")] public string NewWrkTtl { get; set; }

        public UpdFile UpdFile { get; set; }
    }
}

