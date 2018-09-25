using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class CopyRight
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

        [JsonIgnore]
        public RightHolder cust { get; set; }
        [JsonIgnore]
        public ObjectRight obj { get; set; }
        [JsonIgnore]
        public CreativeRoleType roleCodeNavigation { get; set; }
        [JsonIgnore]
        public CRightStatus statusNavigation { get; set; }
        [JsonIgnore]
        public CopyRTranslate CopyRTranslate { get; set; }
        [JsonIgnore]
        public LicAuthorBR LicAuthorBR { get; set; }
        [JsonIgnore]
        public WorkRH WorkRH { get; set; }
    }
}

