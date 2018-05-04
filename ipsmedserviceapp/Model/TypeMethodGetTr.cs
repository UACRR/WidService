using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class TypeMethodGetTr
    {
        public int GetCode { get; set; }
        public string Lang { get; set; }
        public string GetName { get; set; }

        public TypeMethodGet GetCodeNavigation { get; set; }
    }
}
