using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CopyrightObjectSearch.Server
{
    public class TmpSelectedId
    {
        [Key]                                 public          int      Id         { get; set; }
        [Column(TypeName = "varchar(36)")]    public required string   Guid       { get; set; }
        [Column(TypeName = "int")]            public          int      SelectedId { get; set; }
    }
}
