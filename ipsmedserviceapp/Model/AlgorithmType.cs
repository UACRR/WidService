using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class AlgorithmType
    {
        public AlgorithmType()
        {
            AgrLicenseType = new HashSet<AgrLicenseType>();
            AlgorithmTypeTr = new HashSet<AlgorithmTypeTr>();
            Register = new HashSet<Register>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<AgrLicenseType> AgrLicenseType { get; set; }
        public ICollection<AlgorithmTypeTr> AlgorithmTypeTr { get; set; }
        public ICollection<Register> Register { get; set; }
    }
}
