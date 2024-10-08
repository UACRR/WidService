using System.ComponentModel.DataAnnotations.Schema;


namespace WidUpdatesLib.Entities
{
    [Table("RecIns")]
    [CustomTargetWidEntity("Instn")]
    [CustomUpdateMethod("IU")]
    public class RecIns
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "int")] public int UpdFileId { get; set; }
        [CustomPosInFile(1, 3)] [Column(TypeName = "varchar(3)")] public string RecType { get; set; }
        [CustomPosInFile(4, 8)] [Column(TypeName = "varchar(8)")] public string TransSeqNr { get; set; }
        [CustomPosInFile(12, 8)] [Column(TypeName = "varchar(8)")] public string RecSeqNr { get; set; }
        [CustomPosInFile(20, 3)] [Column(TypeName = "varchar(3)")] public string NumOfVoices { get; set; }
        [CustomPosInFile(23, 3)] [Column(TypeName = "varchar(3)")] public string StdInstrType { get; set; }
        [CustomPosInFile(26, 50)] [Column(TypeName = "varchar(50)")] public string InstrDsc { get; set; }

        public UpdFile UpdFile { get; set; }
    }
}

