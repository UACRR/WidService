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

        public int codeI { get; set; }
        public int categoryCode { get; set; }
        public int reqType { get; set; }
        public string name { get; set; }

        public Category categoryCodeNavigation { get; set; }
        public RequestType reqTypeNavigation { get; set; }
        public ObservableListSource<RelAdaptUseArea> RelAdaptUseArea { get; set; }
        public ObservableListSource<UseAreaTypeTr> UseAreaTypeTr { get; set; }
    }
}

