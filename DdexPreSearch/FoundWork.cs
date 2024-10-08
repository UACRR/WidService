using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DdexPreSearch
{
    public class FoundWork
    {
        public int FoundId { get; set; }
        public string Name { get; set; }
        public string Authors { get; set; }
        public string Performers { get; set; }
        public string SourceCol { get; set; }
        public string TargetDb { get; set; }
        public string TargetTbl { get; set; }
        public bool IsMatching { get; set; }
    }
}
