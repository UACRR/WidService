using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class CategoryStatusType
    {
        public CategoryStatusType()
        {
            Category = new HashSet<Category>();
            CategoryStatusTypeTr = new HashSet<CategoryStatusTypeTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<Category> Category { get; set; }
        public ICollection<CategoryStatusTypeTr> CategoryStatusTypeTr { get; set; }
    }
}
