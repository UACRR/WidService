using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ipsCheckWordTemplate.Model
{
    public class TagInfo
    {
        public string name { get; set; }
        public bool isCyrillic { get; set; }
        public bool isNotInList { get; set; }
    }
}
