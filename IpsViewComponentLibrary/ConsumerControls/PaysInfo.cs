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
    public partial class PaysInfo : UserControl
    {
        public PaysInfo()
        {
            InitializeComponent();
        }

        private void gvMoneyResived_CurrentRowChanged(object sender, Telerik.WinControls.UI.CurrentRowChangedEventArgs e)
        {
            if (!(gvMoneyResived.CurrentRow?.DataBoundItem is MoneyReceived))
            {
                bindingPeriod.DataSource = typeof(IPeriodView);
                return;
            }

            var list = ((MoneyReceived) gvMoneyResived.CurrentRow.DataBoundItem).MoneyPeriodLink
                .Select(rec => new PeriodView(rec, _customer.Client.LicenseAgreement.SingleOrDefault(i => i?.LicId == rec?.LicId)?.Agr?.AgreementAddBr?.SingleOrDefault())).ToList();

            bindingPeriod.DataSource = list;
        }

        private Customer _customer;
        public Customer Customer
        {
            get => _customer;
            set
            {
                _customer = value;
                if (_customer == null)
                {
                    bindingMoney.DataSource = typeof(MoneyReceived);
                    bindingPeriod.DataSource = typeof(IPeriodView);
                }
                else
                {
                    NormalizeData(_customer);
                    bindingMoney.DataSource = _customer.Client.MoneyReceived.ToList();
                }
            }
        }

        private void NormalizeData(Customer customer)
        {
            var dicPays = customer.Client.MoneyReceived.ToDictionary(rec => rec.PaidId);

            foreach (var lic in customer.Client.LicenseAgreement)
            {
                foreach (var period in lic.PaidPeriod)
                    foreach (var link in period.MoneyPeriodLink)
                    {
                        if (dicPays.ContainsKey(link.PaidId))
                        {
                            link.Paid = dicPays[link.PaidId];
                            if (!link.Paid.MoneyPeriodLink.Contains(link))
                                link.Paid.MoneyPeriodLink.Add(link);
                        }

                        if (link.Period == null)
                        {
                            link.Period = period;
                        }
                    }
            }
        }
    }

    interface IPeriodView
    {
        string LicNum { get; }
        DateTime? LicDate { get; }
        string PeriodName { get; }
        string PeriodStatus { get; }
        decimal? PeriodAmount { get; }
        decimal? PayAmount { get; }
    }

    class PeriodView : IPeriodView
    {
        private PaidPeriod _period;
        private LicenseAgrParam _license;
        private MoneyPeriodLink _periodlink;
        private PeriodStatus _periodStatus;
        private AgreementAddBr _agreementAddBr;
        public PeriodView(MoneyPeriodLink periodlink, AgreementAddBr agreementAddBr = null)
        {
            _periodlink = periodlink;
            _period = periodlink.Period;
            _agreementAddBr = agreementAddBr;
            _license = _period?.Lic?.LicenseAgrParam?.SingleOrDefault(rec => rec?.LicVersion == _period?.Lic?.LicVersion);
            _periodStatus = IpsGlobal.AnketaDictionaties?.periodStatus?.SingleOrDefault(rec => rec?.CodeI == _period?.Status);
        }

        public string LicNum { get => _license?.LicNum ?? _agreementAddBr?.AgrNumber; }
        public DateTime? LicDate { get => _license?.LicDate ?? _agreementAddBr?.AgrDate; }
        public string PeriodName { get => _period?.PeriodName; }
        public string PeriodStatus { get => _periodStatus?.Name; }
        public decimal? PayAmount { get => _periodlink?.Amount; }
        public decimal? PeriodAmount { get => _period?.Amount; }
    }
}
