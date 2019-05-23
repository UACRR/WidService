using System.Collections.Generic;

namespace ipsFormsDesign.Dictionary
{
    public class ItemListResponse<T> where T : class
    {
        public List<T> List { get; set; }
        public int TotalItems { get; set; }
    }
}
