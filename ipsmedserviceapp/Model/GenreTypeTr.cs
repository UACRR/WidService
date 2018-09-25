using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class GenreTypeTr
    {
        public int codeI { get; set; }
        public string lang { get; set; }
        public string name { get; set; }

        public GenreType codeINavigation { get; set; }
    }
}
