using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ipsFormsDesign.Data;

namespace IPSModulesLibrary.ReportsSRList
{
    public class ReportsSRListModel
    {
        public int RegId { get; set; }
        public int CustId { get; set; }
        public string CustName { get; set; }
        public int PeriodId { get; set; }
        public string PeriodName { get; set; }
        public int LicId { get; set; }
        public string FileName { get; set; }

        public DateTime? CreateDate { get; set; }

        private int? _rgStatus;
        public int? RgStatus
        {
            get => _rgStatus;
            set
            {
                _rgStatus = value;
                if (value.HasValue)
                {
                    RgStatusName = IpsGlobal.AnketaDictionaties.registerStatus.First(rec => rec.CodeI == value).Name;
                }
            }
        }

        public string RgStatusName { get; set; }

        public string UserWho { get; set; }


        public int? CountItem { get; set; }
        public int? CountNoFound { get; set; }

        //public int CRightCode { get; set; }
        //public string CRightName { get; set; }


        //public int CodeI { get; set; }
        //public int? KindCode { get; set; }
        //public int? UsesKind { get; set; }
        //public int? SchemaId { get; set; }
        //public int? AlgorithmId { get; set; }
        //public short? IsPortal { get; set; }
        //public bool? NeedPlace { get; set; }
        //public decimal? AuthRate { get; set; }
        //public string Name { get; set; }
        //public string TemplateName { get; set; }
        //public string Series { get; set; }
    }
}
