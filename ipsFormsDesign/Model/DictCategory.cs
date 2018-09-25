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

        public int code { get; set; }
        public string name { get; set; }

        public ObservableListSource<DicCategoryItems> DicCategoryItems { get; set; }
    }
}

