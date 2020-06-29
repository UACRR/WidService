using System;

namespace IpsCommonTypes.SQLViews
{
    public class FT_TSK_1_BRMoneyPrepay
    {
        public DateTime? DateBegin { get; set; }
        public DateTime? DateEnd { get; set; }
        public int? LicId { get; set; }
        public int? LicVersion { get; set; }
        public int? CustId { get; set; }
        public int? ObjId { get; set; }
        public int? CustIdRH { get; set; }
        public int? RoleCode { get; set; }
        public int? PrepayType { get; set; }
        public decimal? PrepaySumAuthor { get; set; }
        public decimal? PrepaySum { get; set; }
        public decimal? LinkAmount { get; set; }
        public decimal? PrePayBorgLink { get; set; }
        public decimal? TurnAmount { get; set; }
        public decimal? RoleRate { get; set; }
        public string LicNum { get; set; }
        public string NameRH { get; set; }
        public string RoleName { get; set; }
        public string PrepayName { get; set; }
        public string R030_name { get; set; }
        public string R030 { get; set; }
    }
}
