using System.ComponentModel.DataAnnotations.Schema;


namespace WidUpdatesLib.Entities
{
    [Table("RecWpl")]
    [CustomTargetWidEntity("WtrPubRel")]
    [CustomUpdateMethod("C")]
    public class RecWpl
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "int")] public int UpdFileId { get; set; }
        [CustomPosInFile(1, 3)] [Column(TypeName = "varchar(3)")] public string RecType { get; set; }
        [CustomPosInFile(4, 8)] [Column(TypeName = "varchar(8)")] public string TransSeqNr { get; set; }
        [CustomPosInFile(12, 8)] [Column(TypeName = "varchar(8)")] public string RecSeqNr { get; set; }
        [CustomPosInFile(20, 9)] [Column(TypeName = "varchar(9)")] public string Filler7 { get; set; }
        [CustomPosInFile(29, 9)] [Column(TypeName = "varchar(9)")] public string Filler8 { get; set; }
        [CustomPosInFile(38, 11)] [Column(TypeName = "varchar(11)")] public string WrtIpNameNr { get; set; }
        [CustomPosInFile(49, 11)] [Column(TypeName = "varchar(11)")] public string PubIpNameNr { get; set; }

        public UpdFile UpdFile { get; set; }
    }
}

