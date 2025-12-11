using System.ComponentModel.DataAnnotations.Schema;

namespace SocIpiDumpLoader.Entities
{
[Table("RecMao")]
    public class RecMao
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "int")] public int UpdFileId { get; set; }
        [Column(TypeName = "varchar(5)")] public string GrId { get; set; }
        [CustomPosInFile(1, 3)] [Column(TypeName = "varchar(3)")] public string RecType { get; set; }
        [CustomPosInFile(4, 8)] [Column(TypeName = "varchar(8)")] public string TransSeqNr { get; set; }
        [CustomPosInFile(12, 8)] [Column(TypeName = "varchar(8)")] public string RecSeqNr { get; set; }
        [CustomPosInFile(20, 3)] [Column(TypeName = "varchar(3)")] public string SocCde { get; set; }
        [CustomPosInFile(23, 2)] [Column(TypeName = "varchar(2)")] public string CreClsCde { get; set; }
        [CustomPosInFile(25, 2)] [Column(TypeName = "varchar(2)")] public string RolCde { get; set; }
        [CustomPosInFile(27, 2)] [Column(TypeName = "varchar(2)")] public string RgtCde { get; set; }
        [CustomPosInFile(29, 8)] [Column(TypeName = "varchar(8)")] public string ValidFromD { get; set; }
        [CustomPosInFile(37, 6)] [Column(TypeName = "varchar(6)")] public string ValidFromT { get; set; }
        [CustomPosInFile(43, 8)] [Column(TypeName = "varchar(8)")] public string ValidToD { get; set; }
        [CustomPosInFile(51, 6)] [Column(TypeName = "varchar(6)")] public string ValidToT { get; set; }
        [CustomPosInFile(57, 8)] [Column(TypeName = "varchar(8)")] public string SignD { get; set; }
        [CustomPosInFile(65, 5)] [Column(TypeName = "varchar(5)")] public string Shr { get; set; }
        [CustomPosInFile(70, 8)] [Column(TypeName = "varchar(8)")] public string AmdD { get; set; }
        [CustomPosInFile(78, 6)] [Column(TypeName = "varchar(6)")] public string AmdT { get; set; }

        public UpdFile UpdFile { get; set; }
    }
}

