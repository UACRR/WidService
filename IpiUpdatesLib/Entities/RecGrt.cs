using System.ComponentModel.DataAnnotations.Schema;

namespace IpiUpdatesLib.Entities
{
[Table("RecGrt")]
    public class RecGrt
    {
        [Column(TypeName = "int")] public int Id { get; set; }
        [Column(TypeName = "int")] public int UpdFileId { get; set; }
        [CustomPosInFile(1, 3)] [Column(TypeName = "varchar(3)")] public string RecType { get; set; }
        [CustomPosInFile(4, 5)] [Column(TypeName = "varchar(5)")] public string GrId { get; set; }
        [CustomPosInFile(9, 8)] [Column(TypeName = "varchar(8)")] public string TransCnt { get; set; }
        [CustomPosInFile(17, 8)] [Column(TypeName = "varchar(8)")] public string RecCnt { get; set; }

        public UpdFile UpdFile { get; set; }
    }
}

