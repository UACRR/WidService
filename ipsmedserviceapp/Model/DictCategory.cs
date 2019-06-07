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

        public int Code { get; set; }
        public string Name { get; set; }

        public virtual ICollection<DicCategoryItems> DicCategoryItems { get; set; }
    }
}
