using System.ComponentModel.DataAnnotations.Schema;


namespace WidUpdatesLib.Entities
{
    [Table("RecEwt")]
    [CustomTargetWidEntity("OrgTtlVrExrp")]
    [CustomUpdateMethod("IU")]
    [CustomVrExrpIndE]
    public class RecEwt
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "int")] public int UpdFileId { get; set; }
        [CustomPosInFile(1, 3)] [Column(TypeName = "varchar(3)")] public string RecType { get; set; }
        [CustomPosInFile(4, 8)] [Column(TypeName = "varchar(8)")] public string TransSeqNr { get; set; }
        [CustomPosInFile(12, 8)] [Column(TypeName = "varchar(8)")] public string RecSeqNr { get; set; }
        [CustomPosInFile(20, 60)] [Column(TypeName = "varchar(60)")] public string EntireWrkTtl { get; set; }
        [CustomPosInFile(80, 11)] [Column(TypeName = "varchar(11)")] public string IswcWrk { get; set; }
        [CustomPosInFile(91, 2)] [Column(TypeName = "varchar(2)")] public string LngCode { get; set; }
        [CustomPosInFile(93, 45)] [Column(TypeName = "varchar(45)")] public string WrtLstName { get; set; }
        [CustomPosInFile(138, 30)] [Column(TypeName = "varchar(30)")] public string WrtFstName { get; set; }
        [CustomPosInFile(168, 60)] [Column(TypeName = "varchar(60)")] public string Src { get; set; }
        [CustomPosInFile(228, 10)] [Column(TypeName = "varchar(10)")] public string WicCode { get; set; }

        public UpdFile UpdFile { get; set; }
    }
}

