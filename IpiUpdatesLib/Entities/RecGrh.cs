using System.ComponentModel.DataAnnotations.Schema;

namespace IpiUpdatesLib.Entities
{
[Table("RecGrh")]
    public class RecGrh
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "int")] public int UpdFileId { get; set; }
        [CustomPosInFile(1, 3)] [Column(TypeName = "varchar(3)")] public string RecType { get; set; }
        [CustomPosInFile(4, 3)] [Column(TypeName = "varchar(3)")] public string TransType { get; set; }
        [CustomPosInFile(7, 5)] [Column(TypeName = "varchar(5)")] public string GrId { get; set; }
        [CustomPosInFile(12, 5)] [Column(TypeName = "varchar(5)")] public string VerNr { get; set; }

        public UpdFile UpdFile { get; set; }
    }
}

