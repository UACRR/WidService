using Telerik.Windows.Controls;

namespace Launcher.General.Model
{
    public class LauncherPermits : ViewModelBase
    {
        private bool _rightsAdmin;
        private bool _userAdmin;
        private bool _directory;
        private bool _violation;
        private bool _prAdmin;
        private bool _bRightsWp;
        private bool _sRightsWp;
        private bool _royaltyAdmin;

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

        public bool PRAdmin
        {
            get => _prAdmin;
            set
            {
                _prAdmin = value;
                OnPropertyChanged(() => PRAdmin);
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

        public bool UserAdmin
        {
            get => _userAdmin;
            set
            {
                _userAdmin = value;
                OnPropertyChanged(() => UserAdmin);
            }
        }
    }
}
