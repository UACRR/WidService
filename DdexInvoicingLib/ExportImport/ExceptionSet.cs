using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExportImport
{
    public class ExceptionSet
    {
        [Pk]
        public int SetCode { get; set; }
        public string SetName { get; set; }
        public string SetComment { get; set; }
        [ImportValue(0)]
        public int? SetStatus { get; set; }
        [ImportValue(0)]
        public int? IsUsed { get; set; }
        [ImportCurrent]
        public DateTime? DateCreated { get; set; }
        [ImportCurrent]
        public DateTime? DateUpdated { get; set; }
    }
}
