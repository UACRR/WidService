using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class ResidentType : IResidentType
    {
        public ResidentType()
        {
            AnketaPerson = new HashSet<AnketaPerson>();
            ResidentTypeTr = new HashSet<ResidentTypeTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<AnketaPerson> AnketaPerson { get; set; }
        public ICollection<ResidentTypeTr> ResidentTypeTr { get; set; }
    }
}

