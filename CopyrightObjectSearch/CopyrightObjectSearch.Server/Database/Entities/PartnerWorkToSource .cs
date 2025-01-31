using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CopyrightObjectSearch.Server
{
    public class PartnerWorkToSource
    {
        [Key]                       public          int               Id                  { get; set; }
        [Column(TypeName = "int")]  public required int               PartnerWorkSourceId { get; set; }
        [Column(TypeName = "int")]  public required PartnerWorkSource PartnerWorkSource   { get; set; }
        [Column(TypeName = "int")]  public required int               PartnerWorkId       { get; set; }
        [Column(TypeName = "int")]  public required PartnerWork       PartnerWork         { get; set; }
        [Column(TypeName = "int")]  public required int               Rate                { get; set; }
    }
}
