using System.Collections.Generic;
using ipsFormsDesign.Interfaces;

namespace ipsFormsDesign.Dictionary
{
    public class RightholdersResponse
    {
        public List<CommunityAuthorsView> List { get; set; }
        public int TotalItems { get; set; }
    }
}
