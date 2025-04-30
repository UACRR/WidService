using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RadioStationReports
{
    public class ReportAuthor
    {
        public int Id           { get; set; }
        public int ReportId     { get; set; }
        public int WorkId   { get; set; }
        public string Wic     { get; set; }
        public string CalculatedFrom  { get; set; }
        public int CustId       { get; set; }
        public int IpNameNr     { get; set; }
        public decimal PerShr   { get; set; }
        public decimal MecShr    { get; set; }
        public decimal PerSocShr    { get; set; }
        public decimal MecSocShr    { get; set; }
        public int PerSoc       { get; set; }
        public int MecSoc       { get; set; }
    }
}
