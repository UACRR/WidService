using System.ComponentModel.DataAnnotations.Schema;


namespace WidSubmit
{
    [Table("RecAck")]
    public class RecAck
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "int")] public int RecWiaWiuId { get; set; }
        [CustomPosInFile(1, 3, 'A')] [Column(TypeName = "varchar(3)")] public string     RecType            { get; set; }
        [CustomPosInFile(4, 8, 'N')]  [Column(TypeName = "varchar(8)")] public string     TransSeqNr        { get; set; }
        [CustomPosInFile(12, 8, 'N')] [Column(TypeName = "varchar(8)")] public string    RecSeqNr           { get; set; }
        [CustomPosInFile(20, 8, 'D')]   [Column(TypeName = "varchar(8)" )] public string CreDRef            { get; set; }
        [CustomPosInFile(28, 6, 'T')]   [Column(TypeName = "varchar(6)" )] public string CreTRef            { get; set; }
        [CustomPosInFile(34, 5, 'N')]   [Column(TypeName = "varchar(5)" )] public string GrpSeqNrRef        { get; set; } 
        [CustomPosInFile(39, 8, 'N')]   [Column(TypeName = "varchar(8)" )] public string TransSeqNrRef      { get; set; }
        [CustomPosInFile(47, 3, 'L')]   [Column(TypeName = "varchar(3)" )] public string TransTypeRef       { get; set; }
        [CustomPosInFile(50, 60, 'A')]  [Column(TypeName = "varchar(60)")] public string WrkTtlRef          { get; set; }
        [CustomPosInFile(110, 20, 'A')] [Column(TypeName = "varchar(20)")] public string SubmWrkNrRef       { get; set; }
        [CustomPosInFile(130, 20, 'A')] [Column(TypeName = "varchar(20)")] public string Iswc               { get; set; }
        [CustomPosInFile(150, 8, 'D')]  [Column(TypeName = "varchar(8)" )] public string PrcsD              { get; set; }
        [CustomPosInFile(158, 2, 'L')]  [Column(TypeName = "varchar(2)" )] public string Status             { get; set; }
    }
}

