using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DciAssessment
{
    public class ReportWork
    {
        public int      WorkId      { get; set; }
        public int      Wic { get; set; }
        public string   SocWorkCde { get; set; }
        public string   WidName     { get; set; }
        public string   WidIswc     { get; set; }
        public string   WidAuthor   { get; set; }
        public int      ObjId       { get; set; }
        public int      Status      { get; set; }
    }
}
