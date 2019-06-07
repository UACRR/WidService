using System;
using System.Collections.Generic;
using System.Text;

namespace ipsFormsDesign.Dictionary
{
    public class DictTrI
    {
        public int CodeI { get; set; }
        public string Lang { get; set; }
        public string Name { get; set; }

        public DictTrI()
        {
            CodeI = default(int);
            Lang = default(string);
            Name = default(string);
        }
    }

    public class DictTrS
    {
        public string CodeS { get; set; }
        public string Lang { get; set; }
        public string Name { get; set; }
    }
}
