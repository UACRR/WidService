using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class UseAreaType : IUseAreaType
    {
        public UseAreaType()
        {
            RelAdaptUseArea = new ObservableListSource<RelAdaptUseArea>();
            UseAreaTypeTr = new ObservableListSource<UseAreaTypeTr>();
        }

        public int CodeI { get; set; }
        public int CategoryCode { get; set; }
        public int ReqType { get; set; }
        public string Name { get; set; }

        public virtual Category CategoryCodeNavigation { get; set; }
        public virtual RequestType ReqTypeNavigation { get; set; }
        public virtual ObservableListSource<RelAdaptUseArea> RelAdaptUseArea { get; set; }
        public virtual ObservableListSource<UseAreaTypeTr> UseAreaTypeTr { get; set; }
    }
}

