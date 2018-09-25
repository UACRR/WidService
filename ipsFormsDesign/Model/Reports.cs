using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class Reports : IReports
    {
        public int id { get; set; }
        public string repname { get; set; }
    }
}

