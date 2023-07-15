using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
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
using System.Windows;
using IPSViewComponentLibraryWPF.Modules.Consumer.ConsumerSmallRight.Register.Model;

namespace IPSViewComponentLibraryWPF.Modules.Consumer.ConsumerSmallRight.Register.CreatePaidPeriod
{
    public class CreatePaidPeriodViewModel : ViewModelBase
    {
        /// <summary>
        /// Кількість місяців в періоді
        /// </summary>
        private readonly Dictionary<int, int> CountMonths = new Dictionary<int, int>()
        {
            [1] = 1,
            [2] = 3,
            [3] = 6,
            [4] = 12,
        };

        /// <summary>
        /// Назва місяця українською
        /// </summary>
        private readonly Dictionary<int, Func<DateTime, string>> PeriodNameFuncs = new Dictionary<int, Func<DateTime, string>>()
        {
            // Місяць 
            [1] = (d) =>
            {
                return string.Format("{0:MMMM} {0:yyyy} року", d);
            },
            // Квартал
            [2] = (d) =>
            {
                int quarter = (d.Month % 3) == 0 ? d.Month / 3 : d.Month / 3 + 1;
                return string.Format("{0} квартал {1:yyyy} року", quarter, d);
            },
            // Півріччя
            [3] = (d) =>
            {
                int half = d.Month <= 6 ? 1 : 2;
                return string.Format("{0} півріччя {1:yyyy} року", half, d);
            },
            // Рік
            [4] = (d) =>
            {
                return string.Format("{0:yyyy} рік", d);
            },
        };

        public CreatePaidPeriodViewModel() { }

        private LicenseAgreement _licenseAgreement;
        private List<PaidPeriod> _paidPeriods;
        private bool _isOnce = false;

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

        private ObservableListSource<SelecteblePeriods> _selectablePeriods = new ObservableListSource<SelecteblePeriods>();
        public ObservableListSource<SelecteblePeriods> SelectablePeriods
        {
            get => _selectablePeriods;
            set
            {
                _selectablePeriods = value;
                OnPropertyChanged(() => SelectablePeriods);
            }
        }

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

        private bool _customEnabled = true;
        public bool CustomPeriodEnabled
        {
            get => _customEnabled;
            set
            {
                _customEnabled = value;
                OnPropertyChanged(() => CustomPeriodEnabled);
            }
        }

        private DateTime _beginCustomDate = DateTime.Today;
        public DateTime BeginCustomDate
        {
            get => _beginCustomDate;
            set
            {
                _beginCustomDate = value;
                OnPropertyChanged(() => BeginCustomDate);
                CustomPeriodName = UpdateCustomPeriodName(_beginCustomDate, EndCustomDate);
            }
        }

        private DateTime _endCustomDate = DateTime.Today.AddMonths(1);
        public DateTime EndCustomDate
        {
            get => _endCustomDate;
            set
            {
                _endCustomDate = value;
                OnPropertyChanged(() => EndCustomDate);
                CustomPeriodName = UpdateCustomPeriodName(BeginCustomDate, _endCustomDate);
            }
        }

        private string _customPeriodName;
        public string CustomPeriodName
        {
            get => _customPeriodName;
            set
            {
                _customPeriodName = value;
                OnPropertyChanged(() => CustomPeriodName);
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

                if (!_isOnce)
                    CreatePeriods(value);
            }
        }

        private bool CheckDates(DateTime start, DateTime end)
        {
            bool isInvalid = _paidPeriods.Any(i => i.BeginDate > start && i.EndDate < start || i.BeginDate > end && i.EndDate < end);
            return isInvalid;
        }

        public void Init(LicenseAgreement licenseAgreement)
        {
            _licenseAgreement = licenseAgreement;
            _paidPeriods = licenseAgreement.PaidPeriod.ToList();

            int code = _licenseAgreement.GetPeriodCode();
            if (code == 5)
            {
                _isOnce = true;
                CustomPeriodEnabled = false;
                CreateOncePeriod();
            }
            else
            {
                PaidPeriod lastPeriod = licenseAgreement.PaidPeriod.OrderBy(rec => rec.BeginDate).LastOrDefault();
                BeginDate = BeginCustomDate = lastPeriod?.EndDate.AddDays(1) ?? new DateTime(2023, 07, 31); //DateTime.Today;
                EndCustomDate = BeginCustomDate.AddMonths(CountMonths[code]);
            }
        }

        private void CreateOncePeriod()
        {
            if (_licenseAgreement.PaidPeriod.Any())
            {
                MessageShow.ShowWarning("Для даної ліцензії період вже створено!");
                //DialogResult = false;
                return;
            }

            LicenseAgrParam license = _licenseAgreement.CurrentLicenseAgrParam();

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
                return;
            }

