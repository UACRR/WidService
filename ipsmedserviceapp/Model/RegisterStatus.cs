using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class RegisterStatus
    {
        public RegisterStatus()
        {
            BrRegister = new HashSet<BrRegister>();
            Register = new HashSet<Register>();
            RegisterStatusTr = new HashSet<RegisterStatusTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ICollection<BrRegister> BrRegister { get; set; }
        public virtual ICollection<Register> Register { get; set; }
        public virtual ICollection<RegisterStatusTr> RegisterStatusTr { get; set; }
    }
}
