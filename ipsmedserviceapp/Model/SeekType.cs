using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class SeekType
    {
        public SeekType()
        {
            SeekObject = new HashSet<SeekObject>();
            SeekTypeTr = new HashSet<SeekTypeTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ICollection<SeekObject> SeekObject { get; set; }
        public virtual ICollection<SeekTypeTr> SeekTypeTr { get; set; }
    }
}
