using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class DocumentKindTr
    {
        public int CodeI { get; set; }
        public string Lang { get; set; }
        public string Name { get; set; }

        public DocumentKind CodeINavigation { get; set; }
    }
}
