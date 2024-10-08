using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioStationReports
{
    public class MatchingWork
    {
        public int Id { get; set; }
        public int FoundId { get; set; }
        public string Name { get; set; }
        public string Authors { get; set; }
        public string Performers { get; set; }
        public string FoundInDb { get; set; }
        public string MainOrAlt { get; set; }
        public bool IsMatchingAuthorPerformer { get; set; }
    }
}
