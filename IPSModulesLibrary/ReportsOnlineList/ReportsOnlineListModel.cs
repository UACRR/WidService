using System;
using System.Linq;
using ipsFormsDesign.Data;

namespace IPSModulesLibrary.ReportsOnlineList
{
    public class ReportsOnlineListModel
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
    }
}
