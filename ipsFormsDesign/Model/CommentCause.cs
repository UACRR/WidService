using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class CommentCause : ICommentCause
    {
        public CommentCause()
        {
            ReqTrade = new ObservableListSource<ReqTrade>();
        }

        public int CauseCode { get; set; }
        public string CauseNameUk { get; set; }
        public string CauseNameRu { get; set; }
        public string CauseNameEn { get; set; }

        public virtual ObservableListSource<ReqTrade> ReqTrade { get; set; }
    }
}

