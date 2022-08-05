using System;
using System.Linq;
using ipsFormsDesign.Data;

namespace IPSModulesLibrary.ReportsBRList
{
    public class LicenseBRListModel
    {
        public int? CustId { get; set; }
        public string Name { get; set; }

        private int? _licType;
        public int? LicType
        {
            get => _licType;
            set
            {
                _licType = value;
                if (value.HasValue)
                {
                    LicTypeName = IpsGlobal.AnketaDictionaties.licenseType.First(rec => rec.CodeI == value).Name;
                }
            }
        }

        public string LicTypeName { get; set; }
        
        public int LicId { get; set; }
        public string LicNum { get; set; }

        private int? _licStatus;
        public int? LicStatus
        {
            get => _licStatus;
            set
            {
                _licStatus = value;
                if (value.HasValue)
                {
                    LicStatusName = IpsGlobal.AnketaDictionaties.agreementStatus.First(rec => rec.CodeI == value).Name;
                }
            }
        }

        public string LicStatusName { get; set; }

        public int? Objid { get; set; }
        public string ObjName { get; set; }

        private int? _genreType;
        public int? GenreType
        {
            get => _genreType;
            set
            {
                _genreType = value;
                if (value.HasValue)
                {
                    GenreTypeName = IpsGlobal.AnketaDictionaties.genreType.First(rec => rec.CodeI == value).Name;
                }
            }
        }

        public string GenreTypeName { get; set; }

        public DateTime? LicDate { get; set; }
        public DateTime? LicDateBegin { get; set; }
        public DateTime? LicDateEnd { get; set; }
        public DateTime? DatePremiere { get; set; }

        public string Comment { get; set; }

        //public int? ObjStatus { get; set; }
        //public int? PerformNumb { get; set; }
        //public float TicketPriceNC { get; set; }
        //public float TicketPriceUSD { get; set; }
        //public bool? IsTour { get; set; }
        //public float GenreRate72 { get; set; }
        //public float Rate { get; set; }
        //public float FillingRate { get; set; }
        //public string WhereTour { get; set; }
    }
}