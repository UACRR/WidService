using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RhcatalogItem : IRhcatalogItem
    {
        public int ItemId { get; set; }
        public int? FileId { get; set; }
        public string ItemCode { get; set; }
        public string Iswc { get; set; }
        public string ObjName { get; set; }
        public string GenreName { get; set; }
        public string RoleName { get; set; }
        public string AuthorName { get; set; }
        public decimal? Rate { get; set; }
        public string CmName { get; set; }
        public string Comment { get; set; }
        public int? ObjId { get; set; }
        public int? CustId { get; set; }
        public int? GenreCode { get; set; }
        public int? RoleCode { get; set; }
        public int? CmCustId { get; set; }
        public int? Status { get; set; }
        public int? CRightId { get; set; }
        public string ErrComment { get; set; }
        public TimeSpan? Duration { get; set; }

        public virtual CopyRight CRight { get; set; }
        public virtual RightHolder Cust { get; set; }
        public virtual CatalogFile File { get; set; }
        public virtual CatalogStatus StatusNavigation { get; set; }
    }
}

