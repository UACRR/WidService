using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class LicAuthor
    {
        public int LicAutorId { get; set; }
        public int? LicId { get; set; }
        public int? CustId { get; set; }
        public int? RoleType { get; set; }
        public string NameAuthor { get; set; }
        public DateTime? DateCreate { get; set; }
        public DateTime? DateClose { get; set; }
        public DateTime? DateModify { get; set; }
        public DateTime? DateAccept { get; set; }
        public decimal? Rate { get; set; }
        public decimal? LumpSum { get; set; }
        public decimal? R030LumpSum { get; set; }
        public decimal? PrePay { get; set; }
        public decimal? R030PrePay { get; set; }

        public RightHolder Cust { get; set; }
        public LicenseBigR Lic { get; set; }
        public CreativeRoleType RoleTypeNavigation { get; set; }
    }
}
