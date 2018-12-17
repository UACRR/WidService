using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace ipsFormsDesign.Dictionary
{
    public class ObjectCopyright
    {
        public int ObjId { get; set; }
        public int CustId { get; set; }
        public int RoleCode { get; set; }
        public string InnerCode { get; set; }
        public string InterCode { get; set; }
        public string Name { get; set; }
        public decimal Rate { get; set; }
        public RightholderMainView Rightholder { get; set; }
        public string Error { get; set; }
    }
}
