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

        public int codeI { get; set; }
        public string name { get; set; }

        public ICollection<Category> Category { get; set; }
        public ICollection<CategoryStatusTypeTr> CategoryStatusTypeTr { get; set; }
    }
}
