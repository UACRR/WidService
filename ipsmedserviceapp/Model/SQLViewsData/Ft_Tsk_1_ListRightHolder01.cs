using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ipsmedserviceapp.Model.SQLViewsData
{
    [NotMapped]
    public class FtTsk1ListRightHolder01
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

    public class FtTsk1ListRightHolder01Box
    {
        public int TotalPages { get; set; }
        public IEnumerable<FtTsk1ListRightHolder01> list { get; set; }
    }
}
