using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class CrightStatus : ICrightStatus
    {
        public CrightStatus()
        {
            CopyRight = new ObservableListSource<CopyRight>();
            CrightStatusTr = new ObservableListSource<CrightStatusTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ObservableListSource<CopyRight> CopyRight { get; set; }
        public virtual ObservableListSource<CrightStatusTr> CrightStatusTr { get; set; }
    }
}

