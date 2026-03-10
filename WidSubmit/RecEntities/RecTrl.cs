using System.ComponentModel.DataAnnotations.Schema;

namespace WidSubmit
{
    [Table("RecTrl")]
    public class RecTrl
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "int")] public int RecHdrId { get; set; }
        [CustomPosInFile(1, 3, 'A')] [Column(TypeName = "varchar(3)")] public string RecType { get; set; }
        [CustomPosInFile(4, 5, 'N')] [Column(TypeName = "varchar(5)")] public string GrCnt { get; set; }
        [CustomPosInFile(9, 8, 'N')] [Column(TypeName = "varchar(8)")] public string TransCnt { get; set; }
        [CustomPosInFile(17, 8, 'N')] [Column(TypeName = "varchar(8)")] public string RecCnt { get; set; }
    }
}

