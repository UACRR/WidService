using System.ComponentModel.DataAnnotations.Schema;


namespace WidUpdatesLib.Entities
{
    [Table("RecLnk")]
    [CustomTargetWidEntity("Title")]
    [CustomUpdateMethod("C")]
    public class RecLnk
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "int")] public int UpdFileId { get; set; }
        [CustomPosInFile(1, 3)] [Column(TypeName = "varchar(3)")] public string RecType { get; set; }
        [CustomPosInFile(4, 8)] [Column(TypeName = "varchar(8)")] public string TransSeqNr { get; set; }
        [CustomPosInFile(12, 8)] [Column(TypeName = "varchar(8)")] public string RecSeqNr { get; set; }
        [CustomPosInFile(20, 10)] [Column(TypeName = "varchar(10)")] public string WicMergedWrk { get; set; }
        [CustomPosInFile(30, 10)] [Column(TypeName = "varchar(10)")] public string WicDelWrk { get; set; }

        public UpdFile UpdFile { get; set; }
    }
}

