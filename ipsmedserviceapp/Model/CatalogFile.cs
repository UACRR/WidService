using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class CatalogFile
    {
        public CatalogFile()
        {
            PubСatalogItem = new HashSet<PubСatalogItem>();
            RhсatalogItem = new HashSet<RhсatalogItem>();
        }

        public int FileId { get; set; }
        public int? CustId { get; set; }
        public string CustName { get; set; }
        public string FileName { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string UserId { get; set; }
        public int? Status { get; set; }
        public int? RhType { get; set; }
        public string Comment { get; set; }

        public virtual RightHolder Cust { get; set; }
        public virtual RholderType RhTypeNavigation { get; set; }
        public virtual CatalogStatus StatusNavigation { get; set; }
        public virtual ICollection<PubСatalogItem> PubСatalogItem { get; set; }
        public virtual ICollection<RhсatalogItem> RhсatalogItem { get; set; }
    }
}
