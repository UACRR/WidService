
using System.Collections.Generic;

namespace ipsFormsDesign.Dictionary
{
    public class ObjectRightListResponse
    {
        public IList<ObjectRightMainView> List { get; } = new List<ObjectRightMainView>();
        public int TotalItems { get; set; }
    }
}
