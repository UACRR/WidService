using System.ComponentModel.DataAnnotations.Schema;

namespace SocIpiDumpLoader.Entities
{
[Table("DicSoc")]
    public class RecSoc
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "int")] public int UpdFileId { get; set; }
        [Column(TypeName = "varchar(5)")] public string GrId { get; set; }
        [CustomPosInFile(20, 3)] [Column(TypeName = "varchar(3)")] public string Cde { get; set; }
        [CustomPosInFile(23, 20)] [Column(TypeName = "varchar(20)")] public string Name { get; set; }
        [CustomPosInFile(53, 20)] [Column(TypeName = "varchar(20)")] public string Country { get; set; }

        public UpdFile UpdFile { get; set; }
    }
}

