using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class CopyRight : ICopyRight
    {
        public int cRightId { get; set; }
        public int custId { get; set; }
        public int? objId { get; set; }
        public int? lBasis { get; set; }
        public decimal? rate { get; set; }
        public decimal? roleRate { get; set; }
        public DateTime? beginDate { get; set; }
        public DateTime? endDate { get; set; }
        public string lBasisComment { get; set; }
        public DateTime? createDate { get; set; }
        public DateTime? modifyDate { get; set; }
        public string modifyLogin { get; set; }
        public bool? permCode { get; set; }
        public int? parentId { get; set; }
        public int? roleCode { get; set; }
        public int? status { get; set; }

        public RightHolder cust { get; set; }
        public ObjectRight obj { get; set; }
        public CreativeRoleType roleCodeNavigation { get; set; }
        public CRightStatus statusNavigation { get; set; }
        public CopyRTranslate CopyRTranslate { get; set; }
        public LicAuthorBR LicAuthorBR { get; set; }
        public WorkRH WorkRH { get; set; }
    }
}

