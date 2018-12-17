using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class FileType : IFileType
    {
        public FileType()
        {
            FileCustomer = new ObservableListSource<FileCustomer>();
        }

        public int CodeI { get; set; }
        public string Name { get; set; }

        public ObservableListSource<FileCustomer> FileCustomer { get; set; }
    }
}

