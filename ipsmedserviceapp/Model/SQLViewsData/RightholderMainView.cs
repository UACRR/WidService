using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ipsmedserviceapp.Model.SQLViewsData
{
    [NotMapped]
    public class RightholderMainView
    {
        public int CustId { get; set; }
        public int CustStatus { get; set; }
        public int? AgrStatus { get; set; }
        public string InnerCode { get; set; }
        public string InterCode { get; set; }
        public string Name { get; set; }
        public DateTime? RegistrDate { get; set; }
        public int CntObj { get; set; }
        public decimal? YearProfit { get; set; }
        public string Country { get; set; }
    }
}
