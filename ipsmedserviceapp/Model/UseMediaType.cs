using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class UseMediaType
    {
        public UseMediaType()
        {
            RelReqMedia = new HashSet<RelReqMedia>();
        }

        public int UseMediaTypeCode { get; set; }
        public int ReqType { get; set; }
        public string UseMediaTypeNameUk { get; set; }
        public string UseMediaTypeNameRu { get; set; }
        public string UseMediaTypeNameEn { get; set; }
        public int CategoryCode { get; set; }

        public Category CategoryCodeNavigation { get; set; }
        public RequestType ReqTypeNavigation { get; set; }
        public ICollection<RelReqMedia> RelReqMedia { get; set; }
    }
}
