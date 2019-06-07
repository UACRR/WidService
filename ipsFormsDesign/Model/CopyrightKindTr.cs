using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class CopyrightKindTr : ICopyrightKindTr
    {
        public int CodeI { get; set; }
        public string Lang { get; set; }
        public string Name { get; set; }
        public string NameDescript { get; set; }

        public virtual CopyrightKind CodeINavigation { get; set; }
    }
}

