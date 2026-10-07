using System.ComponentModel.DataAnnotations.Schema;

namespace IpiUpdatesLib.Entities
{
[Table("DicTnr")]
    public class DicTnr
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [CustomPosInFile(20, 4)] [Column(TypeName = "varchar(4)")] public string TisNr { get; set; }
        [CustomPosInFile(24, 8)] [Column(TypeName = "varchar(8)")] public string TisNrFromD { get; set; }
        [CustomPosInFile(32, 8)] [Column(TypeName = "varchar(8)")] public string TisNrToD { get; set; }
        [CustomPosInFile(40, 20)] [Column(TypeName = "varchar(20)")] public string Tisan { get; set; }
        [CustomPosInFile(60, 8)] [Column(TypeName = "varchar(8)")] public string TisanFromD { get; set; }
        [CustomPosInFile(68, 8)] [Column(TypeName = "varchar(8)")] public string TisanToD { get; set; }
        [CustomPosInFile(76, 6)] [Column(TypeName = "varchar(6)")] public string Tisa { get; set; }
        [CustomPosInFile(82, 2)] [Column(TypeName = "varchar(2)")] public string LngCde { get; set; }
    }
}

