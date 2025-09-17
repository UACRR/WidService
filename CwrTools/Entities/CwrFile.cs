using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CwrTools
{
    public class CwrFile
    {
        public int CrwFileId { get; set; }
        public string FileFullName { get; set; }

        public RecHdr RecHdr { get; set; }
    }
}
