using System.ComponentModel.DataAnnotations.Schema;

namespace IpiUpdatesLib.Entities
{
[Table("DicSop")]
    public class DicSop
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [CustomPosInFile(20, 3)] [Column(TypeName = "varchar(3)")] public string SocCde { get; set; }
        [CustomPosInFile(23, 3)] [Column(TypeName = "varchar(3)")] public string PartnerSocCde { get; set; }
    }
}

