using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class CrkindGroup : ICrkindGroup
    {
        public CrkindGroup()
        {
            CopyrightKind = new ObservableListSource<CopyrightKind>();
            CrkindGroupTr = new ObservableListSource<CrkindGroupTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ObservableListSource<CopyrightKind> CopyrightKind { get; set; }
        public ObservableListSource<CrkindGroupTr> CrkindGroupTr { get; set; }
    }
}

