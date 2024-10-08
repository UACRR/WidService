using System.ComponentModel.DataAnnotations.Schema;


namespace WidUpdatesLib.Entities
{
    [Table("RecOip")]
    [CustomTargetWidEntity("IntrPty")]
    [CustomUpdateMethod("C")]
    public class RecOip
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "int")] public int UpdFileId { get; set; }
        [CustomPosInFile(1, 3)] [Column(TypeName = "varchar(3)")] public string RecType { get; set; }
        [CustomPosInFile(4, 8)] [Column(TypeName = "varchar(8)")] public string TransSeqNr { get; set; }
        [CustomPosInFile(12, 8)] [Column(TypeName = "varchar(8)")] public string RecSeqNr { get; set; }
        [CustomPosInFile(20, 9)] [Column(TypeName = "varchar(9)")] public string Filler1 { get; set; }
        [CustomPosInFile(29, 9)] [Column(TypeName = "varchar(9)")] public string IpNr { get; set; }
        [CustomPosInFile(38, 45)] [Column(TypeName = "varchar(45)")] public string IpName { get; set; }
        [CustomPosInFile(83, 30)] [Column(TypeName = "varchar(30)")] public string IpFstName { get; set; }
        [CustomPosInFile(113, 2)] [Column(TypeName = "varchar(2)")] public string IpRole { get; set; }
        [CustomForMatch] [CustomPosInFile(115, 11)] [Column(TypeName = "varchar(11)")] public string IpNameNr { get; set; }

        public UpdFile UpdFile { get; set; }
    }
}

