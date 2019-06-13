using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ipsFormsDesign.Model;

namespace IpsViewComponentLibrary.InternalControlsModel
{
    public class ReportPaidPeriod : PaidPeriod
    {
        /// <summary>
        /// К-сть звітів
        /// </summary>
        public int ReportCount { get; set; }

        public static List<ReportPaidPeriod> Convert(IList<PaidPeriod> paidPeriods)
        {
            if (!paidPeriods.Any())
                return new List<ReportPaidPeriod>();

            var list = new List<ReportPaidPeriod>();
            foreach (var period in paidPeriods)
            {
                var item = new ReportPaidPeriod
                {
                    PeriodId = period.PeriodId,
                    CustId = period.CustId,
                    LicId = period.LicId,
                    Status = period.Status,
                    Amount = period.Amount,
                    BeginDate = period.BeginDate,
                    EndDate = period.EndDate,
                    DateActPrint = period.DateActPrint,
                    Distribamount = period.Distribamount,
                    Undistribamount = period.Undistribamount,
                    FagFirst = period.FagFirst,
                    MoneyPeriodLink = period.MoneyPeriodLink,
                    PeriodName = period.PeriodName,
                    PeriodType = period.PeriodType,
                    ReportCount = period.RegisterRatedList?.FirstOrDefault()?.Register?.Count ?? 0,
                    RegisterRatedList = period.RegisterRatedList,
                    Cust = period.Cust,
                    Lic = period.Lic,
                    BrRegister = period.BrRegister,
                    PeriodTypeNavigation = period.PeriodTypeNavigation,
                    StatusNavigation = period.StatusNavigation,
                };
                list.Add(item);
            }
            return list;
        }

    }
}
