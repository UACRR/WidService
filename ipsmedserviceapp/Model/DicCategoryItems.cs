using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class DicCategoryItems
    {
        public string dicName { get; set; }
        public int code { get; set; }
        public string name { get; set; }
        public string url { get; set; }
        public string dicType { get; set; }
        public int? dicLevel { get; set; }

        public DictCategory codeNavigation { get; set; }
    }
}
