using System.Linq;
using ipsFormsDesign.Data;

namespace IPSModulesLibrary.ObjectsRightList
{
    public class ObjectsRightListModel
    {
        public int ObjId { get; set; }
        public string InnerCode { get; set; }
        public string ISWC { get; set; }
        public string Name { get; set; }

        private int? _genreType;
        public int? GenreType
        {
            get => _genreType;
            set
            {
                _genreType = value;
                if (value.HasValue)
                {
                    GenreName = IpsGlobal.AnketaDictionaties.genreType.Single(rec => rec.CodeI == value).Name;
                }
            }
        }

        public string GenreName { get; set; }
        public float RateTotal { get; set; }
        public string Author { get; set; }
        public string Performer { get; set; }
        public float Profit { get; set; }

        private int _categoryCode;
        public int CategoryCode
        {
            get => _categoryCode;
            set
            {
                _categoryCode = value;
                if (value == 5)
                    CategoryName = "М";
                else if (value == 6)
                    CategoryName = "В";
            }
        }
        public string CategoryName { get; set; }

        public byte StatusNoRelate { get; set; }
        public byte StatusNoActive { get; set; }
        public byte StatusUnDistrib { get; set; }

    }
}
