using System.ComponentModel.DataAnnotations.Schema;

namespace IpiUpdatesLib.Entities
{
[Table("RecMcn")]
    public class RecMcn
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "int")] public int UpdFileId { get; set; }
        [Column(TypeName = "varchar(5)")] public string GrId { get; set; }
        [CustomPosInFile(1, 3)] [Column(TypeName = "varchar(3)")] public string RecType { get; set; }
        [CustomPosInFile(4, 8)] [Column(TypeName = "varchar(8)")] public string TransSeqNr { get; set; }
        [CustomPosInFile(12, 8)] [Column(TypeName = "varchar(8)")] public string RecSeqNr { get; set; }
        [CustomPosInFile(20, 11)] [Column(TypeName = "varchar(11)")] public string IpNameNr { get; set; }
        [CustomPosInFile(31, 90)] [Column(TypeName = "varchar(90)")] public string Name { get; set; }
        [CustomPosInFile(121, 2)] [Column(TypeName = "varchar(2)")] public string NameType { get; set; }
        [CustomPosInFile(123, 8)] [Column(TypeName = "varchar(8)")] public string CreD { get; set; }
        [CustomPosInFile(131, 6)] [Column(TypeName = "varchar(6)")] public string CreT { get; set; }
        [CustomPosInFile(137, 8)] [Column(TypeName = "varchar(8)")] public string AmdD { get; set; }
        [CustomPosInFile(145, 6)] [Column(TypeName = "varchar(6)")] public string AmdT { get; set; }
        [CustomPosInFile(151, 13)] [Column(TypeName = "varchar(13)")] public string IpBaseNr { get; set; }

        public UpdFile UpdFile { get; set; }
    }
}

