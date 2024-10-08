using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CopyrightObjectSearch.Server
{
    public class FoundNameAuthorsPerformers
    {
        [Key]
        public          int      FoundCde   { get; set; }
        public required string   FoundIn    { get; set; }
        public required string   Name       { get; set; }
        public required string   Authors    { get; set; }
        public required string   Performers { get; set; }
    }
}
