using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ipsFormsDesign.Model.SQLViewsData
{
    public class vTsk1ListRightHolder01
    {
        public int CustId { get; set; }
        public int? CustStatus { get; set; }
        public int? AgrStatus { get; set; }
        public string InnerCode { get; set; }
        public string InterCode { get; set; }
        public string Name { get; set; }
        public DateTime? RegistrDate { get; set; }
        public int? CntObj { get; set; }
        public decimal? YearProfit { get; set; }
        public string Community_Name { get; set; }
        public string Country { get; set; }
        public int? CustType { get; set; }
    }

    public class vTsk1ListRightHolder01Box
    {
        public int TotalPages { get; set; }
        //public IEnumerable<vTsk1ListRightHolder01> list { get; set; }
        public IEnumerable<RightholderMainView> list { get; set; }
    }
}
