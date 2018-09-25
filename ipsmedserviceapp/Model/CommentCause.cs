using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class CommentCause
    {
        public CommentCause()
        {
            ReqTrade = new HashSet<ReqTrade>();
        }

        public int causeCode { get; set; }
        public string causeNameUk { get; set; }
        public string causeNameRu { get; set; }
        public string causeNameEn { get; set; }

        public ICollection<ReqTrade> ReqTrade { get; set; }
    }
}
