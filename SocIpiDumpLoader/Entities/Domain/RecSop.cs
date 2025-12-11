using System.ComponentModel.DataAnnotations.Schema;

namespace SocIpiDumpLoader.Entities
{
[Table("DicSop")]
    public class RecSop
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "int")] public int UpdFileId { get; set; }
        [Column(TypeName = "varchar(5)")] public string GrId { get; set; }
        [CustomPosInFile(20, 3)] [Column(TypeName = "varchar(3)")] public string SocCde { get; set; }
        [CustomPosInFile(23, 3)] [Column(TypeName = "varchar(3)")] public string PartnerSocCde { get; set; }

        public UpdFile UpdFile { get; set; }
    }
}

