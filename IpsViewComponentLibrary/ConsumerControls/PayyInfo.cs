using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ipsFormsDesign.Model;
using ipsFormsDesign.Data;

namespace IpsViewComponentLibrary.ConsumerControls
{
    public partial class PayyInfo : UserControl
    {
        public PayyInfo()
        {
            InitializeComponent();
        }

        private void gvMoneyResived_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            if (gvMoneyResived.CurrentRow == null || !(gvMoneyResived.CurrentRow.DataBoundItem is MoneyReceived))
            {
                bindingPeriod.DataSource = typeof(IPeriodView);
                return;
            }

            var list = (gvMoneyResived.CurrentRow.DataBoundItem as MoneyReceived).MoneyPeriodLink
                        .Select(rec => new PeriodView(rec)).ToList();

            bindingPeriod.DataSource = list;
        }
    }

    interface IPeriodView
    {
        string LicNum { get; }
        DateTime? LicDate { get; }
        string PeriodName { get; }
        string PeriodStatus { get; }
        decimal Amount { get; }
    }

    class PeriodView : IPeriodView
    {
        private PaidPeriod _period;
        private LicenseAgrParam _license;
        private MoneyPeriodLink _periodlink;
        private PeriodStatus _periodStatus;
        public PeriodView(MoneyPeriodLink periodlink)
        {
            _periodlink = periodlink;
            _period = periodlink.Period;
            _license = _period.Lic.LicenseAgrParam.Single(rec => rec.LicVersion == _period.Lic.LicVersion);
            _periodStatus = IpsGlobal.AnketaDictionaties.periodStatus.Single(rec => rec.CodeI == _period.Status);
        }

        public string LicNum { get => _license.LicNum; }
        public DateTime? LicDate { get => _license.LicDate; }
        public string PeriodName { get => _period.PeriodName; }
        public string PeriodStatus { get => _periodStatus.Name; }
        public decimal Amount { get => _periodlink.Amount; }
    }
}
