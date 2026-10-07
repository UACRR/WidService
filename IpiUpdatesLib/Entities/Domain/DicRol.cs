using System.ComponentModel.DataAnnotations.Schema;

namespace IpiUpdatesLib.Entities
{
[Table("DicRol")]
    public class DicRol
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [CustomPosInFile(20, 2)] [Column(TypeName = "varchar(2)")] public string Cde { get; set; }
        [CustomPosInFile(22, 60)] [Column(TypeName = "varchar(60)")] public string Dsc { get; set; }
        [CustomPosInFile(82, 2)] [Column(TypeName = "varchar(2)")] public string LngCde { get; set; }
    }
}

