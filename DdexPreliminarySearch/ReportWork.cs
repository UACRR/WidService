using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DdexPreSearch
{
    public class ReportWork
    {
        public int Id { get; set; }
        public int MwId { get; set; }
        public string Album { get; set; }
        public string Name { get; set; }
        public string Authors { get; set; }
        public string Performers { get; set; }
        public string AlbumT { get; set; }
        public string NameT { get; set; }
        public string AuthorsT { get; set; }
        public string PerformersT { get; set; }
        public bool HasMatchingWorks { get; set; }
        public List<FoundWork> FoundWorks { get; set; }
    }
}
