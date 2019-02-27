using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class ReportList : IReportList
    {
        public int Id { get; set; }
        public string RepCode { get; set; }
        public int? RepType { get; set; }
        public string RepName { get; set; }
        public string RepDesc { get; set; }
        public string RepDescFile { get; set; }
        public string RepExec { get; set; }
    }
}

