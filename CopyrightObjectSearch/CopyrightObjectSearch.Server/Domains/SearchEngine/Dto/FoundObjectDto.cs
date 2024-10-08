using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CopyrightObjectSearch.Server
{
    public class FoundObjectDto
    {
        public          int      Id         { get; set; }
        public required string   Title      { get; set; }
        public required string   Authors    { get; set; }
        public required string   Performers { get; set; }
    }
}
