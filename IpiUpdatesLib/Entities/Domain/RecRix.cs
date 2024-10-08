using System.ComponentModel.DataAnnotations.Schema;

namespace IpiUpdatesLib.Entities
{
[Table("DicRix")]
    public class RecRix
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "int")] public int UpdFileId { get; set; }
        [Column(TypeName = "varchar(5)")] public string GrId { get; set; }
        [CustomPosInFile(20, 3)] [Column(TypeName = "varchar(3)")] public string SocCde { get; set; }
        [CustomPosInFile(23, 2)] [Column(TypeName = "varchar(2)")] public string CreClsCde { get; set; }
        [CustomPosInFile(25, 2)] [Column(TypeName = "varchar(2)")] public string RolCde { get; set; }
        [CustomPosInFile(27, 2)] [Column(TypeName = "varchar(2)")] public string RgtCde { get; set; }
        [CustomPosInFile(29, 8)] [Column(TypeName = "varchar(8)")] public string FromD { get; set; }
        [CustomPosInFile(36, 8)] [Column(TypeName = "varchar(8)")] public string ToD { get; set; }

        public UpdFile UpdFile { get; set; }
    }
}

