using System.Collections.Generic;

namespace ipsmedserviceapp.Controllers.Resources
{
    public class ObjectRightValidateResource
    {
        public int RowNum { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public int? ObjId { get; set; }
        public int? GenreId { get; set; }
        public List<RightholderValidateResource> Rightholders { get; set; } = new List<RightholderValidateResource>();
    }
}
