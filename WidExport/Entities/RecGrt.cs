using System.ComponentModel.DataAnnotations.Schema;

namespace WidExport.Entities
{
    [Table("RecGrt")]
    public class RecGrt
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "int")] public int SubmFileId { get; set; }
        [CustomPosInFile(1, 3, 'A')] [Column(TypeName = "varchar(3)")] public string RecType { get; set; }
        [CustomPosInFile(4, 5, 'N')] [Column(TypeName = "varchar(5)")] public string GrId { get; set; }
        [CustomPosInFile(9, 8, 'N')] [Column(TypeName = "varchar(8)")] public string TransCnt { get; set; }
        [CustomPosInFile(17, 8, 'N')] [Column(TypeName = "varchar(8)")] public string RecCnt { get; set; }
    }
}

