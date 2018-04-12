using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class SexType
    {
        public SexType()
        {
            SexTypeTr = new HashSet<SexTypeTr>();
        }

        public int SexCode { get; set; }
        public string SexName { get; set; }

        public ICollection<SexTypeTr> SexTypeTr { get; set; }
    }
}
