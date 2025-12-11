using System.ComponentModel.DataAnnotations.Schema;

namespace SocIpiDumpLoader.Entities
{
[Table("RecBdo")]
    public class RecBdo
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "int")] public int UpdFileId { get; set; }
        [Column(TypeName = "varchar(5)")] public string GrId { get; set; }
        [CustomPosInFile(1, 3)] [Column(TypeName = "varchar(3)")] public string RecType { get; set; }
        [CustomPosInFile(4, 8)] [Column(TypeName = "varchar(8)")] public string TransSeqNr { get; set; }
        [CustomPosInFile(12, 8)] [Column(TypeName = "varchar(8)")] public string RecSeqNr { get; set; }
        [CustomPosInFile(20, 1)] [Column(TypeName = "varchar(1)")] public string IpType { get; set; }
        [CustomPosInFile(21, 8)] [Column(TypeName = "varchar(8)")] public string BirthD { get; set; }
        [CustomPosInFile(29, 8)] [Column(TypeName = "varchar(8)")] public string DeathD { get; set; }
        [CustomPosInFile(37, 30)] [Column(TypeName = "varchar(30)")] public string BirthPlace { get; set; }
        [CustomPosInFile(67, 30)] [Column(TypeName = "varchar(30)")] public string BirthState { get; set; }
        [CustomPosInFile(97, 4)] [Column(TypeName = "varchar(4)")] public string BirthTisNr { get; set; }
        [CustomPosInFile(101, 8)] [Column(TypeName = "varchar(8)")] public string TisNrValidFrom { get; set; }
        [CustomPosInFile(109, 20)] [Column(TypeName = "varchar(20)")] public string BirthTisan { get; set; }
        [CustomPosInFile(129, 8)] [Column(TypeName = "varchar(8)")] public string TisanValidFrom { get; set; }
        [CustomPosInFile(137, 1)] [Column(TypeName = "varchar(1)")] public string Sex { get; set; }
        [CustomPosInFile(138, 8)] [Column(TypeName = "varchar(8)")] public string AmdD { get; set; }
        [CustomPosInFile(146, 6)] [Column(TypeName = "varchar(6)")] public string AmdT { get; set; }

        public UpdFile UpdFile { get; set; }
    }
}

