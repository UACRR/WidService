using System.ComponentModel.DataAnnotations.Schema;

namespace IpiUpdatesLib.Entities
{
[Table("DicIsc")]
    public class DicIsc
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "int")] public int UpdFileId { get; set; }
        [Column(TypeName = "varchar(5)")] public string GrId { get; set; }
        [CustomPosInFile(20, 1)] [Column(TypeName = "varchar(1)")] public string Cde { get; set; }
        [CustomPosInFile(21, 60)] [Column(TypeName = "varchar(60)")] public string Dsc { get; set; }
        [CustomPosInFile(81, 2)] [Column(TypeName = "varchar(2)")] public string LngCde { get; set; }

        public UpdFile UpdFile { get; set; }
    }
}

