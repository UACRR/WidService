using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class ReportType : IReportType
    {
        public int CodeI { get; set; }
        public string Name { get; set; }
    }
}

