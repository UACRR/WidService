using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class FileCustomer : IFileCustomer
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

        public Customer Cust { get; set; }
        public FileType DocTypeNavigation { get; set; }
    }
}

