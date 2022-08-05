using System;
using System.Linq;
using ipsFormsDesign.Data;
using ipsFormsDesign.Model;

namespace IPSViewComponentLibraryWPF.Modules.Consumer.ConsumerSmallRight.Register.Model
{
    public class RegisterPeriodModel
    {
        public int PeriodId { get; set; }
        public int LicId { get; set; }
        public string PeriodName { get; set; }

        private int _periodStatus;
        public int PeriodStatus
        {
            get => _periodStatus;
            set
            {
                _periodStatus = value;
                var periodStatus = IpsGlobal.AnketaDictionaties?.periodStatus.FirstOrDefault(rec => rec.CodeI == value);
                PeriodStatusName = periodStatus?.Name;
            }
        }

        public string PeriodStatusName { get; set; }

        public decimal Amount { get; set; }
        public decimal Undistribamount { get; set; }
        public decimal Distribamount { get; set; }
        public int CountReportsOfPeriod { get; set; }

        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }

        // from PD -> "ознака першого періоду"
        public bool? FagFirst { get; set; }

        private PaidPeriod _paidPeriod;
        public PaidPeriod PaidPeriod
        {
            get => _paidPeriod;
            set
            {
                // RegisterRatedList is not null
                // Register in RegisterRatedList is not null
                _paidPeriod = value;
                ResetData();
            }
        }

        private void ResetData()
        {
            PeriodId = _paidPeriod.PeriodId;
            LicId = _paidPeriod.LicId;
            PeriodName = _paidPeriod.PeriodName;
            PeriodStatus = _paidPeriod.Status;
            Amount = _paidPeriod.Amount;
            Undistribamount = _paidPeriod.Undistribamount;
            Distribamount = _paidPeriod.Distribamount;
            BeginDate = _paidPeriod.BeginDate;
            EndDate = _paidPeriod.EndDate;
            FagFirst = _paidPeriod.FagFirst;
            CountReportsOfPeriod = _paidPeriod.RegisterRatedList?.FirstOrDefault()?.Register?.Count ?? 0;
        }
    }
}
