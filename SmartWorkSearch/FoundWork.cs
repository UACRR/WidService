using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartWorkSearch
{
    public class FoundWork
    {
        public int Id { get; set; }
        public int ObjId { get; set; }
        public string LocalName { get; set; }
        public string ReportAlbumName { get; set; }
        public string ReportName { get; set; }
        public string ReportAuthor { get; set; }
        public string ReportPerformer { get; set; }
    }
}
