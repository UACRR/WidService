using System.ComponentModel.DataAnnotations.Schema;


namespace WidUpdatesLib.Entities
{
    [Table("RecDel")]
    [CustomIsTran]
    [CustomTargetWidEntity("Title")]
    [CustomUpdateMethod("C")]
    public class RecDel
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "int")] public int UpdFileId { get; set; }
        [CustomPosInFile(1, 3)] [Column(TypeName = "varchar(3)")] public string RecType { get; set; }
        [CustomPosInFile(4, 8)] [Column(TypeName = "varchar(8)")] public string TransSeqNr { get; set; }
        [CustomPosInFile(12, 8)] [Column(TypeName = "varchar(8)")] public string RecSeqNr { get; set; }
        [CustomPosInFile(20, 14)] [Column(TypeName = "varchar(14)")] public string SubmWrkNr { get; set; }
        [CustomPosInFile(34, 11)] [Column(TypeName = "varchar(11)")] public string Iswc { get; set; }
        [CustomPosInFile(45, 10)] [Column(TypeName = "varchar(10)")] public string WicCode { get; set; }
        [CustomPosInFile(55, 3)] [Column(TypeName = "varchar(3)")] public string RightType { get; set; }

        public UpdFile UpdFile { get; set; }
    }
}

