using System.ComponentModel.DataAnnotations.Schema;


namespace WidUpdatesLib.Entities
{
    [Table("RecMsg")]
    [CustomUpdateMethod("C")]
    public class RecMsg
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "int")] public int UpdFileId { get; set; }
        [CustomPosInFile(1, 3)] [Column(TypeName = "varchar(3)")] public string RecType { get; set; }
        [CustomPosInFile(4, 8)] [Column(TypeName = "varchar(8)")] public string TransSeqNr { get; set; }
        [CustomPosInFile(12, 8)] [Column(TypeName = "varchar(8)")] public string RecSeqNr { get; set; }
        [CustomPosInFile(20, 1)] [Column(TypeName = "varchar(1)")] public string MsgType { get; set; }
        [CustomPosInFile(21, 8)] [Column(TypeName = "varchar(8)")] public string OrigRecSeq { get; set; }
        [CustomPosInFile(29, 3)] [Column(TypeName = "varchar(3)")] public string OrigRecType { get; set; }
        [CustomPosInFile(32, 1)] [Column(TypeName = "varchar(1)")] public string MsgLevel { get; set; }
        [CustomPosInFile(33, 3)] [Column(TypeName = "varchar(3)")] public string CndNr { get; set; }
        [CustomPosInFile(36, 150)] [Column(TypeName = "varchar(150)")] public string MsgTxt { get; set; }

        public UpdFile UpdFile { get; set; }
    }
}

