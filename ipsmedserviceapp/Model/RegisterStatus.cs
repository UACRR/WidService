using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RegisterStatus
    {
        public RegisterStatus()
        {
            RegisterStatusTr = new HashSet<RegisterStatusTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<RegisterStatusTr> RegisterStatusTr { get; set; }
    }
}
