using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class PerformType : IPerformType
    {
        public PerformType()
        {
            LicenseBigR = new ObservableListSource<LicenseBigR>();
            PerformTypetTr = new ObservableListSource<PerformTypetTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ObservableListSource<LicenseBigR> LicenseBigR { get; set; }
        public ObservableListSource<PerformTypetTr> PerformTypetTr { get; set; }
    }
}

