using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpsViewComponentLibrary.CommunityControls.InternalModel
{
    public class RightLimitationsView
    {
        public int CustId { get; set; }
        public int? CmCustId { get; set; }
        public int KindCode { get; set; }
        public string KindName { get; set; }
        public bool Check { get; set; }
        public DateTime? DateBegin { get; set; }
        public DateTime? DateEnd { get; set; }
        public string CommunityName { get; set; }
    }
}
