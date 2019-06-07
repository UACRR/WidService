using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RegisterStatus : IRegisterStatus
    {
        public RegisterStatus()
        {
            BrRegister = new ObservableListSource<BrRegister>();
            Register = new ObservableListSource<Register>();
            RegisterStatusTr = new ObservableListSource<RegisterStatusTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ObservableListSource<BrRegister> BrRegister { get; set; }
        public virtual ObservableListSource<Register> Register { get; set; }
        public virtual ObservableListSource<RegisterStatusTr> RegisterStatusTr { get; set; }
    }
}

