using System.Collections.Generic;

namespace IpsCommonTypes.Wrappers
{
    public class ObjectAndItemsWrap<TObject, TItems>
    {
        public ObjectAndItemsWrap(TObject ObjectData, ICollection<TItems> ItemsData)
        {
            this.ObjectData = ObjectData;
            this.ItemsData = ItemsData;
        }

        public TObject ObjectData { get; set; }
        public ICollection<TItems> ItemsData { get; set; }
    }
}
