using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class CopyRight
    {
        public int CRightId { get; set; }
        public int CustId { get; set; }
        public int? ObjId { get; set; }
        public int? LBasis { get; set; }
        public decimal? Rate { get; set; }
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

        [JsonIgnore]
        public RightHolder Cust { get; set; }
        [JsonIgnore]
        public ObjectRight Obj { get; set; }
        [JsonIgnore]
        public CreativeRoleType RoleCodeNavigation { get; set; }
        [JsonIgnore]
        public CrightStatus StatusNavigation { get; set; }
        [JsonIgnore]
        public CopyRtranslate CopyRtranslate { get; set; }
        public LicAuthorBr LicAuthorBr { get; set; }
        public WorkRh WorkRh { get; set; }
    }
}

