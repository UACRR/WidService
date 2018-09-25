using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class RelEmployee : IRelEmployee
    {
        public int emplid { get; set; }
        public int custId { get; set; }
        public int positionCode { get; set; }
        public string relDocument { get; set; }

        public Company cust { get; set; }
        public Employee empl { get; set; }
        public PositionType positionCodeNavigation { get; set; }
    }
}

