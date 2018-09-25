using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class CRKindGroup : ICRKindGroup
    {
        public CRKindGroup()
        {
            CRKindGroupTr = new ObservableListSource<CRKindGroupTr>();
            CopyrightKind = new ObservableListSource<CopyrightKind>();
        }

        public int codeI { get; set; }
        public string name { get; set; }

        public ObservableListSource<CRKindGroupTr> CRKindGroupTr { get; set; }
        public ObservableListSource<CopyrightKind> CopyrightKind { get; set; }
    }
}

