using System.ComponentModel.DataAnnotations.Schema;

namespace SocIpiDumpLoader.Entities
{
    [Table("RecMaa")]
    public class RecMaa
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "int")] public int UpdFileId { get; set; }
        [Column(TypeName = "varchar(5)")] public string GrId { get; set; }
        [CustomPosInFile(1, 3)] [Column(TypeName = "varchar(3)")] public string RecType { get; set; }
        [CustomPosInFile(4, 8)] [Column(TypeName = "varchar(8)")] public string TransSeqNr { get; set; }
        [CustomPosInFile(12, 8)] [Column(TypeName = "varchar(8)")] public string RecSeqNr { get; set; }
        [CustomPosInFile(20, 8)] [Column(TypeName = "varchar(8)")] public string TransD { get; set; }
        [CustomPosInFile(28, 6)] [Column(TypeName = "varchar(6)")] public string TransT { get; set; }
        [CustomPosInFile(34, 3)] [Column(TypeName = "varchar(3)")] public string RemitSocCde { get; set; }
        [CustomPosInFile(37, 20)] [Column(TypeName = "varchar(20)")] public string RemitSocName { get; set; }
        [CustomPosInFile(57, 13)] [Column(TypeName = "varchar(13)")] public string IpBaseNr { get; set; }
        [CustomPosInFile(70, 1)] [Column(TypeName = "varchar(1)")] public string SttCde { get; set; }
        [CustomPosInFile(71, 11)] [Column(TypeName = "varchar(11)")] public string IpNameNr { get; set; }
        [CustomPosInFile(82, 2)] [Column(TypeName = "varchar(2)")] public string NameType { get; set; }
        [CustomPosInFile(84, 13)] [Column(TypeName = "varchar(13)")] public string IpBaseNrRef { get; set; }
        [CustomPosInFile(97, 1)] [Column(TypeName = "varchar(1)")] public string SttCdeRef { get; set; }
        [CustomPosInFile(98, 11)] [Column(TypeName = "varchar(11)")] public string IpNameNrRef { get; set; }
        [CustomPosInFile(109, 2)] [Column(TypeName = "varchar(2)")] public string NameTypeRef { get; set; }

        public UpdFile UpdFile { get; set; }
    }
}

