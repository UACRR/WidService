using System.Collections.Generic;
using IpsCommonTypes.Types;

namespace IpsCommonTypes.ClassesForSearchQuery
{
    public class SearchModuleResource
    {
        public SearchData SimpleSearch { get; set; }
        public List<SearchDataExtended> MultiplySearch { get; set; }
    }
}
