using System.Collections.Generic;

namespace IpsCommonTypes.Wrappers
{
    public class ItemListResponse<T> where T : class
    {
        public List<T> List { get; set; }
        public int TotalItems { get; set; }
    }
}