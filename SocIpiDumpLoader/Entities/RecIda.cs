using System.ComponentModel.DataAnnotations.Schema;

namespace SocIpiDumpLoader.Entities
{
[Table("RecIda")]
    public class RecIda
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "int")] public int UpdFileId { get; set; }
        [Column(TypeName = "varchar(5)")] public string GrId { get; set; }
        [CustomPosInFile(1, 3)] [Column(TypeName = "varchar(3)")] public string RecType { get; set; }
        [CustomPosInFile(4, 8)] [Column(TypeName = "varchar(8)")] public string TransSeqNr { get; set; }
        [CustomPosInFile(12, 8)] [Column(TypeName = "varchar(8)")] public string RecSeqNr { get; set; }
        [CustomPosInFile(20, 8)] [Column(TypeName = "varchar(8)")] public string TransD { get; set; }
        [CustomPosInFile(28, 6)] [Column(TypeName = "varchar(6)")] public string TransT { get; set; }
        [CustomPosInFile(34, 3)] [Column(TypeName = "varchar(3)")] public string RemitSocCde { get; set; }
        [CustomPosInFile(37, 20)] [Column(TypeName = "varchar(20)")] public string RemitSocName { get; set; }
        [CustomPosInFile(57, 3)] [Column(TypeName = "varchar(13)")] public string DomName { get; set; }

        public UpdFile UpdFile { get; set; }
    }
}

