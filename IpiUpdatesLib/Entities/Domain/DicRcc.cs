using System.ComponentModel.DataAnnotations.Schema;

namespace IpiUpdatesLib.Entities
{
[Table("DicRcc")]
    public class DicRcc
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [CustomPosInFile(20, 2)] [Column(TypeName = "varchar(2)")] public string CreClsCde { get; set; }
        [CustomPosInFile(22, 2)] [Column(TypeName = "varchar(2)")] public string RolCde { get; set; }
    }
}

