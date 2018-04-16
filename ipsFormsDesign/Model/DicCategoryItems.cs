using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class DicCategoryItems
    {
        public string DicName { get; set; }
        public int Code { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string DicType { get; set; }

        public DictCategory CodeNavigation { get; set; }
    }
}
