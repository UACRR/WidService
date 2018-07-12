using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ipsFormsDesign.Dictionary
{
    public class RegisterListViewModel
    {
        public int RegId { get; set; }
        public int? PeriodId { get; set; }
        public string PeriodName { get; set; }
        public DateTime CreateDate { get; set; }
        public string UserWho { get; set; }
        public int CountItem { get; set; }
        public int CountNoFound { get; set; }
        public int? CRightCode { get; set; }
        public string CRightName { get; set; }
        public int RgStatus { get; set; }
        public string RgStatusName { get; set; }
        public int? CustId { get; set; }
        public string CustName { get; set; }
    }
}
