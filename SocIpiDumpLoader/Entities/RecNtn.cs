using System.ComponentModel.DataAnnotations.Schema;

namespace SocIpiDumpLoader.Entities
{
[Table("RecNtn")]
    public class RecNtn
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "int")] public int UpdFileId { get; set; }
        [Column(TypeName = "varchar(5)")] public string GrId { get; set; }
        [CustomPosInFile(1, 3)] [Column(TypeName = "varchar(3)")] public string RecType { get; set; }
        [CustomPosInFile(4, 8)] [Column(TypeName = "varchar(8)")] public string TransSeqNr { get; set; }
        [CustomPosInFile(12, 8)] [Column(TypeName = "varchar(8)")] public string RecSeqNr { get; set; }
        [CustomPosInFile(20, 4)] [Column(TypeName = "varchar(4)")] public string TisNr { get; set; }
        [CustomPosInFile(24, 8)] [Column(TypeName = "varchar(8)")] public string TisNrValidFrom { get; set; }
        [CustomPosInFile(32, 20)] [Column(TypeName = "varchar(20)")] public string Tisan { get; set; }
        [CustomPosInFile(52, 8)] [Column(TypeName = "varchar(8)")] public string TisanValidFrom { get; set; }
        [CustomPosInFile(60, 8)] [Column(TypeName = "varchar(8)")] public string ValidFromD { get; set; }
        [CustomPosInFile(68, 8)] [Column(TypeName = "varchar(8)")] public string ValidToD { get; set; }

        public UpdFile UpdFile { get; set; }
    }
}

