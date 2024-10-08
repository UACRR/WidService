using System.ComponentModel.DataAnnotations.Schema;

namespace IpiUpdatesLib.Entities
{
[Table("RecTrs")]
    public class RecTrs
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "int")] public int UpdFileId { get; set; }
        [Column(TypeName = "varchar(5)")] public string GrId { get; set; }
        [CustomPosInFile(1, 3)] [Column(TypeName = "varchar(3)")] public string RecType { get; set; }
        [CustomPosInFile(4, 8)] [Column(TypeName = "varchar(8)")] public string TransSeqNr { get; set; }
        [CustomPosInFile(12, 8)] [Column(TypeName = "varchar(8)")] public string RecSeqNr { get; set; }
        [CustomPosInFile(20, 4)] [Column(TypeName = "varchar(4)")] public string SttCde { get; set; }
        [CustomPosInFile(24, 100)] [Column(TypeName = "varchar(100)")] public string SttMsg { get; set; }
        [CustomPosInFile(124, 8)] [Column(TypeName = "varchar(8)")] public string TransSubmName { get; set; }
        [CustomPosInFile(132, 8)] [Column(TypeName = "varchar(8)")] public string CreDRef { get; set; }
        [CustomPosInFile(140, 6)] [Column(TypeName = "varchar(6)")] public string CreTRef { get; set; }
        [CustomPosInFile(146, 12)] [Column(TypeName = "varchar(12)")] public string FileNameRef { get; set; }
        [CustomPosInFile(158, 5)] [Column(TypeName = "varchar(5)")] public string GrIdRef { get; set; }
        [CustomPosInFile(163, 8)] [Column(TypeName = "varchar(8)")] public string TransSeqNrRef { get; set; }

        public UpdFile UpdFile { get; set; }
    }
}