            PaidPeriod period = CreateNewPaidPeriod(license.DateBegin.Value, license.DateEnd.Value, license.MinAmount.Value);
            period.PeriodName = $"одноразовий ({license.DateBegin.Value:d} - {license.DateEnd.Value:d})";
            BeginDate = license.DateBegin.Value;

            SelectablePeriods = new ObservableListSource<SelecteblePeriods>()
            {
                new SelecteblePeriods(period)
            };
            SelectedPeriod = SelectablePeriods.First();
        }

        private decimal GetMinAmount()
        {
            int[] schemaTypesWhereAmountIsZero = { 2, 3 };
            decimal? minAmount;
            if (_licenseAgreement.LicClass == 1)
            {
                minAmount = 0;
            }
            else
            {
                var agree = _licenseAgreement.CurrentLicenseAgrParam();
                var licType = _licenseAgreement.LicCodeNavigation;
                minAmount = licType.SchemaId.HasValue && schemaTypesWhereAmountIsZero.Contains(licType.SchemaId.Value) ? 0 : agree.MinAmount;
            }

            return minAmount ?? 0;
        }

        private void CreatePeriods(DateTime beginDateNewPeriod, int cntInList = 4)
        {
            int periodCode = _licenseAgreement.GetPeriodCode();
            int countMonths = CountMonths[periodCode];
            Func<DateTime, string> periodNameFunc = PeriodNameFuncs[periodCode];

            SelectedPeriod = null;
            var selectablePeriods = new ObservableListSource<SelecteblePeriods>();
            decimal minAmount = GetMinAmount();

            for (int i = 0; i < cntInList; i++)
            {
                PaidPeriod period = CreateNewPaidPeriod(beginDateNewPeriod, beginDateNewPeriod.AddMonths(countMonths), minAmount);
                period.PeriodName = periodNameFunc(beginDateNewPeriod);

                beginDateNewPeriod = beginDateNewPeriod.AddMonths(countMonths);

                selectablePeriods.Add(new SelecteblePeriods(period));
            }

            SelectablePeriods = selectablePeriods;
            SelectedPeriod = SelectablePeriods.First();
        }

        private PaidPeriod CreateNewPaidPeriod(DateTime beginDate, DateTime endnDate, decimal amount)
        {
            return new PaidPeriod
            {
                Lic = _licenseAgreement,
                LicId = _licenseAgreement.LicId,
                PeriodType = _licenseAgreement.GetPeriodCode(),
                BeginDate = beginDate,
                EndDate = endnDate,
                Amount = amount,
                Distribamount = 0,
                Undistribamount = 0,
                Status = 1,
                CustId = _licenseAgreement.CustId.Value,
                StatusNavigation = IpsGlobal.AnketaDictionaties.periodStatus.SingleOrDefault(rec => rec.CodeI == 1)
            };
        }

        private static string UpdateCustomPeriodName(DateTime d1, DateTime d2)
        {
            string y1 = d1.Year != d2.Year ? $" {d1:yyyy}р." : string.Empty;
            string y2 = $" {d2:yyyy}р.";

            return $"{d1:MMMM}{y1} - {d2:MMMM}{y2}";
        }

        public ICommand SaveWindowCommand => new IPSDelegateCommand(SaveWindowCommandExecute);
        private async void SaveWindowCommandExecute(object o)
        {
            var window = o as Window;
            if (window == null)
                return;
            PaidPeriod paidPeriod = null;

            if (PeriodMode.IsDefault)
            {
                paidPeriod = SelectedPeriod.Value;
            }
            else if (PeriodMode.IsCustom)
            {
                paidPeriod = CreateNewPaidPeriod(BeginCustomDate, EndCustomDate, GetMinAmount());
            }

            var periodExist = CheckDates(paidPeriod.BeginDate, paidPeriod.EndDate);
            if (periodExist)
            {
                MessageShow.ShowWarning("Такий період вже існує!");
                return;
            }

            if (!_paidPeriods.Any())
                paidPeriod.FagFirst = true;

            var service = ConsumerRegisterService.GetInstance();
            var result = await service.CreatePaidPeriod(paidPeriod);
            ShowMessage.ShowInfoByResult(result.Message, result.IsSuccess);

            window.DialogResult = true;
            window.Close();
        }

        public ICommand CloseWindowCommand => new IPSDelegateCommand(CloseWindowCommandExecute);
        private void CloseWindowCommandExecute(object o)
        {
            var window = o as Window;
            if (window == null)
                return;

            window.DialogResult = false;
            window.Close();
        }
    }
}
