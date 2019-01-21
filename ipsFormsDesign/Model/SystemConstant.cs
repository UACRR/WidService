using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class SystemConstant : ISystemConstant
    {
        public SystemConstant()
        {
            SystemConstantTr = new ObservableListSource<SystemConstantTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }
        public decimal? Rate { get; set; }

        public ObservableListSource<SystemConstantTr> SystemConstantTr { get; set; }
    }
}

