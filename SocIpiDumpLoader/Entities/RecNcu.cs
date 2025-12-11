using System.ComponentModel.DataAnnotations.Schema;

namespace SocIpiDumpLoader.Entities
{
[Table("RecNcu")]
    public class RecNcu
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
        [CustomPosInFile(57, 13)] [Column(TypeName = "varchar(13)")] public string IpBaseNrOld { get; set; }
        [CustomPosInFile(70, 1)] [Column(TypeName = "varchar(1)")] public string SttCdeOld { get; set; }
        [CustomPosInFile(71, 11)] [Column(TypeName = "varchar(11)")] public string IpNameNrOld { get; set; }
        [CustomPosInFile(82, 2)] [Column(TypeName = "varchar(2)")] public string NameTypeOld { get; set; }
        [CustomPosInFile(84, 13)] [Column(TypeName = "varchar(13)")] public string IpBaseNrRefOld { get; set; }
        [CustomPosInFile(97, 1)] [Column(TypeName = "varchar(1)")] public string SttCdeRefOld { get; set; }
        [CustomPosInFile(98, 11)] [Column(TypeName = "varchar(11)")] public string IpNameNrRefOld { get; set; }
        [CustomPosInFile(109, 2)] [Column(TypeName = "varchar(2)")] public string NameTypeRefOld { get; set; }
        [CustomPosInFile(111, 13)] [Column(TypeName = "varchar(13)")] public string IpBaseNrNew { get; set; }
        [CustomPosInFile(124, 1)] [Column(TypeName = "varchar(1)")] public string SttCdeNew { get; set; }
        [CustomPosInFile(125, 11)] [Column(TypeName = "varchar(11)")] public string IpNameNrNew { get; set; }
        [CustomPosInFile(136, 2)] [Column(TypeName = "varchar(2)")] public string NameTypeNew { get; set; }
        [CustomPosInFile(138, 13)] [Column(TypeName = "varchar(13)")] public string IpBaseNrRefNew { get; set; }
        [CustomPosInFile(151, 1)] [Column(TypeName = "varchar(1)")] public string SttCdeRefNew { get; set; }
        [CustomPosInFile(152, 11)] [Column(TypeName = "varchar(11)")] public string IpNameNrRefNew { get; set; }
        [CustomPosInFile(163, 2)] [Column(TypeName = "varchar(2)")] public string NameTypeRefNew { get; set; }

        public UpdFile UpdFile { get; set; }
    }
}

