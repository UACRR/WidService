using System.ComponentModel.DataAnnotations.Schema;


namespace WidUpdatesLib.Entities
{
    [Table("RecOrn")]
    [CustomTargetWidEntity("WrkOrg")]
    [CustomUpdateMethod("IU")]
    public class RecOrn
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "int")] public int UpdFileId { get; set; }
        [CustomPosInFile(1, 3)] [Column(TypeName = "varchar(3)")] public string RecType { get; set; }
        [CustomPosInFile(4, 8)] [Column(TypeName = "varchar(8)")] public string TransSeqNr { get; set; }
        [CustomPosInFile(12, 8)] [Column(TypeName = "varchar(8)")] public string RecSeqNr { get; set; }
        [CustomPosInFile(20, 3)] [Column(TypeName = "varchar(3)")] public string IntndPps { get; set; }
        [CustomPosInFile(23, 60)] [Column(TypeName = "varchar(60)")] public string ProdTtl { get; set; }
        [CustomPosInFile(83, 15)] [Column(TypeName = "varchar(15)")] public string CdId { get; set; }
        [CustomPosInFile(98, 4)] [Column(TypeName = "varchar(4)")] public string CutNr { get; set; }

        public UpdFile UpdFile { get; set; }
    }
}

