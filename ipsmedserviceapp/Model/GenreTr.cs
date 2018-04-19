using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class GenreTr
    {
        public int Id { get; set; }
        public string Lang { get; set; }
        public string Name { get; set; }

        public Genre IdNavigation { get; set; }
    }
}
