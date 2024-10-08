using System.ComponentModel.DataAnnotations.Schema;


namespace WidUpdatesLib.Entities
{
    [Table("RecCon")]
    [CustomIsTran]
    [CustomTargetWidEntity("Conflict")]
    [CustomUpdateMethod("I")]
    [CustomFileTimeCol("CflDt")]
    public class RecCon
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "int")] public int UpdFileId { get; set; }
        [CustomPosInFile(1, 3)] [Column(TypeName = "varchar(3)")] public string RecType { get; set; }
        [CustomPosInFile(4, 8)] [Column(TypeName = "varchar(8)")] public string TransSeqNr { get; set; }
        [CustomPosInFile(12, 8)] [Column(TypeName = "varchar(8)")] public string RecSeqNr { get; set; }
        [CustomPosInFile(20, 11)] [Column(TypeName = "varchar(11)")] public string Iswc { get; set; }
        [CustomPosInFile(31, 10)] [Column(TypeName = "varchar(10)")] public string WicCode { get; set; }
        [CustomPosInFile(41, 3)] [Column(TypeName = "varchar(3)")] public string CflReasonCode { get; set; }
        [CustomPosInFile(44, 3)] [Column(TypeName = "varchar(3)")] public string RightType { get; set; }
        [CustomPosInFile(47, 60)] [Column(TypeName = "varchar(60)")] public string WrkTtl { get; set; }
        [CustomPosInFile(107, 60)] [Column(TypeName = "varchar(60)")] public string CflNote { get; set; }
        [CustomPosInFile(167, 30)] [Column(TypeName = "varchar(30)")] public string CntrName { get; set; }
        [CustomPosInFile(197, 10)] [Column(TypeName = "varchar(10)")] public string CntrId { get; set; }
        [CustomPosInFile(207, 3)] [Column(TypeName = "varchar(3)")] public string SocCode { get; set; }

        public UpdFile UpdFile { get; set; }
    }
}

