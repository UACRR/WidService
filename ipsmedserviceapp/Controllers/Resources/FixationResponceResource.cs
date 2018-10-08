using ipsmedserviceapp.Model;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace ipsmedserviceapp.Controllers.Resources
{
    public class FixationResponseResource
    {
        public Fixation Fixation { get; set; }
        public ICollection<Dictionary<string, object>> RegisterCounts { get; set; } = new Collection<Dictionary<string, object>>();
        //public ICollection<RegisterCountResource> RegisterCounts { get; set; } = new Collection<RegisterCountResource>();
    }

    //public class RegisterCountResource
    //{
    //    public decimal RegCntId { get; set; }
    //    public int RegId { get; set; }
    //    public int RegIitemId { get; set; }
    //    public int ObjId { get; set; }
    //    public int CustId { get; set; }
    //    public decimal Rate { get; set; }
    //    public string Name { get; set; }
    //    public string CreativeRoles { get; set; }
    //}
}
