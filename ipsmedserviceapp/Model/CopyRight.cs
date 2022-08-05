using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class CopyRight
    {
        public CopyRight()
        {
            CopyRightHistoryChild = new HashSet<CopyRightHistory>();
            CopyRightHistoryParent = new HashSet<CopyRightHistory>();
            Distribution = new HashSet<Distribution>();
            LicAuthorBr = new HashSet<LicAuthorBr>();
            RhcatalogItem = new HashSet<RhcatalogItem>();
            Status = 0;
        }

        public int CRightId { get; set; }
        public int CustId { get; set; }
        public int? ObjId { get; set; }
        public int? LBasis { get; set; }
        public decimal Rate { get; set; }
        public decimal? RoleRate { get; set; }
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string LBasisComment { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifyLogin { get; set; }
        public bool? PermCode { get; set; }
        public int? ParentId { get; set; }
        public int? RoleCode { get; set; }
        public int? Status { get; set; }
        public decimal RateMech { get; set; }
        public int? LoadId { get; set; }
        public string SourceName { get; set; }
        public int? LoadSeqNr { get; set; }
        public string CreateLogin { get; set; }

        [JsonIgnore]
        public virtual RightHolder Cust { get; set; }
        public virtual ObjectRight Obj { get; set; }
        [JsonIgnore]
        public virtual CreativeRoleType RoleCodeNavigation { get; set; }
        [JsonIgnore]
        public virtual CrightStatus StatusNavigation { get; set; }
        public virtual WorkRh WorkRh { get; set; }
        [JsonIgnore]
        public virtual ICollection<CopyRightHistory> CopyRightHistoryChild { get; set; }
        [JsonIgnore]
        public virtual ICollection<CopyRightHistory> CopyRightHistoryParent { get; set; }
        [JsonIgnore]
        public virtual ICollection<Distribution> Distribution { get; set; }
        public virtual ICollection<LicAuthorBr> LicAuthorBr { get; set; }
        [JsonIgnore]
        public virtual ICollection<RhcatalogItem> RhcatalogItem { get; set; }
    }
}

