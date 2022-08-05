using System.Collections.Generic;
using IpsCommonTypes.Types;

namespace ipsmedserviceapp.Controllers.Resources
{
    public class ObjectRightSearchResource
    {
        public SearchData SimpleSearch { get; set; }
        public List<SearchDataExtended> MultiplySearch { get; set; }
    }
}
