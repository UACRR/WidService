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

        public int causeCode { get; set; }
        public string causeNameUk { get; set; }
        public string causeNameRu { get; set; }
        public string causeNameEn { get; set; }

        public ObservableListSource<ReqTrade> ReqTrade { get; set; }
    }
}

