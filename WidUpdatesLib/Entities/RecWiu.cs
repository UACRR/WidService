using System.ComponentModel.DataAnnotations.Schema;


namespace WidUpdatesLib.Entities
{
    [Table("RecWiu")]
    [CustomIsTran]
    [CustomUpdateMethod("U")]
    public class RecWiu
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "int")] public int UpdFileId { get; set; }
        [CustomPosInFile(1, 3)] [Column(TypeName = "varchar(3)")] public string RecType { get; set; }
        [CustomPosInFile(4, 8)] [Column(TypeName = "varchar(8)")] public string TransSeqNr { get; set; }
        [CustomPosInFile(12, 8)] [Column(TypeName = "varchar(8)")] public string RecSeqNr { get; set; }
        [CustomPosInFile(20, 60)] [Column(TypeName = "varchar(60)")] public string WrkTtl { get; set; }
        [CustomPosInFile(80, 2)] [Column(TypeName = "varchar(2)")] public string LngCode { get; set; }
        [CustomPosInFile(82, 14)] [Column(TypeName = "varchar(14)")] public string SubmWrkNr { get; set; }
        [CustomPosInFile(96, 11)] [Column(TypeName = "varchar(11)")] public string Iswc { get; set; }
        [CustomPosInFile(107, 8)] [Column(TypeName = "varchar(8)")] public string CprDate { get; set; }
        [CustomPosInFile(115, 12)] [Column(TypeName = "varchar(12)")] public string CprNr { get; set; }
        [CustomPosInFile(127, 3)] [Column(TypeName = "varchar(3)")] public string MwDistrCat { get; set; }
        [CustomPosInFile(130, 6)] [Column(TypeName = "varchar(6)")] public string Dur { get; set; }
        [CustomPosInFile(136, 1)] [Column(TypeName = "varchar(1)")] public string RecInd { get; set; }
        [CustomPosInFile(137, 3)] [Column(TypeName = "varchar(3)")] public string TxtMusicRel { get; set; }
        [CustomPosInFile(140, 3)] [Column(TypeName = "varchar(3)")] public string CmpType { get; set; }
        [CustomPosInFile(143, 3)] [Column(TypeName = "varchar(3)")] public string VerType { get; set; }
        [CustomPosInFile(146, 3)] [Column(TypeName = "varchar(3)")] public string ExcType { get; set; }
        [CustomPosInFile(149, 3)] [Column(TypeName = "varchar(3)")] public string MusicArr { get; set; }
        [CustomPosInFile(152, 3)] [Column(TypeName = "varchar(3)")] public string LyrAdapt { get; set; }
        [CustomPosInFile(155, 10)] [Column(TypeName = "varchar(10)")] public string WicCode { get; set; }
        [CustomPosInFile(165, 8)] [Column(TypeName = "varchar(8)")] public string UpdDate  { get; set; }
        [CustomPosInFile(173, 8)] [Column(TypeName = "varchar(8)")] public string FstSendDateToCis { get; set; }
        [CustomPosInFile(181, 8)] [Column(TypeName = "varchar(8)")] public string LstSendDateToCis { get; set; }
        [CustomPosInFile(189, 3)] [Column(TypeName = "varchar(3)")] public string SocWrkType { get; set; }

        public UpdFile UpdFile { get; set; }
    }
}

