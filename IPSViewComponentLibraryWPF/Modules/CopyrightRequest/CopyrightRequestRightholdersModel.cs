using System;

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
