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
            PerformTypeTr = new ObservableListSource<PerformTypeTr>();
        }

        public int codeI { get; set; }
        public string name { get; set; }

        public ObservableListSource<LicenseBigR> LicenseBigR { get; set; }
        public ObservableListSource<PerformTypeTr> PerformTypeTr { get; set; }
    }
}

