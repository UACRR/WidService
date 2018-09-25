using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class DictCategory
    {
        public DictCategory()
        {
            DicCategoryItems = new HashSet<DicCategoryItems>();
        }

        public int code { get; set; }
        public string name { get; set; }

        public ICollection<DicCategoryItems> DicCategoryItems { get; set; }
    }
}
