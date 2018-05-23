using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class CommentCause : ICommentCause
    {
        public CommentCause()
        {
            ReqTrade = new HashSet<ReqTrade>();
        }

        public int CauseCode { get; set; }
        public string CauseNameUk { get; set; }
        public string CauseNameRu { get; set; }
        public string CauseNameEn { get; set; }

        public ICollection<ReqTrade> ReqTrade { get; set; }
    }
}

