using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class DictCategory : IDictCategory
    {
        public DictCategory()
        {
            DicCategoryItems = new ObservableListSource<DicCategoryItems>();
        }

        public int Code { get; set; }
        public string Name { get; set; }

        public ObservableListSource<DicCategoryItems> DicCategoryItems { get; set; }
    }
}

