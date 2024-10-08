using System.ComponentModel.DataAnnotations.Schema;


namespace WidUpdatesLib.Entities
{
    [Table("RecCom")]
    [CustomTargetWidEntity("Component")]
    [CustomUpdateMethod("R")]
    public class RecCom
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "int")] public int UpdFileId { get; set; }
        [CustomPosInFile(1, 3)] [Column(TypeName = "varchar(3)")] public string RecType { get; set; }
        [CustomPosInFile(4, 8)] [Column(TypeName = "varchar(8)")] public string TransSeqNr { get; set; }
        [CustomPosInFile(12, 8)] [Column(TypeName = "varchar(8)")] public string RecSeqNr { get; set; }
        [CustomForMatch][CustomPosInFile(20, 60)] [Column(TypeName = "varchar(60)")] public string Ttl { get; set; }
        [CustomPosInFile(80, 11)] [Column(TypeName = "varchar(11)")] public string IswcComp { get; set; }
        [CustomPosInFile(91, 14)] [Column(TypeName = "varchar(14)")] public string SubmWrkNr { get; set; }
        [CustomPosInFile(105, 6)] [Column(TypeName = "varchar(6)")] public string Dur { get; set; }
        [CustomPosInFile(111, 45)] [Column(TypeName = "varchar(45)")] public string WrtLstName1 { get; set; }
        [CustomPosInFile(156, 30)] [Column(TypeName = "varchar(30)")] public string WrtFstName1 { get; set; }
        [CustomPosInFile(186, 9)] [Column(TypeName = "varchar(9)")] public string Filler1 { get; set; }
        [CustomPosInFile(195, 45)] [Column(TypeName = "varchar(45)")] public string WriterLstName2 { get; set; }
        [CustomPosInFile(240, 30)] [Column(TypeName = "varchar(30)")] public string WrtFstName2 { get; set; }
        [CustomPosInFile(270, 9)] [Column(TypeName = "varchar(9)")] public string Filler2 { get; set; }
        [CustomPosInFile(279, 11)] [Column(TypeName = "varchar(11)")] public string WrtIpNameNr1 { get; set; }
        [CustomPosInFile(290, 11)] [Column(TypeName = "varchar(11)")] public string WrtIpNameNr2 { get; set; }

        public UpdFile UpdFile { get; set; }
    }
}

