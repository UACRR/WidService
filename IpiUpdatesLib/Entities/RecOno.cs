using System.ComponentModel.DataAnnotations.Schema;

namespace IpiUpdatesLib.Entities
{
[Table("RecOno")]
    public class RecOno
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "int")] public int UpdFileId { get; set; }
        [Column(TypeName = "varchar(5)")] public string GrId { get; set; }
        [CustomPosInFile(1, 3)] [Column(TypeName = "varchar(3)")] public string RecType { get; set; }
        [CustomPosInFile(4, 8)] [Column(TypeName = "varchar(8)")] public string TransSeqNr { get; set; }
        [CustomPosInFile(12, 8)] [Column(TypeName = "varchar(8)")] public string RecSeqNr { get; set; }
        [CustomPosInFile(20, 11)] [Column(TypeName = "varchar(11)")] public string IpNameNr { get; set; }
        [CustomPosInFile(31, 90)] [Column(TypeName = "varchar(90)")] public string Name { get; set; }
        [CustomPosInFile(121, 45)] [Column(TypeName = "varchar(45)")] public string FstName { get; set; }
        [CustomPosInFile(166, 2)] [Column(TypeName = "varchar(2)")] public string NameType { get; set; }
        [CustomPosInFile(168, 8)] [Column(TypeName = "varchar(8)")] public string CreD { get; set; }
        [CustomPosInFile(176, 6)] [Column(TypeName = "varchar(6)")] public string CreT { get; set; }
        [CustomPosInFile(182, 8)] [Column(TypeName = "varchar(8)")] public string AmdD { get; set; }
        [CustomPosInFile(190, 6)] [Column(TypeName = "varchar(6)")] public string AmdT { get; set; }
        [CustomPosInFile(196, 11)] [Column(TypeName = "varchar(11)")] public string IpNameNrRef { get; set; }

        public UpdFile UpdFile { get; set; }
    }
}

