using System.ComponentModel.DataAnnotations.Schema;

namespace WidExport.Entities
{
    [Table("RecGrh")]
    public class RecGrh
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "int")] public int SubmFileId { get; set; }
        [CustomPosInFile(1, 3, 'A')] [Column(TypeName = "varchar(3)")] public string RecType { get; set; }
        [CustomPosInFile(4, 3, 'A')] [Column(TypeName = "varchar(3)")] public string TransType { get; set; }
        [CustomPosInFile(7, 5, 'N')] [Column(TypeName = "varchar(5)")] public string GrId { get; set; }
        [CustomPosInFile(12, 5, 'A')] [Column(TypeName = "varchar(5)")] public string VerNr { get; set; }
    }
}

