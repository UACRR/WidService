using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class Category
    {
        public Category()
        {
            CategoryTr = new HashSet<CategoryTr>();
            CreativeRoleType = new HashSet<CreativeRoleType>();
            DocumentKind = new HashSet<DocumentKind>();
            Genre = new HashSet<Genre>();
            ObjectType = new HashSet<ObjectType>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }
        public int? Status { get; set; }
        public string TableObj { get; set; }

        public CategoryStatusType StatusNavigation { get; set; }
        public ICollection<CategoryTr> CategoryTr { get; set; }
        public ICollection<CreativeRoleType> CreativeRoleType { get; set; }
        public ICollection<DocumentKind> DocumentKind { get; set; }
        public ICollection<Genre> Genre { get; set; }
        public ICollection<ObjectType> ObjectType { get; set; }
    }
}
