using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class DicCategoryItems : IDicCategoryItems
    {
        public string DicName { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string DicType { get; set; }
        public int? DicLevel { get; set; }

        public virtual DictCategory CodeNavigation { get; set; }
    }
}

