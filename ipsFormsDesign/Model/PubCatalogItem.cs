using ipsFormsDesign.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class PubCatalogItem : IPubCatalogItem
    {
        public int ItemId { get; set; }
        public int? FileId { get; set; }
        public int? CRightId { get; set; }
        public int? CustId { get; set; }
        public string ItemCode { get; set; }
        public string Iswc { get; set; }
        public string ObjName { get; set; }
        public string GenreName { get; set; }
        public string RoleName { get; set; }
        public decimal? Rate { get; set; }
        public string AuthorMusic { get; set; }
        public string AuthorText { get; set; }
        public string Performer { get; set; }
        public string Comment { get; set; }
        public int? ObjId { get; set; }
        public int? GenreCode { get; set; }
        public int? RoleCode { get; set; }
        public int? Status { get; set; }
        public string ErrComment { get; set; }
        public string RhName { get; set; }
        public DateTime? DateBegin { get; set; }
        public DateTime? DateEnd { get; set; }

        [JsonIgnore]
        public virtual RightHolder Cust { get; set; }
        [JsonIgnore]
        public virtual CatalogFile File { get; set; }
        public virtual CatalogStatus StatusNavigation { get; set; }
    }
}



