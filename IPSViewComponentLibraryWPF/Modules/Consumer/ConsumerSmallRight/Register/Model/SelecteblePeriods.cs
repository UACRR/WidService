using ipsFormsDesign.Model;

namespace IPSViewComponentLibraryWPF.Modules.Consumer.ConsumerSmallRight.Register.Model
{
    public class SelecteblePeriods
    {
        public SelecteblePeriods(PaidPeriod value)
        {
            PeriodName = value.PeriodName;
            Value = value;
        }

        public string PeriodName { get; set; }
        public PaidPeriod Value { get; set; }
    }
}
