using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class FileCustomer
    {
        public int DocId { get; set; }
        public int CustId { get; set; }
        public int DocType { get; set; }
        public DateTime? CreateDate { get; set; }
        public string DocFile { get; set; }
        public string DocComment { get; set; }
        public string MimeType { get; set; }
        public DateTime? ModifyDate { get; set; }
        public string ModifyLogin { get; set; }

        public virtual Customer Cust { get; set; }
        public virtual FileType DocTypeNavigation { get; set; }
    }
}
