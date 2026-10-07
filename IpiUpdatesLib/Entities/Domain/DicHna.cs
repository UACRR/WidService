using System.ComponentModel.DataAnnotations.Schema;

namespace IpiUpdatesLib.Entities
{
[Table("DicHna")]
    public class DicHna
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [CustomPosInFile(20, 4)] [Column(TypeName = "varchar(4)")] public string TisNrPa { get; set; }
        [CustomPosInFile(24, 8)] [Column(TypeName = "varchar(8)")] public string TisNrPaFromD { get; set; }
        [CustomPosInFile(32, 8)] [Column(TypeName = "varchar(8)")] public string TisNrPaToD { get; set; }
        [CustomPosInFile(40, 20)] [Column(TypeName = "varchar(20)")] public string TisanPa { get; set; }
        [CustomPosInFile(60, 8)] [Column(TypeName = "varchar(8)")] public string TisanPaFromD { get; set; }
        [CustomPosInFile(68, 8)] [Column(TypeName = "varchar(8)")] public string TisanPaToD { get; set; }
        [CustomPosInFile(76, 6)] [Column(TypeName = "varchar(6)")] public string TisaPa { get; set; }
        [CustomPosInFile(82, 4)] [Column(TypeName = "varchar(4)")] public string TisNrCh { get; set; }
        [CustomPosInFile(86, 8)] [Column(TypeName = "varchar(8)")] public string TisNrChFromD { get; set; }
        [CustomPosInFile(94, 8)] [Column(TypeName = "varchar(8)")] public string TisNrChToD { get; set; }
        [CustomPosInFile(102, 20)] [Column(TypeName = "varchar(20)")] public string TisanCh { get; set; }
        [CustomPosInFile(122, 8)] [Column(TypeName = "varchar(8)")] public string TisanChFromD { get; set; }
        [CustomPosInFile(130, 8)] [Column(TypeName = "varchar(8)")] public string TisanChToD { get; set; }
        [CustomPosInFile(138, 6)] [Column(TypeName = "varchar(6)")] public string TisaCh { get; set; }
        [CustomPosInFile(144, 8)] [Column(TypeName = "varchar(8)")] public string FromD { get; set; }
        [CustomPosInFile(152, 8)] [Column(TypeName = "varchar(8)")] public string ToD { get; set; }
        [CustomPosInFile(160, 2)] [Column(TypeName = "varchar(2)")] public string LngCde { get; set; }
    }
}

