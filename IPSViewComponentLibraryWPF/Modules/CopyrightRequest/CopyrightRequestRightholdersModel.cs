using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPSViewComponentLibraryWPF.Modules.CopyrightRequest
{
    public class CopyrightRequestRightholdersModel
    {
        public int CustId { get; set; }
        public string InnerCode { get; set; }
        public string InterCode { get; set; }
        public string Name { get; set; }
        public int CntObj { get; set; }
        public DateTime? RegistrDate { get; set; }
        public DateTime? WorkDateRH { get; set; }
    }
}
