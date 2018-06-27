using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class CopyRight
    {
        public CopyRight()
        {
            LicAuthorBr = new HashSet<LicAuthorBr>();
            WorkRh = new HashSet<WorkRh>();
        }

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

        public RightHolder Cust { get; set; }
        public ObjectRight Obj { get; set; }
        public CreativeRoleType RoleCodeNavigation { get; set; }
        public CrightStatus StatusNavigation { get; set; }
        public CopyRtranslate CopyRtranslate { get; set; }
        public ICollection<LicAuthorBr> LicAuthorBr { get; set; }
        public ICollection<WorkRh> WorkRh { get; set; }
    }
}
