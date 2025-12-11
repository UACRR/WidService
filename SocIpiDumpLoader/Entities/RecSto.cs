using System.ComponentModel.DataAnnotations.Schema;

namespace SocIpiDumpLoader.Entities
{
[Table("RecStn")]
    public class RecStn
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "int")] public int UpdFileId { get; set; }
        [Column(TypeName = "varchar(5)")] public string GrId { get; set; }
        [CustomPosInFile(1, 3)] [Column(TypeName = "varchar(3)")] public string RecType { get; set; }
        [CustomPosInFile(4, 8)] [Column(TypeName = "varchar(8)")] public string TransSeqNr { get; set; }
        [CustomPosInFile(12, 8)] [Column(TypeName = "varchar(8)")] public string RecSeqNr { get; set; }
        [CustomPosInFile(20, 13)] [Column(TypeName = "varchar(13)")] public string IpBaseNrRef { get; set; }
        [CustomPosInFile(33, 1)] [Column(TypeName = "varchar(1)")] public string SttCde { get; set; }
        [CustomPosInFile(34, 8)] [Column(TypeName = "varchar(8)")] public string ValidFromD { get; set; }
        [CustomPosInFile(42, 6)] [Column(TypeName = "varchar(6)")] public string ValidFromT { get; set; }
        [CustomPosInFile(48, 8)] [Column(TypeName = "varchar(8)")] public string ValidToD { get; set; }
        [CustomPosInFile(56, 6)] [Column(TypeName = "varchar(6)")] public string ValidToT { get; set; }
        [CustomPosInFile(62, 8)] [Column(TypeName = "varchar(8)")] public string AmdD { get; set; }
        [CustomPosInFile(70, 6)] [Column(TypeName = "varchar(6)")] public string AmdT { get; set; }

        public UpdFile UpdFile { get; set; }
    }
}

