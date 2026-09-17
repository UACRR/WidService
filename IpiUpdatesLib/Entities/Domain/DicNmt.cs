using System.ComponentModel.DataAnnotations.Schema;

namespace IpiUpdatesLib.Entities
{
[Table("DicNmt")]
    public class DicNmt
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "int")] public int UpdFileId { get; set; }
        [Column(TypeName = "varchar(5)")] public string GrId { get; set; }
        [CustomPosInFile(20, 2)] [Column(TypeName = "varchar(2)")] public string Cde { get; set; }
        [CustomPosInFile(22, 60)] [Column(TypeName = "varchar(60)")] public string Dsc { get; set; }
        [CustomPosInFile(62, 2)] [Column(TypeName = "varchar(2)")] public string LngCde { get; set; }

        public UpdFile UpdFile { get; set; }
    }
}

