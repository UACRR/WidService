using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class AlgorithmType
    {
        public AlgorithmType()
        {
            AgrLicenseType = new HashSet<AgrLicenseType>();
            Register = new HashSet<Register>();
        }

        public int codeI { get; set; }
        public string name { get; set; }

        public ICollection<AgrLicenseType> AgrLicenseType { get; set; }
        public ICollection<Register> Register { get; set; }
    }
}
