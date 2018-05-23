using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class SexType : ISexType
    {
        public SexType()
        {
            AnketaPerson = new HashSet<AnketaPerson>();
            SexTypeTr = new HashSet<SexTypeTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<AnketaPerson> AnketaPerson { get; set; }
        public ICollection<SexTypeTr> SexTypeTr { get; set; }
    }
}

