using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class PopGenreTr
    {
        public int Id { get; set; }
        public string lang { get; set; }
        public string name { get; set; }

        public PopGenre IdNavigation { get; set; }
    }
}
