using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartRoyaltyAccessAdmin
{
    public class Role
    {
        public int CodeI { get; set; }
        public string Name { get; set; }
        public bool IsRead { get; set; }
        public bool IsWrite { get; set; }
    }
}
