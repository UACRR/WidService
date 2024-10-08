using System.ComponentModel.DataAnnotations.Schema;

namespace WidUpdatesLib.Entities
{
    [Table("RecAck")]
    [CustomTargetWidEntity("Submission")]
    [CustomUpdateMethod("U")]
    [CustomIsTran]
    public class RecAck
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "int")] public int UpdFileId { get; set; }
        [CustomPosInFile(1, 3)] [Column(TypeName = "varchar(3)")] public string RecType { get; set; }
        [CustomPosInFile(4, 8)] [Column(TypeName = "varchar(8)")] public string TransSeqNr { get; set; }
        [CustomPosInFile(12, 8)] [Column(TypeName = "varchar(8)")] public string RecSeqNr { get; set; }
        [CustomPosInFile(20, 8)] [Column(TypeName = "varchar(8)")] public string CreDate { get; set; }
        [CustomPosInFile(28, 6)] [Column(TypeName = "varchar(6)")] public string CreTime { get; set; }
        [CustomPosInFile(34, 5)] [Column(TypeName = "varchar(5)")] public string OrigGrpNr { get; set; }
        [CustomPosInFile(39, 8)] [Column(TypeName = "varchar(8)")] public string OrigTransSeqNr { get; set; }
        [CustomPosInFile(47, 3)] [Column(TypeName = "varchar(3)")] public string OrigTransType { get; set; }
        [CustomPosInFile(50, 60)] [Column(TypeName = "varchar(60)")] public string CreTtl { get; set; }
        [CustomPosInFile(110, 20)] [Column(TypeName = "varchar(20)")] public string SubmCreNr { get; set; }
        [CustomPosInFile(130, 20)] [Column(TypeName = "varchar(20)")] public string RcpntCreNr { get; set; }
        [CustomPosInFile(150, 8)] [Column(TypeName = "varchar(8)")] public string ProcDate { get; set; }
        [CustomPosInFile(158, 2)] [Column(TypeName = "varchar(2)")] public string TransStt { get; set; }

        public UpdFile UpdFile { get; set; }
    }
}

