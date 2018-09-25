using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class FileCustomer
    {
        public int docId { get; set; }
        public int custId { get; set; }
        public int docType { get; set; }
        public DateTime? createDate { get; set; }
        public string docFile { get; set; }
        public string docComment { get; set; }
        public string mimeType { get; set; }
        public DateTime? modifyDate { get; set; }
        public string modifyLogin { get; set; }

        public Customer cust { get; set; }
        public FileType docTypeNavigation { get; set; }
    }
}
