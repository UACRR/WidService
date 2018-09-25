using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsFormsDesign.Model
{
    public partial class FileType : IFileType
    {
        public FileType()
        {
            DocumentTypeTr = new ObservableListSource<DocumentTypeTr>();
            FileCustomer = new ObservableListSource<FileCustomer>();
        }

        public int codeI { get; set; }
        public string name { get; set; }

        public ObservableListSource<DocumentTypeTr> DocumentTypeTr { get; set; }
        public ObservableListSource<FileCustomer> FileCustomer { get; set; }
    }
}

