using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class FileType
    {
        public FileType()
        {
            FileCustomer = new HashSet<FileCustomer>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public virtual ICollection<FileCustomer> FileCustomer { get; set; }
    }
}
