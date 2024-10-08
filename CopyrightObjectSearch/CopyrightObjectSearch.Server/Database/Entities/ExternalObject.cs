using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CopyrightObjectSearch.Server
{
    public class ExternalObject
    {
        [Key]                                 public          int      Id         { get; set; }
        [Column(TypeName = "nvarchar(64)")]   public required string   Title      { get; set; }
        [Column(TypeName = "nvarchar(256)")]  public required string   Authors    { get; set; }
        [Column(TypeName = "nvarchar(256)")]  public required string   Performers { get; set; }
        [Column(TypeName = "varchar(13)")]    public required string   Iswc       { get; set; }
        [Column(TypeName = "int")]            public required int      FoundObjId { get; set; }
        [Column(TypeName = "int")]            public required int      FoundWic   { get; set; }
        [Column(TypeName = "varchar(13)")]    public required string   FoundIswc  { get; set; }
        [Column(TypeName = "varchar(8)")]     public required string   FoundVia   { get; set; }
        [Column(TypeName = "datetime2")]      public required DateTime CreatedAt  { get; set; }
        [Column(TypeName = "datetime2")]      public required DateTime UpdatedAt  { get; set; }
    }
}
