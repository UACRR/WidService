using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class CategoryStatusType : ICategoryStatusType
    {
        public CategoryStatusType()
        {
            Category = new ObservableListSource<Category>();
            CategoryStatusTypeTr = new ObservableListSource<CategoryStatusTypeTr>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ObservableListSource<Category> Category { get; set; }
        public ObservableListSource<CategoryStatusTypeTr> CategoryStatusTypeTr { get; set; }
    }
}

