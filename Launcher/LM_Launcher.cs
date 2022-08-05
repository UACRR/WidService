using Telerik.Windows.Controls;

namespace Launcher
{
    public class LM_Launcher : ViewModelBase
    {
        private string _rh_or = "Правовласники та об'єкти права";
        private string _sysAdmin = "Правам доступу";
        private string _anketaOfTheCompany = "Анкета компанії";
        private string _processes = "Управління технологічними процесами";
        private string _partner_WP = "Представники компанії";
        private string _fixationOfViolations = "Фіксація порушення авторських прав";
        private string _systemDictionaries = "Системні довідники";
        private string _clients_WP = "Користувачі (Малі права)";
        private string _theatres_WP = "Користувачі (Великі права)";
        private string _analyticsAndReports = "Звітність (Аналітика)";
        private string _reportsAndRoyalty = "Обробка звітів користувачів (індентифікація)";
        private string _ddex = "Звіти онлайн-ресурсів";

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

        public string ReportsAndRoyalty
        {
            get => _reportsAndRoyalty;
            set
            {
                _reportsAndRoyalty = value;
                OnPropertyChanged(() => ReportsAndRoyalty);
            }
        }


        public string AnalyticsAndReports
        {
            get => _analyticsAndReports;
            set
            {
                _analyticsAndReports = value;
                OnPropertyChanged(() => AnalyticsAndReports);
            }
        }

        public string Clients_WP
        {
            get => _clients_WP;
            set
            {
                _clients_WP = value;
                OnPropertyChanged(() => Clients_WP);
            }
        }

        public string Theatres_WP
        {
            get => _theatres_WP;
            set
            {
                _theatres_WP = value;
                OnPropertyChanged(() => Theatres_WP);
            }
        }


        public string Partner_WP
        {
            get => _partner_WP;
            set
            {
                _partner_WP = value;
                OnPropertyChanged(() => Partner_WP);
            }
        }


        public string FixationOfViolations
        {
            get => _fixationOfViolations;
            set
            {
                _fixationOfViolations = value;
                OnPropertyChanged(() => FixationOfViolations);
            }
        }

        public string SystemDictionaries
        {
            get => _systemDictionaries;
            set
            {
                _systemDictionaries = value;
                OnPropertyChanged(() => SystemDictionaries);
            }
        }

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

        public string Processes
        {
            get => _processes;
            set
            {
                _processes = value;
                OnPropertyChanged(() => Processes);
            }
        }

        public string DDEX
        {
            get => _ddex;
            set
            {
                _ddex = value;
                OnPropertyChanged(() => DDEX);
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
