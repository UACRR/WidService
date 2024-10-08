using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioStationReports
{
    public class ReportLine
    {
        public int      LineNr            { get; set; }
        public string   Name              { get; set; }
        public string   Performer         { get; set; }
        public string   MusicAuthor       { get; set; }
        public string   TextAuthor        { get; set; }
        public string   Duration          { get; set; }
        public string   CountUses         { get; set; }
        public string   TotalDuration     { get; set; }
        public Work     Work              { get; set; }
    }
}
