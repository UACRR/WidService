using System;
using System.Collections.Generic;

namespace ipsmedserviceapp
{
    public partial class Category
    {
        public int CategoryCode { get; set; }
        public string CategoryName { get; set; }
        public int? CategoryStatus { get; set; }
        public string TableObj { get; set; }
    }
}
