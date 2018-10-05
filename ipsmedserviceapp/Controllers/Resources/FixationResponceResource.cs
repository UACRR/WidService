using ipsmedserviceapp.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ipsmedserviceapp.Controllers.Resources
{
    public class FixationResponceResource
    {
        public Fixation Fixation { get; set; }
        public ICollection<RegisterCountResource> RegisterCounts { get; set; } = new Collection<RegisterCountResource>();
    }

    public class RegisterCountResource
    {
        public decimal RegCntId { get; set; }
        public int RegId { get; set; }
        public int RegIitemId { get; set; }
        public int RoleCode { get; set; }
        public string AuthorName { get; set; }
        public decimal Rate { get; set; }
    }
}
