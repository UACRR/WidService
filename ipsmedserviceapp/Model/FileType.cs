using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class FileType
    {
        public FileType()
        {
            DocumentTypeTr = new HashSet<DocumentTypeTr>();
            FileCustomer = new HashSet<FileCustomer>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ICollection<DocumentTypeTr> DocumentTypeTr { get; set; }
        public ICollection<FileCustomer> FileCustomer { get; set; }
    }
}
