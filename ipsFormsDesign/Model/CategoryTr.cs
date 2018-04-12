using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class CategoryTr
    {
        public string Lang { get; set; }
        public int CategoryCode { get; set; }
        public string CategoryName { get; set; }

        public Category CategoryCodeNavigation { get; set; }
    }
}
