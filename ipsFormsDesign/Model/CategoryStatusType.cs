using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class CategoryStatusType : ICategoryStatusType
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

