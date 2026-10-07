using System.ComponentModel.DataAnnotations.Schema;

namespace IpiUpdatesLib.Entities
{
[Table("DicRis")]
    public class DicRis
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [CustomPosInFile(20, 3)] [Column(TypeName = "varchar(3)")] public string SocCde { get; set; }
        [CustomPosInFile(23, 2)] [Column(TypeName = "varchar(2)")] public string CreClsCde { get; set; }
        [CustomPosInFile(25, 2)] [Column(TypeName = "varchar(2)")] public string RolCde { get; set; }
        [CustomPosInFile(27, 2)] [Column(TypeName = "varchar(2)")] public string RgtCde { get; set; }
    }
}

