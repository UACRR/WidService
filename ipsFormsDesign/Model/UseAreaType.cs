using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class UseAreaType
    {
        public UseAreaType()
        {
            RelAdaptUseArea = new HashSet<RelAdaptUseArea>();
        }

        public int UseAreaTypeCode { get; set; }
        public int CategoryCode { get; set; }
        public int ReqType { get; set; }
        public string UseAreaTypeNameUk { get; set; }
        public string UseAreaTypeNameRu { get; set; }
        public string UseAreaTypeNameEn { get; set; }

        public Category CategoryCodeNavigation { get; set; }
        public RequestType ReqTypeNavigation { get; set; }
        public ICollection<RelAdaptUseArea> RelAdaptUseArea { get; set; }
    }
}
