using System.ComponentModel.DataAnnotations.Schema;


namespace WidSubmit
{
    [Table("RecMsg")]
    public class RecMsg
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "int")] public int SubmissionId { get; set; }
        [CustomPosInFile(1, 3, 'A')] [Column(TypeName = "varchar(3)")] public string        RecType             { get; set; }
        [CustomPosInFile(4, 8, 'N')] [Column(TypeName = "varchar(8)")] public string        TransSeqNr          { get; set; }
        [CustomPosInFile(12, 8, 'N')] [Column(TypeName = "varchar(8)")] public string       RecSeqNr            { get; set; }
        [CustomPosInFile(20, 1, 'L')] [Column(TypeName = "varchar(1)")] public string       MsgType             { get; set; }
        [CustomPosInFile(21, 8, 'N')] [Column(TypeName = "varchar(8)")] public string       RecSeqNrRef         { get; set; }
        [CustomPosInFile(29, 3, 'A')] [Column(TypeName = "varchar(3)")] public string       RecTypeRef          { get; set; }
        [CustomPosInFile(32, 1, 'L')] [Column(TypeName = "varchar(1)")] public string       MsgLevel            { get; set; }
        [CustomPosInFile(33, 3, 'A')] [Column(TypeName = "varchar(3)")] public string       ErrCondNr           { get; set; }
        [CustomPosInFile(36, 150, 'A')] [Column(TypeName = "varchar(150)")] public string   MsgTxt              { get; set; }

    }
}

