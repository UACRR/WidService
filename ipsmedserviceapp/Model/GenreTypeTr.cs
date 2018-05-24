using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class GenreTypeTr
    {
        public int CodeI { get; set; }
        public string Lang { get; set; }
        public string Name { get; set; }
        public int CategoryCode { get; set; }

        public GenreType C { get; set; }
    }
}
