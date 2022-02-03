using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicingLib
{
    public class DdexAgreement
    {
        public int          LicId                   { get; set; }
        public int          CustId                  { get; set; }
        public string       LicenseeName            { get; set; }
        public string       LicenseDescription      { get; set; }
        public decimal?     MusicRate               { get; set; }
        public decimal?     GeRate                  { get; set; }
        public decimal?     MechSplit               { get; set; }
        public decimal?     PerfSplit               { get; set; }
        public decimal?     MusicPSM                { get; set; }
        public decimal?     GePSM                   { get; set; }
        public string       ReportCurrency          { get; set; }
        public string       ReportType              { get; set; }
        public decimal?     RoyaltyThreshold        { get; set; }
    }
}
