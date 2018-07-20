using ipsFormsDesign.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ipsFormsDesign.Dictionary
{
    public class ObjectAuthorRightholderBrViewModel
    {
        public string InnerCode { get; set; }
        public string Country { get; set; }
        public Authors Author { get; set; }
        public CopyRight CopyRight { get; set; }
        public WorkRh WorkRh { get; set; }
        public LicAuthorBr LicAuthorBr { get; set; }
    }
}
