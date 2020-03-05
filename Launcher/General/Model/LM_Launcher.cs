using Telerik.Windows.Controls;

namespace Launcher.General.Model
{
    public class LM_Launcher : ViewModelBase
    {
        private string _rh_or = "Адміністратор авторів/правовласників та об'єктів права";
        private string _sysAdmin = "Управління правами доступу";
        private string _catSys = "Система";
        private string _catOther = "Інше";
        private string _catConsumers = "Користувачі";
        private string _catRights = "Права";


        public string RH_OR
        {
            get => _rh_or;
            set
            {
                _rh_or = value;
                OnPropertyChanged(() => RH_OR);
            }
        }

        private string _reportsAndRoyalty = "Робоче місце по управлінню розподілу авторської виногороди (обробка звітів користувачів)";
        public string ReportsAndRoyalty
        {
            get => _reportsAndRoyalty;
            set
            {
                _reportsAndRoyalty = value;
                OnPropertyChanged(() => ReportsAndRoyalty);
            }
        }

        private string _analyticsAndReports = "Аналітична звітність";
        public string AnalyticsAndReports
        {
            get => _analyticsAndReports;
            set
            {
                _analyticsAndReports = value;
                OnPropertyChanged(() => AnalyticsAndReports);
            }
        }

        private string _operativeReporting = "Оперативна звітність";
        public string OperativeReporting
        {
            get => _operativeReporting;
            set
            {
                _operativeReporting = value;
                OnPropertyChanged(() => OperativeReporting);
            }
        }

        private string _clients_WP = "Робоче місце по роботі з «малими правами»";
        public string Clients_WP
        {
            get => _clients_WP;
            set
            {
                _clients_WP = value;
                OnPropertyChanged(() => Clients_WP);
            }
        }

        private string _theatres_WP = "Робоче місце по роботі з «великими правами»";
        public string Theatres_WP
        {
            get => _theatres_WP;
            set
            {
                _theatres_WP = value;
                OnPropertyChanged(() => Theatres_WP);
            }
        }

        private string _partner_WP = "Робоче місце адміністратора по роботі з представниками компанії";
        public string Partner_WP
        {
            get => _partner_WP;
            set
            {
                _partner_WP = value;
                OnPropertyChanged(() => Partner_WP);
            }
        }

        private string _fixationOfViolations = "Фіксація порушень прав";
        public string FixationOfViolations
        {
            get => _fixationOfViolations;
            set
            {
                _fixationOfViolations = value;
                OnPropertyChanged(() => FixationOfViolations);
            }
        }

        private string _systemDictionaries = "Довідники системи";
        public string SystemDictionaries
        {
            get => _systemDictionaries;
            set
            {
                _systemDictionaries = value;
                OnPropertyChanged(() => SystemDictionaries);
            }
        }

        private string _anketaOfTheCompany = "Анкета компанії";
        public string AnketaOfTheCompany
        {
            get => _anketaOfTheCompany;
            set
            {
                _anketaOfTheCompany = value;
                OnPropertyChanged(() => AnketaOfTheCompany);
            }
        }



        public string SysAdmin
        {
            get => _sysAdmin;
            set
            {
                _sysAdmin = value;
                OnPropertyChanged(() => SysAdmin);
            }
        }

        public string CAT_SYS
        {
            get => _catSys;
            set
            {
                _catSys = value;
                OnPropertyChanged(() => CAT_SYS);
            }
        }

        public string CAT_OTHER
        {
            get => _catOther;
            set
            {
                _catOther = value;
                OnPropertyChanged(() => CAT_OTHER);
            }
        }

        public string CAT_CONSUMERS
        {
            get => _catConsumers;
            set
            {
                _catConsumers = value;
                OnPropertyChanged(() => CAT_CONSUMERS);
            }
        }

        public string CAT_RIGHTS
        {
            get => _catRights;
            set
            {
                _catRights = value;
                OnPropertyChanged(() => CAT_RIGHTS);
            }
        }
    }
}
