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

        public ObservableListSource<CopyRight> CopyRight { get; set; }
        public ObservableListSource<CrightStatusTr> CrightStatusTr { get; set; }
    }
}

