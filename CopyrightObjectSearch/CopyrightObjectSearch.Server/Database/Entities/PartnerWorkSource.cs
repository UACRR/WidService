using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CopyrightObjectSearch.Server
{
    public class PartnerWorkSource
    {
        [Key]                                 public          int                   Id               { get; set; }
        [Column(TypeName = "nvarchar(266)")]  public required string                Title            { get; set; }
        [Column(TypeName = "int")]            public required int                   PartnerId        { get; set; }
        [Column(TypeName = "int")]            public required Partner               Partner          { get; set; }
        [Column(TypeName = "int")]            public required int                   SourceId         { get; set; }
        [Column(TypeName = "int")]            public required int                   SourceTypeId     { get; set; }
        [Column(TypeName = "int")]            public required PartnerWorkSourceType SourceType       { get; set; }
        [Column(TypeName = "nvarchar(256)")]  public required string                FileName         { get; set; }
        [Column(TypeName = "int")]            public required int                   Year             { get; set; }
        [Column(TypeName = "int")]            public required int                   Quarter          { get; set; }
        [Column(TypeName = "int")]            public required int                   Month            { get; set; }
        [Column(TypeName = "datetime2")]      public required DateTime              CreatedAt        { get; set; }
        [Column(TypeName = "datetime2")]      public required DateTime              UpdatedAt        { get; set; }
    }
}
