using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoicingLib
{
    public class DdexReportInfo
    {
        [ReadOnly(true)]
        public int DdexReportId { get; set; }

        [ReadOnly(true)]
        public int Year { get; set; }

        [ReadOnly(true)]
        public int Quarter { get; set; }

        [ReadOnly(true)]
        public int Status { get; set; }

        [ReadOnly(true)]
        public int SubStatus { get; set; }

        [ReadOnly(true)]
        public string FileType { get; set; }

        [ReadOnly(true)]
        public string FileFolder { get; set; }

        [ReadOnly(true)]
        public string FileName { get; set; }

        [ReadOnly(true)]
        public string MessageId { get; set; }

        [ReadOnly(true)]
        public string MessageCreatedDateTime { get; set; }

        [ReadOnly(true)]
        public string UsageStartDate { get; set; }

        [ReadOnly(true)]
        public string UsageEndDate { get; set; }

        [ReadOnly(true)]
        public string SenderName { get; set; }

        [ReadOnly(true)]
        public decimal? RoyaltyThreshold { get; set; }

        [ReadOnly(true)]
        public decimal? MusicRate { get; set; }

        [ReadOnly(true)]
        public decimal? GeRate { get; set; }

        [ReadOnly(true)]
        public decimal? MechSplit { get; set; }

        [ReadOnly(true)]
        public decimal? PerfSplit { get; set; }

        [ReadOnly(true)]
        public decimal? MusicPSM { get; set; }

        [ReadOnly(true)]
        public decimal? GePSM { get; set; }

        [ReadOnly(true)]
        public decimal? ExchRate { get; set; }

    }
}
