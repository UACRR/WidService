using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class Category
    {
        public Category()
        {
            CategoryTr = new HashSet<CategoryTr>();
        }

        public int CategoryCode { get; set; }
        public string CategoryName { get; set; }
        public int? CategoryStatus { get; set; }
        public string TableObj { get; set; }

        public ICollection<CategoryTr> CategoryTr { get; set; }
    }
}
