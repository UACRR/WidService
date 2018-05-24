using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class TypeMethodGetTr : ITypeMethodGetTr
    {
        public int GetCode { get; set; }
        public string Lang { get; set; }
        public string GetName { get; set; }

        public TypeMethodGet GetCodeNavigation { get; set; }
    }
}

