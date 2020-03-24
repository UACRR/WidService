using Telerik.Windows.Controls;

namespace Launcher.General.Model
{
    public class LauncherPermits : ViewModelBase
    {
        private bool _rightsAdmin;
        private bool _permit;
        private bool _directory;
        private bool _violation;
        private bool _bRightsWp;
        private bool _sRightsWp;
        private bool _royaltyAdmin;
        private bool _processes;
        private bool _analytics;
        private bool _ourProfile;
        private bool _represent;

        public bool RightsAdmin
        {
            get => _rightsAdmin;
            set
            {
                _rightsAdmin = value;
                OnPropertyChanged(() => RightsAdmin);
            }
        }

        public bool RoyaltyAdmin
        {
            get => _royaltyAdmin;
            set
            {
                _royaltyAdmin = value;
                OnPropertyChanged(() => RoyaltyAdmin);
            }
        }

        public bool SRightsWp
        {
            get => _sRightsWp;
            set
            {
                _sRightsWp = value;
                OnPropertyChanged(() => SRightsWp);
            }
        }

        public bool BRightsWp
        {
            get => _bRightsWp;
            set
            {
                _bRightsWp = value;
                OnPropertyChanged(() => BRightsWp);
            }
        }

        public bool Violation
        {
            get => _violation;
            set
            {
                _violation = value;
                OnPropertyChanged(() => Violation);
            }
        }

        public bool Directory
        {
            get => _directory;
            set
            {
                _directory = value;
                OnPropertyChanged(() => Directory);
            }
        }

        public bool Permit
        {
            get => _permit;
            set
            {
                _permit = value;
                OnPropertyChanged(() => Permit);
            }
        }

        public bool Processes
        {
            get => _processes;
            set
            {
                _processes = value;
                OnPropertyChanged(() => Processes);
            }
        }

        public bool OurProfile
        {
            get => _ourProfile;
            set
            {
                _ourProfile = value; 
                OnPropertyChanged(() => OurProfile);
            }
        }

        public bool Analytics
        {
            get => _analytics;
            set
            {
                _analytics = value; 
                OnPropertyChanged(() => Analytics);
            }
        }

        public bool Represent
        {
            get => _represent;
            set
            {
                _represent = value;
                OnPropertyChanged(() =>  Represent);
            }
        }
    }
}
