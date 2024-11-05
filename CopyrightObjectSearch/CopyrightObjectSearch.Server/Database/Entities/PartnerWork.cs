using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CopyrightObjectSearch.Server
{
    public class PartnerWork
    {
        [Key]                               public          int                  Id                     { get; set; }
        [Column(TypeName = "int")]          public          int                  AlbumId                { get; set; }
        [Column(TypeName = "int")]          public required PartnerWorkAlbum     Album       { get; set; }
        [Column(TypeName = "int")]          public          int                  NameId                 { get; set; }
        [Column(TypeName = "int")]          public required PartnerWorkName      Name                   { get; set; }
        [Column(TypeName = "int")]          public          int                  AuthorsId              { get; set; }
        [Column(TypeName = "int")]          public required PartnerWorkAuthor    Authors     { get; set; }
        [Column(TypeName = "int")]          public          int                  PerformersId           { get; set; }
        [Column(TypeName = "int")]          public required PartnerWorkPerformer Performers  { get; set; }
        [Column(TypeName = "int")]          public          int                  IswcId                 { get; set; }
        [Column(TypeName = "int")]          public required PartnerWorkIswc      Iswc       { get; set; }
        [Column(TypeName = "int")]          public required int                  FoundObjId             { get; set; }
        [Column(TypeName = "int")]          public required int                  FoundWic               { get; set; }
        [Column(TypeName = "varchar(13)")]  public required string               FoundIswc              { get; set; }
        [Column(TypeName = "varchar(8)")]   public required string               FoundVia               { get; set; }
        [Column(TypeName = "datetime2")]    public required DateTime             CreatedAt              { get; set; }
        [Column(TypeName = "datetime2")]    public required DateTime             UpdatedAt              { get; set; }

        public required ICollection<UserTaskItem> UserTaskItems { get; set; }
    }
}
