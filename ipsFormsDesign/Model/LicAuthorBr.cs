using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class LicAuthorBr : ILicAuthorBr
    {
        public LicAuthorBr()
        {
            WorkRh = new ObservableListSource<WorkRh>();
        }

        public int LicAuthorId { get; set; }
        public int? LicId { get; set; }
        public int? CustId { get; set; }
        public int? RoleType { get; set; }
        public int? CRightId { get; set; }
        public int? PrepayType { get; set; }
        public string NameAuthor { get; set; }
        public DateTime? DateCreate { get; set; }
        public DateTime? DateClose { get; set; }
        public DateTime? DateModify { get; set; }
        public DateTime? DateAccept { get; set; }
        public decimal? Rate { get; set; }
        public decimal? R030 { get; set; }
        public decimal? PrepaySum { get; set; }
        public decimal? PrepaySumAuthor { get; set; }

        public CopyRight CRight { get; set; }
        public RightHolder Cust { get; set; }
        public LicenseBigR Lic { get; set; }
        public PrePayType PrepayTypeNavigation { get; set; }
        public CreativeRoleType RoleTypeNavigation { get; set; }
        public ObservableListSource<WorkRh> WorkRh { get; set; }
    }
}

