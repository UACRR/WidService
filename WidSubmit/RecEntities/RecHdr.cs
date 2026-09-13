using System.ComponentModel.DataAnnotations.Schema;

namespace WidSubmit
{
    [Table("RecHdr")]
    public class RecHdr
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "int")] public int SubmissionId { get; set; }
        [CustomPosInFile(1, 3, 'A')] [Column(TypeName = "varchar(3)")] public string RecType { get; set; }
        [CustomPosInFile(4, 2, 'A')] [Column(TypeName = "varchar(2)")] public string SenderType { get; set; }
        [CustomPosInFile(6, 9, 'N')] [Column(TypeName = "varchar(9)")] public string SenderId { get; set; }
        [CustomPosInFile(15, 45, 'A')] [Column(TypeName = "varchar(45)")] public string SenderName { get; set; }
        [CustomPosInFile(60, 5, 'A')] [Column(TypeName = "varchar(5)")] public string StdVerNr { get; set; }
        [CustomPosInFile(65, 8, 'D')] [Column(TypeName = "varchar(8)")] public string CreD { get; set; }
        [CustomPosInFile(73, 6, 'T')] [Column(TypeName = "varchar(6)")] public string CreT { get; set; }
        [CustomPosInFile(79, 8, 'D')] [Column(TypeName = "varchar(8)")] public string TransmitD { get; set; }
        [CustomPosInFile(87, 15, 'A')] [Column(TypeName = "varchar(15)")] public string Filler { get; set; }
        [CustomPosInFile(102, 29, 'A')] [Column(TypeName = "varchar(29)")] public string FileNameRef { get; set; }
    }
}
