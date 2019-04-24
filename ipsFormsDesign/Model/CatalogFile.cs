using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class CatalogFile : ICatalogFile
    {
        public CatalogFile()
        {
            PubÑatalogItem = new ObservableListSource<PubÑatalogItem>();
            RhñatalogItem = new ObservableListSource<RhñatalogItem>();
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
        public virtual ObservableListSource<PubÑatalogItem> PubÑatalogItem { get; set; }
        public virtual ObservableListSource<RhñatalogItem> RhñatalogItem { get; set; }
    }
}

