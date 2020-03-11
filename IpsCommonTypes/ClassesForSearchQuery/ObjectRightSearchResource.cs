using System;
using System.Collections.Generic;
using System.Text;
using IpsCommonTypes.Types;

namespace IpsCommonTypes.ClassesForSearchQuery
{
    public class ObjectRightSearchResource
    {
        public SearchData SimpleSearch { get; set; }
        public List<SearchDataExtended> MultiplySearch { get; set; }
    }
}
