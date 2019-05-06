using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class CopyRight : ICopyRight
    {
        public CopyRight()
        {
            CopyRightHistoryChild = new ObservableListSource<CopyRightHistory>();
            CopyRightHistoryParent = new ObservableListSource<CopyRightHistory>();
            Distribution = new ObservableListSource<Distribution>();
            PubCatalogItem = new ObservableListSource<PubCatalogItem>();
            RhñatalogItem = new ObservableListSource<RhñatalogItem>();
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
        public decimal? RateMech { get; set; }

        public virtual RightHolder Cust { get; set; }
        public virtual ObjectRight Obj { get; set; }
        public virtual CreativeRoleType RoleCodeNavigation { get; set; }
        public virtual CrightStatus StatusNavigation { get; set; }
        public virtual LicAuthorBr LicAuthorBr { get; set; }
        public virtual WorkRh WorkRh { get; set; }
        public virtual ObservableListSource<CopyRightHistory> CopyRightHistoryChild { get; set; }
        public virtual ObservableListSource<CopyRightHistory> CopyRightHistoryParent { get; set; }
        public virtual ObservableListSource<Distribution> Distribution { get; set; }
        public virtual ObservableListSource<PubCatalogItem> PubCatalogItem { get; set; }
        public virtual ObservableListSource<RhñatalogItem> RhñatalogItem { get; set; }
    }
}

