using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telerik.Windows.Controls;
using IPSViewComponentLibraryWPF.IPSExtensions;
using ipsFormsDesign.Services;
using ipsFormsDesign.Model;
using IPSComponentLibrary.Extensions;
using ipsFormsDesign.Interfaces;
using ipsFormsDesign.Utilities;
using ipsFormsDesign.Data;
using System.Windows.Controls;
using System.Globalization;

namespace IPSViewComponentLibraryWPF.Modules.Consumer.ConsumerSmallRight.Register.CreatePaidPeriod
{
    public class CreatePaidPeriodViewModel : ViewModelBase
    {
        public CreatePaidPeriodViewModel() { }

        private LicenseAgreement _licenseAgreement;
        private List<PaidPeriod> _paidPeriods;

        public ObservableListSource<SelecteblePeriods> SelectablePeriods { get; set; } = new ObservableListSource<SelecteblePeriods>();

        private SelecteblePeriods _selectedPeriod;
        public SelecteblePeriods SelectedPeriod
        {
            get => _selectedPeriod;
            set
            {
                _selectedPeriod = value;
                OnPropertyChanged(() => SelectedPeriod);
            }
        }

        private PeriodMode _periodMode = new PeriodMode();
        public PeriodMode PeriodMode
        {
            get => _periodMode;
            set
            {
                _periodMode = value;
                OnPropertyChanged(() => PeriodMode);
            }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged(() => IsBusy);
            }
        }

        private DateTime _beginDate = DateTime.Today;
        public DateTime BeginDate
        {
            get => _beginDate;
            set
            {
                _beginDate = value;
                OnPropertyChanged(() => BeginDate);
                CreatePeriods(value);
            }
        }

        private void CheckDates(DateTime start, DateTime end)
        {
            bool isInvalid = _paidPeriods.Any(i => i.BeginDate > start && i.EndDate < start || i.BeginDate > end && i.EndDate < end);
        }


        public void Init(LicenseAgreement licenseAgreement)
        {
            _licenseAgreement = licenseAgreement;
            _paidPeriods = licenseAgreement.PaidPeriod.ToList();
            var lastPeriod = licenseAgreement.PaidPeriod.OrderBy(rec => rec.BeginDate).LastOrDefault();
            BeginDate = lastPeriod?.EndDate.AddDays(1) ?? DateTime.Today;

            if (licenseAgreement.GetPeriodCode() == 5)
                CreateOncePeriod();
            else
                CreatePeriods(BeginDate);
        }

        private void CreateOncePeriod()
        {
            if (_licenseAgreement.PaidPeriod.Any())
            {
                MessageShow.ShowWarning("Для даної ліцензії період вже створено!");
                //DialogResult = false;
                return;
            }

            var license = _licenseAgreement.CurrentLicenseAgrParam();

            List<string> invalidItems = new List<string>();

            if (!license.DateBegin.HasValue)
                invalidItems.Add("дата початку ліцензії");

            if (!license.DateEnd.HasValue)
                invalidItems.Add("дата завершення ліцензії");

            // для схеми 2 мінімальної суми може не бути
            var schemaType = IpsGlobal.AnketaDictionaties.agrLicenseType.First(rec => rec.CodeI == _licenseAgreement.LicCode).SchemaId;
            if (!license.MinAmount.HasValue && schemaType != 2)
                invalidItems.Add("мінімальна сума");

            if (invalidItems.Any())
            {
                MessageShow.ShowWarning($"Для створення періоду в даній ліцензії відсутні необхідні дані!\n({string.Join(", ", invalidItems)})");
                //DialogResult = false;
                return;
            }

            var newPeriod = CreateNewPaidPeriod();
            newPeriod.PeriodName = $"одноразовий ({license.DateBegin.Value:d} - {license.DateEnd.Value:d})";
        }

        private void CreatePeriods(DateTime beginDateNewPeriod, int cntInList = 4)
        {
            // Щомісячно
            int cntMonth = 1;
            //string[] quartals = { "I", "II", "III", "IV" };
            //string[] halfYear = { "I", "II" };

            // Назва місяця українською
            TextInfo ti = new CultureInfo("uk-UA", false).TextInfo;

            Func<DateTime, string>[] namePeriods = {
                (d)=> string.Format( "{0:MMMM} {0:yyyy} року", d ), // Місяць 
                (d)=> string.Format( "{0} квартал {1:yyyy} року", d.Month / 3 + 1, d ), // Квартал
                (d)=> string.Format( "{0} півріччя {1:yyyy} року", d.Month/6+1, d ), // Півріччя
                (d)=> string.Format( "{0:yyyy} рік", d ), // Рік
            };
            Func<DateTime, string> namePariod = namePeriods[0];

            decimal? MinAmount = 0;

            int[] schemaTypesWhereAmountIsZero = { 2, 3 };

            if (_licenseAgreement.LicClass == 1)
            {
                MinAmount = 0;
            }
            else
            {
                var agree = _licenseAgreement.CurrentLicenseAgrParam();
                var licType = _licenseAgreement.LicCodeNavigation;
                MinAmount = licType.SchemaId.HasValue && schemaTypesWhereAmountIsZero.Contains(licType.SchemaId.Value) ? 0 : agree.MinAmount;
            }

            switch (_licenseAgreement.GetPeriodCode())
            {
                // Поквартально
                case 2:
                    cntMonth = 3;
                    namePariod = namePeriods[1];
                    break;
                // Раз в півроку
                case 3:
                    cntMonth = 6;
                    namePariod = namePeriods[2];
                    break;
                // раз в рік
                case 4:
                    cntMonth = 12;
                    namePariod = namePeriods[3];
                    break;
            }


            for (int i = 0; i < cntInList; i++)
            {
                var newPeriod = new PaidPeriod
                {
                    Lic = _licenseAgreement,
                    LicId = _licenseAgreement.LicId,
                    BeginDate = beginDateNewPeriod,
                    EndDate = beginDateNewPeriod.AddMonths(cntMonth).AddDays(-1),
                    PeriodName = namePariod(beginDateNewPeriod),
                    PeriodType = _licenseAgreement.GetPeriodCode(),
                    Amount = MinAmount ?? 0,
                    Distribamount = 0,
                    Undistribamount = 0,
                    Status = 1,
                    CustId = _licenseAgreement.CustId.Value,
                    StatusNavigation = IpsGlobal.AnketaDictionaties.periodStatus.SingleOrDefault(rec => rec.CodeI == 1)
                };

                beginDateNewPeriod = beginDateNewPeriod.AddMonths(cntMonth);

                SelectablePeriods.Add(new SelecteblePeriods(newPeriod));
            }

            SelectedPeriod = SelectablePeriods.First();
        }

        public PaidPeriod CreateNewPaidPeriod()
        {
            var license = _licenseAgreement.CurrentLicenseAgrParam();

            return new PaidPeriod
            {
                Lic = _licenseAgreement,
                LicId = _licenseAgreement.LicId,
                BeginDate = license.DateBegin.Value,
                EndDate = license.DateEnd.Value,
                PeriodType = _licenseAgreement.GetPeriodCode(),
                Amount = license.MinAmount.Value,
                Distribamount = 0,
                Undistribamount = 0,
                Status = 1,
                CustId = _licenseAgreement.CustId.Value,
                StatusNavigation = IpsGlobal.AnketaDictionaties.periodStatus.SingleOrDefault(rec => rec.CodeI == 1)
            };
        }

        private void RadComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    }

    public class CustomPeriod
    {
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public string PeriodName { get; set; }
    }
}
