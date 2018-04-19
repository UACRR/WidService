using System;
using System.Collections.Generic;

namespace ipsmedserviceapp.Model
{
    public partial class Genre
    {
        public Genre()
        {
            GenreTr = new HashSet<GenreTr>();
        }

        public int CategoryCode { get; set; }
        public string Name { get; set; }
        public int Id { get; set; }

        public Category CategoryCodeNavigation { get; set; }
        public ICollection<GenreTr> GenreTr { get; set; }
    }
}
