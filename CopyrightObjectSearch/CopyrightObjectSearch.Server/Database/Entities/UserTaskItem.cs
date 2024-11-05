using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CopyrightObjectSearch.Server
{
    public class UserTaskItem
    {
        [Key]                       public          int          Id            { get; set; }
        [Column(TypeName = "int")]  public required int          UserTaskId    { get; set; }
        [Column(TypeName = "int")]  public required UserTask     UserTask      { get; set; }
        [Column(TypeName = "int")]  public required int          PartnerWorkId { get; set; }
        [Column(TypeName = "int")]  public required PartnerWork  PartnerWork   { get; set; }
    }
}
