using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class LicAuthorBr
    {
        public LicAuthorBr()
        {
            MoneyPrepayLink = new HashSet<MoneyPrepayLink>();
        }

        public int CRightId { get; set; }
        public int? PrepayType { get; set; }
        public DateTime? DateCreate { get; set; }
        public DateTime? DateClose { get; set; }
        public DateTime? DateModify { get; set; }
        public DateTime? DateAccept { get; set; }
        public decimal? Rate { get; set; }
        public decimal? PrepaySum { get; set; }
        public decimal? PrepaySumAuthor { get; set; }
        public string R030 { get; set; }
        public DateTime? PrepayDateDo { get; set; }
        public decimal? PrepayRest { get; set; }
        public decimal? PrepayUsed { get; set; }
        public int CustIdRh { get; set; }
        public string ModifyLogin { get; set; }
        public int LicId { get; set; }
        public int LicVersion { get; set; }

        public virtual CopyRight CRight { get; set; }
        public virtual RightHolder CustIdRhNavigation { get; set; }
        public virtual LicenseBigR Lic { get; set; }
        public virtual PrePayType PrepayTypeNavigation { get; set; }
        public virtual ICollection<MoneyPrepayLink> MoneyPrepayLink { get; set; }
    }
}
