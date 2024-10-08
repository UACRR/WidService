using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WidExport
{
    public class DsiFoundWork
    {
        public int      WorkId { get; set; }
        public int      ObjId { get; set; }
        public string   WidName { get; set; }
        public string   Iswc { get; set; }
        public string   LocalName { get; set; }
        public string   LocalAuthor { get; set; }
        public string   LocalPerformer { get; set; }
        public int      Status { get; set; }
    } 
}
