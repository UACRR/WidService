using ipsFormsDesign.Interfaces;
using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class CategoryTr : ICategoryTr
    {
        public int CodeI { get; set; }
        public string Lang { get; set; }
        public string Name { get; set; }

        public Category CodeINavigation { get; set; }
    }
}

