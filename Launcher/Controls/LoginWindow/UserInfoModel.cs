using System.Security;
using System.ServiceModel;
using Telerik.Windows.Controls;

namespace Launcher.Controls.LoginWindow
{
    public class UserInfoModel : ViewModelBase
    {
        private string _userName;
        public string UserName
        {
            get => _userName;
            set
            {
                _userName = value;
                if (string.IsNullOrWhiteSpace(value))
                    IconChar = string.Empty;

                IconChar = $"{UserName[0]}".ToUpper();

                OnPropertyChanged(() => UserName);
            }
        }

        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(() => Name);
            }
        }

        private string _userRole;
        public string UserRole
        {
            get => _userRole;
            set
            {
                _userRole = value;
                OnPropertyChanged(() => UserRole);
            }
        }

        private string _iconChar;
        public string IconChar
        {
            get => _iconChar;
            set
            {
                _iconChar = value;
                OnPropertyChanged(() => IconChar);
            }
        }
    }
}
