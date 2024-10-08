using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CopyrightObjectSearch.Server
{
    public class ExternalObjectDto
    {
        public          int      Id         { get; set; }
        public required string   Title      { get; set; }
        public required string   Authors    { get; set; }
        public required string   Performers { get; set; }
        public required string   Iswc       { get; set; }
        public required int      FoundObjId { get; set; }
        public required int      FoundWic   { get; set; }
        public required string   FoundIswc  { get; set; }
        public required string   FoundVia   { get; set; }
        public required DateTime CreatedAt  { get; set; }
        public required DateTime UpdatedAt  { get; set; }
    }
}
