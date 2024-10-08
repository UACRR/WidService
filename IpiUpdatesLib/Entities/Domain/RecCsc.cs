using System.ComponentModel.DataAnnotations.Schema;

namespace IpiUpdatesLib.Entities
{
[Table("DicCsc")]
    public class RecCsc
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "int")] public int UpdFileId { get; set; }
        [Column(TypeName = "varchar(5)")] public string GrId { get; set; }
        [CustomPosInFile(20, 2)] [Column(TypeName = "varchar(2)")] public string CreClsCde { get; set; }
        [CustomPosInFile(22, 2)] [Column(TypeName = "varchar(2)")] public string CreSubClsCde { get; set; }

        public UpdFile UpdFile { get; set; }
    }
}

