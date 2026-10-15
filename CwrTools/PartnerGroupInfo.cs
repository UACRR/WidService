using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CwrTools
{
    public class PartnerGroupInfo
    {
            public int Id              { get; set; }
            public string Name         { get; set; }
            public bool IsStandard     { get; set; }
            public bool IsV21          { get; set; }
            public bool IsV22          { get; set; }
            public bool AddNativeNames { get; set; }
    }
}
