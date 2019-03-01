using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class Authors : IAuthors
    {
        public int AuthId { get; set; }
        public int ObjId { get; set; }
        public int RoleCode { get; set; }
        public int? CustId { get; set; }
        public string AuthorName { get; set; }
        public int? IsFolkOrUnknown { get; set; }
        public int? FolkType { get; set; }

        public virtual RightHolder Cust { get; set; }
        public virtual FolkType FolkTypeNavigation { get; set; }
        public virtual ObjectRight Obj { get; set; }
        public virtual CreativeRoleType RoleCodeNavigation { get; set; }
    }
}

