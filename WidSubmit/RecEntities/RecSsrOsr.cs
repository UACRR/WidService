using System.ComponentModel.DataAnnotations.Schema;


namespace WidSubmit
{
    [Table("RecSsr")]
    public class RecSsrOsr
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "int")] public int RecSipOipId { get; set; }
        [CustomPosInFile(1, 3, 'A')] [Column(TypeName = "varchar(3)")] public string RecType { get; set; }
        [CustomPosInFile(4, 8, 'N')] [Column(TypeName = "varchar(8)")] public string TransSeqNr { get; set; }
        [CustomPosInFile(12, 8, 'N')] [Column(TypeName = "varchar(8)")] public string RecSeqNr { get; set; }
        [CustomPosInFile(20, 9, ' ')] [Column(TypeName = "varchar(9)")] public string Filler6 { get; set; }
        [CustomPosInFile(29, 3, 'L')] [Column(TypeName = "varchar(3)")] public string RightType { get; set; }
        [CustomPosInFile(32, 5, 'N')] [Column(TypeName = "varchar(5)")] public string Shares { get; set; }
        [CustomPosInFile(37, 11, 'N')] [Column(TypeName = "varchar(11)")] public string IpNameNr { get; set; }
        [CustomPosInFile(48, 3, 'L')] [Column(TypeName = "varchar(3)")] public string Aff { get; set; }
    }
}

