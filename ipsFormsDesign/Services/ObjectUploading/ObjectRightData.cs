using System.Collections.Generic;

namespace ipsFormsDesign.Services.ObjectUploading
{
    public class ObjectRightData
    {
        public int RowNum { get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public int? ObjId { get; set; }
        public int? GenreId { get; set; }
        public List<RightholderData> Rightholders { get; set; } = new List<RightholderData>();
    }
}
