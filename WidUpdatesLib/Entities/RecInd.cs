using System.ComponentModel.DataAnnotations.Schema;


namespace WidUpdatesLib.Entities
{
    [Table("RecInd")]
    [CustomTargetWidEntity("InstnDtl")]
    [CustomUpdateMethod("IU")]
    public class RecInd
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "int")] public int UpdFileId { get; set; }
        [CustomPosInFile(1, 3)] [Column(TypeName = "varchar(3)")] public string RecType { get; set; }
        [CustomPosInFile(4, 8)] [Column(TypeName = "varchar(8)")] public string TransSeqNr { get; set; }
        [CustomPosInFile(12, 8)] [Column(TypeName = "varchar(8)")] public string RecSeqNr { get; set; }
        [CustomForMatch][CustomPosInFile(20, 3)] [Column(TypeName = "varchar(3)")] public string InstrCode { get; set; }
        [CustomPosInFile(23, 3)] [Column(TypeName = "varchar(3)")] public string NumOfPlayers { get; set; }

        public UpdFile UpdFile { get; set; }
    }
}

