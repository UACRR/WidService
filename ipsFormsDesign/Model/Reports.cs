using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class Reports : IReports
    {
        public int Id { get; set; }
        public string Repname { get; set; }
    }
}

